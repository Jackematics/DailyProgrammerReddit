using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GoldbachWeakConjecture
{
    class PrimeEmitter
    {
        internal int[] EmitPrimesAddingTo(int n)
        {
            List<int> primes = GeneratePrimesLessThan(n);
            var result = new int[3];

            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = 0; j < primes.Count; j++)
                {
                    for (int k = 0; k < primes.Count; k++)
                    {
                        if (primes[i] + primes[j] + primes[k] == n)
                        {
                            result[0] = primes[i];
                            result[1] = primes[j];
                            result[2] = primes[k];

                            return result;
                        }
                    }
                }
            }

            throw new ArgumentException("Wow you have just disproven Goldbach's Weak Conjecture!");
        }

        private List<int> GeneratePrimesLessThan(int n)
        {
            List<int> primes = new List<int>();

            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private bool IsPrime(int integer)
        {
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
