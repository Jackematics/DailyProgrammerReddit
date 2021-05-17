using System;
using System.Collections.Generic;
using System.Text;

namespace ElsieFour
{
    class ElsieFour
    {
        internal string Key { get; }

        internal char[,] SubstitutionBox { get; private set; }

        private int[] MarkerIndex { get; set; } = new int[2] { 0, 0 };

        internal ElsieFour(string key)
        {
            SubstitutionBox = CreateSubstitutionBox(key);
            Key = key;
        }        

        private enum CryptType
        {
            Encrypt,
            Decrypt
        }

        internal string Crypt(string cipher)
        {            
            CryptType cryptType = SetCryptType(cipher);

            var cryptedCipher = new StringBuilder();

            if (cryptType == CryptType.Encrypt)
            {
                cipher = cipher.Substring(1);
            }            

            for (int i = 0; i < cipher.Length; i++)
            {
                char cryptedCharacter = CryptCharacter(cipher[i], cryptType);

                SubstitutionBox = cryptType == CryptType.Encrypt ? 
                        PermuteSubstitutionBox(cipher[i], cryptedCharacter) : 
                        PermuteSubstitutionBox(cryptedCharacter, cipher[i]);

                if (cryptType == CryptType.Encrypt)
                {
                    MoveMarker(cryptedCharacter);
                }
                else
                {
                    MoveMarker(cipher[i]);
                }                

                cryptedCipher.Append(cryptedCharacter);
            }                   

            ResetSubstitutionBox();
            ResetMarkedTile();

            return cryptedCipher.ToString();
        }

        private void ResetSubstitutionBox()
        {
            SubstitutionBox = CreateSubstitutionBox(Key);
        }

        private void ResetMarkedTile()
        {
            MarkerIndex = new int[2] { 0, 0 };
        }

        private CryptType SetCryptType(string cipher)
        {
            CryptType cryptType;
            if (cipher[0] == '%')
            {
                cryptType = CryptType.Encrypt;
            }
            else
            {
                cryptType = CryptType.Decrypt;
            }

            return cryptType;
        }

        private char CryptCharacter(char cipherCharacter, CryptType cryptType)
        {
            char[,] substitutionBox = SubstitutionBox;
            int[] cipherCharacterIndex = GetGridIndex(substitutionBox, cipherCharacter);
            Tile markedTile = new Tile(substitutionBox[MarkerIndex[0], MarkerIndex[1]]);

            int[] cryptedCipherCharacterIndex = new int[2];

            switch (cryptType)
            {
                case CryptType.Encrypt:
                    cryptedCipherCharacterIndex[0] = (cipherCharacterIndex[0] + markedTile.X) % 6;
                    cryptedCipherCharacterIndex[1] = (cipherCharacterIndex[1] + markedTile.Y) % 6;
                    break;

                case CryptType.Decrypt:
                    cryptedCipherCharacterIndex[0] = (cipherCharacterIndex[0] - markedTile.X + 6) % 6;
                    cryptedCipherCharacterIndex[1] = (cipherCharacterIndex[1] - markedTile.Y + 6) % 6;
                    break;
            }

            char cryptedCipherCharacter = substitutionBox[cryptedCipherCharacterIndex[0], cryptedCipherCharacterIndex[1]];

            return cryptedCipherCharacter;
        }

        private char[,] PermuteSubstitutionBox(
        char cipherCharacter,
        char encryptedCipherCharacter)
        {
            char[,] substitutionBox = SubstitutionBox;

            substitutionBox = RotateSubBoxTuple(substitutionBox, cipherCharacter, Tuple.Row);
            substitutionBox = RotateSubBoxTuple(substitutionBox, encryptedCipherCharacter, Tuple.Column);

            return substitutionBox;
        }

        private void MoveMarker(char cryptedCipherCharacter)
        {
            var cryptedCipherCharacterTile = new Tile(cryptedCipherCharacter);

            MarkerIndex[0] = (MarkerIndex[0] + cryptedCipherCharacterTile.X) % 6;
            MarkerIndex[1] = (MarkerIndex[1] + cryptedCipherCharacterTile.Y) % 6;
        }

        private enum Tuple
        {
            Row,
            Column
        }

        /// <summary>
        /// Rotate a row or column of the sub box after encryption
        /// </summary>
        /// <param name="tuple">Specifies whether we are rotating a row or column
        /// <param name="operatingCharacter">The character causing this tuple to be rotated</param>
        private char[,] RotateSubBoxTuple(
                char[,] substitutionBox, 
                char operatingCharacter, 
                Tuple tuple)
        {
            int[] operatingCharacterCoordinate = GetGridIndex(substitutionBox, operatingCharacter);

            char tempPrevious = tuple == Tuple.Row ? 
                    substitutionBox[substitutionBox.GetLength(0) - 1, operatingCharacterCoordinate[1]] : 
                    substitutionBox[operatingCharacterCoordinate[0], substitutionBox.GetLength(1) - 1];
            char tempCurrent;
            for (int i = 0; i < substitutionBox.GetLength(0); i++)
            {
                tempCurrent = tuple == Tuple.Row ? 
                        substitutionBox[i, operatingCharacterCoordinate[1]] :
                        substitutionBox[operatingCharacterCoordinate[0], i];

                if (tuple == Tuple.Row)
                {
                    substitutionBox[i, operatingCharacterCoordinate[1]] = tempPrevious;
                }
                else
                {
                    substitutionBox[operatingCharacterCoordinate[0], i] = tempPrevious;
                }                    

                tempPrevious = tempCurrent;
            }
            UpdateMarkerPosition(operatingCharacterCoordinate, tuple);

            return substitutionBox;
        }

        /// <summary>
        /// When the rows or columns of the substitution box are rotated during encryption, if the marker is on a rotated row or column then 
        /// update the marker's position to the new rotated position (because the marker stays on the rotated tile)
        /// </summary>
        private void UpdateMarkerPosition(int[] operatingCharacterCoordinate, Tuple tuple)
        {
            switch (tuple)
            {
                case Tuple.Row:
                    if (operatingCharacterCoordinate[1] == MarkerIndex[1])
                    {
                        MarkerIndex[0] = (MarkerIndex[0] + 1) % 6;
                    }
                    break;

                case Tuple.Column:
                    if (operatingCharacterCoordinate[0] == MarkerIndex[0])
                    {
                        MarkerIndex[1] = (MarkerIndex[1] + 1) % 6;
                    }
                    break;
            }
        }

        private char[,] CreateSubstitutionBox(string key)
        {
            char[,] substitutionBox = new char[6, 6];

            for (int y = 0; y < substitutionBox.GetLength(1); y++)
            {
                for (int x = 0; x < substitutionBox.GetLength(0); x++)
                {
                    substitutionBox[x, y] = key[x + y * 6];
                }
            }

            return substitutionBox;
        }

        private int[] GetGridIndex(char[,] grid, char character)
        {
            var gridIndex = new int[2];
            bool characterFound = false;

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y] == character)
                    {
                        gridIndex[0] = x;
                        gridIndex[1] = y;

                        characterFound = true;
                        break;
                    }
                }
                if (characterFound)
                {
                    break;
                }
            }

            if (characterFound == false)
            {
                throw new ArgumentException("Grid must contain the specified character");
            }

            return gridIndex;
        }
    } 
}
