using System;
using System.Collections.Generic;

namespace DucciSequence
{
    class Program
    {
        static Ducci _Ducci = new Ducci();

        static void Main(string[] args)
        {
            var exampleCase = new List<int> { 0, 653, 1854, 4063 };
            var testCase1 = new List<int> { 1, 5, 7, 9, 9 };
            var testCase2 = new List<int> { 1, 2, 1, 2, 1, 0 };
            var testCase3 = new List<int> { 10, 12, 41, 62, 31, 50 };
            var testCase4 = new List<int> { 10, 12, 41, 62, 31 };

            var noRepeatersCase = new List<int> { 2, 4126087, 4126085 };

            //PrintResult(exampleCase, "Example Case");
            //PrintResult(testCase1, "Test Case 1");
            //PrintResult(testCase2, "Test Case 2");
            //PrintResult(testCase3, "Test Case 3");
            //PrintResult(testCase4, "Test Case 4");
            PrintResult(noRepeatersCase, "No Repeaters Case");

            Console.ReadLine();
        }

        static void PrintResult(List<int> testCase, string test)
        {
            List<List<int>> testSequence = _Ducci.GetDucciSequence(testCase);

            Console.WriteLine(test + ":");
            Console.WriteLine("Number of steps = " + testSequence.Count);
            Console.WriteLine();

            for (int i = 0; i < testSequence.Count; i++)
            {                
                for (int j = 0; j < testSequence[i].Count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("[" + testSequence[i][j] + ";");
                    }
                    else if (j == testSequence[i].Count - 1)
                    {
                        Console.Write(" " + testSequence[i][j] + "]");
                    }
                    else
                    {
                        Console.Write(" " + testSequence[i][j] + ";");
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
