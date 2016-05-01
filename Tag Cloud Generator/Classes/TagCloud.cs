﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class TagCloud : ITagCloud
    {
        public TagCloud(Size cloudSize, WordBlock[] words)
        {
            if (cloudSize == Size.Empty || words == null)
                throw new Exception("Can not cunstruct cloud");
            CloudSize = cloudSize;
            Words = words;
        }

        public Size CloudSize { get; }
        public IEnumerable<WordBlock> Words { get; }

        public ITagCloud OffsetAllWords(int offsetX, int offsetY)
        {
            foreach (var word in Words)
                word.MoveOn(offsetX, offsetY);
            return this;
        }
    }
}