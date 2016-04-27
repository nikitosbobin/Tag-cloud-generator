using System;
using System.Collections.Generic;
using System.Linq;
using NHunspell;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class TextSpellHandler : ITextHandler
    {
        private static readonly char[] Separators =
        {
            '[', ']', '$', '<','>', '{', '}', '=', ' ', ' ', '.', ',',
            ':', '-', '…', '!', '?', '(', ')', '\'', '"', '`', ';', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '«','»','–'
        };

        public string[] TextLines { get; set; } = new string[0];
        
        public Dictionary<string, int> GetWords()
        {
            var innerWords = new Dictionary<string, int>();
            var actualWords = SplitWords().Where(WordIsRight).ToArray();
            foreach (var word in StemWords(actualWords))
            {
                if (innerWords.ContainsKey(word))
                    innerWords[word]++;
                else
                    innerWords.Add(word, 1);
            }
            return innerWords;
        }

        private string[] SplitWords()
        {
            var words = TextLines.Select(line => line.Split(Separators, StringSplitOptions.RemoveEmptyEntries));
            return words.SelectMany(line => line.Select(word => word.ToUpper())).ToArray();
        }

        private static bool WordIsRight(string word)
        {
            return word.Length >= 5;
        }

        private static string[] StemWords(string[] source)
        {
            var result = new List<string>();
            using (var hunspell = new Hunspell("en-ru.aff", "en-ru.dic"))
            {
                foreach (var word in source.Where(WordIsRight))
                {
                    var tmp = hunspell.Stem(word);
                    if (tmp.Count == 0)
                        result.Add(word);
                    else if (tmp.Count > 1)
                        result.Add(tmp[1]);
                    else result.Add(tmp[0]);
                }
            }
            return result.Select(e => e.ToUpper()).ToArray();
        }
    }
}
