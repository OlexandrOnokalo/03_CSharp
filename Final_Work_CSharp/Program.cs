using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Final_Work_CSharp
{
    class OneDictionary
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> OneDict { get; set; }

        public OneDictionary()
        {
            Name = "";
            OneDict = new Dictionary<string, List<string>>();
        }

        public void AddWordWithTranslations(string word, List<string> translations)
        {
            if (OneDict.ContainsKey(word))
            {
                List<string> list = OneDict[word];
                int i = 0;
                while (i < translations.Count)
                {
                    list.Add(translations[i]);
                    i++;
                }
            }
            else
            {
                OneDict[word] = new List<string>(translations);
            }
        }

        public bool AddTranslation(string word, string translation)
        {
            if (!OneDict.ContainsKey(word))
            {
                return false;
            }
            List<string> list = OneDict[word];
            list.Add(translation);
            return true;
        }

        public bool ReplaceWord(string oldWord, string newWord)
        {
            if (!OneDict.ContainsKey(oldWord))
            {
                return false;
            }
            if (OneDict.ContainsKey(newWord))
            {
                return false;
            }
            List<string> list = OneDict[oldWord];
            OneDict.Remove(oldWord);
            OneDict[newWord] = list;
            return true;
        }

        public bool ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            if (!OneDict.ContainsKey(word))
            {
                return false;
            }
            List<string> list = OneDict[word];
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] == oldTranslation)
                {
                    list[i] = newTranslation;
                    return true;
                }
                i++;
            }
            return false;
        }

        public bool RemoveWord(string word)
        {
            if (!OneDict.ContainsKey(word))
            {
                return false;
            }
            OneDict.Remove(word);
            return true;
        }

        public bool RemoveTranslation(string word, string translation, out bool lastBlocked)
        {
            lastBlocked = false;
            if (!OneDict.ContainsKey(word))
            {
                return false;
            }
            List<string> list = OneDict[word];
            if (list.Count == 1)
            {
                lastBlocked = true;
                return false;
            }
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] == translation)
                {
                    list.RemoveAt(i);
                    return true;
                }
                i++;
            }
            return false;
        }

        public List<string> FindTranslations(string word)
        {
            if (!OneDict.ContainsKey(word))
            {
                return null;
            }
            return new List<string>(OneDict[word]);
        }
    }

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

    class Program
    {
        static void ShowCreateDictionary(AllDictionaries store)
        {
            Console.Clear();
            Console.WriteLine("== Create dictionary ==");
            Console.Write("Enter dictionary short name (e.g., Ukr-Eng): ");
            string name = Console.ReadLine();
            if (name == null)
            {
                name = "";
            }
            name = name.Trim();

            if (name.Length == 0)
            {
                Pause("Name cannot be empty.");
                return;
            }
            if (store.Exists(name))
            {
                Pause("Dictionary with this name already exists.");
                return;
            }

            store.Create(name);
            Pause("Dictionary created. Remember to save it from the main menu.");
        }

        static void ShowOpenDictionary(AllDictionaries store, string folderPath)
        {
            Console.Clear();
            store.PrintAllDictionaries();
            Console.WriteLine();
            Console.Write("Enter dictionary name to open: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                name = "";
            }
            name = name.Trim();

            OneDictionary d = store.FindByName(name);
            if (d == null)
            {
                Pause("Dictionary not found.");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Dictionary: " + d.Name + " ==");
                Console.WriteLine("1) Show dictionary content");
                Console.WriteLine("2) Add new word with translations");
                Console.WriteLine("3) Add translation to existing word");
                Console.WriteLine("4) Replace word");
                Console.WriteLine("5) Replace translation");
                Console.WriteLine("6) Delete word");
                Console.WriteLine("7) Delete translation");
                Console.WriteLine("8) Find translations");
                Console.WriteLine("9) Export word to a file (.txt)");
                Console.WriteLine("0) Back");
                Console.Write("Select: ");

                string choice = Console.ReadLine();
                if (choice == null)
                {
                    choice = "";
                }

                if (choice == "1")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    Pause();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoAddWord(d);
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoAddTranslation(d);
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoReplaceWord(d);
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoReplaceTranslation(d);
                }
                else if (choice == "6")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoDeleteWord(d);
                }
                else if (choice == "7")
                {
                    Console.Clear();
                    AllDictionaries.PrintDictionaryContent(d);
                    DoDeleteTranslation(d);
                }
                else if (choice == "8")
                {
                    Console.Clear();                  
                    DoFindTranslations(d);
                }
                else if (choice == "9")
                {
                    AllDictionaries.PrintDictionaryContent(d);
                    DoExportWord(d);
                }
                else if (choice == "0")
                {
                    return;
                }
                else
                {
                    Pause("Unknown command.");
                }
            }
        }

        static void DoAddWord(OneDictionary d)
        {
            Console.WriteLine("== Add word ==");
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            if (word == null)
            {
                word = "";
            }
            word = word.Trim();

            Console.Write("Enter translations (comma-separated): ");
            string line = Console.ReadLine();
            if (line == null)
            {
                line = "";
            }

            string[] parts = line.Split(',');
            List<string> translations = new List<string>();
            int i = 0;
            while (i < parts.Length)
            {
                string t = parts[i].Trim();
                if (t.Length > 0)
                {
                    translations.Add(t);
                }
                i++;
            }

            if (word.Length == 0)
            {
                Pause("Word cannot be empty.");
                return;
            }
            if (translations.Count == 0)
            {
                Pause("No translations provided.");
                return;
            }

            d.AddWordWithTranslations(word, translations);
            Pause("Word added or updated. Remember to save from the main menu.");
        }

        static void DoAddTranslation(OneDictionary d)
        {
            Console.WriteLine("== Add translation ==");
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            if (word == null)
            {
                word = "";
            }
            word = word.Trim();

            Console.Write("Enter translation: ");
            string tr = Console.ReadLine();
            if (tr == null)
            {
                tr = "";
            }
            tr = tr.Trim();

            if (word.Length == 0 || tr.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            bool ok = d.AddTranslation(word, tr);
            if (ok)
            {
                Pause("Translation added. Remember to save from the main menu.");
            }
            else
            {
                Pause("Word not found.");
            }
        }

        static void DoReplaceWord(OneDictionary d)
        {
            Console.WriteLine("== Replace word ==");
            Console.Write("Enter existing word: ");
            string oldW = Console.ReadLine();
            if (oldW == null)
            {
                oldW = "";
            }
            oldW = oldW.Trim();

            Console.Write("Enter new word: ");
            string newW = Console.ReadLine();
            if (newW == null)
            {
                newW = "";
            }
            newW = newW.Trim();

            if (oldW.Length == 0 || newW.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            bool ok = d.ReplaceWord(oldW, newW);
            if (ok)
            {
                Pause("Word replaced. Remember to save from the main menu.");
            }
            else
            {
                Pause("Failed. Old word may not exist or new word already exists.");
            }
        }

        static void DoReplaceTranslation(OneDictionary d)
        {
            Console.WriteLine("== Replace translation ==");
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            if (w == null)
            {
                w = "";
            }
            w = w.Trim();

            Console.Write("Enter old translation: ");
            string oldT = Console.ReadLine();
            if (oldT == null)
            {
                oldT = "";
            }
            oldT = oldT.Trim();

            Console.Write("Enter new translation: ");
            string newT = Console.ReadLine();
            if (newT == null)
            {
                newT = "";
            }
            newT = newT.Trim();

            if (w.Length == 0 || oldT.Length == 0 || newT.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            bool ok = d.ReplaceTranslation(w, oldT, newT);
            if (ok)
            {
                Pause("Translation replaced. Remember to save from the main menu.");
            }
            else
            {
                Pause("Failed. Check inputs.");
            }
        }

        static void DoDeleteWord(OneDictionary d)
        {
            Console.WriteLine("== Delete word ==");
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            if (w == null)
            {
                w = "";
            }
            w = w.Trim();

            if (w.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            bool ok = d.RemoveWord(w);
            if (ok)
            {
                Pause("Word deleted. Remember to save from the main menu.");
            }
            else
            {
                Pause("Word not found.");
            }
        }

        static void DoDeleteTranslation(OneDictionary d)
        {
            Console.WriteLine("== Delete translation ==");
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            if (w == null)
            {
                w = "";
            }
            w = w.Trim();

            Console.Write("Enter translation to delete: ");
            string t = Console.ReadLine();
            if (t == null)
            {
                t = "";
            }
            t = t.Trim();

            if (w.Length == 0 || t.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            bool lastBlocked;
            bool ok = d.RemoveTranslation(w, t, out lastBlocked);
            if (ok)
            {
                Pause("Translation deleted. Remember to save from the main menu.");
            }
            else
            {
                if (lastBlocked)
                {
                    Pause("You cannot delete the last translation of a word.");
                }
                else
                {
                    Pause("Failed. Word or translation not found.");
                }
            }
        }

        static void DoFindTranslations(OneDictionary d)
        {
            Console.WriteLine("== Find translations ==");
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            if (w == null)
            {
                w = "";
            }
            w = w.Trim();

            if (w.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            List<string> tr = d.FindTranslations(w);
            if (tr == null)
            {
                Console.WriteLine("No translations found.");
            }
            else
            {
                Console.WriteLine("Translations: " + string.Join(", ", tr));
            }
            Pause();
        }

        static void DoExportWord(OneDictionary d)
        {
            
            Console.WriteLine("== Export word ==");
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            if (w == null)
            {
                w = "";
            }

            if (w.Length == 0)
            {
                Pause("Invalid input.");
                return;
            }

            Console.Write("Enter file name (e.g., result.txt): ");
            string file = Console.ReadLine();
            if (file == null)
            {
                file = "";
            }
            file = file.Trim();
            if (file.Length == 0)
            {
                file = d.Name + "_" + w + ".txt";
            }

            string exportFolder = "Exports";
            Directory.CreateDirectory(exportFolder);
            string path = Path.Combine(exportFolder, file);
            using (StreamWriter sw = new StreamWriter(path))
            {
                List<string> list = d.FindTranslations(w);
                if (list == null)
                {
                    sw.WriteLine($"[{d.Name}] {w} -> <no translations found>");
                }
                else
                {
                    sw.WriteLine($"[{d.Name}] {w} -> {string.Join(", ", list)}");
                }
            }
            Pause("Exported to: " + path);
        }

        static void Pause()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void Pause(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string folderPath = "Dictionaries";
            Directory.CreateDirectory(folderPath);

            AllDictionaries store = new AllDictionaries();
            store.LoadAll(folderPath);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== DICTIONARIES APP ===");
                Console.WriteLine("1) Create dictionary");
                Console.WriteLine("2) List dictionaries");
                Console.WriteLine("3) Open dictionary");
                Console.WriteLine("4) Save all dictionaries (writes to dictionaries.json)");
                Console.WriteLine("5) Reload dictionaries from dictionaries.json");
                Console.WriteLine("0) Exit");
                Console.Write("Select: ");

                string choice = Console.ReadLine();
                if (choice == null)
                {
                    choice = "";
                }
                choice = choice.Trim();

                if (choice == "1")
                {
                    ShowCreateDictionary(store);
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    store.PrintAllDictionaries();
                    Pause();
                }
                else if (choice == "3")
                {
                    ShowOpenDictionary(store, folderPath);
                }
                else if (choice == "4")
                {
                    store.SaveAll(folderPath);
                    Pause("All dictionaries saved to 'dictionaries.json'.");
                }
                else if (choice == "5")
                {
                    store.LoadAll(folderPath);
                    Pause("Dictionaries reloaded from 'dictionaries.json'.");
                }
                else if (choice == "0")
                {
                    return;
                }
                else
                {
                    Pause("Unknown command.");
                }
            }
        }
    }
}
