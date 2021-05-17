using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace ProgressiveTaxation
{
    class Program
    {
        static DataTable TaxBrackets { get; set; }

        static void Main(string[] args)
        {
            //tax(0) => 0
            //tax(10000) => 0
            //tax(10009) => 0
            //tax(10010) => 1
            //tax(12000) => 200
            //tax(56789) => 8697
            //tax(1234567) => 473326

            Console.WriteLine("tax(0) => " + CalculateTax(0));
            Console.WriteLine("tax(10000) => " + CalculateTax(10000));
            Console.WriteLine("tax(10009) => " + CalculateTax(10009));
            Console.WriteLine("tax(10010) => " + CalculateTax(10010));
            Console.WriteLine("tax(12000) => " + CalculateTax(12000));
            Console.WriteLine("tax(56789) => " + CalculateTax(56789));
            Console.WriteLine("tax(1234567) => " + CalculateTax(1234567));

            Console.ReadLine();
        }

        static double CalculateTax(int income)
        {
            SetTaxBrackets();

            double firstBracketTax;
            double secondBracketTax;
            double thirdbracketTax;

            if (zerothBracket(income))
            {
                return 0;
            }
            else if (firstBracket(income))
            {
                firstBracketTax = Math.Floor((income - 10000) * 0.1);
                return firstBracketTax;
            }
            else if (secondBracket(income))
            {
                firstBracketTax = Math.Floor(20000 * 0.1);
                secondBracketTax = Math.Floor((income - 30000) * 0.25);

                return firstBracketTax + secondBracketTax;
            }
            else
            {
                firstBracketTax = Math.Floor(20000 * 0.1);
                secondBracketTax = Math.Floor(70000 * 0.25);
                thirdbracketTax = Math.Floor((income - 100000) * 0.4);

                return firstBracketTax + secondBracketTax + thirdbracketTax;
            }
        }

        static void SetTaxBrackets()
        {
            using (var reader = new StreamReader("C:\\Users\\jackr\\Documents\\Coding\\Projects\\DailyProgrammerReddit\\ProgressiveTaxation\\TaxBrackets.csv"))
            {
                var taxBrackets = new DataTable();

                var bracket = new DataColumn();
                bracket.ColumnName = "Bracket";
                bracket.Unique = true;

                var incomeCap = new DataColumn();
                incomeCap.ColumnName = "IncomeCap";
                incomeCap.DataType = Type.GetType("System.String");

                var marginalTaxRate = new DataColumn();
                marginalTaxRate.ColumnName = "MarginalTaxRate";
                marginalTaxRate.DataType = Type.GetType("System.String");

                taxBrackets.Columns.Add(bracket);
                taxBrackets.Columns.Add(incomeCap);
                taxBrackets.Columns.Add(marginalTaxRate);

                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = taxBrackets.Columns["Bracket"];
                taxBrackets.PrimaryKey = PrimaryKeyColumns;

                var dataSet = new DataSet();
                dataSet.Tables.Add(taxBrackets);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var row = taxBrackets.NewRow();
                    row["Bracket"] = values[0];
                    row["IncomeCap"] = values[1];
                    row["MarginalTaxRate"] = values[2];
                }

                TaxBrackets = taxBrackets;
                reader.Close();
            }
        }

        static bool zerothBracket(int income)
        {
            return income < 10000;
        }

        static bool firstBracket(int income)
        {
            return income >= 10000 && income < 30000;
        }

        static bool secondBracket(int income)
        {
            return income >= 30000 && income < 100000;
        }
    }
}
