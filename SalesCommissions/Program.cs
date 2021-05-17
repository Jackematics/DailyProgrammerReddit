using System;

namespace SalesCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = new TestCases();
            var commission = new Commission();

            PrintResults(
                    commission.CalculateCommission(testCases._ExampleCaseRevenue, testCases._ExampleCaseExpenses), 
                    testCases._ExampleCaseColumnHeaders);

            PrintResults(
                    commission.CalculateCommission(testCases._TestCaseRevenue, testCases._TestCaseExpenses),
                    testCases._TestCaseColumnHeaders);

            Console.ReadLine();
        }

        static private void PrintResults(double[] commissions, string[] columnHeaders)
        {
            for (int i = 0; i < commissions.Length; i++)
            {
                Console.WriteLine(columnHeaders[i] + ": " + commissions[i]);
            }
            Console.WriteLine();
        }
    }
}
