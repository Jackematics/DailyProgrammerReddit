using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RouteTranspositionCipher
{
    internal class RouteCipher
    {
        internal enum Rotation
        {
            Clockwise,
            Anticlockwise
        }

        internal string Encrypt(                
                string cipherText,
                int columns,
                int rows,
                Rotation rotation)
        {
            char[,] grid = Gridify(cipherText, columns, rows);
            return SpiralEncrypt(grid, rotation);
        }

        internal char[,] Gridify(string cipherText, int columns, int rows)
        {
            string standardisedCipher = Standardise(cipherText);

            char[,] grid = new char[rows, columns];
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (count < standardisedCipher.Length)
                    {
                        grid[i, j] = standardisedCipher[count];
                        count++;
                    }
                    else
                    {
                        grid[i, j] = 'X';
                    }
                }
            }

            return grid;
        }

        private string Standardise(string input)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            return regex.Replace(input, "").ToUpper();
        }

        private enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        private string SpiralEncrypt(char[,] grid, Rotation rotation)
        {
            var encryptedText = new StringBuilder();
            Direction spiralDirection = Direction.Down;

            if (rotation == Rotation.Anticlockwise)
            {
                spiralDirection = Direction.Left;
            }

            int currentMinColumn = 0;
            int currentMaxColumn = grid.GetLength(1) - 1;

            int currentMinRow = 0;
            int currentMaxRow = grid.GetLength(0) - 1;

            while (encryptedText.Length < grid.Length)
            {
                switch (spiralDirection)
                {
                    case Direction.Down:
                        for (int i = currentMinRow; i <= currentMaxRow; i++)
                        {
                            int setColumn = rotation == Rotation.Clockwise ? currentMaxColumn : currentMinColumn;
                            encryptedText.Append(grid[i, setColumn]);
                        }

                        if (rotation == Rotation.Clockwise)
                        {
                            currentMaxColumn--;
                        }
                        else
                        {
                            currentMinColumn++;
                        }                        

                        spiralDirection = UpdateSpiralDirection(rotation, spiralDirection);
                        break;

                    case Direction.Left:
                        for (int j = currentMaxColumn; j >= currentMinColumn; j--)
                        {
                            int setRow = rotation == Rotation.Clockwise ? currentMaxRow : currentMinRow;
                            encryptedText.Append(grid[setRow, j]);
                        }

                        if (rotation == Rotation.Clockwise)
                        {
                            currentMaxRow--;
                        }
                        else
                        {
                            currentMinRow++;
                        }

                        spiralDirection = UpdateSpiralDirection(rotation, spiralDirection);
                        break;

                    case Direction.Up:
                        for (int i = currentMaxRow; i >= currentMinRow; i--)
                        {
                            int setColumn = rotation == Rotation.Clockwise ? currentMinColumn : currentMaxColumn;
                            encryptedText.Append(grid[i, setColumn]);
                        }

                        if (rotation == Rotation.Clockwise)
                        {
                            currentMinColumn++;
                        }
                        else
                        {
                            currentMaxColumn--;
                        }     

                        spiralDirection = UpdateSpiralDirection(rotation, spiralDirection);
                        break;

                    case Direction.Right:
                        for (int j = currentMinColumn; j <= currentMaxColumn; j++)
                        {
                            int setRow = rotation == Rotation.Clockwise ? currentMinRow : currentMaxRow;
                            encryptedText.Append(grid[setRow, j]);
                        }

                        if (rotation == Rotation.Clockwise)
                        {
                            currentMinRow++;
                        }
                        else
                        {
                            currentMaxRow--;
                        }

                        spiralDirection = UpdateSpiralDirection(rotation, spiralDirection);
                        break;
                }
            }

            return encryptedText.ToString();
        }

        private Direction UpdateSpiralDirection(Rotation rotation, Direction spiralDirection)
        {
            switch(rotation)
            {
                case Rotation.Clockwise:
                    if (spiralDirection == (Direction)3)
                    {
                        spiralDirection = 0;
                    }
                    else
                    {
                        spiralDirection++;
                    }
                    break;

                case Rotation.Anticlockwise:
                    if (spiralDirection == 0)
                    {
                        spiralDirection = (Direction)3;
                    }
                    else
                    {
                        spiralDirection--;
                    }
                    break;
            }

            return spiralDirection;                 
        }
    }
}
