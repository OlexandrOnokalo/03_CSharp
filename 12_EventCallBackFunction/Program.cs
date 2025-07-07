namespace _12_EventCallBackFunction
{
    public delegate void ActionDelegate(double course);

    class Trader
    {
        private string _name;
        private int _money;

        public Trader(string name, int initialMoney)
        {
            _name = name;
            _money = initialMoney;
        }

        public void MyAction(double course)
        {
            Console.WriteLine($"Current course: {course:F2}");

            if (course > 42)
            {
                Console.WriteLine($"{_name}: I buy 100$");
                _money += 100;
            }
            else if (course >= 40 && course <= 42)
            {
                Console.WriteLine($"{_name}: I do nothing");
            }
            else if (course < 40)
            {
                Console.WriteLine($"{_name}: I sell 100$");
                _money -= 100;
            }

            Console.WriteLine($"{_name}: Current balance: {_money}$");
            Console.WriteLine();
        }
    }

    class Exchange
    {
        public double Course { get; set; }
        public event ActionDelegate ExchangeDelegate;

        public void ChangeCourse(double newCourse)
        {
            Course = newCourse;

            if (ExchangeDelegate != null)
                ExchangeDelegate.Invoke(Course);
        }

        public void GenerateCourse()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++) 
            {
                double newCourse = random.Next(35, 45) + random.NextDouble();
                ChangeCourse(newCourse);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange();

            Trader trader1 = new Trader("Alice", 1000);
            Trader trader2 = new Trader("Bob", 800);

            exchange.ExchangeDelegate += trader1.MyAction;
            exchange.ExchangeDelegate += trader2.MyAction;

            exchange.GenerateCourse();

            
        }
    }
}
