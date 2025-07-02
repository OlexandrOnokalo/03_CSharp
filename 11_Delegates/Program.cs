namespace _11_Delegates
{

    class Operations
    {
        public int[] MyArr { get; set; }

        public Operations()
        {
            MyArr = new int[0];
        }
        public Operations(int[] arr) 
        {
            MyArr = arr;
        }
        public int Negative()
        {
            int count = 0;
            for (int i = 0; i < MyArr.Length; i++)
            {
                if (MyArr[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int SummAll()
        {
            int summ = 0;
            for (int i = 0; i < MyArr.Length; i++)
            {
                summ += MyArr[i];
            }
            return summ;

        }
        public int CountPrime()
        {
            int count = 0;
            for (int i = 0; i < MyArr.Length; i++)
            {
                if (IsPrime(MyArr[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int boundary = (int)Math.Sqrt(number);
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }



        internal class Program
        {
            static void Main(string[] args)
            {

            }
        }

    }
}
