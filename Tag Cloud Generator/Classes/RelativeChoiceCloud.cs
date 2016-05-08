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
            frames = new Dictionary<Rectangle, int>();
            words = new List<WordBlock>();
            GeneratorState = RelativeChoiceCloudStates.NotCreating;
            MaxAttemptsCount = 3;
        }

        private CloudMectrics metrics;
        private Dictionary<Rectangle, int> frames;
        private Dictionary<string, int> sortedWords;
        private readonly List<WordBlock> words;
        private FontsCache fontsCache;

        public RelativeChoiceCloudStates GeneratorState { get; private set; }
        public int MaxWordsCount => sortedWords?.Count ?? 0;
        public ITextHandler TextHandler { get; set; }
        public int MaxAttemptsCount { get; set; }

        public void InitCreating(Size targetCloudSize, Font wordsFont, 
            int wordsAmount, int minWordsLength, int firstScale)
        {
            sortedWords = GetWordsStatistics(wordsAmount, minWordsLength);
            if (sortedWords.Count == 0)
                throw new Exception("There are no words to build cloud");
            metrics?.Dispose();
            fontsCache = new FontsCache(wordsFont);
            metrics = new CloudMectrics(targetCloudSize, fontsCache);
            frames.Clear();
            words.Clear();
            words.Capacity = sortedWords.Count;
            CommitWord(CreateFirstWord(firstScale));
            GeneratorState = RelativeChoiceCloudStates.Creating;
        }

        public bool TryHandleNextWord()
        {
            switch (GeneratorState)
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
                GeneratorState = RelativeChoiceCloudStates.Ready;
                return false;
            }
            var currentWord = sortedWords.ElementAt(frames.Count);
            return TryLocateWordOnImage(currentWord);
        }

        public ITagCloud GetCreatedCloud()
        {
            if (GeneratorState == RelativeChoiceCloudStates.NotCreating)
                throw new Exception("Creating process does not initialized");
            return new TagCloud(metrics.CloudSize, words.ToArray(), fontsCache);
        }

        private void CommitWord(WordBlock word)
        {
            words.Add(word);
            frames.Add(GetWordRectangle(word), 1);
        }

        private WordBlock CreateFirstWord(int scale)
        {
            var result = new WordBlock(metrics.CloudSize.Width * scale / 1000f, sortedWords.First());
            var size = metrics.MeasureWord(result);
            if (size.Width > metrics.CloudSize.Width)
                result.FontSize /= size.Width / (float)metrics.CloudSize.Width;
            return PutWordInCloudCenter(result);
        }

        private bool TryLocateWordOnImage(KeyValuePair<string, int> wordFreqPair)
        {
            WordBlock result;
            if (!TryFindPosition(wordFreqPair, out result)) return false;
            CommitWord(result);
            return true;
        }

        private Dictionary<string, int> GetWordsStatistics(int wordsAmount, int minWordsLength)
        {
            var result = TextHandler.GetWordsStatisctics(minWordsLength)
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
            var currentWordRectangle = GetWordRectangle(word);
            return frames?
                .Any(frame => frame.Key.IntersectsWith(currentWordRectangle))
                ?? false;
        }

        private WordBlock PutWordInCloudCenter(WordBlock word)
        {
            var wordCenter = metrics.MeasureWord(word).Center();
            var cloudCenter = metrics.CloudSize.Center();
            word.MoveToPoint(-wordCenter.X + cloudCenter.X, -wordCenter.Y + cloudCenter.Y);
            word.IsVertical = false;
            return word;
        }

        private bool TryFindPosition(KeyValuePair<string, int> wordFreqPair, out WordBlock resultWord)
        {
            resultWord = null;
            if (frames.Count == 0) return false;
            frames = frames.OrderBy(t => t.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var firstFrame = frames.First();
            var targetFontSize = GetWordFontSize(wordFreqPair.Value);
            var resultWordBlock = new WordBlock(targetFontSize, wordFreqPair);
            foreach (var frame in frames.Keys.ToArray())
            {
                var currentPriority = frames[frame];
                var currentAttemptsCount = currentPriority * MaxAttemptsCount / firstFrame.Value;
                if (TryBypassFrame(resultWordBlock, frame, currentAttemptsCount > 0 ? currentAttemptsCount : 1))
                {
                    resultWord = resultWordBlock;
                    return true;
                }
                frames[frame]++;
            }
            return false;
        }

        private bool TryBypassFrame(WordBlock word, Rectangle frame, int attemptsCount)
        {
            var points = frame.GetPoints().RandomOffsetArray();
            for (var i = 0; i < points.Length; ++i)
                if (TryFindPositionOnLine(word, points[i], points[(i + 1)%points.Length], attemptsCount))
                    return true;
            return false;
        }

        private bool TryFindPositionOnLine(WordBlock word, Point start, Point end, int attemptsCount)
        {
            var dist = start.OffsetTo(end);
            for (var i = 0; i < attemptsCount; ++i)
            {
                word.MoveToPoint(start.X + i*dist.X/attemptsCount, start.Y + i*dist.Y/attemptsCount);
                if (ChoosePermutationAroundPoint(word))
                    return true;
                word.IsVertical = !word.IsVertical;
                if (ChoosePermutationAroundPoint(word))
                    return true;
            }
            return false;
        }

        private bool ChoosePermutationAroundPoint(WordBlock word)
        {
            var tmpRect = GetWordRectangle(word);
            var permutations = new[,] {{0, 0}, {1, 0}, {0, 1}, {1, 1}};
            for (var j = 0; j < 4; ++j)
            {
                word.SaveLocation();
                word.OffsetOn(-tmpRect.Width*permutations[j, 0],
                    tmpRect.Height*permutations[j, 1]*(word.IsVertical ? 1 : -1));
                if (metrics.WordInsideImage(word) && !AnyFrameIntersection(word))
                    return true;
                word.RestoreLocation();
            }
            return false;
        }

        public void Dispose()
        {
            if (GeneratorState != RelativeChoiceCloudStates.NotCreating)
                GetCreatedCloud().Dispose();
            metrics?.Dispose();
        }
    }
}
