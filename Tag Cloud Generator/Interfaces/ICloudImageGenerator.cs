using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        Size ImageSize { get; }
        Bitmap CreateImage(ICloudGenerator cloud, Font wordsFont, Color backgroundColor, List<Color> wordsBrushes);
    }
}
