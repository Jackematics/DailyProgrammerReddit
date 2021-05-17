using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KolakoskiSequences
{
    internal class KolakoskiSequence
    {
        internal int[] GetOnesAndTwosRatio(int n)
        {
            List<int> kolakoskiSequence = GenerateSequence(n);

            int numberOfOnes = kolakoskiSequence.Where(x => x == 1).Count();
            int numberOfTwos = kolakoskiSequence.Count - numberOfOnes;

            return new int[2] { numberOfOnes, numberOfTwos };
        }

        internal List<int> GenerateSequence(int n)
        {            
            var mainSequence = new List<int>() { 1, 2 };
            var mainSequencePreAppend = new List<int>(mainSequence);
            var secondarySequence = new List<int>() { 1, 2, 2 };

            while (secondarySequence.Count <= n)
            {
                List<int> elementsToAppend = GetMostRecentElements(secondarySequence, mainSequence);
                mainSequence.AddRange(elementsToAppend);

                for (int i = 0; i < elementsToAppend.Count; i++)
                {
                    if (elementsToAppend[i] == 1 && secondarySequence[secondarySequence.Count - 1] == 1)
                    {
                        secondarySequence.Add(2);
                    }
                    else if (elementsToAppend[i] == 1 && secondarySequence[secondarySequence.Count - 1] == 2)
                    {
                        secondarySequence.Add(1);
                    }
                    else if (elementsToAppend[i] == 2 && secondarySequence[secondarySequence.Count - 1] == 1)
                    {
                        secondarySequence.AddRange(new List<int>() { 2, 2 });
                    }
                    else if (elementsToAppend[i] == 2 && secondarySequence[secondarySequence.Count - 1] == 2)
                    {
                        secondarySequence.AddRange(new List<int>() { 1, 1 });
                    }
                }

                mainSequencePreAppend.AddRange(GetMostRecentElements(mainSequence, mainSequencePreAppend));
            }            

            return secondarySequence.GetRange(0, n);
        }

        private List<int> GetMostRecentElements(List<int> listAfterAppend, List<int> listBeforeAppend)
        {
            int difference = listAfterAppend.Count - listBeforeAppend.Count;
            return listAfterAppend.GetRange(listAfterAppend.Count - difference, difference);
        }
    }
}
