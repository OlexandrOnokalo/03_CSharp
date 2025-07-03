using System;
using System.Collections.Generic;

namespace _11_Delegates
{
    public delegate int IntOperation();
    public delegate void VoidOperation();

    class Operations
    {
        public int[] MyArr { get; set; }

        public Operations(int[] arr)
        {
            MyArr = arr;
        }

        public int Negative()
        {
            int count = 0;
            for (int i = 0; i < MyArr.Length; i++)
                if (MyArr[i] < 0)
                    count++;
            return count;
        }

        public int SummAll()
        {
            int summ = 0;
            for (int i = 0; i < MyArr.Length; i++)
                summ += MyArr[i];
            return summ;
        }

        public int CountPrime()
        {
            int count = 0;
            for (int i = 0; i < MyArr.Length; i++)
                if (IsPrime(MyArr[i]))
                    count++;
            return count;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int boundary = (int)Math.Sqrt(number);
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0) return false;
            return true;
        }

        public void ReplaceNegativesWithZero()
        {
            for (int i = 0; i < MyArr.Length; i++)
                if (MyArr[i] < 0)
                    MyArr[i] = 0;
        }

        public void SortArray()
        {
            Array.Sort(MyArr);
        }

        public void MoveEvensToStart()
        {
            int[] temp = new int[MyArr.Length];
            int idx = 0;

            for (int i = 0; i < MyArr.Length; i++)
                if (MyArr[i] % 2 == 0)
                    temp[idx++] = MyArr[i];

            for (int i = 0; i < MyArr.Length; i++)
                if (MyArr[i] % 2 != 0)
                    temp[idx++] = MyArr[i];

            for (int i = 0; i < MyArr.Length; i++)
                MyArr[i] = temp[i];
        }

        public static void DoIntOperation(IntOperation op)
        {
            Console.WriteLine($"Result: {op.Invoke()}");
        }

        public static void DoVoidOperation(VoidOperation op)
        {
            op.Invoke();
            Console.WriteLine("Operation completed.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, -5, 6, 2, 7, -1, 0, 11, 4, -8 };
            Operations ops = new Operations(array);

            Console.WriteLine("Initial array: " + string.Join(", ", ops.MyArr));
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1.1 - Count negative elements");
            Console.WriteLine("1.2 - Sum all elements");
            Console.WriteLine("1.3 - Count prime numbers");
            Console.WriteLine("2.1 - Replace negative elements with zero");
            Console.WriteLine("2.2 - Sort array");
            Console.WriteLine("2.3 - Move even elements to start");
            string userInput = Console.ReadLine()?.Trim() ?? "";

            var intOperations = new Dictionary<string, IntOperation>
            {
                ["1.1"] = ops.Negative,
                ["1.2"] = ops.SummAll,
                ["1.3"] = ops.CountPrime,
            };

            var voidOperations = new Dictionary<string, VoidOperation>
            {
                ["2.1"] = ops.ReplaceNegativesWithZero,
                ["2.2"] = ops.SortArray,
                ["2.3"] = ops.MoveEvensToStart,
            };

            try
            {
                
                IntOperation intOp = intOperations[userInput];
                Operations.DoIntOperation(intOp);
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    
                    VoidOperation voidOp = voidOperations[userInput];
                    Operations.DoVoidOperation(voidOp);
                    Console.WriteLine("Modified array: " + string.Join(", ", ops.MyArr));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid operation code.");
                }
            }
        }
    }
}
