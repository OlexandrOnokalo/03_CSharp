namespace _14_Dictionary
{

    //    Завдання 1:
    //Реалізувати клас PhoneBook на базі дженерік колекції
    //Dictionary<TKey, TValue>,
    //передбачити додавання, зміну, пошук та видалення записів.


    //Завдання 2***. Програма «Статистика»
    //Підрахувати, скільки разів кожне слово зустрічається у заданому
    //текстi. Результат записати до колекції Dictionary<
    //TKey, TValue>.Тексt використовувати із додатка 1.
    //Вивести статистику за текстом у вигляді таблиці (рис. 1).
    //Додаток 1.
    //Ось будинок, який збудував Джек.А це пшениця, яка
    //у темній коморі зберігається у будинку, який збудував
    //Джек.А це веселий птах-синиця, який часто краде
    //пшеницю, яка в темній коморі зберігається у будинку,
    //який збудував Джек.

    class Abonent
    {
        public string _name { get; set; } }

    class PhoneBook
    {
        Dictionary<string, Abonent> _phones = new Dictionary<string, Abonent>();

        public void AddAbonent(string key, Abonent abonent)
        {
            if (!_phones.ContainsKey(key)) { _phones[key] = abonent; }
            else
            {
                Console.WriteLine("Abonent allready in phonebook");
            }
        }

        public void RemoveAbonent(string key)
        {
            if (!_phones.ContainsKey(key)) return;
            else
            {
                _phones.Remove(key);
            }

        }

        public void EditAbonent(string key, Abonent)
        {
            if (_phones.ContainsKey(key))
            {
                _phones.
            }


        }


    }






    internal class Program

    {
        static void Main(string[] args)
        {
            
        }
    }
}
