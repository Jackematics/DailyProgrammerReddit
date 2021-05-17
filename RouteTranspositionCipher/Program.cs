using System;

namespace RouteTranspositionCipher
{
    class Program
    {
        static RouteCipher _RouteCipher = new RouteCipher();

        static void Main(string[] args)
        {
            PrintResults("WE ARE DISCOVERED. FLEE AT ONCE", 9, 3, RouteCipher.Rotation.Clockwise);
            PrintResults("why is this professor so boring omg", 6, 5, RouteCipher.Rotation.Anticlockwise);
            PrintResults("Solving challenges on r/dailyprogrammer is so much fun!!", 8, 6, RouteCipher.Rotation.Anticlockwise);
            PrintResults("For lunch let's have peanut-butter and bologna sandwiches", 4, 12, RouteCipher.Rotation.Clockwise);
            PrintResults("I've even witnessed a grown man satisfy a camel", 9, 5, RouteCipher.Rotation.Clockwise);
            PrintResults("Why does it say paper jam when there is no paper jam?", 3, 14, RouteCipher.Rotation.Anticlockwise);

            Console.ReadLine();
        }

        static private void PrintResults(
                string testInput, 
                int columns, 
                int rows, 
                RouteCipher.Rotation rotation)
        {
            Console.WriteLine("Test input: " + testInput);
            Console.WriteLine();
            Console.WriteLine("Gridified input: ");
            Console.WriteLine();

            char[,] grid = _RouteCipher.Gridify(testInput, columns, rows);
            
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Encrypted Text: ");
            Console.WriteLine();
            Console.WriteLine
            (
                    _RouteCipher.Encrypt(
                        testInput,
                        columns,
                        rows,
                        rotation)
            );
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
