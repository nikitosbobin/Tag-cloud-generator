﻿using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            void InitCreating(Size targetCloudSize, Font wordsFont, int wordsAmount, int firstScale);
            bool HandleNextWord();
            ITagCloud GetCreatedCloud();
            int MaxWordsCount { get; }
            ITextHandler TextHandler { get; set; }
        }
    }

}
