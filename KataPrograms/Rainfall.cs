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
        private static readonly string[] Alltowns =
        {
            "Rome", "London", "Paris", "NY", "Vancouver", "Sydney", "Bangkok", "Tokyo", "Beijing", "Lima", "Montevideo",
            "Caracas", "Madrid", "Berlin", "Lon"
        };

        public static Dictionary<string, List<Record>> TownsDictionary = new Dictionary<string, List<Record>>();

        private static Dictionary<string, List<Record>> GetTowns()
        {
            return TownsDictionary ?? new Dictionary<string, List<Record>>();
        }

        public static double Mean(string townName, string strng)
        {
            if (string.IsNullOrEmpty(strng))
                return -1;

            if (!Alltowns.Contains(townName))
                return -1;

            Parse(strng);
            var townRecords = GetTownRecords(townName);
            var sum = townRecords.Sum(townRecord => townRecord.Rainfallcm);
            var avg = sum / townRecords.Count;

            return avg;
        }

        public static double Variance(string townName, string strng)
        {
            if (string.IsNullOrEmpty(strng))
                return -1;

            if (!Alltowns.Contains(townName))
                return -1;

            Parse(strng);
            var townRecords = GetTownRecords(townName);
            var sum = townRecords.Sum(townRecord => townRecord.Rainfallcm);
            var avg = sum / townRecords.Count();
            var variance = townRecords.Sum(townRecord => (townRecord.Rainfallcm - avg) * (townRecord.Rainfallcm - avg));

            return variance / townRecords.Count;
        }

        private static List<Record> GetTownRecords(string townName)
        {
            var existing = new List<Record>();
            if (GetTowns().ContainsKey(townName))
                existing = TownsDictionary[townName];
            return existing;
        }

        public static void Parse(string strng)
        {
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

                if (!GetTowns().ContainsKey(townName))
                    GetTowns().Add(townName, rainfallRecords);
                else
                    GetTowns()[townName] = rainfallRecords;
            }
        }
    }
}
