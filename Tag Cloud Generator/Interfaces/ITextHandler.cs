using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ITextHandler
    {
        IEnumerable<WordBlock> GetWords(ITextDecoder decoder, Graphics graphics, Font wordsFont);
    }
}
