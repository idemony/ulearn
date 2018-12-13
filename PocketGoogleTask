using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        private Dictionary<string, Dictionary<int, List<int>>> words = 
            new Dictionary<string, Dictionary<int, List<int>>>();

        private List<char> separators = new List<char>() { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        private bool isSeparator(char symbol)
        {
            return separators.Contains(symbol);
        }

        private void addCurrentWord(int leftSeparator, int rightSeparator, string documentText, int id)
        {
            var word = documentText.Substring(leftSeparator + 1, rightSeparator - leftSeparator - 1);
            if (words.ContainsKey(word))
            {
                if (words[word].ContainsKey(id))
                    words[word][id].Add(leftSeparator + 1);
                else words[word].Add(id, new List<int>() { leftSeparator + 1 });
            }
            else words.Add(word, new Dictionary<int, List<int>>() { { id, new List<int>() { leftSeparator + 1 } } });
        }

        public void Add(int id, string documentText)
        {
            var lastSeparator = -1;
            for (var i = 0; i < documentText.Length; i++)
            {
                if (isSeparator(documentText[i]))
                {
                    if (i - lastSeparator > 1)
                        addCurrentWord(lastSeparator, i, documentText, id);
                    lastSeparator = i;
                } else if (i == documentText.Length - 1 && i + 1 - lastSeparator > 1)
                    addCurrentWord(lastSeparator, i + 1, documentText, id);
            }
        }

        public List<int> GetIds(string word)
        {
            if (words.ContainsKey(word))
                return words[word].Keys.ToList<int>();
            return new List<int>();
        }

        public List<int> GetPositions(int id, string word)
        {
            if (words.ContainsKey(word) && words[word].ContainsKey(id))
                return words[word][id];
            return new List<int>();
        }

        public void Remove(int id)
        {
            foreach (var pair in words)
                words[pair.Key].Remove(id);
        }
    }
}
