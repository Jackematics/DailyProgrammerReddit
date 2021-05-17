using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeUpperSectionScoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("yahtzee_upper([2, 3, 5, 5, 6]) => " + YahtzeeUpperScore(new int[] { 2, 3, 5, 5, 6 }));
            Console.WriteLine("yahtzee_upper([1, 1, 1, 1, 3]) => " + YahtzeeUpperScore(new int[] { 1, 1, 1, 1, 3 }));
            Console.WriteLine("yahtzee_upper([1, 1, 1, 3, 3]) => " + YahtzeeUpperScore(new int[] { 1, 1, 1, 3, 3 }));
            Console.WriteLine("yahtzee_upper([1, 2, 3, 4, 5]) => " + YahtzeeUpperScore(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine("yahtzee_upper([6, 6, 6, 6, 6]) => " + YahtzeeUpperScore(new int[] { 6, 6, 6, 6, 6 }));

            Console.WriteLine("yahtzee_upper([1654, 1654, 50995, 30864, 1654, 50995, 22747, 1654, 1654, 1654, 1654, 1654, 30864, 4868, 1654, 4868, 1654, 30864, 4868, 30864]) => " + YahtzeeUpperScore(new int[] { 1654, 1654, 50995, 30864, 1654, 50995, 22747, 1654, 1654, 1654, 1654, 1654, 30864, 4868, 1654, 4868, 1654, 30864, 4868, 30864 }));

            Console.ReadLine();
        }

        static int YahtzeeUpperScore(int[] diceRolls)
        {
            List<int> distinctRolls = diceRolls.Distinct().ToList();
            var yahtzeedScores = new List<int>();            

            for (int i = 0; i < distinctRolls.Count(); i++)
            {
                int currentRoll = distinctRolls[i];
                int count = 0;

                foreach(int score in diceRolls)
                {
                    if (currentRoll == score)
                    {
                        count++;
                    }
                }

                yahtzeedScores.Add(currentRoll * count);
            }

            return yahtzeedScores.Max();
        }
    }
}
