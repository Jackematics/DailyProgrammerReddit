using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DucciSequence
{
    internal class Ducci
    {
        internal List<List<int>> GetDucciSequence(List<int> tuple)
        {
            var ducciSequence = new List<List<int>>();
            ducciSequence.Add(tuple);

            var currentTuple = GetNextTuple(tuple);

            while (
                !TupleIsZeroes(currentTuple) && 
                !SequenceRepeating(ducciSequence, currentTuple)
            )
            {
                ducciSequence.Add(currentTuple);
                currentTuple = GetNextTuple(currentTuple);

                if (ducciSequence.Count == 10000)
                {
                    Console.WriteLine("This sequence may continue forever without repeating, no more tuples will be printed");
                    break;
                }
            }
            
            if (TupleIsZeroes(currentTuple))
            {
                ducciSequence.Add(currentTuple);
            }

            return ducciSequence;
        }

        private List<int> GetNextTuple(List<int> currentTuple)
        {
            var nextTuple = new List<int>();

            for (int i = 0; i < currentTuple.Count; i++)
            {
                if (i == currentTuple.Count - 1)
                {
                    nextTuple.Add(Math.Abs(currentTuple[i] - currentTuple[0]));
                }
                else
                {
                    nextTuple.Add(Math.Abs(currentTuple[i + 1] - currentTuple[i]));
                }
            }

            return nextTuple;
        }

        private bool TupleIsZeroes(List<int> tuple)
        {
            List<int> zeroTuple = new List<int>(new int[tuple.Count]);

            return tuple.SequenceEqual(zeroTuple);
        }

        private bool SequenceRepeating(List<List<int>> ducciSequence, List<int> currentTuple)
        {
            foreach (List<int> tuple in ducciSequence)
            {                 
                if (currentTuple.SequenceEqual(tuple))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
