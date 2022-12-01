using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1 : DayBase
    {
        public Day1() : base(1)
        {
            var elves = new List<int>();
            var amount = 0;

            // calculate calories for each elf
            foreach (var item in Properties.Resources.InputDay1.Split("\\r\\n"))
            {
                if (item == string.Empty)
                {
                    elves.Add(amount);
                    amount = 0;
                    continue;
                }

                amount += int.Parse(item);
            }

            Console.WriteLine($"Most calories: {elves.Max()}");

            elves.Sort();
            var sumTop3Calories = 0;

            for (int i = 1; i <= 3; i++)
            {
                sumTop3Calories += elves[^i];
            }

            Console.WriteLine($"Top3 calories: {sumTop3Calories}");
        }

    }
}
