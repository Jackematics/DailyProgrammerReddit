using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameOfBlobs
{
    class TestCases
    {
        internal int[,] TestExample1 = new int[2, 3]
        {
            { 0, 2, 1 },
            { 2, 1, 2 }
        };

        internal int[,] TestExample2 = new int[2, 3]
        {
            { 2, 0, 1 },
            { 1, 2, 2 }
        };

        internal int[,] TestBlobs1 = new int[2, 3]
        {
            { 0, 1, 2 },
            { 10, 0, 2 }
        };

        internal int[,] TestBlobs2 = new int[4, 3]
        {
            { 4, 3, 4 },
            { 4, 6, 2 },
            { 8, 3, 2 },
            { 2, 1, 3 }
        };

        internal int[,] TestBlobs3 = new int[8, 3]
        {
            { -57, -16, 10 },
            { -171, -158, -13 },
            { -84, 245, 15 },
            { -128, -61, 16 },
            { 65, 196, 4 },
            { -221, 121, 8 },
            { 145, 157, 3 },
            { -27, -75, 5 }
        };

        internal int[,] FlatlandBonus = new int[2, 3]
        {
            { 1, 0, 2 },
            { 4, 0, 2 }
        };
    }
}
