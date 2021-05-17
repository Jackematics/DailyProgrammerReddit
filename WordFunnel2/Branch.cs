using System;
using System.Collections.Generic;
using System.Text;

namespace WordFunnel2
{
    class Branch
    {
        internal int Number { get; private set; }
        internal List<string> WordFunnel { get; private set; }

        internal Branch(int number, List<string> startingWords)
        {
            Number = number;
            WordFunnel = startingWords;            
        }

        internal void AddWord(string word)
        {
            WordFunnel.Add(word);
        }

        internal int GetLength()
        {
            return WordFunnel.Count;
        }
    }
}
