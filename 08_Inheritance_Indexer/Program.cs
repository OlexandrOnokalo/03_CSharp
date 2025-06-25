using System.Drawing;

namespace _08_Inheritance_Indexer
{
    //    Завдання 1:

    //Розробити абстрактний клас «Геометрична Фігура» з методами:
    //GetArea – обчислення площі
    //GetPerimeter – обчислення периметра

    //Описати похідні класи:
    //Трикутник
    //Квадрат
    //Ромб
    //Прямокутник
    //Паралелограм
    //Трапеція
    //Коло
    //Еліпс.
    //Класи повинні містити характеристики певної фігури та 
    //    конструктори, які їх встановлять.
    //Також реалізувати клас «Складена Фігура», 
    //    який буде складатися з будь-якої кількості 
    //    «Геометричних фігур» (міститиме масив фігур). 
    //    Класі повинен містити конструктор, який 
    //    використовуючи params прийматиме перелік 
    //    фігур з який він буде складатися.

    abstract class GeometricFigure
    {
        public abstract void GetArea();
        public abstract void GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override void GetArea() { Console.WriteLine("Getting Area of Triangle"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Triangle"); }
    }


//        Square
//Rhombus
// Rectangle
// Parallelogram
// Trapezoid
// Circle
// Ellipse.

        class Square :GeometricFigure
        {
            public int A { get; set; }
            public override void GetArea() { Console.WriteLine("Getting Area of Square"); }
            public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Square"); }
        }

        class Rhombus:GeometricFigure
        {
            public int A { get; set; }
            public int H { get; set; }
            

            public override void GetArea() { Console.WriteLine("Getting Area of Triangle"); }
            public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Triangle"); }
        }













    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
