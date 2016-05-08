using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Classes
{
    class FormDataProvider : IDisposable
    {
        private Font wordsFont;
        public Font WordsFont
        {
            get
            {
                return wordsFont;
            }
            set
            {
                wordsFont = (Font) value.Clone();
            }
        }
        public Color BackGroundColor { get; set; }
        public List<Color> WordsColors { get; set; }
        public int WordsCount { get; set; }
        public int FirstScale { get; set; }
        public Size ImageSize { get; set; }
        public bool ShouldStemWords { get; set; }
        public int Accuracy { get; set; }
        public int MinWordsLength { get; set; }

        public void Dispose()
        {
            wordsFont?.Dispose();
        }
    }
}
