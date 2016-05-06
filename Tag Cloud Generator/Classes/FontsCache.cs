using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class FontsCache : IFontCache
    {
        public FontsCache(Font baseFont)
        {
            this.baseFont = (Font)baseFont.Clone();
            fontsDictionary = new Dictionary<float, Font> { { this.baseFont.Size, this.baseFont } };
        }

        private readonly Font baseFont;

        public Font GetFont(float size)
        {
            if (!fontsDictionary.ContainsKey(size))
                fontsDictionary.Add(size, new Font(baseFont.Name, size, baseFont.Style));
            return fontsDictionary[size];
        }

        private readonly Dictionary<float, Font> fontsDictionary;

        public void Dispose()
        {
            foreach (var font in fontsDictionary)
                font.Value.Dispose();
        }
    }
}
