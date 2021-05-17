using System;
using System.Collections.Generic;
using System.Text;

namespace SalesCommissions
{
    internal class TestCases
    {
        internal double[,] _ExampleCaseRevenue = new double[2, 2]
            {
                { 120, 145 },
                { 243, 265 }
            };

        internal double[,] _ExampleCaseExpenses = new double[2, 2]
        {
                { 130, 59 },
                { 143, 198 }
        };

        internal string[] _ExampleCaseRowHeaders = new string[2]
        {
            "Tea",
            "Coffee"
        };

        internal string[] _ExampleCaseColumnHeaders = new string[2]
        {
            "Frank",
            "Jane"
        };


        internal double[,] _TestCaseRevenue = new double[4, 5]
            {
                { 190, 140, 1926,   14, 143 },
                { 325,  19,  293, 1491, 162 },
                { 682,  14,  852,   56, 659 },
                { 829, 140,  609,  120,  87 }

            };

        internal double[,] _TestCaseExpenses = new double[4, 5]
        {
                { 120,  65,  890,  54, 430 },
                { 300,  10,   23, 802, 235 },
                {  50, 299, 1290,  12, 145 },
                {  67, 254,   89, 129,  76 }
        };

        internal string[] _TestCaseRowHeaders = new string[4]
        {
            "Tea",
            "Coffee",
            "Water",
            "Milk"
        };

        internal string[] _TestCaseColumnHeaders = new string[5]
        {
            "Johnver",
            "Vanston",
            "Danbree",
            "Vansey",
            "Mundyke"
        };
    }
}
