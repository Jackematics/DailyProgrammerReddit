using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmooshedMorseCode2
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

        static Dictionary<char, string> MorseCodePairs { get; set; } = new Dictionary<char, string>();

        static void Main(string[] args)
        {
            for (int i = 0; i < _Alphabet.Length; i++)
            {
                MorseCodePairs.Add(_Alphabet[i], _MorseAlphabet[i]);
            }

            Console.WriteLine("smalpha(\".--...-.-.-.....-.--........----.-.-..---.---.--.--.-.-....-..-...-.---..--.----..\") => " + 
                    Smalpha(".--...-.-.-.....-.--........----.-.-..---.---.--.--.-.-....-..-...-.---..--.----..", 4));
            Console.WriteLine("smalpha(\".----...---.-....--.-........-----....--.-..-.-..--.--...--..-.---.--..-.-...--..-\") => " + 
                    Smalpha(".----...---.-....--.-........-----....--.-..-.-..--.--...--..-.---.--..-.-...--..-", 4));
            Console.WriteLine("smalpha(\"..-...-..-....--.---.---.---..-..--....-.....-..-.--.-.-.--.-..--.--..--.----..-..\") => " + 
                    Smalpha("..-...-..-....--.---.---.---..-..--....-.....-..-.--.-.-.--.-..--.--..--.----..-..", 4));

            Console.ReadLine();
        }

        static string Smalpha(string cipher, int longestMorseLetter)
        {
            string currentLetter;
            var decodedText = new StringBuilder();

            while (cipher.Length > 0)
            {
                for (int i = 0; i < longestMorseLetter; i++)
                {
                    currentLetter = cipher.Length >= longestMorseLetter ? 
                            cipher.Substring(0, longestMorseLetter - i) : 
                            cipher.Substring(0);

                    if (_MorseAlphabet.Contains(currentLetter))
                    {
                        decodedText.Append(MorseCodePairs.FirstOrDefault(x => x.Value == currentLetter).Key);
                        cipher = cipher.Substring(currentLetter.Length);
                    }
                }
            }

            return decodedText.ToString();
        }
    }
}
