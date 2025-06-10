namespace _01_IntroToDotNet
{
    using System; 

    class Program
    {
        static void Main()
        {
            
            Console.WriteLine("It's easy to win forgiveness for being wrong;");
            Console.WriteLine("being right is what gets you into real trouble.");
            Console.WriteLine("Bjarne Stroustrup\n"); 

            
            int[] numbers = new int[5]; 
            Console.WriteLine("Enter 5 numbers:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Number {i + 1}: "); 
                numbers[i] = int.Parse(Console.ReadLine()); 
            }

            
            int sum = 0, product = 1, min = numbers[0], max = numbers[0];

            foreach (int num in numbers) 
            {
                sum += num;        
                product *= num;    
                if (num < min) min = num; 
                if (num > max) max = num; 
            }

            
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}\n");

            
            Console.Write("Enter a six-digit number: ");
            string input = Console.ReadLine(); 
            char[] reversed = input.ToCharArray(); 
            Array.Reverse(reversed);
            string result = new string(reversed); 
            Console.WriteLine($"Reversed number: {result}\n");

            
            Console.Write("Enter range start: ");
            int rangeStart = int.Parse(Console.ReadLine()); 

            Console.Write("Enter range end: ");
            int rangeEnd = int.Parse(Console.ReadLine()); 

            int a = 0, b = 1; 
            Console.Write("Fibonacci numbers in range: ");
            while (a <= rangeEnd)
            {
                if (a >= rangeStart)
                    Console.Write($"{a} "); 
                int temp = a + b; 
                a = b; 
                b = temp;
            }
            Console.WriteLine("\n");

            
            Console.Write("Enter A (A < B): ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            int B = int.Parse(Console.ReadLine());

            for (int i = A; i <= B; i++) 
            {
                for (int j = 0; j < i; j++) 
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine(); 
            }
            Console.WriteLine();

            
            Console.Write("Enter line length: ");
            int length = int.Parse(Console.ReadLine()); 

            Console.Write("Enter fill symbol: ");
            char fill = Console.ReadLine()[0];

            Console.Write("Enter direction (horizontal/vertical): ");
            string direction = Console.ReadLine(); 

            if (direction.ToLower() == "horizontal") 
            {
                for (int i = 0; i < length; i++)
                    Console.Write(fill); 
                Console.WriteLine();
            }
            else if (direction.ToLower() == "vertical") 
            {
                for (int i = 0; i < length; i++)
                    Console.WriteLine(fill);
            }
            else
            {
                Console.WriteLine("Invalid direction."); 
            }
        }
    }



}
