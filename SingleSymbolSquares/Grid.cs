using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SingleSymbolSquares
{
    class Grid
    {
        internal int Dimension { get; }
        internal char[,] GridElements { get; set; } = new char[9, 9];
        private bool NoughtsChanged { get; set; } = true;
        private bool CrossesChanged { get; set; } = true;

        internal Grid(int gridDimension)
        {
            Dimension = gridDimension;
            GridElements = GetDefaultGrid(gridDimension);
        }

        private char[,] GetDefaultGrid(int gridDimension)
        {
            var defaultGrid = new char[gridDimension, gridDimension];
            for (int i = 0; i < gridDimension; i++)
            {
                for (int j = 0; j < gridDimension; j++)
                {
                    defaultGrid[i, j] = 'X';
                }
            }

            return defaultGrid;
        }

        internal void PrintGridToConsole()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    Console.Write(GridElements[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        internal void SingleSymbolise()
        {
            var symbols = new char[2] { 'X', 'O' };
            int count = 0;

            while (CrossesChanged && NoughtsChanged)
            {
                NoughtsChanged = false;
                CrossesChanged = false;

                SwapSymbols(symbols, 0);
                SwapSymbols(symbols, 1);

                count++;

                if (count % 10 == 0)
                {
                    PrintGridToConsole();
                }
            }
        }

        private void SwapSymbols(char[] symbols, int positionToCheck)
        {
            var rand = new Random();

            for (int i = 2; i <= Dimension; i++)
            {
                List<List<int[]>> ListOfVerticesSets = GetInteriorSquareVertices(i);

                foreach (List<int[]> SetOfVertices in ListOfVerticesSets)
                {
                    int countSymbol = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        if (GridElements[SetOfVertices[j][0], SetOfVertices[j][1]] == symbols[positionToCheck])
                        {
                            countSymbol++;
                        }
                    }

                    if (countSymbol == 4)
                    {
                        int squareToChange = rand.Next(0, 3);

                        GridElements[SetOfVertices[squareToChange][0], SetOfVertices[squareToChange][1]] = symbols[1 - positionToCheck];

                        if (symbols[positionToCheck] == 'X')
                        {
                            CrossesChanged = true;
                        }
                        else
                        {
                            NoughtsChanged = true;
                        }
                    }

                    countSymbol = 0;
                }
            }
        }

        private List<List<int[]>> GetInteriorSquareVertices(int squareDimension)
        {
            var squaresVerticesCoordinates = new List<List<int[]>>();

            for (int i = 0; i < Dimension - squareDimension + 1; i++)
            {
                for (int j = 0; j < Dimension - squareDimension + 1; j++)
                {
                    var squareCoordinates = new List<int[]>();
                    squareCoordinates.Add(new int[2] { i, j });
                    squareCoordinates.Add(new int[2] { i + squareDimension - 1, j });
                    squareCoordinates.Add(new int[2] { i, j + squareDimension - 1 });
                    squareCoordinates.Add(new int[2] { i + squareDimension - 1, j + squareDimension - 1 });

                    squaresVerticesCoordinates.Add(squareCoordinates);
                }
            }

            return squaresVerticesCoordinates;
        }
    }
}
