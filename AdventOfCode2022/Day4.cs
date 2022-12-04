using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4 : DayBase
    {
        public Day4() : base(4)
        {
            var doublePairs = 0;
            foreach (var item in Properties.Resources.InputDay4.Split("\r\n"))
            {
                var startPair1 = int.Parse(item.Split(',')[0].Split('-')[0]);
                var endPair1 = int.Parse(item.Split(',')[0].Split('-')[1]);
                var startPair2 = int.Parse(item.Split(',')[1].Split('-')[0]);
                var endPair2 = int.Parse(item.Split(',')[1].Split('-')[1]);

                var sequencePair1 = Enumerable.Range(startPair1, endPair1 - startPair1 + 1).ToList();
                var sequencePair2 = Enumerable.Range(startPair2, endPair2 - startPair2 + 1).ToList();

                if (sequencePair1.Intersect(sequencePair2).Count() == sequencePair1.Count ||
                    sequencePair2.Intersect(sequencePair1).Count() == sequencePair2.Count)
                {
                    doublePairs++;
                }
            }

            Console.WriteLine($"Total doubles: {doublePairs}");
            doublePairs = 0;

            foreach (var item in Properties.Resources.InputDay4.Split("\r\n"))
            {
                var startPair1 = int.Parse(item.Split(',')[0].Split('-')[0]);
                var endPair1 = int.Parse(item.Split(',')[0].Split('-')[1]);
                var startPair2 = int.Parse(item.Split(',')[1].Split('-')[0]);
                var endPair2 = int.Parse(item.Split(',')[1].Split('-')[1]);

                var sequencePair1 = Enumerable.Range(startPair1, endPair1 - startPair1 + 1).ToList();
                var sequencePair2 = Enumerable.Range(startPair2, endPair2 - startPair2 + 1).ToList();

                if (sequencePair1.Intersect(sequencePair2).Count() > 0)
                {
                    doublePairs++;
                }
            }

            Console.WriteLine($"Total doubles: {doublePairs}");
        }
    }
}
