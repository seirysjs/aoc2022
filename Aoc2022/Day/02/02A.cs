using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._02
{
    public class _02A
    {
        public static int totalScore = 0;
        public static void Do()
        {
            var lines = File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/02/input.txt").ToList();
            foreach (var line in lines)
                MatchScore((line.Split(" ")[0], line.Split(" ")[1]));
            Console.WriteLine($"{nameof(_02)} A:{totalScore}");
            //Console.WriteLine(containerGroups[0] + containerGroups[1] + containerGroups[2]);
        }

        private static void MatchScore((string Player, string Opponent) matchHands)
        {
            var score = 0;
            switch(matchHands.Opponent)
            {
                case ("X"):
                    // Rock
                    score = 1;
                    break;
                case ("Y"):
                    score = 2;
                    // Paper
                    break;
                case ("Z"):
                    score = 3;
                    // Scissors
                    break;
            }
            MatchEndingCheck(score, matchHands.Player);
        }

        private static void MatchEndingCheck(int playerHandType, string opponentHandType)
        {
            switch (opponentHandType)
            {
                case ("A"):
                    // Rock
                    if (playerHandType == 1) totalScore += playerHandType + 3;
                    if (playerHandType == 2) totalScore += playerHandType + 6;
                    if (playerHandType == 3) totalScore += playerHandType + 0;
                    break;
                case ("B"):
                    // paper
                    if (playerHandType == 1) totalScore += playerHandType + 0;
                    if (playerHandType == 2) totalScore += playerHandType + 3;
                    if (playerHandType == 3) totalScore += playerHandType + 6;
                    break;
                case ("C"):
                    // Scissors
                    if (playerHandType == 1) totalScore += playerHandType + 6;
                    if (playerHandType == 2) totalScore += playerHandType + 0;
                    if (playerHandType == 3) totalScore += playerHandType + 3;
                    break;
            }
        }
    }
}
