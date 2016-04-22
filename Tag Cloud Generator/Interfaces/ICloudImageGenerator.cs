using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        /*Bitmap CreateImage(ITagCloud cloud, Action<int> setProgress, 
            Font wordsFont, int wordsCount, int firstScale, Color backgroundColor, List<Color> wordsBrushes);*/
        Bitmap CreateImage(ITagCloud cloud, Color backgroundColor, List<Color> wordsBrushes);
    }
}
