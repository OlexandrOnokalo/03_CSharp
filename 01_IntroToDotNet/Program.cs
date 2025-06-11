using System; // Підключення стандартної бібліотеки для роботи з консоллю та іншими базовими можливостями

class Program
{
    static void Main()
    {
        /*Завдання 1 Виведіть на екран цитату Б'ярна Страуструпа: It's easy to win forgiveness
                     * for being wrong; being right is what gets you into real trouble. Приклад виводу:
                     * It's easy to win forgiveness for being wrong;  being right is what gets you into
                     * real trouble. Bjarne Stroustrup*/
        
        Console.WriteLine("It's easy to win forgiveness for being wrong;\nbeing right is what gets you into real trouble.\nBjarne Stroustrup");

        /*Завдання 2 Користувач вводить з клавіатури п'ять чисел. Необхідно знайти суму чисел, максимум і мінімум з п'яти чисел, добуток чисел. Результат обчислень вивести на екран.*/
        int[] numbers = new int[5];
        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Number {i + 1}: "); 
            numbers[i] = int.Parse(Console.ReadLine()!); 
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

        /*Завдання 3 Користувач з клавіатури вводить шестизначне число. Необхідно перевернути число і відобразити результат. Наприклад, якщо введено 341256, результат 652143.без масива Array*/


        Console.Write("Enter a six-digit number: ");
        string input = Console.ReadLine()!;
        Console.WriteLine($"Resault: {input[5]}{input[4]}{input[3]}{input[2]}{input[1]}{input[0]}");

        /*Завдання 4 Користувач вводить з клавіатури межі числового діапазону.
             * Потрібно показати усі числа Фібоначчі з цього 1діапазону.
             * Числа Фібоначчі — елементи числової послідовності, у якій перші два числа дорівнюють
             * 0 і 1, а кожне наступне число дорівнює сумі двох попередніх чисел. Наприклад,
             * якщо вказано діапазон 0–20, результат буде: 0, 1, 1, 2, 3, 5, 8, 13.*/

        Console.Write("Enter range start: ");
        int rangeStart = int.Parse(Console.ReadLine()!); 

        Console.Write("Enter range end: ");
        int rangeEnd = int.Parse(Console.ReadLine()!); 

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

        /*Завдання 5 Дано цілі додатні числа A і B (A < B).
             * Вивести усі цілі числа від A до B включно; кожне число має виводитися у новому рядку;
             * при цьому кожне число має виводитися у кількість разів, рівну його значенню. Наприклад:
             * якщо А = 3, а В = 7, то програма має сформувати в консолі такий висновок: 3 3 3 4 4 4 4 5 5 5 5 5 6 6 6 6 6 6 7 7 7 7 7 7 7*/
        Console.Write("Enter A (A < B): ");
        int A = int.Parse(Console.ReadLine()!);

        Console.Write("Enter B: ");
        int B = int.Parse(Console.ReadLine()!);

        for (int i = A; i <= B; i++) 
        {
            for (int j = 0; j < i; j++) 
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine(); 
        }
        Console.WriteLine();

        /*Завдання 6 Користувач з клавіатури вводить довжину лінії, символ заповнювач,
             * напрямок лінії (горизонтальна, вертикальна). Програма відображає лінію по заданих параметрах.
             * Наприклад: +++++. Параметри лінії: горизонтальна лінія, довжина дорівнює п'яти, символ заповнювач +.*/


        Console.Write("Enter line length: ");
        int length = int.Parse(Console.ReadLine()!); 

        Console.Write("Enter fill symbol: ");
        char fill = Console.ReadLine()![0]; 

        Console.Write("Enter direction (horizontal/vertical): ");
        string direction = Console.ReadLine()!; 

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
