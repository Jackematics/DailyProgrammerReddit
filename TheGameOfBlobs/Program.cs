using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TheGameOfBlobs
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = new TestCases();
            var blobPopulation = new BlobPopulation();

            PrintSolution(blobPopulation, testCases.TestExample1);
            PrintSolution(blobPopulation, testCases.TestExample2);
            PrintSolution(blobPopulation, testCases.TestBlobs1);
            PrintSolution(blobPopulation, testCases.TestBlobs2);
            PrintSolution(blobPopulation, testCases.TestBlobs3);
            PrintSolution(blobPopulation, testCases.FlatlandBonus);
        }        

        static void PrintSolution(BlobPopulation blobPopulation, int[,] testCase)
        {
            blobPopulation.PopulateBlobs(testCase);
            blobPopulation.SurvivalOfTheFattest();

            Console.WriteLine("Next Test Case: ");
            foreach (Blob blob in blobPopulation.Blobs)
            {                
                Console.WriteLine("Name = " + blob.Name);
                Console.WriteLine("Size = " + blob.Size);
                Console.WriteLine("Coordinates = (" + blob.Position.X + ", " + blob.Position.Y + ")");
                Console.WriteLine();
            }

            blobPopulation.ClearBlobs();
            Console.ReadLine();
        }
    }
}
