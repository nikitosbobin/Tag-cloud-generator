using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        Bitmap CreateImage(ITagCloud cloud, Color backgroundColor, List<Color> wordsBrushes);
    }
}
