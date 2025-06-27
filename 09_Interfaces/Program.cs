using System.Globalization;

namespace _09_Interfaces
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    interface IMath
    {
        int Max();
        int Min();
        float Avg();

        bool Search(int value);

    }

    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }


    class MyArray : IOutput , IMath , ISort
    {
        private int[] numbers;

        public MyArray()
        {
            numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2; 
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;
        }

        public float Avg()
        {
            if (numbers == null || numbers.Length == 0)
                return 0;
            float sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum / numbers.Length;
        }

        public int Max()
        {
            if (numbers == null || numbers.Length == 0)
                throw new InvalidOperationException("Array is empty.");
            int max = numbers[0];
            foreach (var num in numbers)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        public int Min()
        {
            if (numbers == null || numbers.Length == 0)
                throw new InvalidOperationException("Array is empty.");
            int min = numbers[0];
            foreach (var num in numbers)
            {
                if (num < min )
                    min = num;
            }
            return min;
        }

        public bool Search(int value)
        {
            bool result = false;
            foreach (var num in numbers)
            {
                if (num == value)
                {
                    result = true;
                }
            }
            return result;
        }

        public void Show()
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }

        public void SortAsc()
        {
            Array.Sort(numbers);
        }

        public void SortDesc()
        {
            SortAsc();
            Array.Reverse(numbers);
        }

        public void SortByParam(bool isAsc)
        {
            if (!isAsc)
            {
                SortDesc();
            }
            else
            {
                SortAsc();
            }
        }


    }




    internal class Program
    {
        static void Main(string[] args)
        {
            MyArray numbers = new MyArray();
            numbers.Show();
            numbers.Show("Info!!!");
            Console.WriteLine("2");
            int max = numbers.Max();
            int min = numbers.Min();
            float avg = numbers.Avg();
            bool search = numbers.Search(9);
            Console.WriteLine($"Max = {max}, min = {min}, avg = {avg}. Is 9 in numbers? {search}!!!");
            numbers.SortAsc();
            numbers.Show();
            numbers.SortDesc();
            numbers.Show();
            Console.WriteLine("If false") ;
            numbers.SortByParam(false);
            numbers.Show();
            Console.WriteLine("If true") ;
            numbers.SortByParam(true);
            numbers.Show();

        }
    }
}
