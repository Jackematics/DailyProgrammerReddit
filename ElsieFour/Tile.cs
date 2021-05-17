using System;
using System.Collections.Generic;
using System.Text;

namespace ElsieFour
{
    internal class Tile
    {
        internal char Character { get; }
        internal int X { get; }
        internal int Y { get; }

        internal Tile(char character)
        {
            string alphabet = ElsieFourAlphabet.Alphabet;

            if (!alphabet.Contains(character))
            {
                throw new ArgumentException("character must be in Elsie-Four alphabet");
            }

            Character = character;

            int alphabetPosition = alphabet.IndexOf(character);

            X = alphabetPosition % 6;
            Y = alphabetPosition / 6;
        }
    }
}
