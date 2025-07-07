namespace _14_Dictionary
{
    class Abonent
    {
        public string _name { get; set; }

        public override string ToString()
        {
            return $"Name: {_name}";
        }
    }

    class PhoneBook
    {
        Dictionary<string, Abonent> _phones = new Dictionary<string, Abonent>();

        public void AddAbonent(string key, Abonent abonent)
        {
            if (!_phones.ContainsKey(key)) { _phones[key] = abonent; }
            else
            {
                Console.WriteLine("Abonent already in phonebook");
            }
        }

        public void RemoveAbonent(string key)
        {
            if (!_phones.ContainsKey(key))
            {
                Console.WriteLine("Abonent not found");
                return;
            }
            else
            {
                _phones.Remove(key);
                Console.WriteLine("Abonent removed");
            }
        }

        public void EditAbonent(string key, Abonent abonent)
        {
            if (_phones.ContainsKey(key))
            {
                _phones[key] = abonent;
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Abonent not found");
            }
        }

        public Abonent FindAbonent(string key)
        {
            if (_phones.ContainsKey(key))
            {
                return _phones[key];
            }
            else
            {
                Console.WriteLine("Abonent not found");
                return null;
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("All Abonents:");
            foreach (var pair in _phones)
            {
                Console.WriteLine($"Phone: {pair.Key}, {pair.Value}");
            }
        }
    }

    class WordStatistics
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string[] words = text.Split(new[] { ' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }

            return wordCount;
        }

        public static void PrintStatistics(Dictionary<string, int> stats)
        {
            Console.WriteLine("Word\t\tCount");
            Console.WriteLine("------------------------");
            foreach (var pair in stats.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{pair.Key,-15}{pair.Value}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            

            PhoneBook phoneBook = new PhoneBook();

            phoneBook.AddAbonent("123-456", new Abonent { _name = "Alice" });
            phoneBook.AddAbonent("789-111", new Abonent { _name = "Bob" });
            phoneBook.AddAbonent("222-333", new Abonent { _name = "Charlie" });

            phoneBook.PrintAll();

            Console.WriteLine("\nEditing Bob's name to Bobby:");
            phoneBook.EditAbonent("789-111", new Abonent { _name = "Bobby" });

            Console.WriteLine("PHONEBOOK:");
            phoneBook.PrintAll();

            Console.WriteLine("\nFinding abonent by phone '123-456':");
            Abonent a = phoneBook.FindAbonent("123-456");
            if (a != null)
                Console.WriteLine(a);

            Console.WriteLine("\nRemoving abonent with phone '222-333':");
            phoneBook.RemoveAbonent("222-333");

            phoneBook.PrintAll();

            Console.WriteLine("\nWORD STATISTICS:");

            string inputText = "Ось будинок, який збудував Джек. А це пшениця, яка у темній коморі зберігається у будинку, який збудував Джек. А це веселий птах-синиця, який часто краде пшеницю, яка в темній коморі зберігається у будинку, який збудував Джек.";

            var stats = WordStatistics.CountWords(inputText);
            WordStatistics.PrintStatistics(stats);
        }
    }
}
