using System;
using System.Collections.Generic;

namespace KolakoskiSequences
{
    class Program
    {
        static KolakoskiSequence _KolakoskiSequence = new KolakoskiSequence();

        static void Main(string[] args)
        {
            int testCase1 = 10;
            int testCase2 = 100;
            int testCase3 = 1000;
            int challenge1 = 1000000;
            int challenge2 = 100000000;

            PrintTestCase(testCase1);
            PrintTestCase(testCase2);
            PrintTestCase(testCase3);

            Console.WriteLine("Length 1,000,000: ");
            PrintRatio(challenge1);
            Console.WriteLine();

            Console.WriteLine("Length 100,000,000: ");
            PrintRatio(challenge2);
            Console.WriteLine();

            Console.ReadLine();
        }

        static private void PrintTestCase(int n)
        {
            PrintSequence(n);
            PrintRatio(n);
            Console.WriteLine();
        }

        static private void PrintSequence(int n)
        {
            Console.WriteLine("Length: " + n);

            List<int> sequence = _KolakoskiSequence.GenerateSequence(n);

            Console.Write(sequence[0]);
            for (int i = 1; i < sequence.Count; i++)
            {
                Console.Write(", " + sequence[i]);
            }
            Console.WriteLine();
        }

        static private void PrintRatio(int n)
        {
            int[] ratio = _KolakoskiSequence.GetOnesAndTwosRatio(n);

            Console.WriteLine("Ratio: " + ratio[0] + ":" + ratio[1]);
        }
    }
}
