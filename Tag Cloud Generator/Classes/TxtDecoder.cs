using System;
using System.Linq;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class TxtDecoder : ITextDecoder
    {
        private static readonly char[] Separators =
        {
            '[', ']', '$', '<','>', '{', '}', '=', ' ', '.', ',',
            ':', '-', '!', '?', '(', ')', '\'', '"', '`', ';', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public string[] TextLines { get; set; } = new string[0];

        public string[] GetDecodedText()
        {
            var words = TextLines.Select(line => line.Split(Separators, StringSplitOptions.RemoveEmptyEntries));
            return words.SelectMany(line => line.Select(word => word.ToUpper())).ToArray();
        }
    }
}
