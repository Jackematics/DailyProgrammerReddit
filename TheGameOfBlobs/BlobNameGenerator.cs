using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameOfBlobs
{
    class BlobNameGenerator
    {
        internal string GenerateName()
        {
            Random rand = new Random();

            return firstNamesPartOne[rand.Next(0, 10)] + firstNamesPartTwo[rand.Next(0, 10)] + " " + surnamesPartOne[rand.Next(0, 10)] + surnamesPartTwo[rand.Next(0, 10)];
        }

        List<string> firstNamesPartOne = new List<string>()
        {
            "Wobb",
            "Pigg",
            "Munch",
            "Chomp",
            "Flubb",
            "Jigg",
            "Shuf",
            "Jel",
            "Pea",
            "Puff",
            "Glug"
        };

        List<string> firstNamesPartTwo = new List<string>()
        {
            "le",
            "let",
            "ing",
            "ers",
            "ly",
            "ler",
            "bean",
            "nut",
            "ler",
            "ton",
            "ger"
        };

        List<string> surnamesPartOne = new List<string>()
        {
            "Snot",
            "Mash",
            "Room",
            "Cheek",
            "Goo",
            "Gob",
            "Fold",
            "Nose",
            "Cheese",
            "Ooze",
            "Belly",            
        };

        List<string> surnamesPartTwo = new List<string>()
        {
            "flinger",
            "whacker",
            "rubber",
            "squelcher",
            "bumble",
            "gooch",
            "fondle",
            "nail",
            "paddle",
            "sniffer",
            "clearer"
        };
    }
}
