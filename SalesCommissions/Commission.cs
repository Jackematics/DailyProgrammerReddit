using System;
using System.Collections.Generic;
using System.Text;

namespace SalesCommissions
{
    internal class Commission
    {
        internal double[] CalculateCommission(
                double[,] revenue, 
                double[,] expenses)
        {
            double[] commission = new double[revenue.GetLength(1)];

            for (int column = 0; column < revenue.GetLength(1); column++)
            {
                double columnCommission = 0;

                for (int row = 0; row < revenue.GetLength(0); row++)
                {
                    double profit = revenue[row, column] - expenses[row, column];

                    if (profit >= 0)
                    {
                        columnCommission += Math.Round(profit * (0.062), 2);
                    }
                }

                commission[column] = Math.Round(columnCommission, 2);
            }

            return commission;
        }
    }
}
