using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{

    class RelativeChoiceCloud : ICloudGenerator
    {
        public RelativeChoiceCloud(ITextHandler textHandler)
        {
            TextHandler = textHandler;
            frames = new List<RecanglePriorityPair>();
            generatorState = RelativeChoiceCloudStates.NotCreating;
        }

        private CloudMectrics metrics;
        private List<RecanglePriorityPair> frames;
        private Dictionary<string, int> sortedWords;
        private List<WordBlock> words;
        private RelativeChoiceCloudStates generatorState;

        private static readonly int StandartIterations = 3;

        public int MaxWordsCount => sortedWords?.Count ?? 0;
        public ITextHandler TextHandler { get; set; }

        public void InitCreating(Size targetCloudSize, Font wordsFont, int wordsAmount, int firstScale)
        {
            metrics?.Dispose();
            metrics = new CloudMectrics(targetCloudSize, wordsFont);
            frames.Clear();
            sortedWords = GetWords(wordsAmount);
            words = new List<WordBlock>(new[] {new WordBlock(wordsFont, sortedWords.First())})
            {
                [0] = {FontSize = targetCloudSize.Height*firstScale/100f}
            };
            frames.Add(GetWordRectangle(PutWordInImageCenter(words[0])));
            generatorState = RelativeChoiceCloudStates.Creating;
        }

        public bool HandleNextWord()
        {
            switch (generatorState)
            {
                case RelativeChoiceCloudStates.NotCreating:
                    throw new Exception("Creating process does not initialized");
                case RelativeChoiceCloudStates.Ready:
                    return false;
            }
            if (sortedWords.Count == words.Count)
            {
                metrics.Dispose();
                generatorState = RelativeChoiceCloudStates.Ready;
                return false;
            }
            var currentWord = sortedWords.ElementAt(frames.Count);
            return LocateWordOnImage(currentWord);
        }

        public ITagCloud GetCreatedCloud()
        {
            switch (generatorState)
            {
                case RelativeChoiceCloudStates.NotCreating:
                    throw new Exception("Creating process does not initialized");
                case RelativeChoiceCloudStates.Creating:
                    return new StemTagCloud(metrics.CloudSize, words.Take(frames.Count).ToArray());
                default:
                    return new StemTagCloud(metrics.CloudSize, words.ToArray());
            }
        }

        private bool LocateWordOnImage(KeyValuePair<string, int> wordFreqPair)
        {
            WordBlock result;
            if (!CanFindPosition(wordFreqPair, out result)) return false;
            frames.Add(GetWordRectangle(result));
            words.Add(result);
            return true;
        }

        private Dictionary<string, int> GetWords(int wordsAmount)
        {
            var result = TextHandler.GetWords()
                .OrderByDescending(u => u.Value)
                .ThenByDescending(w => w.Key.Length)
                .ToDictionary(y => y.Key, pair => pair.Value);
            result = result.Take((int)(result.Count * wordsAmount / (double)100)).ToDictionary(j => j.Key, k => k.Value);
            if (result.Count == 0)
                throw new Exception("There are no words to build cloud");
            return result;
        }

        private float GetWordFontSize(int frequency)
        {
            var firstWord = words.First();
            return frequency * firstWord.FontSize / firstWord.Frequency;
        }

        private Rectangle GetWordRectangle(WordBlock word)
        {
            var wordSize = metrics.MeasureWord(word);
            var location = new Point(word.Location.X, word.Location.Y);
            if (word.IsVertical) location.Y -= wordSize.Height;
            return new Rectangle(location, wordSize);
        }

        private bool AnyFrameIntersection(WordBlock word)
        {
            return frames?
                .Select(frame => frame.Rect)
                .Any(rectangle => rectangle.IntersectsWith(GetWordRectangle(word))) ?? false;
        }

        private WordBlock PutWordInImageCenter(WordBlock word)
        {
            var wordCenter = metrics.MeasureWord(word).Center();
            var cloudCenter = metrics.CloudSize.Center();
            word.MoveToPoint(-wordCenter.X + cloudCenter.X, -wordCenter.Y + cloudCenter.Y);
            word.IsVertical = false;
            return word;
        }

        private bool CanFindPosition(KeyValuePair<string, int> wordFreqPair, out WordBlock resultWord)
        {
            if (frames.Count == 0)
            {
                resultWord = null;
                return false;
            }
            frames = frames.OrderBy(t => t.Priority).ThenByDescending(i => i.Rect.Perimetr()).ToList();
            var better = frames.First();
            foreach (var pair in frames)
            {
                var it = pair.Priority * StandartIterations / better.Priority;
                var resultWordBlock = new WordBlock(metrics.WordsFont, wordFreqPair)
                {
                    FontSize = GetWordFontSize(wordFreqPair.Value)
                };
                if (BypassCircuit(resultWordBlock, pair.Rect, it != 0 ? it : 1))
                {
                    resultWord = resultWordBlock;
                    return true;
                }
                pair.Priority++;
            }
            resultWord = null;
            return false;
        }

        private bool BypassCircuit(WordBlock word, Rectangle circuit, int count)
        {
            var points = circuit.GetPoints().RandomOffsetArray();
            for (var i = 0; i < points.Length; ++i)
                if (MoveOnLine(word, points[i], points[(i + 1) % points.Length], count))
                    return true;
            return false;
        }

        private bool MoveOnLine(WordBlock word, Point start, Point end, int count)
        {
            var dist = start.OffsetTo(end);
            for (var i = 0; i < count; ++i)
            {
                word.MoveToPoint(start.X + i * dist.X / count, start.Y + i * dist.Y / count);
                if (TryFindPosition(word))
                    return true;
                word.IsVertical = !word.IsVertical;
                if (TryFindPosition(word))
                    return true;
            }
            return false;
        }

        private bool TryFindPosition(WordBlock word)
        {
            var tmpRect = GetWordRectangle(word);
            var permutations = new[,] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 } };
            for (var j = 0; j < 4; ++j)
            {
                word.SaveLocation();
                word.MoveOn(-tmpRect.Width * permutations[j, 0],
                    tmpRect.Height * permutations[j, 1] * (word.IsVertical ? 1 : -1));
                if (!AnyFrameIntersection(word) && metrics.WordInsideImage(word))
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
