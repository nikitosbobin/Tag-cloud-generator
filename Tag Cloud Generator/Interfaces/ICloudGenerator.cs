using System;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            ITagCloud CreateCloud(Size targetCloudSize, Font wordsFont, int wordsAmount,
                int firstScale, Action<int> setProgressAction);
            ITextHandler TextHandler { get; set; }
            WordBlock[] Words { get; set; }
        }
    }

}
