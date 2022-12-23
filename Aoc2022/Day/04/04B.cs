using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._04
{
    public class _04B
    {
        public static int totalPairs = 0;
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/04/input.txt").ToList();
            foreach (var line in lines)
                MatchScore(line);
            Console.WriteLine($"{nameof(_04)} A:{totalPairs}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void MatchScore(string line)
        {
            var container = new HashSet<int>();
            var item = new HashSet<int>();
            for (int i = int.Parse(line.Split(",")[0].Split("-")[0]); i <= int.Parse(line.Split(",")[0].Split("-")[1]); i++)
                container.Add(i);
            for (int i = int.Parse(line.Split(",")[1].Split("-")[0]); i <= int.Parse(line.Split(",")[1].Split("-")[1]); i++)
                item.Add(i);
            var contains = false;
            while (!contains)
            {
                foreach (var number in item)
                    if (container.Contains(number))
                        contains = true;
                if (contains)
                {
                    totalPairs++;
                    continue;
                }
                contains = false;
                foreach (var number in container)
                    if (item.Contains(number))
                        contains = true;
                if (contains) totalPairs++;
                contains = true;
            }

            
            return;
        }
    }
}
