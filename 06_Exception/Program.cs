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

    class CreditCard
    {
        private string number;

        public string Number
        {
            get { return number; }
            set 
            {
                if (number.Length == 16)
                {
                    number = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
            }
                
        }
        
        private string? cvc;

        public string? Cvc
        {
            get { return cvc; }
            set
            {
                if (number.Length == 3)
                {
                    number = value!;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set {
                if (value > DateTime.Now)
                {
                    data = value;
                }
                else
                {
                    throw new ArgumentException();
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
                Console.WriteLine("Enter number: ");
                int n = int.Parse(Console.ReadLine()!);
                Console.WriteLine(n);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
                try
                {
                    CreditCard creditCard = new CreditCard();
                    creditCard.Data = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }





        }
    }
}
