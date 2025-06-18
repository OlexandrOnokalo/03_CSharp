namespace _04_IntroToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Freezer[] freezers = new Freezer[5];

            freezers[0] = new Freezer("LG", 300, true, -18.5, 150);
            freezers[1] = new Freezer("Samsung", 250, false, -20.0, 180);
            freezers[2] = new Freezer(); 
            freezers[3] = new Freezer("Bosch", 220);
            freezers[4] = new Freezer("Whirlpool", 280, true, -24.0, 200);

            
            foreach (Freezer f in freezers)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine(new string('-', 40));
            }

            
            Console.WriteLine($"Total Freezers Created: {Freezer.TotalCreated}");
            Console.WriteLine($"Default Warranty Period: {Freezer.DefaultWarrantyYears} years");
        }
    }
}

