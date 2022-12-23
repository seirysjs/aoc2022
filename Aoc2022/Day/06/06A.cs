using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._06
{
    public class _06A
    {
        public static List<string> lastChars = new List<string>();
        public static int blockLength = 4;
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/06/input.txt").ToList();
            var charsOffset = 0;

            var line = lines[0];
            var lineLength = line.Length;
            for (var i = 0; i < lineLength; i++)
            {
                charsOffset = i;
                var currentChar = line.Substring(i, 1);
                var unique = ParseNextSymbol(currentChar);
                if (unique && lastChars.Count == blockLength)
                {
                    Console.WriteLine($"{nameof(_06)} A:{charsOffset+1}");
                    return;
                }
            }
        }

        private static bool ParseNextSymbol(string symbolChar)
        {
            var unique = true;
            var cloneChars = new List<string>();

            while (lastChars.Count >= blockLength)
            {
                lastChars.RemoveAt(0);
            }

            for (var i = 0; i < lastChars.Count; i++)
            {
                if (cloneChars.Contains(lastChars[i])) unique = false;
                cloneChars.Add(lastChars[i]);
            }

            if (cloneChars.Contains(symbolChar)) unique = false;
            cloneChars.Add(symbolChar);
            lastChars = cloneChars;

            return unique;
        }
    }
}
