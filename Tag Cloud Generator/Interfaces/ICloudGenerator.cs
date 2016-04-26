using System.Collections.Generic;
using System.Drawing;
using Tag_Cloud_Generator.Classes;

namespace Tag_Cloud_Generator.Interfaces
{
    namespace TagCloudGenerator.Interfaces
    {
        interface ICloudGenerator
        {
            void InitCreating(Size targetCloudSize, Font wordsFont, int wordsAmount, int firstScale);
            bool HandleNextWord();
            ITagCloud GetCreatedCloud();
            IReadOnlyCollection<WordBlock> WordBlocks { get; }
            ITextHandler TextHandler { get; set; }
        }
    }

}
