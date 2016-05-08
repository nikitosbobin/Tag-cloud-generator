using System;
using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator : IDisposable
        {
            void InitCreating(Size targetCloudSize, Font wordsFont, int wordsAmount, 
                int minWordsLength, int firstScale);
            bool TryHandleNextWord();
            ITagCloud GetCreatedCloud();
            int MaxWordsCount { get; }
            ITextHandler TextHandler { get; set; }
        }
    }

}
