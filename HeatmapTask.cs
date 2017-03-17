using System;
namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetHistogramBirthsPerDate(NameData[] names)
        {
            var minDay = 2;
            var maxDay = 31;
            var days = new string[maxDay - minDay + 1];
            for (int y = 0; y < days.Length; y++)
                days[y] = (y + minDay).ToString();
            var months = new string[12];
            for (int y = 0; y < months.Length; y++)
                months[y] = (y + 1).ToString();
            var heat = new double[maxDay - minDay + 1, 12];
            foreach (var nameData in names)
                if (nameData.BirthDate.Day != 1)
                    heat[nameData.BirthDate.Day - minDay, nameData.BirthDate.Month - 1]++;
            return new HeatmapData("Тепловая карта рождаемости в зависимости от дня и месяца для заданного имени",
                heat, days, months);
        }
    }
}