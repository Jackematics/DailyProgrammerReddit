using System;
using System.Collections.Generic;

namespace NecklaceCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CountNecklaces(2, 12) = " + CountNecklaces(2, 12));
            Console.WriteLine("CountNecklaces(3, 7) = " + CountNecklaces(3, 7));
            Console.WriteLine("CountNecklaces(9, 4) = " + CountNecklaces(9, 4));
            Console.WriteLine("CountNecklaces(21, 3) = " + CountNecklaces(21, 3));
            Console.WriteLine("CountNecklaces(99, 2) = " + CountNecklaces(99, 2));

            Console.ReadLine();
        }

        static private double CountNecklaces(int linkVariations, int necklaceSize)
        {
            List<int[]> factorPairs = GetFactorPairs(necklaceSize);

            double sum = 0;
            foreach (int[] factorPair in factorPairs)
            {
                sum += Phi(factorPair[0]) * Math.Pow(linkVariations, factorPair[1]);
            }

            return sum / necklaceSize;
        }

        static private List<int[]> GetFactorPairs(int n)
        {
            List<int[]> factorPairs = new List<int[]>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    int[] factorPair = new int[2];
                    factorPair[0] = i;
                    factorPair[1] = n / i;

                    factorPairs.Add(factorPair);
                }
            }

            return factorPairs;
        }

        static private double Phi(double n)
        {
            if (n < 1 || n != (int)n)
            {
                throw new ArgumentException("n must be a positive integer");
            }

            List<double> primeDividers = GetPrimeDivisors(n);

            double product = 1;
            foreach (double prime in primeDividers)
            {
                product *= (prime - 1) / prime;
            }

            return n*product;
        }

        static private List<double> GetPrimeDivisors(double n)
        {
            if (n < 1 || n != (int)n)
            {
                throw new ArgumentException("n must be a positive integer");
            }

            List<double> primeDivisors = new List<double>();

            if (n == 1)
            {
                return primeDivisors;
            }            

            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i) && n % i == 0)
                {
                    primeDivisors.Add(i);
                }
            }

            return primeDivisors;
        }

        static private bool IsPrime(int integer)
        {
            if (integer < 1)
            {
                throw new ArgumentException("Must be a positive integer");
            }

            if (integer == 1)
            {
                return false;
            }

            for (int i = 2; i < integer; i++)
            {
                if (integer % i == 0)
                {
                    return false;
                }
            }

            return true;
        }        
    }
}
