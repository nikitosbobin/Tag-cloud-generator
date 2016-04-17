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
        public RelativeChoiceCloud(ITextDecoder decoder, ITextHandler textHandler, Control context)
        {
            this.context = (MainForm) context;
            TextHandler = textHandler;
            this.decoder = decoder;
            frames = new List<Tuple<Rectangle, int>>();
            WordScale = 0.06f;
            rnd = new Random(DateTime.Now.Millisecond);
        }
        
        private readonly MainForm context;
        private List<Tuple<Rectangle, int>> frames;
        private readonly ITextDecoder decoder;
        private readonly Random rnd;

        private void SmoothFrequences()
        {
            var count = Words.Length;
            Words = Words.OrderByDescending(u => u.Frequency).ToArray();
            for (var i = 0; i < count; ++i)
                Words[i].Frequency = count - i;
        }

        public ICloudGenerator CreateCloud(Graphics graphics, Font wordsFont, int wordsCount)
        {
            frames.Clear();
            Words = TextHandler.GetWords(decoder, graphics, wordsFont)
                .OrderByDescending(u => u.Frequency)
                .ThenByDescending(w => w.Source.Length)
                .ToArray();
            Words = Words.Take((int) (Words.Length*wordsCount/(double) 100)).ToArray();
            if (Words.Length == 0)
                throw new Exception("There are no words to build cloud");
            Words[0].FontSize = graphics.VisibleClipBounds.Height * WordScale;
            for (var index = 0; index < Words.Length; index++)
            {
                context.Invoke((MethodInvoker)delegate
                {
                    context.SetProgress((index + 1) * 100 / Words.Length);
                });
                var word = Words[index];
                word.FontSize = GetWordFontSize(word);
                if (CanFindPosition(word))
                    frames.Add(Tuple.Create(word.GetWordRectangle(), 1));
                else if (frames.Count == 0)
                    frames.Add(Tuple.Create(word.StayInCenterOfImage().GetWordRectangle(), 1));
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
        public float WordScale { get; set; }
        public string FontFamily { get; set; }
        public bool MoreDensity { get; set; }
        private static readonly int StandartIterations = 3;

        private bool CanFindPosition(WordBlock word)
        {
            if (frames.Count == 0) return false;
            frames = frames.OrderBy(t => t.Item2).ThenByDescending(i => i.Item1.Perimetr()).ToList();
            var better = frames.First();
            var worst = frames.Last();
            var it = worst.Item2 * StandartIterations / better.Item2;
            for (var i = 0; i < frames.Count; ++i)
            {
                if (BypassCircuit(word, frames[i].Item1, it != 0 ? it : 1))
                    return true;
                frames[i] = Tuple.Create(frames[i].Item1, frames[i].Item2 + 1);
            }
            return false;
        }

        private bool BypassCircuit(WordBlock word, Rectangle circuit, int count)
        {
            var points = circuit.GetPoints().OffsetArray(rnd.Next(0, 4));
            for (var i = 0; i < points.Length; ++i)
            {
                if (MoveOnLine(word, points[i], points[(i + 1) % points.Length], count))
                    return true;
            }
            return false;
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
                if (!word.IntersectsWith(frames.Select(h => h.Item1)) && word.InsideImage())
                    return true;
                word.RestoreLocation();
            }
            return false;
        }
    }
}
