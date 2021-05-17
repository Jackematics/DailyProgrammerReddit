using System;
using System.Collections.Generic;

namespace SingleSymbolSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(32);

            grid.PrintGridToConsole();
            grid.SingleSymbolise();
            grid.PrintGridToConsole();
        }        
    }
}