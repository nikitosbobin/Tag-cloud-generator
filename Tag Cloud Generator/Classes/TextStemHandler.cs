using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NHunspell;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class TextStemHandler : ITextHandler
    {
        public TextStemHandler(string affixFilePath, string dictionaryFilePath)
        {
            if (!File.Exists(affixFilePath) || !affixFilePath.EndsWith(".aff"))
                throw new Exception("Can not read affix file");
            if (!File.Exists(dictionaryFilePath) || !dictionaryFilePath.EndsWith(".dic"))
                throw new Exception("Can not read dictionary file");
            this.dictionaryFilePath = dictionaryFilePath;
            this.affixFilePath = affixFilePath;
        }

        private static readonly char[] Separators =
        {
            '[', ']', '$', '<','>', '{', '}', '=', ' ', ' ', '.', ',',
            ':', '-', '…', '!', '?', '(', ')', '\'', '"', '`', ';', '0',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '«','»','–', '_'
        };

        private readonly string affixFilePath;
        private readonly string dictionaryFilePath;
        public string[] TextLines { get; set; } = new string[0];
        public bool ShouldStemWords { get; set; } = false;

        public Dictionary<string, int> GetWordsStatisctics()
        {
            var innerWords = new Dictionary<string, int>();
            var actualWords = SplitWords().Where(WordIsRight).ToArray();
            foreach (var word in ShouldStemWords ? StemWords(actualWords) : actualWords)
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

        private string[] StemWords(string[] source)
        {
            var result = new List<string>();
            using (var hunspell = new Hunspell(affixFilePath, dictionaryFilePath))
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
