using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6 : DayBase
    {
        public Day6() : base(6)
        {
            Console.WriteLine($"Start of packet: {ProcessMessages(4)}");
            Console.WriteLine($"Start of packet: {ProcessMessages(14)}");
        }

        private int ProcessMessages(int distinctCharacters)
        {
            var received = new Queue<char>();
            var index = 0;
            var characterAppearance = 0;
            foreach (var character in Properties.Resources.InputDay6)
            {
                received.Enqueue(character);
                index++;
                if (received.Count < distinctCharacters) continue;
                characterAppearance = received.Distinct().Count();
                received.Dequeue();
                if (characterAppearance >= distinctCharacters) return index;
            }

            return -1;
        }
    }
}
