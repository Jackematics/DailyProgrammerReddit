using System;
using System.Reflection.Metadata;

namespace ElsieFour
{
    class Program
    {
        static string _Alphabet = ElsieFourAlphabet.Alphabet;

        static void Main(string[] args)
        {
            string alphabet = ElsieFourAlphabet.Alphabet;

            var exampleEncryptionCase = new TestCase("gp3lehwzf9jx5yo6r#nd8auks4qtv72cmib_", "%xyz");
            var exampleDecryptionCase = new TestCase("gp3lehwzf9jx5yo6r#nd8auks4qtv72cmib_", "auf");

            var elsieFourExample = new ElsieFour(exampleEncryptionCase.Key);
            PrintResults(elsieFourExample, exampleEncryptionCase.CipherText);
            PrintResults(elsieFourExample, exampleDecryptionCase.CipherText);

            var testCase1Encryption = new TestCase("s2ferw_nx346ty5odiupq#lmz8ajhgcvk79b", "%aaaaaaaaaaaaaaaaaaaa");
            var testCase1Decryption = new TestCase("s2ferw_nx346ty5odiupq#lmz8ajhgcvk79b", "tk5j23tq94_gw9c#lhzs");

            var elsieFourTestCase1 = new ElsieFour(testCase1Encryption.Key);
            PrintResults(elsieFourTestCase1, testCase1Encryption.CipherText);
            PrintResults(elsieFourTestCase1, testCase1Decryption.CipherText);

            var testCase2Encryption = new TestCase("#o2zqijbkcw8hudm94g5fnprxla7t6_yse3v", "%be_sure_to_drink_your_ovaltine");
            var testCase2Decryption = new TestCase("#o2zqijbkcw8hudm94g5fnprxla7t6_yse3v", "b66rfjmlpmfh9vtzu53nwf5e7ixjnp");

            var elsieFourTestCase2 = new ElsieFour(testCase2Encryption.Key);
            PrintResults(elsieFourTestCase2, testCase2Encryption.CipherText);
            PrintResults(elsieFourTestCase2, testCase2Decryption.CipherText);

            var challengeEncryption = new TestCase("9mlpg_to2yxuzh4387dsajknf56bi#ecwrqv", "%congratulations_youre_a_dailyprogrammer");
            var challengeDecryption = new TestCase("9mlpg_to2yxuzh4387dsajknf56bi#ecwrqv", "grrhkajlmd3c6xkw65m3dnwl65n9op6k_o59qeq");

            var elsieFourChallenge = new ElsieFour(challengeEncryption.Key);
            PrintResults(elsieFourChallenge, challengeEncryption.CipherText);
            PrintResults(elsieFourChallenge, challengeDecryption.CipherText);

            Console.ReadLine();
        }

        static private void PrintResults(ElsieFour elsieFourCase, string cipher)
        {
            string cryptMessage = SetCryptMessage(cipher);
            Console.WriteLine("Cipher: " + cipher);

            DisplaySubstitutionBox(elsieFourCase.SubstitutionBox);

            string cryptedCipher = elsieFourCase.Crypt(cipher);
            Console.WriteLine(cryptMessage + " Cipher: " + cryptedCipher);

            Console.WriteLine();
        }

        static private string SetCryptMessage(string cipher)
        {
            string cryptMessage;
            if (cipher[0] == '%')
            {
                cryptMessage = "Encrypted";
            }
            else
            {
                cryptMessage = "Decrypted";
            }

            return cryptMessage;
        }

        static private void DisplaySubstitutionBox(char[,] substitutionBox)
        {
            Console.WriteLine("Substitution Box: ");
            Console.WriteLine();

            for (int y = 0; y < substitutionBox.GetLength(1); y++)
            {
                for (int x = 0; x < substitutionBox.GetLength(0); x++)
                {
                    Console.Write(substitutionBox[x, y] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
