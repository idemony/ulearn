using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = new string[30];
            var mounths = new string[12];
            var heat = new double[30, 12];
            for (var i = 2; i < 32; i++)
                days[i - 2] = i.ToString();
            for (var i = 1; i < 13; i++)
                mounths[i - 1] = i.ToString();
            foreach (var currname in names)
                if (currname.BirthDate.Day != 1)
                    heat[currname.BirthDate.Day - 2, currname.BirthDate.Month - 1] += 1;
            return new HeatmapData("Пример карты интенсивностей", heat, days, mounths);
        }
    }
}
