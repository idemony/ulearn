using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] sentences = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' });
            var sentenceCount = -1;
            var flagNewSentence = 0;
            var lastSeparator = -1;
            for (var i = 0; i < sentences.Length; i++)
            {
                flagNewSentence = 0;
                var currSentence = sentences[i];
                if (currSentence == null)
                    continue;
                lastSeparator = -1;
                for (var j = 0; j < currSentence.Length; j++)
                    if (!char.IsLetter(currSentence, j) && currSentence[j] != '\'')
                    {
                        if (lastSeparator != j - 1)
                        {
                            var currSeparator = j - lastSeparator;
                            var currWord = currSentence.Substring(lastSeparator + 1, currSeparator - 1).ToLower();
                            if (flagNewSentence == 0)
                            {
                                sentencesList.Add(new List<string> { currWord });
                                sentenceCount++;
                            }
                            else
                                sentencesList[sentenceCount].Add(currWord);
                            flagNewSentence = 1;
                        }
                        lastSeparator = j;
                    }
                if ((lastSeparator != currSentence.Length - 1) && text != null)
                {
                    var currWord = currSentence.Substring(lastSeparator + 1).ToLower();
                    if (flagNewSentence == 0)
                    {
                        sentencesList.Add(new List<string> { currWord });
                        sentenceCount++;
                    }
                    else sentencesList[sentenceCount].Add(currWord);
                }
            }
            return sentencesList;
        }
    }
}
