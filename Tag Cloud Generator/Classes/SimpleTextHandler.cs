using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public IEnumerable<WordBlock> GetWords(ITextDecoder decoder, Graphics graphics)
        {
            decodedLines = decoder.GetDecodedText();
            var innerWords = new Dictionary<string, WordBlock>();
            foreach (var word in decodedLines)
            {
                if (WordIsRight(word))
                {
                    if (innerWords.ContainsKey(word))
                        innerWords[word].Frequency++;
                    else
                        innerWords.Add(word, new WordBlock(graphics, word));
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
