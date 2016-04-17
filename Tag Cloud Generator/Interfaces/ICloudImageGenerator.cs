using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        Size ImageSize { get; set; }
        Bitmap CreateImage(ICloudGenerator cloud, Font wordsFont, int wordsCount, Color backgroundColor, List<Color> wordsBrushes);
        Bitmap CreateImage(ICloudGenerator cloud, Color backgroundColor, List<Color> wordsBrushes);
    }
}
