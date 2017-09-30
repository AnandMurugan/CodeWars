using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KataPrograms
{
    public class Record
    {
        public string Month { get; set; }

        public double Rainfallcm { get; set; }
    }

    public class Rainfall
    {
        public static double Mean(string townName, string strng)
        {
            if (string.IsNullOrEmpty(strng))
                return -1;

            Dictionary<string, List<Record>> townsDictionary;
            Parse(strng, out townsDictionary);

            if (!townsDictionary.ContainsKey(townName))
                return -1;
            var townRecords = townsDictionary[townName];
            var sum = townRecords.Sum(townRecord => townRecord.Rainfallcm);
            var avg = sum / townRecords.Count;

            return avg;
        }

        public static double Variance(string townName, string strng)
        {
            if (string.IsNullOrEmpty(strng))
                return -1;

            Dictionary<string, List<Record>> townsDictionary;
            Parse(strng, out townsDictionary);

            if (!townsDictionary.ContainsKey(townName))
                return -1;
            var townRecords = townsDictionary[townName];
            var sum = townRecords.Sum(townRecord => townRecord.Rainfallcm);
            var avg = sum / townRecords.Count;
            var variance = townRecords.Sum(townRecord => (townRecord.Rainfallcm - avg) * (townRecord.Rainfallcm - avg));

            return variance / townRecords.Count;
        }

        private static void Parse(string strng, out Dictionary<string, List<Record>> townsDictionary)
        {
            townsDictionary = new Dictionary<string, List<Record>>();
            var townvalues = strng.Split('\n');
            foreach (var townvalue in townvalues)
            {
                var rainfallvalues = townvalue.Split(':')[1].Split(',');
                var townName = townvalue.Split(':')[0];
                var rainfallRecords = rainfallvalues.Select(rainfallvalue => new Record
                    {
                        Month = rainfallvalue.Split(' ')[0],
                        Rainfallcm = Convert.ToDouble(rainfallvalue.Split(' ')[1], CultureInfo.InvariantCulture)
                    })
                    .ToList();

                if (townsDictionary != null && !townsDictionary.ContainsKey(townName))
                    townsDictionary.Add(townName, rainfallRecords);
            }
        }
    }
}