namespace _12_EventCallBackFunction
{
    public delegate void ActionDelegate(double m);


    class Trader
    {
        private string _name;

        private int _money;

        public void MyAction(double course)
        {
            if (course > 42) {
                Console.WriteLine("I buy 100$");
                _money += 100;
            }
            if (course >= 40 && course <= 42)
            {
                Console.WriteLine("I do nothing");
            }
            if (course < 40)
            {
                Console.WriteLine("I sale 100$");
                _money -= 100;
            }
           
        }
    }

    class Exchange
    {
        public double Course { get; set; }
        public event ActionDelegate ExchangeDelegate;

        public void ChangeCourse(double c) {
            ExchangeDelegate.Invoke(c);

        }

        public void GenerateCourse() 
        {
            Random  random = new Random();
            Course = random.Next(35, 45)+random.NextDouble();
            ChangeCourse(Course);
            Console.WriteLine(
        }

    }






    internal class Program
    {
        static void Main(string[] args)
        {
         
            Exchange exchange = new Exchange();

            

        }
    }
}
