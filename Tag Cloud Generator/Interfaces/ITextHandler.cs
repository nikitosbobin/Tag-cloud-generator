using System.Collections.Generic;

namespace Tag_Cloud_Generator.Interfaces
{
    interface ITextHandler
    {
        Dictionary<string, int> GetWords();
    }
}
