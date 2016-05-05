using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class CloudMectrics : IDisposable
    {
        private readonly Graphics graphics;
        public Size CloudSize { get; }
        public Font WordsFont { get; }
        private readonly Dictionary<WordBlock, Size> wordSizes;

        public CloudMectrics(Size cloudSize, Font wordsFont)
        {
            if (cloudSize == Size.Empty)
                throw new Exception("Can not create metrics");
            CloudSize = cloudSize;
            try
            {
                WordsFont = (Font) wordsFont.Clone();
            }
            catch
            {
                WordsFont = new Font("Segoe UI", 12f);
            }
            using (var image = new Bitmap(cloudSize.Width, cloudSize.Height))
                graphics = Graphics.FromImage(image);
            wordSizes = new Dictionary<WordBlock, Size>(new WordBlock.Comparer());
        }

        public Size MeasureWord(WordBlock word)
        {
            Size wordSize;
            if (!wordSizes.ContainsKey(word))
            {
                wordSize = graphics.MeasureString(word.Source, word.Font).ToSize();
                wordSizes.Add(word, wordSize);
            }
            else
                wordSize = wordSizes[word];
            return word.IsVertical ? new Size(wordSize.Height, wordSize.Width) : wordSize;
        }

        public Rectangle GetWordRectangle(WordBlock word)
        {
            var wordSize = MeasureWord(word);
            var location = new Point(word.Location.X, word.Location.Y);
            if (word.IsVertical) location.Y -= wordSize.Height;
            return new Rectangle(location, wordSize);
        }

        public bool WordInsideImage(WordBlock word)
        {
            var wordRect = GetWordRectangle(word);
            return graphics.IsVisible(wordRect.Location) && graphics.IsVisible(wordRect.RigthBottom());
        }

        public void Dispose()
        {
            graphics.Dispose();
            WordsFont.Dispose();
        }
    }
}
