namespace _19_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { -10, 5, 12, 43, -3, 0, 18, -25, 8, 99, 100, 7, -2 };

            foreach (int number in numbers)
                Console.Write(number+" ");
            Console.WriteLine();


            Console.WriteLine("\nTask 1");
            
            var query1 = from n in numbers
                         where n > 0
                         orderby n
                         select n;

            Console.WriteLine("Query syntax");
            foreach (var n in query1)
                Console.Write(n + " ");
            Console.WriteLine();

            
            var method1 = numbers.Where(n => n > 0).OrderBy(n => n);

            Console.WriteLine("Method syntax");
            foreach (var n in method1)
                Console.Write(n + " ");
            Console.WriteLine("\n");

            Console.WriteLine("Task 2");

            
            var query2 = from n in numbers
                         where n > 9 && n < 100
                         select n;

            int count2_query = query2.Count();
            double avg2_query = query2.Average();

            Console.WriteLine($"Query syntax: Count = {count2_query}, Average = {avg2_query:F2}");

            
            var method2 = numbers.Where(n => n >= 10 && n <= 99);
            int count2_method = method2.Count();
            double avg2_method = method2.Any() ? method2.Average() : 0;

            Console.WriteLine($"Method syntax: Count = {count2_method}, Average = {avg2_method:F2}");
        }
    }
}
