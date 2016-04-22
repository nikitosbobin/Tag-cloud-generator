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

        private Size cloudSize; 
        private List<RecanglePriorityPair> frames;
        private readonly Random rnd;

        public ITagCloud CreateCloud(Size targetCloudSize, Font wordsFont, int wordsAmount,
            int firstScale, Action<int> setProgressAction)
        {
            cloudSize = targetCloudSize;
            frames.Clear();
            Words = TextHandler.GetWords(wordsFont)
                .OrderByDescending(u => u.Frequency)
                .ThenByDescending(w => w.Source.Length)
                .ToArray();
            Words = Words.Take((int) (Words.Length*wordsAmount/(double) 100)).ToArray();
            if (Words.Length == 0)
                throw new Exception("There are no words to build cloud");
            Words[0].FontSize = targetCloudSize.Height * firstScale/100f;
            for (var index = 0; index < Words.Length; index++)
            {
                setProgressAction((index + 1) * 100 / Words.Length);
                var word = Words[index];
                word.FontSize = GetWordFontSize(word);
                if (CanFindPosition(word))
                    frames.Add(GetWordRectangle(word));
                else if (frames.Count == 0)
                    frames.Add(GetWordRectangle(PutWordInImageCenter(word)));
            }
            return new StemTagCloud(targetCloudSize, Words);
        }

        private float GetWordFontSize(WordBlock word)
        {
            var firstWord = Words.First();
            return word.Frequency * firstWord.FontSize / firstWord.Frequency;
        }

        public ITextHandler TextHandler { get; set; }
        public WordBlock[] Words { get; set; }
        private static readonly int StandartIterations = 3;

        private Size MeasureWord(WordBlock word)
        {
            var wordSize = TextRenderer.MeasureText(word.Source, word.Font);
            return word.IsVertical ? new Size(wordSize.Height, wordSize.Width) : wordSize;
        }

        private Rectangle GetWordRectangle(WordBlock word)
        {
            var wordSize = MeasureWord(word);
            var location = new Point(word.Location.X, word.Location.Y);
            if (word.IsVertical) location.Y -= wordSize.Height;
            return new Rectangle(location, MeasureWord(word));
        }

        private bool WordInsideImage(WordBlock word)
        {
            var wordRect = GetWordRectangle(word);
            return PointInsideCloud(wordRect.LeftBottom()) && PointInsideCloud(wordRect.RigthBottom());
        }

        private bool PointInsideCloud(Point point)
        {
            var b1 = point.X >= 0 && point.X <= cloudSize.Width;
            var b2 = point.Y >= 0 && point.Y <= cloudSize.Height;
            return b1 && b2;
        }

        private bool WordIntersectsWith(WordBlock word, IEnumerable<Rectangle> frames)
        {
            return frames?.Any(rectangle => rectangle.IntersectsWith(GetWordRectangle(word))) ?? false;
        }

        private WordBlock PutWordInImageCenter(WordBlock word)
        {
            var center = MeasureWord(word).Center();
            word.MoveToPoint(-center.X + cloudSize.Center().X, -center.Y + cloudSize.Center().Y);
            word.IsVertical = false;
            return word;
        }

        private bool CanFindPosition(WordBlock word)
        {
            if (frames.Count == 0) return false;
            frames = frames.OrderBy(t => t.Priority).ThenByDescending(i => i.Rect.Perimetr()).ToList();
            var better = frames.First();
            var worst = frames.Last();
            var it = worst.Priority * StandartIterations / better.Priority;
            foreach (var pair in frames)
            {
                if (BypassCircuit(word, pair.Rect, it != 0 ? it : 1))
                    return true;
                pair.Priority++;
            }
            return false;
        }

        private bool BypassCircuit(WordBlock word, Rectangle circuit, int count)
        {
            var points = circuit.GetPoints().OffsetArray(rnd.Next(0, 4));
            return points.Where((t, i) => MoveOnLine(word, t, points[(i + 1)%points.Length], count)).Any();
        }

        private bool MoveOnLine(WordBlock word, Point start, Point end, int count)
        {
            var dist = start.OffsetTo(end);
            var startLocation = word.Location;
            var startRotation = word.IsVertical;
            for (var i = 0; i < count; ++i)
            {
                word.MoveToPoint(start.X + i * dist.X / count, start.Y + i * dist.Y / count);
                if (TryFindPosition(word))
                    return true;
                word.IsVertical = !word.IsVertical;
                if (TryFindPosition(word))
                    return true;
                word.IsVertical = startRotation;
            }
            word.MoveToPoint(startLocation);
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
                if (!WordIntersectsWith(word, frames.Select(h => h.Rect)) && WordInsideImage(word))
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
