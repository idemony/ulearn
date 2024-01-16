using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var daysCounts = new double[31];
            var days = new string[31];
            for (int i = 1; i < 32; i++)
                days[i - 1] = i.ToString();
            foreach (var currname in names)
                if (currname.Name == name && currname.BirthDate.Day != 1)
                    daysCounts[currname.BirthDate.Day - 1] += 1;
            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), days, daysCounts);
        }
    }
}
