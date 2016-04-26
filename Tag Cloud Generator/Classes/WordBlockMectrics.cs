using System;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class WordBlockMectrics
    {
        private readonly WordBlock currentWordBlock;
        public WordBlockMectrics(WordBlock word)
        {
            if (word == null)
                throw new Exception("Can not create metrics");
            currentWordBlock = word;
        }

        public Size MeasureWord(Graphics graphics)
        {
            var wordSize = graphics.MeasureString(currentWordBlock.Source, currentWordBlock.Font).ToSize();
            return currentWordBlock.IsVertical ? new Size(wordSize.Height, wordSize.Width) : wordSize;
        }

        public Rectangle GetWordRectangle(Graphics graphics)
        {
            var wordSize = MeasureWord(graphics);
            var location = new Point(currentWordBlock.Location.X, currentWordBlock.Location.Y);
            if (currentWordBlock.IsVertical) location.Y -= wordSize.Height;
            return new Rectangle(location, wordSize);
        }

        public bool WordInsideImage(Graphics graphics)
        {
            var wordRect = GetWordRectangle(graphics);
            return graphics.IsVisible(wordRect.LeftBottom()) && graphics.IsVisible(wordRect.RigthBottom());
        }
    }
}
