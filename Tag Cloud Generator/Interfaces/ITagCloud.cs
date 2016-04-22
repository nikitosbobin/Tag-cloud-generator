using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ITagCloud
    {
        Size CloudSize { get; }
        IEnumerable<WordBlock> Words { get; }
        ITagCloud OffsetAllWords(int offsetX, int offsetY);
    }
}
