using System.ComponentModel.DataAnnotations;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace _06_Exception
{
    //    Завдання 1
    //Користувач вводить до рядка з клавіатури набір сим-
    //волів від 0-9. Необхідно перетворити рядок на число ціло-
    //го типу.Передбачити випадок виходу за межі діапазону,
    //який визначається типом int. Використовуйте механізм
    //виключень.
    //Завдання 2
    //Створіть клас «Кредитна картка». Вам необхідно зберіга-
    //ти інформацію про номер картки, ПІБ власника, CVC, дату
    //завершення роботи картки і т.д.Передбачити механізми
    //ініціалізації полів класу.Якщо значення для ініціалізації
    //неправильне, генеруйте виняток.
    //Завдання 3
    //Користувач вводить до рядка з клавіатури математич-
    //ний вираз. Наприклад, 3*2*1*4. Програма має підрахувати
    //результат введеного виразу. У рядку можуть бути лише
    //цілі числа і оператор*. Для обробки помилок введення
    //використовуйте механізм виключень.

    using System;

    class CreditCard
    {
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 16)
                {
                    number = value;
                }
                else
                {
                    throw new ArgumentException("Card number must be exactly 16 digits.");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Cardholder name cannot be empty.");
                }
            }
        }

        private string cvc;
        public string Cvc
        {
            get { return cvc; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 3)
                {
                    cvc = value;
                }
                else
                {
                    throw new ArgumentException("CVC must be exactly 3 digits.");
                }
            }
        }

        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set
            {
                if (value > DateTime.Now)
                {
                    data = value;
                }
                else
                {
                    throw new ArgumentException("Expiration date must be in the future.");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine()!;
                int result = int.Parse(input);
                Console.WriteLine($"Parsed number: {result}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Number is too large or too small for type int.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
            }

            
            try
            {
                CreditCard creditCard = new CreditCard();

                Console.Write("Enter 16-digit card number: ");
                creditCard.Number = Console.ReadLine()!;

                Console.Write("Enter cardholder name: ");
                creditCard.Name = Console.ReadLine()!;

                Console.Write("Enter 3-digit CVC: ");
                creditCard.Cvc = Console.ReadLine()!;

                Console.Write("Enter expiration date (yyyy-MM-dd): ");
                creditCard.Data = DateTime.Parse(Console.ReadLine()!);

                Console.WriteLine("Card added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
            try
            {
                Console.Write("Enter a math expression (e.g. 3*2*4): ");
                string expression = Console.ReadLine()!;
                string[] parts = expression.Split('*');

                int result = 1;
                foreach (string part in parts)
                {
                    result *= int.Parse(part.Trim());
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
