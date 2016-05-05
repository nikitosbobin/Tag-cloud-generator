using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Tag_Cloud_Generator.Interfaces;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{

    class RelativeChoiceCloud : ICloudGenerator
    {
        public RelativeChoiceCloud(ITextHandler textHandler)
        {
            TextHandler = textHandler;
            frames = new List<PriorityPair<Rectangle>>();
            words = new List<WordBlock>();
            generatorState = RelativeChoiceCloudStates.NotCreating;
            TryingIterations = 3;
        }

        private CloudMectrics metrics;
        private List<PriorityPair<Rectangle>> frames;
        private Dictionary<string, int> sortedWords;
        private List<WordBlock> words;
        private RelativeChoiceCloudStates generatorState;

        public int MaxWordsCount => sortedWords?.Count ?? 0;
        public ITextHandler TextHandler { get; set; }
        public int TryingIterations { get; set; }

        public void InitCreating(Size targetCloudSize, Font wordsFont, int wordsAmount, int firstScale)
        {
            sortedWords = GetWordsStatistics(wordsAmount);
            if (sortedWords.Count == 0)
                throw new Exception("There are no words to build cloud");
            if (metrics != null && !metrics.Disposed)
                metrics.Dispose();
            metrics = new CloudMectrics(targetCloudSize, wordsFont);
            frames.Clear();
            words.Clear();
            frames.Capacity = sortedWords.Count;
            words.Capacity = frames.Capacity;
            CommitWord(CreateFirstWord(firstScale));
            generatorState = RelativeChoiceCloudStates.Creating;
        }

        private void CommitWord(WordBlock word)
        {
            words.Add(word);
            frames.Add(new PriorityPair<Rectangle>(GetWordRectangle(word)));
        }

        private WordBlock CreateFirstWord(int scale)
        {
            var result = new WordBlock(metrics.WordsFont, sortedWords.First())
            {
                FontSize = metrics.CloudSize.Width*scale/100f
            };
            var size = metrics.MeasureWord(result);
            if (size.Width > metrics.CloudSize.Width)
                result.FontSize /= size.Width / (float)metrics.CloudSize.Width;
            return PutWordInImageCenter(result);
        }

        public bool HandleNextWord()
        {
            switch (generatorState)
            {
                case RelativeChoiceCloudStates.NotCreating:
                    throw new Exception("Creating process does not initialized");
                case RelativeChoiceCloudStates.Ready:
                    return false;
                case RelativeChoiceCloudStates.Creating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
            if (generatorState == RelativeChoiceCloudStates.NotCreating)
                throw new Exception("Creating process does not initialized");
            return new TagCloud(metrics.CloudSize, words.ToArray());
        }

        private bool LocateWordOnImage(KeyValuePair<string, int> wordFreqPair)
        {
            WordBlock result;
            if (!CanFindPosition(wordFreqPair, out result)) return false;
            CommitWord(result);
            return true;
        }

        private Dictionary<string, int> GetWordsStatistics(int wordsAmount)
        {
            var result = TextHandler.GetWordsStatisctics()
                .OrderByDescending(u => u.Value)
                .ThenByDescending(w => w.Key.Length)
                .ToDictionary(y => y.Key, pair => pair.Value);
            result = result
                .Take((int) (result.Count*wordsAmount/(double) 100))
                .ToDictionary(j => j.Key, k => k.Value);
            return result;
        }

        private float GetWordFontSize(int frequency)
        {
            var firstWord = words.First();
            return frequency*firstWord.FontSize/firstWord.Frequency;
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
            return frames?.Select(frame => frame.Value).Any(rectangle => rectangle.IntersectsWith(GetWordRectangle(word))) ?? false;
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
            resultWord = null;
            if (frames.Count == 0) return false;
            frames = frames.OrderBy(t => t.Priority).ThenByDescending(i => i.Value.Perimetr()).ToList();
            var betterFrame = frames.First();
            foreach (var frame in frames)
            {
                var tryingCount = frame.Priority*TryingIterations/betterFrame.Priority;
                var targetFontSize = GetWordFontSize(wordFreqPair.Value);
                var resultWordBlock = new WordBlock(metrics.WordsFont.SetSize(targetFontSize), wordFreqPair);
                if (BypassFrame(resultWordBlock, frame.Value, tryingCount != 0 ? tryingCount : 1))
                {
                    resultWord = resultWordBlock;
                    return true;
                }
                frame.Priority++;
            }
            return false;
        }

        private bool BypassFrame(WordBlock word, Rectangle frame, int tryingCount)
        {
            var points = frame.GetPoints().RandomOffsetArray();
            for (var i = 0; i < points.Length; ++i)
                if (MoveOnLine(word, points[i], points[(i + 1)%points.Length], tryingCount))
                    return true;
            return false;
        }

        private bool MoveOnLine(WordBlock word, Point start, Point end, int tryingCount)
        {
            var dist = start.OffsetTo(end);
            for (var i = 0; i < tryingCount; ++i)
            {
                word.MoveToPoint(start.X + i*dist.X/tryingCount, start.Y + i*dist.Y/tryingCount);
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
            var permutations = new[,] {{0, 0}, {1, 0}, {0, 1}, {1, 1}};
            for (var j = 0; j < 4; ++j)
            {
                word.SaveLocation();
                word.MoveOn(-tmpRect.Width*permutations[j, 0], tmpRect.Height*permutations[j, 1]*(word.IsVertical ? 1 : -1));
                if (metrics.WordInsideImage(word) && !AnyFrameIntersection(word))
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
