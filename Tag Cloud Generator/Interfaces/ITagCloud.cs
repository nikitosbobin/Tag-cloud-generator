using System;
using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ITagCloud : IDisposable
    {
        Size CloudSize { get; }
        IEnumerable<WordBlock> Words { get; }
    }
}
