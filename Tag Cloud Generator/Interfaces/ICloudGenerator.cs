using System;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            ICloudGenerator CreateCloud(Graphics graphics, Font wordsFont, int wordsCount,
                int firstScale, Action<int> setProgressAction);
            ITextHandler TextHandler { get; set; }
            WordBlock[] Words { get; set; }
        }
    }

}
