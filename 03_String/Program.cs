using System;
using System.Text;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string original = "Hello World!";
            string toInsert = "Beautiful ";
            int position = 6;

            string result1 = original.Insert(position, toInsert);
            Console.WriteLine($"Result: {result1}");


            Console.WriteLine("\nTask 2:");
            Console.Write("Enter a word to check for palindrome: ");
            string? text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Input is empty.");
            }
            else
            {
                bool isPalindrome = text == new string(text.Reverse().ToArray());
                Console.WriteLine($"Is \"{text}\" a palindrome? {isPalindrome}");
            }


            Console.WriteLine("\nTask 3:");
            string inputText = "Hello World!";
            int upper = 0, lower = 0;
            foreach (char c in inputText)
            {
                if (char.IsUpper(c)) upper++;
                if (char.IsLower(c)) lower++;
            }
            int total = inputText.Length;
            double upperPercent = (double)upper / total * 100;
            double lowerPercent = (double)lower / total * 100;
            Console.WriteLine($"Uppercase: {upperPercent:F2}%");
            Console.WriteLine($"Lowercase: {lowerPercent:F2}%");


            Console.WriteLine("\nTask 4:");
            string[] words = { "programming", "cat", "keyboard", "dog", "monitor" };
            Console.WriteLine("Original words: " + string.Join(", ", words));
            Console.Write("Enter target word length: ");
            string? targetLengthInput = Console.ReadLine();
            int targetLength;
            if (!int.TryParse(targetLengthInput, out targetLength))
            {
                Console.WriteLine("Invalid input.");
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length == targetLength && words[i].Length >= 3)
                    {
                        words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
                    }
                }
                Console.WriteLine("Modified words: " + string.Join(", ", words));
            }


            Console.WriteLine("\nTask 5:");
            string sentence = "The quick brown fox jumps over the lazy dog";
            string[] splitWords = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Words in text:");
            for (int i = 0; i < splitWords.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {splitWords[i]}");
            }
            Console.Write("Enter word number to extract first letter: ");
            string? wordIndexInput = Console.ReadLine();
            int wordIndex;
            if (int.TryParse(wordIndexInput, out wordIndex))
            {
                wordIndex -= 1;
                if (wordIndex >= 0 && wordIndex < splitWords.Length)
                {
                    Console.WriteLine($"First letter of word #{wordIndex + 1}: {splitWords[wordIndex][0]}");
                }
                else
                {
                    Console.WriteLine("Invalid word index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }


            Console.WriteLine("\nTask 6:");
            string rawText = "   This    is   a   test   ";
            Console.WriteLine("Original string: \"" + rawText + "\"");

            string cleaned = string.Join("*", rawText.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine("Formatted: " + cleaned);


            Console.WriteLine("\nTask 7:");
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                Console.Write("Enter word: ");
                string? word = Console.ReadLine();
                if (string.IsNullOrEmpty(word))
                    continue;
                sb.Append(word);
                if (word.EndsWith('.'))
                    break;
                sb.Append(", ");
            }
            Console.WriteLine("Resulting string: " + sb.ToString());
        }
    }
}
