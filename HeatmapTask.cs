using System;
namespace Names
{
    internal static class HeatmapTask
    {
        public static string[] CreateRow(int length, int startingValue)
        {
            var row = new string[length];
            for (int i = 0; i < length; i++)
                row[i] = (i + startingValue).ToString();
            return row;
        }
        public static HeatmapData GetHistogramBirthsPerDate(NameData[] names)
        {
            var days = CreateRow(30, 2);
            var months = CreateRow(12, 1);
            var heatMap = new double[30, 12];
            foreach (var nameData in names)
                if (nameData.BirthDate.Day != 1)
                    heatMap[nameData.BirthDate.Day - 2, nameData.BirthDate.Month - 1]++;
            return new HeatmapData("Тепловая карта рождаемости в зависимости от дня и месяца для заданного имени",
                heatMap, days, months);
        }
    }
}