using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NecklaceMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string testMatchNecklaceOne = "nicole";
            string testMatchNecklaceTwo = "icolen";
            string testMatchNecklaceThree = "lenico";
            string testMatchNecklaceFour = "coneli";

            string testMatchNecklaceFive = "aabaaaaabaab";
            string testMatchNecklaceSix = "aabaabaabaaa";

            string testMatchNecklaceSeven = "abc";
            string testMatchNecklaceEight = "cba";

            string testMatchNecklaceNine = "xxyyy";
            string testMatchNecklaceTen = "xxyxz";
            string testMatchNecklaceEleven = "xyxxz";
            string testMatchNecklaceTwelve = "xxyxz";

            string testMatchNecklaceThirteen = "x";
            string testMatchNecklaceFourteen = "xx";
            string testMatchNecklaceFifteen = "";

            Console.WriteLine("same_necklace(nicole, icolen) => " + MatchNecklaces(testMatchNecklaceOne, testMatchNecklaceTwo));
            Console.WriteLine("same_necklace(nicole, lenico) => " + MatchNecklaces(testMatchNecklaceOne, testMatchNecklaceThree));
            Console.WriteLine("same_necklace(nicole, coneli) => " + MatchNecklaces(testMatchNecklaceOne, testMatchNecklaceFour));

            Console.WriteLine("same_necklace(aabaaaaabaab, aabaabaabaaa) => " + MatchNecklaces(testMatchNecklaceFive, testMatchNecklaceSix));
            Console.WriteLine("same_necklace(abc, cba) => " + MatchNecklaces(testMatchNecklaceSeven, testMatchNecklaceEight));
            Console.WriteLine("same_necklace(xxyyy, xxyxz) => " + MatchNecklaces(testMatchNecklaceNine, testMatchNecklaceTen));
            Console.WriteLine("same_necklace(xyxxz, xxyxz) => " + MatchNecklaces(testMatchNecklaceEleven, testMatchNecklaceTwelve));
            Console.WriteLine("same_necklace(x, x) => " + MatchNecklaces(testMatchNecklaceThirteen, testMatchNecklaceThirteen));
            Console.WriteLine("same_necklace(x, xx) => " + MatchNecklaces(testMatchNecklaceThirteen, testMatchNecklaceFourteen));
            Console.WriteLine("same_necklace(x, \"\") => " + MatchNecklaces(testMatchNecklaceThirteen, testMatchNecklaceFifteen));
            Console.WriteLine("same_necklace(\"\", \"\") => " + MatchNecklaces(testMatchNecklaceFifteen, testMatchNecklaceFifteen));

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("repeats(\"abc\") => " + CountRepeats("abc"));
            Console.WriteLine("repeats(\"abcabcabc\") => " + CountRepeats("abcabcabc"));
            Console.WriteLine("repeats(\"abcabcabcx\") => " + CountRepeats("abcabcabcx"));
            Console.WriteLine("repeats(\"aaaaaa\") => " + CountRepeats("aaaaaa"));
            Console.WriteLine("repeats(\"a\") => " + CountRepeats("a"));
            Console.WriteLine("repeats(\"\") => " + CountRepeats(""));

            var fourMatchingNecklaces = FindFourMatchingNecklaces(4);

            foreach(string necklace in fourMatchingNecklaces)
            {
                Console.WriteLine(necklace);
            }

            Console.ReadLine();
        }

        static List<string> FindFourMatchingNecklaces(int necklaceLength)
        {
            var necklaces = new List<string>();
            string line;

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/dolph/dictionary/master/enable1.txt");
            StreamReader reader = new StreamReader(stream);

            while((line = reader.ReadLine()) != null)
            {
                if (line.Length == necklaceLength)
                {
                    necklaces.Add(line);
                }
            }

            stream.Close();

            var fourMatchingWords = new List<string>();
            int count = 0;
            int executions = 0;

            for(int i = 0; i < necklaces.Count; i++)
            {
                fourMatchingWords.Add(necklaces[i]);

                for(int j = 0; j < necklaces.Count; j++)
                {                    
                    if (MatchNecklaces(necklaces[i], necklaces[j]) && necklaces[i] != necklaces[j])
                    {
                        fourMatchingWords.Add(necklaces[j]);
                        count++;
                    }
                    executions++;
                }

                if (count == 4)
                {
                    return fourMatchingWords;
                }
                else
                {
                    fourMatchingWords.Clear();
                    count = 0;
                }
            }

            return null;
        }

        static private bool MatchNecklaces(string necklaceOne, string necklaceTwo)
        {
            if (necklaceOne == necklaceTwo)
            {
                return true;
            }

            string currentNecklace = necklaceOne;
            for (int i = 0; i < necklaceOne.Length - 1; i++)
            {      
                currentNecklace = CycleNecklace(currentNecklace);

                if (necklaceTwo == currentNecklace)
                {
                    return true;
                }
            }

            return false;
        }

        static int CountRepeats(string necklace)
        {
            int count = 1;
            string currentNecklace = necklace;
            for (int i = 0; i < necklace.Length - 1; i++)
            {
                currentNecklace = CycleNecklace(currentNecklace);

                if (currentNecklace == necklace)
                {
                    count++;
                }
            }

            return count;
        }

        static string CycleNecklace(string currentNecklace)
        {
            char charToAppend = currentNecklace[0];
            string nextNecklace = currentNecklace.Remove(0, 1);
            nextNecklace = nextNecklace.Insert(nextNecklace.Length, charToAppend.ToString());

            return nextNecklace;
        }
    }
}
