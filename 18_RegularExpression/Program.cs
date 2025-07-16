using System.Text.RegularExpressions;

namespace _18_RegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                numb[i] = double.Parse(coll[i].Value);
            }

            foreach (double num in numb) {
                Console.WriteLine(num);
            }






        }
    }
}
