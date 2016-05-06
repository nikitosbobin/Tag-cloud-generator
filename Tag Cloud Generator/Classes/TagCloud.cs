using System;
using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class TagCloud : ITagCloud
    {
        public TagCloud(Size cloudSize, WordBlock[] words, IFontCache cache)
        {
            if (cloudSize == Size.Empty || words == null)
                throw new Exception("Can not cunstruct cloud");
            CloudSize = cloudSize;
            Words = words;
            FontsCache = cache;
        }

        public Size CloudSize { get; }
        public IEnumerable<IWordBlock> Words { get; }
        public IFontCache FontsCache { get; }

        public void Dispose()
        {
            FontsCache?.Dispose();
        }
    }
}
