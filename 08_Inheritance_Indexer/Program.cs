using System;

namespace _08_Inheritance_Indexer
{
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

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Triangle"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Triangle"); }
    }

    class Square : GeometricFigure
    {
        public int A { get; set; }

        public Square(int a)
        {
            A = a;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Square"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Square"); }
    }

    class Rhombus : GeometricFigure
    {
        public int A { get; set; }
        public int H { get; set; }

        public Rhombus(int a, int h)
        {
            A = a;
            H = h;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Rhombus"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Rhombus"); }
    }

    class Rectangle : GeometricFigure
    {
        public int A { get; set; }
        public int B { get; set; }

        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Rectangle"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Rectangle"); }
    }

    class Parallelogram : GeometricFigure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int H { get; set; }

        public Parallelogram(int a, int b, int h)
        {
            A = a;
            B = b;
            H = h;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Parallelogram"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Parallelogram"); }
    }

    class Trapezoid : GeometricFigure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public Trapezoid(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Trapezoid"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Trapezoid"); }
    }

    class Circle : GeometricFigure
    {
        public int R { get; set; }

        public Circle(int r)
        {
            R = r;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Circle"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Circle"); }
    }

    class Ellipse : GeometricFigure
    {
        public int A { get; set; }
        public int B { get; set; }

        public Ellipse(int a, int b)
        {
            A = a;
            B = b;
        }

        public override void GetArea() { Console.WriteLine("Getting Area of Ellipse"); }
        public override void GetPerimeter() { Console.WriteLine("Getting Perimeter of Ellipse"); }
    }

    class CompositeFigure : GeometricFigure
    {
        private GeometricFigure[] figures;

        public CompositeFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }

        public override void GetArea()
        {
            Console.WriteLine("Getting Area of Composite Figure:");
            foreach (var figure in figures)
            {
                figure.GetArea();
            }
        }

        public override void GetPerimeter()
        {
            Console.WriteLine("Getting Perimeter of Composite Figure:");
            foreach (var figure in figures)
            {
                figure.GetPerimeter();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square(4);
            Rhombus rhombus = new Rhombus(5, 3);
            Rectangle rectangle = new Rectangle(4, 6);
            Parallelogram parallelogram = new Parallelogram(5, 7, 3);
            Trapezoid trapezoid = new Trapezoid(3, 4, 5, 6);
            Circle circle = new Circle(5);
            Ellipse ellipse = new Ellipse(4, 2);

            triangle.GetArea();
            triangle.GetPerimeter();

            square.GetArea();
            square.GetPerimeter();

            rhombus.GetArea();
            rhombus.GetPerimeter();

            rectangle.GetArea();
            rectangle.GetPerimeter();

            parallelogram.GetArea();
            parallelogram.GetPerimeter();

            trapezoid.GetArea();
            trapezoid.GetPerimeter();

            circle.GetArea();
            circle.GetPerimeter();

            ellipse.GetArea();
            ellipse.GetPerimeter();

            CompositeFigure composite = new CompositeFigure(
                triangle, square, rectangle, circle
            );

            composite.GetArea();
            composite.GetPerimeter();
        }
    }
}
