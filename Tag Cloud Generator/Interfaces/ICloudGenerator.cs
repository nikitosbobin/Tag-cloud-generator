using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            ICloudGenerator CreateCloud(Graphics graphics);
            ITextHandler TextHandler { get; set; }
            WordBlock[] Words { get; set; }
            ICloudImageGenerator ImageGenerator { get; }
            float WordScale { get; set; }
            string FontFamily { get; set; }
            bool MoreDensity { get; set; }
        }
    }

}
