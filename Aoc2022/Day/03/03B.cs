using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._03
{
    public class _03B
    {
        public static int lineIndex = 0;
        public static int totalPriorities = 0;
        public static List<string> lines = new();
        public static void Do()
        {
            lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/03/input.txt").ToList();
            for (lineIndex = 0; lineIndex < lines.Count; lineIndex += 3)
                MatchScore(lineIndex);
            Console.WriteLine($"{nameof(_03)} B:{totalPriorities}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void MatchScore(int index)
        {
            if (index < lineIndex) return;
            lineIndex = index;
            var chars0 = lines[index].ToCharArray();
            var chars1 = lines[index+1].ToCharArray();
            var chars2 = lines[index+2].ToCharArray();
            var looking = true;
            while (looking)
            {
                foreach (var top in chars0)
                    foreach (var middle in chars1)
                    {
                        if ((int)top == (int)middle && looking)
                            foreach (var bottom in chars2)
                            {
                                if ((int)top != (int)middle || (int)top != (int)bottom || !looking) continue;
                                looking = false;
                                var symbolValue = bottom;
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
                    }
                    looking = false;
            }
        }
    }
}
