﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Interfaces.TagCloudGenerator.Interfaces;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ICloudImageGenerator
    {
        Bitmap CreateImage(ICloudGenerator cloud, Action<int> setProgress, Font wordsFont, int wordsCount, int firstScale, Color backgroundColor, List<Color> wordsBrushes);
        Bitmap CreateImage(ICloudGenerator cloud, Color backgroundColor, List<Color> wordsBrushes);
    }
}
