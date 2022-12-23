using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._03
{
    public class _03A
    {
        public static int totalPriorities = 0;
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/03/input.txt").ToList();
            foreach (var line in lines)
                MatchScore(line);
            Console.WriteLine($"{nameof(_03)} A:{totalPriorities}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void MatchScore(string line)
        {
            var leftSide = line.Substring(0, line.Length/2).ToCharArray();
            var rightSide = line.Substring(line.Length/2, line.Length / 2).ToCharArray();
            var looking = true;
            while (looking)
            {
                foreach (var left in leftSide)
                    foreach (var right in rightSide)
                        if ((int)left == (int)right && looking)
                        {
                            looking = false;
                            var symbolValue = left;
                            var charValue = (int)symbolValue;
                            if (symbolValue > 90)
                            {
                                charValue += -96;
                                totalPriorities += charValue;
                                continue;
                            }
                            charValue += -64 + 26;
                            totalPriorities += charValue;
                        }
                    looking = false;
            }
        }
    }
}
