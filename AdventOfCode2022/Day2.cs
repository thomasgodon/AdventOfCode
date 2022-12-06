using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2 : DayBase
    {
        int totalScore;

        public Day2() : base(2)
        {
            foreach (var item in Properties.Resources.InputDay2.Split("\r\n"))
            {
                var hisRole = item.Substring(0, 1).ToPoints();
                var myRole = item.Substring(2, 1).ToPoints();

                CalculatePoints(myRole, hisRole);
            }

            Console.WriteLine($"My total score: {totalScore}");
            totalScore = 0;

            foreach (var item in Properties.Resources.InputDay2.Split("\r\n"))
            {
                var hisRole = item.Substring(0, 1).ToPoints();
                var gameStep = item.Substring(2, 1).ToPoints();
                var myRole = 1;

                if (gameStep == 1)
                {
                    // loose
                    myRole = hisRole - 1 < 1 ? 3 : hisRole - 1;
                }
                else if (gameStep == 2)
                {
                    // draw
                    myRole = hisRole;
                }
                else
                {
                    // win
                    myRole = hisRole + 1 > 3 ? 1 : hisRole + 1;
                }

                CalculatePoints(myRole, hisRole);
            }

            Console.WriteLine($"My total score: {totalScore}");
        }

        private void CalculatePoints(int myRole, int hisRole)
        {
            if (WhoWon(myRole, hisRole) == 0)
            {
                totalScore += myRole + 6;
            }
            else if (WhoWon(myRole, hisRole) == 1)
            {
                totalScore += myRole + 0;
            }
            else
            {
                totalScore += myRole + 3;
            }
        }

        private static int WhoWon(int myRole, int hisRole)
        {
            if (myRole == 1 && hisRole == 2) return 1;
            if (myRole == 2 && hisRole == 3) return 1;
            if (myRole == 3 && hisRole == 1) return 1;
            if (hisRole == 1 && myRole == 2) return 0;
            if (hisRole == 2 && myRole == 3) return 0;
            if (hisRole == 3 && myRole == 1) return 0;

            return -1;
        }
    }

    internal static partial class Extensions
    {
        public static int ToPoints(this string letter)
        {
            switch (letter.ToLower())
            {
                case "a":
                case "x":
                    return 1;

                case "b":
                case "y":
                    return 2;

                case "c":
                case "z":
                    return 3;
            }

            return 0;
        }
    }
}
