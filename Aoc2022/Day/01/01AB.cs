using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day._01;

public static class _01AB
{
    public static void Do ()
    {
        List<int> containerGroups = new(), container = new();
        foreach (var line in File.ReadAllLines("D:/git/Aoc2022/Aoc2022/Day/01/input.txt"))
        {
            if (!String.IsNullOrEmpty(line))
                container.Add(int.Parse(line));
            if (string.IsNullOrEmpty(line))
            {
                var containerSum = 0;
                foreach (var item in container)
                    containerSum += item;
                containerGroups.Add(containerSum);
                container = new List<int>();
            }
        };
        containerGroups = containerGroups.OrderByDescending(x => x).ToList();
        Console.WriteLine($"{nameof(_01)} A: {containerGroups[0]}");
        Console.WriteLine($"{nameof(_01)} B: {containerGroups[0] + containerGroups[1] + containerGroups[2]}");
    }
}
