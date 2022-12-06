using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5 : DayBase
    {
        public Day5() : base(5)
        {
            var crates = GetStartPosition();

            foreach (var item in Properties.Resources.InputDay52.Split("\r\n"))
            {
                var amount = int.Parse(item.Split(' ')[1]);
                var fromRow = int.Parse(item.Split(' ')[3]) - 1; 
                var toRow = int.Parse(item.Split(' ')[5]) - 1;

                var movingCrates = crates[fromRow].PopRange(amount);
                crates[toRow].PushRange(movingCrates);
            }

            var builder = new StringBuilder();
            foreach (var crateRow in crates)
            {
                builder.Append(crateRow.Pop());
            }

            Console.WriteLine($"Top crates: {builder}");
            crates = GetStartPosition();

            foreach (var item in Properties.Resources.InputDay52.Split("\r\n"))
            {
                var amount = int.Parse(item.Split(' ')[1]);
                var fromRow = int.Parse(item.Split(' ')[3]) - 1;
                var toRow = int.Parse(item.Split(' ')[5]) - 1;

                var movingCrates = crates[fromRow].PopRange(amount);
                movingCrates.Reverse(0, movingCrates.Count);
                crates[toRow].PushRange(movingCrates);
            }

            builder = new StringBuilder();
            foreach (var crateRow in crates)
            {
                builder.Append(crateRow.Pop());
            }

            Console.WriteLine($"Top crates: {builder}");
        }

        private static List<Stack<string>> GetStartPosition()
        {
            var crates = new List<Stack<string>>();

            for (int i = 0; i < 9; i++)
            {
                crates.Add(new Stack<string>());
            }

            foreach (var item in Properties.Resources.InputDay51.Split("\r\n").Reverse())
            {
                if (!item.StartsWith("[")) continue;

                var crateStock = new List<string>();
                for (int i = 1; i < item.Length; i += 4)
                {
                    crateStock.Add(item.Substring(i, 1));
                }

                var crateRowIndex = 0;
                foreach (var crate in crateStock)
                {
                    if (crate != " ") crates[crateRowIndex].Push(crate); 
                    crateRowIndex++;
                }
            }

            return crates;
        }
    }

    internal static partial class Extensions
    {
        public static void PushRange(this Stack<string> stack, List<string> elements)
        {
            foreach (var element in elements)
            {
                stack.Push(element);
            }
        }

        public static List<string> PopRange(this Stack<string> stack, int amount)
        {
            var list = new List<string>();
            for(int i = 0; i < amount; i++) 
                list.Add(stack.Pop());

            return list;
        }
    }
}
