using System.Text.Json;

namespace Final_Work_CSharp
{
    class AllDictionaries
    {
        public List<OneDictionary> AllDict;

        public AllDictionaries()
        {
            AllDict = new List<OneDictionary>();
        }

        public OneDictionary FindByName(string name)
        {
            int i = 0;
            while (i < AllDict.Count)
            {
                if (AllDict[i].Name == name)
                {
                    return AllDict[i];
                }
                i++;
            }
            return null;
        }

        public bool Exists(string name)
        {
            OneDictionary d = FindByName(name);
            if (d == null)
            {
                return false;
            }
            return true;
        }

        public OneDictionary Create(string name)
        {
            OneDictionary d = new OneDictionary();
            d.Name = name;
            d.OneDict = new Dictionary<string, List<string>>();
            AllDict.Add(d);
            return d;
        }

        public void SaveAll(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
            string file = Path.Combine(folderPath, "dictionaries.json");           
            string json = JsonSerializer.Serialize(AllDict, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(file, json);
        }

        public void LoadAll(string folderPath)
        {
            AllDict.Clear();
            Directory.CreateDirectory(folderPath);
            string file = Path.Combine(folderPath, "dictionaries.json");
            if (!File.Exists(file))
            {
                return;
            }
            string json = File.ReadAllText(file);
            if (json == null)
            {
                return;
            }
            json = json.Trim();
            if (json.Length == 0)
            {
                return;
            }
            List<OneDictionary> list = JsonSerializer.Deserialize<List<OneDictionary>>(json);
            if (list == null)
            {
                return;
            }
            int i = 0;
            while (i < list.Count)
            {
                OneDictionary d = list[i];
                if (d != null)
                {
                    if (d.OneDict == null)
                    {
                        d.OneDict = new Dictionary<string, List<string>>();
                    }
                    if (!Exists(d.Name))
                    {
                        AllDict.Add(d);
                    }
                }
                i++;
            }
        }

        public void PrintAllDictionaries()
        {
            Console.WriteLine("== Available dictionaries ==");
            if (AllDict.Count == 0)
            {
                Console.WriteLine("<none>");
                return;
            }
            int i = 0;
            while (i < AllDict.Count)
            {
                OneDictionary d = AllDict[i];
                int words = 0;
                if (d.OneDict != null)
                {
                    words = d.OneDict.Count;
                }
                Console.WriteLine($"{i + 1}. {d.Name} (words: {words})");
                i++;
            }
        }

        public static void PrintDictionaryContent(OneDictionary d)
        {
            Console.WriteLine("== Words in dictionary " + d.Name + " ==");
            if (d.OneDict == null || d.OneDict.Count == 0)
            {
                Console.WriteLine("<empty>");
                Console.WriteLine("----------------------------");
                return;
            }
            List<string> keys = new List<string>(d.OneDict.Keys);
            keys.Sort();
            int i = 0;
            while (i < keys.Count)
            {
                List<string> list = d.OneDict[keys[i]];
                Console.WriteLine(keys[i] + " -> " + string.Join(", ", list));
                i++;
            }
            Console.WriteLine("----------------------------");
        }
    }
}
