using System;
using System.Linq;

namespace Psychosis.Models
{
    public class Password
    {
        private const int MIN_PASSWORD_LENGTH = 8;
        private const int MAX_PASSWORD_LENGTH = 16;
        private const int ALPHABET_CODE_SHIFT = 'A';
        private const int ENGLISH_ALPHABET_SIZE = 26;

        public static char[] AcceptPasswordInput()
        {
            var password = new char[MAX_PASSWORD_LENGTH];
            int i = 0;

            Console.WriteLine($"Enter your password (min {MIN_PASSWORD_LENGTH} characters): ");

            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                var ch = key.KeyChar;

                if (key.Key == ConsoleKey.Enter || i >= MAX_PASSWORD_LENGTH - 1)
                {
                    break;
                }
                else if (ch != '\b') // Check for backspace
                {
                    Console.Write('*'); // Print asterisks instead of actual characters
                    password[i++] = ch;
                }
                else if (i > 0) // Handle backspace
                {
                    Console.Write("\b \b"); // Move cursor back, overwrite with space, move cursor back again
                    i--;
                }
            }

            password[i] = '\0'; // Null terminate the password string

            if (i < MIN_PASSWORD_LENGTH)
            {
                Console.WriteLine($"\nPassword is too short. Please use at least {MIN_PASSWORD_LENGTH} characters.\n");
            }
            else
            {
                Console.WriteLine("\nPassword accepted. You can now proceed with the game.\n");
            }

            return password.Take(i).ToArray();
        }

        public static string Encrypt(string password)
        {
            // Implementation to encrypt the password
            return password;
        }

        public static char[][] SquareMatrixRotation(char[][] originalMatrix)
        {
            var matrix = (char[][])originalMatrix.Clone();
            int size = matrix.Length;

            for (int i = 0; i < size / 2; i++)
            {
                for (int j = i; j < size - i - 1; j++)
                {
                    char temp = matrix[i][j];
                    matrix[i][j] = matrix[size - 1 - j][i];
                    matrix[size - 1 - j][i] = matrix[size - 1 - i][size - 1 - j];
                    matrix[size - 1 - i][size - 1 - j] = matrix[j][size - 1 - i];
                    matrix[j][size - 1 - i] = temp;
                }
            }

            return matrix;
        }

        public static bool RegularExpressionMatching(string str, string pattern)
        {
            bool[,] matchMatrix = new bool[str.Length + 1, pattern.Length + 1];
            matchMatrix[0, 0] = true;

            for (int columnIndex = 1; columnIndex <= pattern.Length; columnIndex++)
            {
                if (pattern[columnIndex - 1] == '*')
                {
                    matchMatrix[0, columnIndex] = matchMatrix[0, columnIndex - 2];
                }
            }

            for (int rowIndex = 1; rowIndex <= str.Length; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex <= pattern.Length; columnIndex++)
                {
                    int stringIndex = rowIndex - 1;
                    int patternIndex = columnIndex - 1;

                    if (pattern[patternIndex] == '.' || pattern[patternIndex] == str[stringIndex])
                    {
                        matchMatrix[rowIndex, columnIndex] = matchMatrix[rowIndex - 1, columnIndex - 1];
                    }
                    else if (pattern[patternIndex] == '*')
                    {
                        matchMatrix[rowIndex, columnIndex] = matchMatrix[rowIndex, columnIndex - 2];
                        if (pattern[patternIndex - 1] == '.' || pattern[patternIndex - 1] == str[stringIndex])
                        {
                            matchMatrix[rowIndex, columnIndex] |= matchMatrix[rowIndex - 1, columnIndex];
                        }
                    }
                    else
                    {
                        matchMatrix[rowIndex, columnIndex] = false;
                    }
                }
            }

            return matchMatrix[str.Length, pattern.Length];
        }

        public static int[,] GenerateKeyMatrix(string keyString)
        {
            int matrixSize = (int)Math.Sqrt(keyString.Length);
            if (matrixSize * matrixSize != keyString.Length)
            {
                throw new ArgumentException("Invalid key string length. The square root of the key string must be an integer");
            }

            int keyStringIndex = 0;
            return Enumerable.Range(0, matrixSize)
                .Select(i => Enumerable.Range(0, matrixSize)
                    .Select(j => (keyString[keyStringIndex++] % ALPHABET_CODE_SHIFT))
                    .ToArray())
                .ToArray();
        }

        public static int[,] GenerateMessageVector(string message)
        {
            return Enumerable.Range(0, message.Length)
                .Select(i => new[] { message[i] % ALPHABET_CODE_SHIFT })
                .ToArray();
        }

        public static string HillCipherEncrypt(string message, string keyString)
        {
            if (!message.All(char.IsLetter) || !keyString.All(char.IsLetter))
            {
                throw new ArgumentException("The message and key string can only contain letters");
            }

            int[,] keyMatrix = GenerateKeyMatrix(keyString);
            int[,] messageVector = GenerateMessageVector(message);

            if (keyMatrix.GetLength(0) != message.Length)
            {
                throw new ArgumentException("Invalid key string length. The key length must be a square of message length");
            }

            int[,] cipherVector = MultiplyMatrices(keyMatrix, messageVector);
            string cipherString = "";
            for (int row = 0; row < cipherVector.GetLength(0); row++)
            {
                int item = cipherVector[row, 0];
                cipherString += (char)((item % ENGLISH_ALPHABET_SIZE) + ALPHABET_CODE_SHIFT);
            }

            return cipherString;
        }

        private static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rowsA = matrix1.GetLength(0);
            int colsA = matrix1.GetLength(1);
            int colsB = matrix2.GetLength(1);

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static void HillCipherDecrypt()
        {
            throw new NotImplementedException("This method is not implemented yet");
        }

        private static char[] GetCipherMap(char[] alphabet, int shift)
        {
            return alphabet.Select((currentChar, charIndex) =>
            {
                int encryptedCharIndex = (charIndex + shift) % alphabet.Length;
                if (encryptedCharIndex < 0)
                {
                    encryptedCharIndex += alphabet.Length;
                }
                return alphabet[encryptedCharIndex];
            }).ToArray();
        }
    }
}
