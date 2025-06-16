namespace _04_IntroToOOP
{

    //завдання 1:
    //розробити клас «freezer», який описує морозильну камеру з дотриманням наступних вимог:
    //1. реалізувати не менше п'яти закритих полів (різних типів), 
    //що представляють основні характеристики класу.

    //2. створити не менше двох статичних полів(різних типів), що представляють спільні характеристики
    //об'єктів даного класу.
    //3. створити статичний конструктор для ініціалізації статичних полів.
    //4. обов'язковою вимогою є реалізація декількох перевантажених конструкторів, 
    //аргументи яких визначаються студентом,
    //виходячи із специфіки реалізованого класу і
    //так само реалізація конструктора за замовчуванням.
    //по можливості застосувати делегування конструкторів.

    //5. перевизначити алгоритм методу tostring(), 
    //який буде повертати інформацію про об’єкт у вигляді рядка.

    //6. перенести описи всіх методів в інший файл, використовуючи partial class.

    //7. створити масив(не менше 5 елементів) об'єктів створеного класу та показати інформацію по кожному.

    class Freezer
    {
        private static string model;
      
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value > 0)
                {
                    capacity = value;
                }
                else
                {
                    capacity = 0;

                }

            }   
        }
        
        private int maxT;

        public int MaxT
        {
            get { return maxT; }
            set
            {
                if (value>0)
                {
                    maxT = value;

                }
                else { maxT = 0; }
            
            }
            
        }

        
        private int minT;

        public int MinT
        {
            get { return minT; }
            set {
                if (value > 0) 
                {
                    minT = value;
                }
                else {  minT = 0; }
            }
        }
        private static int count;

        

        static Freezer()
        {
            count = 0;
            model = "Samsung";
        }


    }






    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
