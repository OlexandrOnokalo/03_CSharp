namespace _12_01_ExtensionMetod
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            string reversed = new string(str.Reverse().ToArray());
            return reversed == str;
        }

        public static string Encrypt(this string str, int key)
        {
            char[] result = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = (char)(str[i] + key);
            }
            return new string(result);
        }
    }

    public static class ArrayExtensions
    {
        public static int CountDuplicates(this int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                        break; 
                    }
                }
            }
            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input1 = "Madam";
            Console.WriteLine($"Is \"{input1}\" a palindrome? {input1.IsPalindrome()}");

            string input2 = "Hello";
            Console.WriteLine($"Is \"{input2}\" a palindrome? {input2.IsPalindrome()}");

            Console.WriteLine();

            
            string original = "HelloWorld";
            int key = 3;
            string encrypted = original.Encrypt(key);
            Console.WriteLine($"Original string: {original}");
            Console.WriteLine($"Encrypted string with key {key}: {encrypted}");

            Console.WriteLine();

            
            int[] array = { 1, 2, 3, 2, 4, 5, 1, 1 };
            int duplicates = array.CountDuplicates();
            Console.WriteLine("Array: " + string.Join(", ", array));
            Console.WriteLine($"Total duplicate elements in array: {duplicates}");
        }
    }
}
