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
}
