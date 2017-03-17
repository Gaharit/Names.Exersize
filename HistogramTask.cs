using System;
namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetHistogramBirthsPerDay(NameData[] names, string histogramName)
        {
            var days = new string[31];
            for (int y = 0; y < days.Length; y++)
                days[y] = (y + 1).ToString();
            var birthsCount = new double[31];
            foreach (var nameData in names)
                if (nameData.Name == histogramName && nameData.BirthDate.Day != 1)
                    birthsCount[nameData.BirthDate.Day - 1]++;
            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", histogramName), days, birthsCount);
        }
            public static HistogramData GetHistogramLivedInUSSR(NameData[] names)
        {
            var wasBornInUSSR = new string[2];
            wasBornInUSSR[0] = "родились в СССР";
            wasBornInUSSR[1] = "родились не в СССР";
            var birthsCount = new double[2];
            foreach (var nameData in names)
                if (nameData.BirthDate.Year > 1991 ||
                    (nameData.BirthDate.Year == 1991 && nameData.BirthDate.Month == 12 && nameData.BirthDate.Day > 26))
                    birthsCount[1]++;
                else birthsCount[0]++;
            return new HistogramData("Рождаемость в СССР", wasBornInUSSR, birthsCount);
        }
        public static HistogramData GetHistogramAge(NameData[] names)
        {
            var age = new string[100];
            for (int y = 0; y < age.Length; y++)
                age[y] = (y + 1).ToString();
            var birthsCount = new double[200];
            foreach (var nameData in names)
                    birthsCount[2017 - nameData.BirthDate.Year]++;
            return new HistogramData("Количество людей по возрасту", age, birthsCount);
        }
    }
}