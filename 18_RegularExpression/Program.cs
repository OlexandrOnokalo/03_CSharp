using System.Text.RegularExpressions;

namespace _18_RegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part one, classwork");
            string jsonString = File.ReadAllText("text.txt");
            Console.WriteLine(jsonString);

            MatchCollection coll = Regex.Matches(jsonString, @"\d+\.\d+|\d+\,\d+");
            foreach (Match match in coll)
            {
                Console.WriteLine($"Index = {match.Index}. Value : {match.Value}");
            }

            Console.WriteLine();
            int index = coll.Count;
            double[] numb = new double[index];

            for (int i = 0; i < index; i++)
                {
                    string value = coll[i].Value.Replace('.', ',');
                    numb[i] = double.Parse(value);
                }

            foreach (double num in numb)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("End of part one");


            Console.WriteLine("Part two, homework");


            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();


            string emailPattern = @"^[a-zA-Z0-9._-]{4,}@[a-zA-Z0-9]{2,}(\.[a-zA-Z0-9]{2,})+$";

            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[-_])[A-Za-z\d\-_]{6,}$";

            bool emailValid = Regex.IsMatch(email, emailPattern);
            bool passwordValid = Regex.IsMatch(password, passwordPattern);

            Console.WriteLine($"Email is valid: {emailValid}");
            Console.WriteLine($"Password is valid: {passwordValid}");

            
        }
    }
}
