using System;
using System.IO;
using System.Text;

namespace _16_WorkWithFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter file path to view content:");
            string filePath = Console.ReadLine()!;
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Error: File does not exist.");
            }

            
            Console.WriteLine("Enter array elements separated by space:");
            string[] input = Console.ReadLine()!.Split();
            File.WriteAllLines("array.txt", input);
            Console.WriteLine("Array saved to file 'array.txt'.");

            
            if (File.Exists("array.txt"))
            {
                string[] loadedArray = File.ReadAllLines("array.txt");
                Console.WriteLine("Loaded array from file:");
                Console.WriteLine(string.Join(" ", loadedArray));
            }

            
            Random rnd = new Random();
            string evenPath = "even.txt";
            string oddPath = "odd.txt";
            int evenCount = 0, oddCount = 0;
            using (StreamWriter evenWriter = new StreamWriter(evenPath))
            using (StreamWriter oddWriter = new StreamWriter(oddPath))
            {
                for (int i = 0; i < 10000; i++)
                {
                    int num = rnd.Next(0, 100000);
                    if (num % 2 == 0)
                    {
                        evenWriter.WriteLine(num);
                        evenCount++;
                    }
                    else
                    {
                        oddWriter.WriteLine(num);
                        oddCount++;
                    }
                }
            }
            Console.WriteLine($"Task 4 complete. Even: {evenCount}, Odd: {oddCount}");

            
            Console.WriteLine("Enter file path for search:");
            string searchFilePath = Console.ReadLine()!;
            if (!File.Exists(searchFilePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            Console.WriteLine("Enter word to search:");
            string wordToFind = Console.ReadLine()!;
            string text = File.ReadAllText(searchFilePath);

            
            int count = 0;
            int index = text.IndexOf(wordToFind);
            while (index != -1)
            {
                count++;
                index = text.IndexOf(wordToFind, index + 1);
            }
            Console.WriteLine($"Occurrences of '{wordToFind}': {count}");

            
            char[] charArray = wordToFind.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            int reversedCount = 0;
            int rIndex = text.IndexOf(reversed);
            while (rIndex != -1)
            {
                reversedCount++;
                rIndex = text.IndexOf(reversed, rIndex + 1);
            }
            Console.WriteLine($"Occurrences of reversed '{reversed}': {reversedCount}");

            
            Console.WriteLine("Enter file path to analyze:");
            string statPath = Console.ReadLine()!;
            if (!File.Exists(statPath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            string fileText = File.ReadAllText(statPath);
            int sentenceCount = 0, upper = 0, lower = 0, vowels = 0, consonants = 0, digits = 0;
            string vowelSet = "aeiouAEIOU";
            foreach (char ch in fileText)
            {
                if (ch == '.' || ch == '!' || ch == '?') sentenceCount++;
                if (char.IsUpper(ch)) upper++;
                if (char.IsLower(ch)) lower++;
                if (char.IsDigit(ch)) digits++;
                if (char.IsLetter(ch))
                {
                    if (vowelSet.Contains(ch)) vowels++;
                    else consonants++;
                }
            }

            Console.WriteLine("Statistics:");
            Console.WriteLine($"Sentences: {sentenceCount}");
            Console.WriteLine($"Uppercase letters: {upper}");
            Console.WriteLine($"Lowercase letters: {lower}");
            Console.WriteLine($"Vowels: {vowels}");
            Console.WriteLine($"Consonants: {consonants}");
            Console.WriteLine($"Digits: {digits}");
        }
    }
}

