using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal abstract class DayBase
    {
        protected DayBase(int day)
        {
            Console.WriteLine("===========================");
            Console.WriteLine($"Day {day}");
            Console.WriteLine("------");
        }
    }
}
