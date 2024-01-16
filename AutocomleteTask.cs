using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            
            return null;
        }

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var countOfPhrases = phrases.Count;
            if (countOfPhrases == 0)
                return new string[0];

            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, countOfPhrases);
            if (left == countOfPhrases - 1)
                return new string[0];

            var countByPrefix = Math.Min(count, GetCountByPrefix(phrases, prefix));
            var topByPrefix = new string[countByPrefix];
            var j = 0;
            for (var i = left + 1; i <= left + countByPrefix; i++)
            {
                topByPrefix[j] = phrases[i];
                j++;
            }
            return topByPrefix;
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var countOfPhrases = phrases.Count;
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, countOfPhrases);
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, countOfPhrases);
            return right - left - 1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var myList = new List<string>() { };
            IReadOnlyList<string> phrases = myList;
            var prefix = "abc";
            var count = 1;

            var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

            CollectionAssert.IsEmpty(actualTopWords);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            var myList = new List<string>() { "a", "b", "cc", "cd" };
            IReadOnlyList<string> phrases = myList;
            var prefix = "";
            var count = 4;

            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);

            Assert.AreEqual(count , actualCount);
        }
    }
}
