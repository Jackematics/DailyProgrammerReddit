using System;
using System.Collections.Generic;
using System.Text;

namespace ElsieFour
{
    internal class TestCase
    {
        internal string Key { get; }
        internal string CipherText { get; }

        internal TestCase(string key, string cipherText)
        {
            Key = key;
            CipherText = cipherText;
        }
    }
}
