using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NHunspell;
using Tag_Cloud_Generator.Interfaces;

namespace Tag_Cloud_Generator.Classes
{
    class SimpleTextHandler : ITextHandler
    {
        public SimpleTextHandler(IEnumerable<string> boringWords = null)
        {
            this.boringWords = new HashSet<string>(boringWords ?? new string[0]);
        }

        private string[] decodedLines;
        private readonly HashSet<string> boringWords;

        private string[] StemWords(string[] source)
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

        public IEnumerable<WordBlock> GetWords(ITextDecoder decoder, Graphics graphics, Font wordsFont)
        {
            decodedLines = decoder.GetDecodedText();
            var innerWords = new Dictionary<string, WordBlock>();
            foreach (var word in StemWords(decodedLines))
            {
                if (WordIsRight(word))
                {
                    if (innerWords.ContainsKey(word))
                        innerWords[word].Frequency++;
                    else
                        innerWords.Add(word, new WordBlock(graphics, wordsFont, word));
                }
                else
                    if (!boringWords.Contains(word))
                    boringWords.Add(word);
            }
            return innerWords.Select(pair => pair.Value).ToArray();
        }

        private bool WordIsRight(string word)
        {
            return word.Length >= 5 && !boringWords.Contains(word);
        }
    }
}
