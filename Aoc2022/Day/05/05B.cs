using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._05
{
    public class _05B
    {
        public static Dictionary<int, List<string>> cratesDictonary = new();
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/05/input.txt").ToList();
            var movesLine = 0;
            var indexLineTemp = 0;
            while (movesLine == 0)
            {
                var line = lines[indexLineTemp];
                if (line.Substring(0, 1) != "[" && movesLine == 0)
                {
                    movesLine = indexLineTemp;
                    continue;
                }
                indexLineTemp++;
            }

            var counter = lines.Count;
            for (int indexLine = movesLine - 1; indexLine >= 0; indexLine--)
            {
                var line = lines[indexLine];
                var indexDictionaryList = 1;
                for (int charIndex = 0; charIndex < (line.Length); charIndex++)
                {
                    if ((1 + charIndex) % 4 == 0) indexDictionaryList++;
                    var crateChar = line.Substring(charIndex, 1);
                    if (crateChar == " " || String.IsNullOrEmpty(crateChar) || crateChar == "[" || crateChar == "]") continue;

                    if (!cratesDictonary.ContainsKey(indexDictionaryList))
                        cratesDictonary[indexDictionaryList] = new List<string>();
                    if (crateChar != " " && !String.IsNullOrEmpty(crateChar))
                        cratesDictonary[indexDictionaryList].Add(crateChar);
                }
            }

            var test = cratesDictonary;

            for (var index = movesLine + 2; index < lines.Count; index++)
                ProcessMove(lines[index]);
            var cratesWord = String.Empty;

            foreach (var cratesGroupIndex in cratesDictonary)
            {
                cratesWord += cratesGroupIndex.Value.LastOrDefault();
            }
            Console.WriteLine($"{nameof(_05)} A:{cratesWord}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void ProcessMove(string line)
        {
            var amount = int.Parse(line.Split(" from")[0].Split("move ")[1]);
            var from = int.Parse(line.Split(" from ")[1].Split(" to ")[0]);
            var to = int.Parse(line.Split(" from ")[1].Split(" to ")[1]);
            MoveMultipleCrates(amount, from, to);

            return;
        }

        private static void MoveMultipleCrates(int amount, int from, int to)
        {
            var cratesLength = cratesDictonary[from].Count;
            var cratesIndexes = new List<int>();
            for (var i = amount; i > 0; i--)
            {
                var cratesIndex = cratesLength - i;
                var item = cratesDictonary[from][cratesIndex];
                if (item == null) continue;
                cratesDictonary[to].Add(item);
                cratesIndexes.Add(cratesIndex);
            }

            foreach (var indexItem in cratesIndexes)
            {
                cratesDictonary[from].RemoveAt(cratesIndexes.FirstOrDefault());
            }
        }
    }
}
