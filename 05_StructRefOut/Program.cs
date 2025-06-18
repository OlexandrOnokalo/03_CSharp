namespace _05_StructRefOut
{
    class Worker
    {
        
        private string name=" ";
        private int age;
        private int salary;
        private DateTime hireDate;

        
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Name cannot be null or empty.");
                }
            }
        }

        
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 100)
                {
                    throw new Exception("Age must be between 18 and 100.");
                }
                age = value;
            }
        }

        
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary cannot be negative.");
                }
                salary = value;
            }
        }

        
        public DateTime HireDate
        {
            get { return hireDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Hire date cannot be in the future.");
                }
                hireDate = value;
            }
        }

        
        public int GetExperience()
        {
            return DateTime.Now.Year - HireDate.Year;
        }
    }

    class Calculator
    {
        
        public double Add(double a, double b)
        {
            return a + b;
        }

        
        public double Sub(double a, double b)
        {
            return a - b;
        }

        
        public double Mul(double a, double b)
        {
            return a * b;
        }

        
        public double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new Exception("Cannot divide by zero.");
            }
            return a / b;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Worker> workers = new List<Worker>();

            Console.WriteLine("Enter data for 5 workers:");
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Worker w = new Worker();

                    Console.Write("Enter name: ");
                    w.Name = Console.ReadLine()!;

                    Console.Write("Enter age: ");
                    w.Age = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter salary: ");
                    w.Salary = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter hire date (yyyy-MM-dd): ");
                    w.HireDate = DateTime.Parse(Console.ReadLine()!);

                    workers.Add(w);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }


            }

            
            var sortedWorkers = workers.OrderBy(w => w.Name).ToList();

            Console.Write("\nEnter minimum experience (in years): ");
            int minExp = int.Parse(Console.ReadLine()!);

            Console.WriteLine("\nWorkers with experience greater than entered:");
            foreach (var w in sortedWorkers)
            {
                if (w.GetExperience() > minExp)
                {
                    Console.WriteLine($"Name: {w.Name}, Experience: {w.GetExperience()} years");
                }
            }

            
            Calculator calc = new Calculator();

            try
            {
                Console.Write("\nEnter first number: ");
                double a = double.Parse(Console.ReadLine()!);
                Console.Write("Enter second number: ");
                double b = double.Parse(Console.ReadLine()!);

                Console.Write("Choose operation (+, -, *, /): ");
                string op = Console.ReadLine()!;

                double result = 0;
                switch (op)
                {
                    case "+": result = calc.Add(a, b); break;
                    case "-": result = calc.Sub(a, b); break;
                    case "*": result = calc.Mul(a, b); break;
                    case "/": result = calc.Div(a, b); break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        return;
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

