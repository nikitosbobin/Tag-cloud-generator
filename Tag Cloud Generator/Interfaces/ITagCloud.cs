using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ITagCloud : IDisposable
    {
        Size CloudSize { get; }
        IEnumerable<IWordBlock> Words { get; }
        IFontCache FontsCache { get; }
    }
}
