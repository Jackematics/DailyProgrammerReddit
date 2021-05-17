using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;



namespace WordFunnel2
{
    internal class Funnel
    {
        private List<string> WordList { get; }
        private List<Branch> Branches { get; set; } = new List<Branch>();

        private int _CurrentBranchNumber;

        internal Funnel()
        {
            WordList = GetWordList();
        }

        private void GetMultiStepWordFunnels(string word)
        {
            if (Branches.Count == 0)
            {
                CreateFirstBranch(word);
            }

            var nextFunnelLayer = GetNextFunnelLayer(word);

            if (nextFunnelLayer.Count == 0)
            {
                return;
            }

            for (int i = 0; i < nextFunnelLayer.Count; i++)
            {
                if (i == 0)
                {
                    AppendToCurrentBranch(nextFunnelLayer[i]);
                }
                else
                {
                    CreateNewBranch(i, word, nextFunnelLayer[i]);
                }
            }
        }

        internal string GetFunnelOfLength(int length)
        {
            List<string> largerWords = GetLargerWords(11);

            for (int i = 0; i < largerWords.Count; i++)
            {
                if (HasFunnelOfLength(length, largerWords[i]))
                {
                    return largerWords[i];
                }
            }
            throw new ArgumentException("There should exist a word funnel of length " + length);
        }

        private List<string> GetLargerWords(int length)
        {
            return WordList.Where(x => x.Length >= length).ToList();
        }

        private List<string> GetWordList()
        {
            var wordList = new List<string>();
            string line;

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/dolph/dictionary/master/enable1.txt");
            StreamReader reader = new StreamReader(stream);

            while ((line = reader.ReadLine()) != null)
            {
                wordList.Add(line);
            }

            return wordList;
        }

        internal bool HasFunnelOfLength(int length, string word)
        {
            GetWordFunnels(word);
            var funnelsOfLength = Branches.Where(x => x.WordFunnel.Count == length).ToList();

            if (funnelsOfLength.Count != 0)
            {

            }

            Branches.Clear();
            _CurrentBranchNumber = 0;

            return funnelsOfLength.Count != 0;
        }

        internal List<List<string>> GetLongestFunnels(string word)
        {
            GetWordFunnels(word);

            var maxFunnelLength = Branches.OrderByDescending(x => x.WordFunnel.Count).First().WordFunnel.Count;
            var longestBranches = Branches.Where(x => x.GetLength() == maxFunnelLength).ToList();

            var longestFunnels = new List<List<string>>();

            for (int i = 0; i < longestBranches.Count; i++)
            {
                longestFunnels.Add(longestBranches[i].WordFunnel);
            }

            Branches.Clear();
            _CurrentBranchNumber = 0;

            return longestFunnels;
        }

        private void GetWordFunnels(string word)
        {
            if (Branches.Count == 0)
            {
                CreateFirstBranch(word);
            }

            var nextFunnelLayer = GetNextFunnelLayer(word);

            if (nextFunnelLayer.Count == 0)
            {
                return;
            }

            for (int i = 0; i < nextFunnelLayer.Count; i++)
            {
                if (i == 0)
                {
                    AppendToCurrentBranch(nextFunnelLayer[i]);
                }
                else
                {
                    CreateNewBranch(i, word, nextFunnelLayer[i]);
                }
            }
        }

        private void CreateFirstBranch(string word)
        {
            var firstBranch = new Branch(0, new List<string>() { word });
            _CurrentBranchNumber = firstBranch.Number;

            Branches.Add(firstBranch);
        }

        private List<string> GetNextFunnelLayer(string word)
        {
            var nextFunnelLayer = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string funneledWord = word.Remove(i, 1);

                if (WordList.Contains(funneledWord))
                {
                    nextFunnelLayer.Add(funneledWord);
                }
            }

            return nextFunnelLayer;
        }

        private void AppendToCurrentBranch(string nextWord)
        {
            Branches[_CurrentBranchNumber].AddWord(nextWord);
            GetWordFunnels(nextWord);
        }

        private List<string> GetCurrentFunnel(string word)
        {
            List<string> currentFunnel = new List<string>(Branches[_CurrentBranchNumber].WordFunnel);

            int layerJumps = CalculateLayerJumps(Branches[_CurrentBranchNumber].WordFunnel, word);
            for (int j = 0; j < layerJumps; j++)
            {
                currentFunnel.RemoveAt(currentFunnel.Count - 1);
            }

            return currentFunnel;
        }

        private int CalculateLayerJumps(List<string> funnel, string word)
        {
            int count = 0;
            for (int i = funnel.Count - 1; i >= 0; i--)
            {
                if (funnel[i] != word)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private void CreateNewBranch(int branchNumber, string word, string nextWord)
        {
            List<string> currentFunnel = GetCurrentFunnel(word);

            var newBranch = new Branch(branchNumber, currentFunnel);
            _CurrentBranchNumber++;
            newBranch.AddWord(nextWord);
            Branches.Add(newBranch);
            GetWordFunnels(nextWord);
        }
    }
}
