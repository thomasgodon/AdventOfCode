using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day7 : DayBase
    {
        public Day7() : base(7)
        {
            var totalFileSize = GetDirSizes().Where(m => m < 100000).Sum();
            Console.WriteLine($"Total file size: {totalFileSize}");

            var dirSizes = GetDirSizes();
            var freeSpace = 70000000 - dirSizes.Max();

            var totalSizeSmallestToDelete = dirSizes.Where(m => m + freeSpace >= 30000000).Min(); 
            Console.WriteLine($"smallest file size: {totalSizeSmallestToDelete}");
        }

        private List<int> GetDirSizes()
        {
            var paths = new Stack<string>();
            var sizes = new Dictionary<string, int>();

            foreach (var item in Properties.Resources.InputDay7.Split("\r\n"))
            {
                if (item == "$ cd ..")
                {
                    paths.Pop();
                }
                else if (item.StartsWith("$ cd"))
                {
                    paths.Push($"{string.Join(string.Empty, paths)}{item.Split(" ")[2]}");
                }
                else if (Regex.Match(item, @"\d+").Success)
                {
                    var size = int.Parse(item.Split(" ")[0]);
                    foreach (var dir in paths)
                    {
                        sizes[dir] = sizes.GetValueOrDefault(dir) + size;
                    }
                }
            }

            return sizes.Values.ToList();
        }
    }
}
