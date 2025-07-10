using System;

namespace _15_02_Generics
{
    class Stack<T>
    {
        private T[] items;

        public Stack()
        {
            items = new T[0];
        }

        public void Push(T value)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = value;
        }

        public T Pop()
        {
            if (items.Length == 0)
                throw new InvalidOperationException("Stack is empty.");

            T value = items[items.Length - 1];
            Array.Resize(ref items, items.Length - 1);
            return value;
        }

        public T Peek()
        {
            if (items.Length == 0)
                throw new InvalidOperationException("Stack is empty.");
            return items[items.Length - 1];
        }

        public int Count => items.Length;

        public void Print()
        {
            Console.WriteLine("Stack contents:");
            for (int i = items.Length - 1; i >= 0; i--)
                Console.WriteLine(items[i]);
        }
    }

    class Queue<T>
    {
        private T[] items;

        public Queue()
        {
            items = new T[0];
        }

        public void Enqueue(T value)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = value;
        }

        public T Dequeue()
        {
            if (items.Length == 0)
                throw new InvalidOperationException("Queue is empty.");

            T value = items[0];
            for (int i = 1; i < items.Length; i++)
                items[i - 1] = items[i];
            Array.Resize(ref items, items.Length - 1);
            return value;
        }

        public T Peek()
        {
            if (items.Length == 0)
                throw new InvalidOperationException("Queue is empty.");
            return items[0];
        }

        public int Count => items.Length;

        public void Print()
        {
            Console.WriteLine("Queue contents:");
            foreach (var item in items)
                Console.WriteLine(item);
        }
    }

    internal class Program
    {
        public static T Max<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;
            if (b.CompareTo(max) > 0)
                max = b;
            if (c.CompareTo(max) > 0)
                max = c;
            return max;
        }

        public static T Min<T>(T a, T b, T c) where T : IComparable<T>
        {
            T min = a;
            if (b.CompareTo(min) < 0)
                min = b;
            if (c.CompareTo(min) < 0)
                min = c;
            return min;
        }

        public static T Sum<T>(T[] array)
        {
            dynamic sum = 0;
            foreach (var item in array)
                sum += item;
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Generic Max/Min/Sum ===");
            Console.WriteLine($"Max(4, 7, 2): {Max(4, 7, 2)}");
            Console.WriteLine($"Min(4, 7, 2): {Min(4, 7, 2)}");
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Sum of [1, 2, 3, 4, 5]: {Sum(numbers)}");

            Console.WriteLine("\n=== Stack Test ===");
            Stack<string> stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Print();
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            stack.Print();
            Console.WriteLine($"Count: {stack.Count}");

            Console.WriteLine("\n=== Queue Test ===");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Print();
            Console.WriteLine($"Peek: {queue.Peek()}");
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            queue.Print();
            Console.WriteLine($"Count: {queue.Count}");
        }
    }
}
