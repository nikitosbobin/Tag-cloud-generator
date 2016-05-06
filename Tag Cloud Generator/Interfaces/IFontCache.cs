using System;
using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    interface IFontCache : IDisposable
    {
        Font GetFont(float size);
    }
}
