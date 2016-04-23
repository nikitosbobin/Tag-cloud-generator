using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
            rnd = new Random(DateTime.Now.Millisecond);
        }

        private Graphics tmpGraphics;
        private Size cloudSize; 
        private List<RecanglePriorityPair> frames;
        private readonly Random rnd;

        public ITagCloud CreateCloud(Size targetCloudSize, Font wordsFont, int wordsAmount,
            int firstScale, Action<int> setProgressAction)
        {
            cloudSize = targetCloudSize;
            frames.Clear();
            Words = GetWords(wordsFont, wordsAmount);
            Words[0].FontSize = targetCloudSize.Height * firstScale/100f;
            using (var image = new Bitmap(targetCloudSize.Width, targetCloudSize.Height))
            using (tmpGraphics = Graphics.FromImage(image))
            {
                for (var index = 0; index < Words.Length; index++)
                {
                    setProgressAction((index + 1)*100/Words.Length);
                    var word = Words[index];
                    word.FontSize = GetWordFontSize(word);
                    LocateWordOnImage(word);
                }
            }
            return new StemTagCloud(targetCloudSize, Words);
        }

        private void LocateWordOnImage(WordBlock word)
        {
            if (CanFindPosition(word))
                frames.Add(GetWordRectangle(word));
            else if (frames.Count == 0)
                frames.Add(GetWordRectangle(PutWordInImageCenter(word)));
        }

        private WordBlock[] GetWords(Font wordsFont, int wordsAmount)
        {
            var result = TextHandler.GetWords(wordsFont)
                .OrderByDescending(u => u.Frequency)
                .ThenByDescending(w => w.Source.Length)
                .ToArray();
            result = result.Take((int)(result.Length * wordsAmount / (double)100)).ToArray();
            if (result.Length == 0)
                throw new Exception("There are no words to build cloud");
            return result;
        }

        private float GetWordFontSize(WordBlock word)
        {
            var firstWord = Words.First();
            return word.Frequency * firstWord.FontSize / firstWord.Frequency;
        }

        public ITextHandler TextHandler { get; set; }
        public WordBlock[] Words { get; set; }
        private static readonly int StandartIterations = 3;

        private Rectangle GetWordRectangle(WordBlock word)
        {
            var wordSize = word.Metrics.MeasureWord(tmpGraphics);
            var location = new Point(word.Location.X, word.Location.Y);
            if (word.IsVertical) location.Y -= wordSize.Height;
            return new Rectangle(location, wordSize);
        }

        private bool WordIntersectsWith(WordBlock word, IEnumerable<Rectangle> frames)
        {
            return frames?.Any(rectangle => rectangle.IntersectsWith(GetWordRectangle(word))) ?? false;
        }

        private WordBlock PutWordInImageCenter(WordBlock word)
        {
            var wordCenter = word.Metrics.MeasureWord(tmpGraphics).Center();
            var cloudCenter = cloudSize.Center();
            word.MoveToPoint(-wordCenter.X + cloudCenter.X, -wordCenter.Y + cloudCenter.Y);
            word.IsVertical = false;
            return word;
        }

        private bool CanFindPosition(WordBlock word)
        {
            if (frames.Count == 0) return false;
            frames = frames.OrderBy(t => t.Priority).ThenByDescending(i => i.Rect.Perimetr()).ToList();
            var better = frames.First();
            foreach (var pair in frames)
            {
                var it = pair.Priority * StandartIterations / better.Priority;
                if (BypassCircuit(word, pair.Rect, it != 0 ? it : 1))
                    return true;
                pair.Priority++;
            }
            return false;
        }

        private bool BypassCircuit(WordBlock word, Rectangle circuit, int count)
        {
            var points = circuit.GetPoints().OffsetArray(rnd.Next(0, 4));
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
            var what = new[,] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 } };
            for (var j = 0; j < 4; ++j)
            {
                word.SaveLocation();
                word.MoveOn(-tmpRect.Width * what[j, 0],
                    tmpRect.Height * what[j, 1] * (word.IsVertical ? 1 : -1));
                if (!WordIntersectsWith(word, frames.Select(h => h.Rect)) && word.Metrics.WordInsideImage(tmpGraphics))
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
