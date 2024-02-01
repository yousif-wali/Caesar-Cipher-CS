using System;
using System.Linq;

namespace AdvancedCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your text:");
            string inputText = Console.ReadLine();

            Console.WriteLine("Enter the shift (integer):");
            int shift = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choose cipher direction (F = Forward, R = Reverse):");
            string direction = Console.ReadLine().ToUpper();

            string cipheredText = CipherText(inputText, shift, direction);

            Console.WriteLine("Original Text: " + inputText);
            Console.WriteLine("Ciphered Text: " + cipheredText);
        }

        static string CipherText(string text, int shift, string direction)
        {
            return new string(text.Select(c => CipherCharacter(c, shift, direction)).ToArray());
        }

        static char CipherCharacter(char c, int shift, string direction)
        {
            if (!char.IsLetter(c)) return c; // Non-letter characters are not shifted

            int shiftDirection = direction == "R" ? -1 : 1;
            int offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + shift * shiftDirection - offset) % 26 + 26) % 26) + offset);
        }
    }
}
