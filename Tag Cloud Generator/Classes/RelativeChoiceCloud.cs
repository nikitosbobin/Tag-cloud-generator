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
            rnd = new Random(DateTime.Now.Millisecond);
        }
        
        private List<RecanglePriorityPair> frames;
        private readonly Random rnd;

        public ICloudGenerator CreateCloud(Graphics graphics, Font wordsFont, int wordsCount,
            int firstScale, Action<int> setProgressAction)
        {
            frames.Clear();
            Words = TextHandler.GetWords(graphics, wordsFont)
                .OrderByDescending(u => u.Frequency)
                .ThenByDescending(w => w.Source.Length)
                .ToArray();
            Words = Words.Take((int) (Words.Length*wordsCount/(double) 100)).ToArray();
            if (Words.Length == 0)
                throw new Exception("There are no words to build cloud");
            Words[0].FontSize = graphics.VisibleClipBounds.Height * firstScale/100f;
            for (var index = 0; index < Words.Length; index++)
            {
                setProgressAction((index + 1) * 100 / Words.Length);
                var word = Words[index];
                word.FontSize = GetWordFontSize(word);
                if (CanFindPosition(word))
                    frames.Add(word.GetWordRectangle());
                else if (frames.Count == 0)
                    frames.Add(word.StayInCenterOfImage().GetWordRectangle());
            }
            return this;
        }

        private float GetWordFontSize(WordBlock word)
        {
            var firstWord = Words.First();
            return word.Frequency * firstWord.FontSize / firstWord.Frequency;
        }

        public ITextHandler TextHandler { get; set; }
        public WordBlock[] Words { get; set; }
        private static readonly int StandartIterations = 3;

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
            var tmpRect = word.GetWordRectangle();
            var what = new[,] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 } };
            for (var j = 0; j < 4; ++j)
            {
                word.SaveLocation();
                word.MoveOn(-tmpRect.Width * what[j, 0],
                    tmpRect.Height * what[j, 1] * (word.IsVertical ? 1 : -1));
                if (!word.IntersectsWith(frames.Select(h => h.Rect)) && word.InsideImage())
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
