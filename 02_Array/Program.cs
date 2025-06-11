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
            int n = int.Parse(Console.ReadLine())!;
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
            int[,] B = new int[row,col];
            
            for (int i = 0;i < 5; i++)
            {
                Console.WriteLine($"Enter {i+1} number: ");
                A[i] = int.Parse(Console.ReadLine())!;
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int[]
                }
            }
            

        }
    }
}
