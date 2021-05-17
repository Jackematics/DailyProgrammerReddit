using System;
using System.Collections.Generic;
using System.Text;

namespace WordFunnel2
{
    class Program
    {
        static Funnel _Funnel = new Funnel();

        static void Main(string[] args)
        {
            var testCases = new List<string>()
            {
                "gnash",
                "princesses",
                "turntables",
                "implosive",
                "programmer"
            };

            for (int i = 0; i < testCases.Count; i++)
            {
                PrintResults(testCases[i]);
            }

            string lengthTenFunnel = _Funnel.GetFunnelOfLength(10);
            PrintResults(lengthTenFunnel);

            Console.ReadLine();
        }

        static void PrintResults(string startingWord)
        {
            List<List<string>> longestFunnels = _Funnel.GetLongestFunnels(startingWord);

            Console.WriteLine("Starting Word: " + startingWord);
            Console.WriteLine("Funnel Length: " + longestFunnels[0].Count);

            for (int i = 0; i < longestFunnels.Count; i++)
            {               
                var sb = new StringBuilder();

                sb.Append(longestFunnels[i][0]);
                for (int j = 1; j < longestFunnels[i].Count; j++)
                {
                    sb.Append(" => " + longestFunnels[i][j]);
                }

                Console.WriteLine("Word Funnel " + i + ": " + sb.ToString());                
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
