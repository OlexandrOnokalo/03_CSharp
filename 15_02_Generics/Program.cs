namespace _15_02_Generics
{

    class Stack<Type>
    {
        private Type[] myArr;

        public Type[] MyArr
        {
            get { return myArr; }
            set { myArr = value; }
        }

        public void Pop() 
        {
            Array.Resize(ref myArr, myArr.Length-1);

        }

        public void Push(Type value)
        {
            Array.Resize(ref myArr, myArr.Length);

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

        public  static T Summ<T>(T[] array) where T : IComparable<T>
        {
            dynamic sum = 0;

        foreach (var t in array)
            {
                sum += t;
            }
            
            return sum;
        }





        static void Main(string[] args)
        {
            
        }
    }
}
