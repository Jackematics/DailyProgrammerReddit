using System;

namespace GoldbachWeakConjecture
{
    class Program
    {
        static private PrimeEmitter _PrimeEmitter = new PrimeEmitter();

        static void Main(string[] args)
        {
            int example1 = 11;
            int example2 = 35;

            int challenge1 = 111;
            int challenge2 = 17;
            int challenge3 = 199;
            int challenge4 = 287;
            int challenge5 = 53;

            PrintResults(example1);
            PrintResults(example2);

            PrintResults(challenge1);
            PrintResults(challenge2);
            PrintResults(challenge3);
            PrintResults(challenge4);
            PrintResults(challenge5);
        }

        static private void PrintResults(int testInput)
        {
            int[] primesAddingToInput = _PrimeEmitter.EmitPrimesAddingTo(testInput);

            Console.WriteLine("Test: " + testInput);
            Console.WriteLine(primesAddingToInput[0] + " + " + primesAddingToInput[1] + " + " + primesAddingToInput[2] + " = " + testInput);
            Console.WriteLine();
        }
    }
}
