using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._02
{
    public class _02B
    {
        public static int totalScore = 0;
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/02/input.txt").ToList();
            foreach (var line in lines)
                MatchScore((line.Split(" ")[0], line.Split(" ")[1]));
            Console.WriteLine($"{nameof(_02)} B:{totalScore}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void MatchScore((string HandType, string Opponent) matchHands)
        {
            var score = 0;
            switch(matchHands.HandType)
            {
                case ("A"):
                    // rock
                    score = 1;
                    break;
                case ("B"):
                    score = 2;
                    // paper
                    break;
                case ("C"):
                    score = 3;
                    // scissors
                    break;
            }
            MatchEndingCheck(score, matchHands.Opponent);
        }

        private static void MatchEndingCheck(int opponentHandType, string ending )
        {
            switch (ending)
            {
                case ("X"):
                    // loose
                    if (opponentHandType == 1) totalScore += 3 + 0;
                    if (opponentHandType == 2) totalScore += 1 + 0;
                    if (opponentHandType == 3) totalScore += 2 + 0;
                    break;
                case ("Y"):
                    // draw
                    if (opponentHandType == 1) totalScore += 1 + 3;
                    if (opponentHandType == 2) totalScore += 2 + 3;
                    if (opponentHandType == 3) totalScore += 3 + 3;
                    break;
                case ("Z"):
                    // win
                    if (opponentHandType == 1) totalScore += 2 + 6;
                    if (opponentHandType == 2) totalScore += 3 + 6;
                    if (opponentHandType == 3) totalScore += 1 + 6;
                    break;
            }
        }
    }
}
