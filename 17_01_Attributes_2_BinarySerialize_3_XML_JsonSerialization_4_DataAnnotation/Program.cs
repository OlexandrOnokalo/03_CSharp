using System.ComponentModel.DataAnnotations;

namespace _17_01_Attributes_2_BinarySerialize_3_XML_JsonSerialization_4_DataAnnotation
{
    //    1. Реалізувати додаток з наступним функціоналом:

    //a)Консольне меню
    //b)В якості колекції для даних використати Словник
    //(Dictionary<TKey, TValue>), який реалізує CRUD
    //c) Значущими елементами словника є екземпляри класу User

    //2. Класс User повинен містити наступні властивості:
    //a) Id - int унікальні значення в діапазоні 1000 - 9999
    //b) Login - string, лише друємі символи без спец сиволів
    //c) Password - string, лише друємі символи без спец сиволів,
    //довжина не менше 8ми сиволів,
    //d) ConfirmPassword - string, лише друємі символи без спец
    //сиволів, довжина не менше 8ми сиволів,
    //e) E-mail - string, валідація згідно загальних правил
    //стандарту
    //f) CreditCard - валідація згідно загальних правил стандарту
    //g)Phone - валідація згідно українського формату +38-0**-
    //***-**-**

    //3. Всі властивості містять відповідні атрибути валідації, з
    //перевизначиними повідомленнями, згідно яких модель після
    //перевірки записується в словник.Якщо якісь властивості не
    //проходять валідацію - користувач змушений ввести їх
    //повторно.

    //4. Після вибору відповідного пункту меню екземпляр словника
    //серіалізується і зберігається у файл. (робиться резервна копія)

    //5. Після вибору відповідного пунктуц меню дані з файлу
    //читаються і десеріалізуються переписуючи поточний
    //екземпляр.


    [Serializable]
    class User
    {
        [Range(1000,9999)]
        public int Id { get; set; }

        [Required] 
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Not confirm password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [Phone]
        public string Phone { get; set; }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
