using System;
using System.Collections.Generic;
using System.Text;

namespace SmooshedMorseCode1
{
    class Program
    {
        static char[] _Alphabet =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };


        static string[] _MorseAlphabet =
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", 
            "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };

        static void Main(string[] args)
        {
            //smorse("sos") => "...---..."
            //smorse("daily") => "-...-...-..-.--"
            //smorse("programmer") => ".--..-.-----..-..-----..-."
            //smorse("bits") => "-.....-..."
            //smorse("three") => "-.....-..."

            Console.WriteLine("smorse(\"sos\") => " + Smorse("sos"));
            Console.WriteLine("smorse(\"daily\") => " + Smorse("daily"));
            Console.WriteLine("smorse(\"programmer\") => " + Smorse("programmer"));
            Console.WriteLine("smorse(\"bits\") => " + Smorse("bits"));
            Console.WriteLine("smorse(\"three\") => " + Smorse("three"));

            Console.ReadLine();
        }

        static string Smorse(string cipherText)
        {
            char[] cipherTextAsArray = cipherText.ToUpper().ToCharArray();
            var encryption = new StringBuilder();

            foreach(char letter in cipherTextAsArray)
            {
                int positionInAlphabet = Array.IndexOf(_Alphabet, letter);
                string letterInMorse = _MorseAlphabet[positionInAlphabet];

                encryption.Append(letterInMorse);
            }

            return encryption.ToString();
        }
    }
}
