using System;

namespace _02_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Завдання 1
            //Створіть додаток, який відображає кількість парних,
            //непарних, унікальних елементів масиву.

            int[] array = { 1, 2, 3, 4, 5, 2, 3, 6, 7, 8, 8 };

            int evenCount = 0;
            int oddCount = 0;
            int uniqCount = 0;

            
            foreach (int num in array)
            {
                if (num % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }

            
            int[] unique = new int[array.Length];
            int uniqueIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < uniqueIndex; j++)
                {
                    if (array[i] == unique[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    unique[uniqueIndex] = array[i];
                    uniqueIndex++;
                }
            }
            uniqCount = uniqueIndex;

            Console.WriteLine($"Even count: {evenCount}");
            Console.WriteLine($"Odd count: {oddCount}");
            Console.WriteLine($"Uniq count: {uniqCount}");

            //            Завдання 2
            //Створіть додаток, який відображає кількість значень у
            //масиві менше заданого параметра користувачем.Наприклад,
            //кількість значень менших, ніж 7(7 введено користувачем
            //з клавіатури).

            Console.WriteLine("Task 2:");
            Console.WriteLine("Enter number: ");
            int n = int.Parse(Console.ReadLine()!);
            int count = 0;
            foreach (int elem in array)
            {
                if (elem < n)
                {
                    count++;
                }
            }
            Console.WriteLine($"The count of elements less than {n} is {count}");

            //            Завдання 3
            //Оголосити одновимірний(5 елементів) масив з назвою
            //A i двовимірний масив(3 рядки, 4 стовпці) дробових чисел
            //з назвою B.Заповнити одновимірний масив А числами,
            //введеними з клавіатури користувачем, а двовимірний
            //масив В — випадковими числами за допомогою циклів.
            //Вивести на екран значення масивів: масиву А — в один
            //рядок, масиву В — у вигляді матриці.Знайти у даних
            //масивах загальний максимальний елемент, мінімальний
            //елемент, загальну суму усіх елементів, загальний добуток
            //усіх елементів, суму парних елементів масиву А, суму
            //непарних стовпців масиву В
            Console.WriteLine("Task 3:");

            int[] A = new int[5];
            int row = 3, col = 4;
            double[,] B = new double[row, col];
            Random random = new Random();

            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter {i + 1} number: ");
                A[i] = int.Parse(Console.ReadLine()!);
            }

            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    B[i, j] = Math.Round(random.Next(100) + random.NextDouble(), 2);
                }
            }

            
            Console.Write("Array A: ");
            foreach (int val in A)
                Console.Write(val + " ");
            Console.WriteLine();

            
            Console.WriteLine("Array B:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            
            double max = A[0];
            double min = A[0];
            double sum = 0;
            double product = 1;
            int sumEvenA = 0;
            double sumOddColsB = 0;

            
            foreach (int val in A)
            {
                if (val > max) max = val;
                if (val < min) min = val;
                sum += val;
                product *= val;
                if (val % 2 == 0) sumEvenA += val;
            }

            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double val = B[i, j];
                    if (val > max) max = val;
                    if (val < min) min = val;
                    sum += val;
                    product *= val;
                    if (j % 2 == 1) 
                        sumOddColsB += val;
                }
            }
            sum = Math.Round(sum, 2);
            product = Math.Round(product, 2);
            sumOddColsB = Math.Round(sumOddColsB, 2);


            Console.WriteLine($"Max element: {max}");
            Console.WriteLine($"Min element: {min}");
            Console.WriteLine($"Sum of all elements: {sum}");
            Console.WriteLine($"Product of all elements: {product}");
            Console.WriteLine($"Sum of even elements in A: {sumEvenA}");
            Console.WriteLine($"Sum of elements in odd columns of B: {sumOddColsB}");

            //    Завдання 4
            //Дано двовимірний масив розміром 5×5, заповне -
            //ний випадковими числами з діапазону від –100 до 100.
            //Визначити суму елементів масиву, розташованих між
            //мінімальним і максимальним елементами.

            Console.WriteLine("Task 4:");

            int[,] array2D = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array2D[i, j] = rand.Next(100);
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }

            
            int[] flatArray = new int[25];
            int index = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    flatArray[index++] = array2D[i, j];

            int minIndex = 0, maxIndex = 0;
            for (int i = 1; i < flatArray.Length; i++)
            {
                if (flatArray[i] < flatArray[minIndex])
                    minIndex = i;
                if (flatArray[i] > flatArray[maxIndex])
                    maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);
            int sumBetween = 0;
            for (int i = start + 1; i < end; i++)
            {
                sumBetween += flatArray[i];
            }

            Console.WriteLine($"Sum of elements between min and max: {sumBetween}");


            //    Завдання 5:
            //Визначити кількість елементів в заданому масиві, що відрізняються
            //від мінімального на 5.

            Console.WriteLine("Task 5:");

            int minVal = array[0];
            foreach (int val in array)
            {
                if (val < minVal)
                    minVal = val;
            }

            int diffCount = 0;
            foreach (int val in array)
            {
                if (Math.Abs(val - minVal) == 5)
                    diffCount++;
            }

            Console.WriteLine($"Number of elements differing from min ({minVal}) by 5: {diffCount}");




        }
    }
}
