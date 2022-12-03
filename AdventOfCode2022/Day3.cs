using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3 : DayBase
    {
        public Day3() : base(3)
        {
            var priorities = 0;
            foreach (var item in Properties.Resources.InputDay3.Split("\r\n"))
            {
                var compart1 = item.Substring(0, item.Length / 2);
                var compart2 = item.Substring(item.Length / 2);
                var equalItem = compart1.Intersect(compart2).First();

                if (char.IsUpper(equalItem))
                {
                    priorities += equalItem - 38;
                }
                else
                {
                    priorities += char.ToUpper(equalItem) - 64;
                }
            }

            Console.WriteLine($"Sum priorities: {priorities}");
            priorities = 0;

            var batchCounter = 0;
            var currentBatch = new List<string>();

            foreach (var item in Properties.Resources.InputDay3.Split("\r\n"))
            {
                batchCounter++;
                currentBatch.Add(item);

                if (batchCounter < 3) continue;

                var equalItem = currentBatch[0].Intersect(currentBatch[1]).Intersect(currentBatch[2]).First();

                if (char.IsUpper(equalItem))
                {
                    priorities += equalItem - 38;
                }
                else
                {
                    priorities += char.ToUpper(equalItem) - 64;
                }

                batchCounter = 0;
                currentBatch.Clear();
            }

            Console.WriteLine($"Sum priorities: {priorities}");
        }
    }
}
