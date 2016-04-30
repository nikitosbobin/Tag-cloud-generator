using System;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class CloudMectrics : IDisposable
    {
        private bool disposed;
        private readonly Graphics graphics;
        public Size CloudSize { get; }
        public Font WordsFont { get; }

        public CloudMectrics(Size cloudSize, Font wordsFont = null)
        {
            if (cloudSize == Size.Empty)
                throw new Exception("Can not create metrics");
            CloudSize = cloudSize;
            WordsFont = wordsFont ?? new Font("Segoe UI", 12f);
            var image = new Bitmap(cloudSize.Width, cloudSize.Height);
            graphics = Graphics.FromImage(image);
            image.Dispose();
            disposed = false;
        }

        public Size MeasureWord(WordBlock word)
        {
            var wordSize = graphics.MeasureString(word.Source, word.Font).ToSize();
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
            if (disposed) return;
            graphics.Dispose();
            disposed = true;
        }
    }
}
