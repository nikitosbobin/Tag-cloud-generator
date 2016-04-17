using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            ICloudGenerator CreateCloud(Graphics graphics, Font wordsFont, int wordsCount);
            ITextHandler TextHandler { get; set; }
            WordBlock[] Words { get; set; }
            float WordScale { get; set; }
            string FontFamily { get; set; }
            bool MoreDensity { get; set; }
        }
    }

}
