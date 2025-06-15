using System;
using System.Text;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Вставити в задану позицію рядка інший рядок.
            Console.WriteLine("Task 1:");
            string original = "Hello World!";
            string toInsert = "Beautiful ";
            int position = 6;
            // Вставляємо підрядок у вказану позицію
            string result1 = original.Insert(position, toInsert);
            Console.WriteLine($"Result: {result1}");

            // Task 2: Визначити, чи є рядок паліндромом
            Console.WriteLine("\nTask 2:");
            Console.Write("Enter a word to check for palindrome: ");
            string text = Console.ReadLine();
            // Перевіряємо, чи однаковий рядок у прямому та зворотному порядку
            bool isPalindrome = text == new string(text.Reverse().ToArray());
            Console.WriteLine($"Is \"{text}\" a palindrome? {isPalindrome}");

            // Task 3: Визначити відсоток малих і великих літер у тексті
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

            // Task 4: Замінити останні 3 символи у словах заданої довжини на "$"
            Console.WriteLine("\nTask 4:");
            string[] words = { "programming", "cat", "keyboard", "dog", "monitor" };
            Console.WriteLine("Original words: " + string.Join(", ", words));
            Console.Write("Enter target word length: ");
            int targetLength = int.Parse(Console.ReadLine());
            // Проходимо по словах та модифікуємо ті, що мають вказану довжину
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == targetLength && words[i].Length >= 3)
                {
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
                }
            }
            Console.WriteLine("Modified words: " + string.Join(", ", words));

            // Task 5: Вивести першу літеру слова за номером
            Console.WriteLine("\nTask 5:");
            string sentence = "The quick brown fox jumps over the lazy dog";
            string[] splitWords = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Words in text:");
            for (int i = 0; i < splitWords.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {splitWords[i]}");
            }
            Console.Write("Enter word number to extract first letter: ");
            int wordIndex = int.Parse(Console.ReadLine()) - 1; // Користувач бачить з 1
            if (wordIndex >= 0 && wordIndex < splitWords.Length)
            {
                Console.WriteLine($"First letter of word #{wordIndex + 1}: {splitWords[wordIndex][0]}");
            }
            else
            {
                Console.WriteLine("Invalid word index.");
            }

            // Task 6: Прибрати зайві пробіли та розділити слова символом "*"
            Console.WriteLine("\nTask 6:");
            string rawText = "   This    is   a   test   ";
            Console.WriteLine("Original string: \"" + rawText + "\"");
            // Видаляємо зайві пробіли на початку та в кінці, потім замінюємо всі послідовності пробілів на *
            string cleaned = string.Join("*", rawText.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine("Formatted: " + cleaned);

            // Task 7: Збираємо слова в рядок до введення слова з крапкою, розділяючи комами
            Console.WriteLine("\nTask 7:");
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                Console.Write("Enter word: ");
                string word = Console.ReadLine();
                sb.Append(word);
                if (word.EndsWith('.'))
                    break;
                sb.Append(", ");
            }
            Console.WriteLine("Resulting string: " + sb.ToString());
        }
    }
}
