using System.Drawing;

namespace _07_OverloadOperator
{

    //    Завдання:
    //Створити два класи, які будуть описувати фігуру:
    //Square.Містить властивість A - довжина сторони квадрату.
    //Rectangle.Містить властивості A, B - довжина сторін прямокутника.
    //Написати для класів конструктор по замовчуванню та параметризований,
    //перевизначити метод ToString та перевантажити наступні оператори:

    //(++ --) - оператори змінюють розмір кожної з сторін на одиницю
    //відповідно

    //(+ - * /) - оператори створюють нову фігуру зробивши відповідну
    //операцію з кожною зі сторін.Перевіряйте, щоб сторона не була від'ємною.

    //(< > <= >= == !=) - оператори порівнюють відповідні фігури по
    //розмірам сторін.Для операторів рівності перевизначте базовий метод
    //Equals в парі з методом GetHashCode.

    //(true false) - умовою істиності фігури є перевірка чи розміри
    //сторін відмінні від нуля.
    //Також перевизначити оператори приведення типу в наступних варіантах:
    //неявне приведення(implicit) квадрату до прямокутника
    //явне приведення(explicit) прямокутника до квадрату
    //неявне приведення квадрату до типу int
    //явне приведення прямокутника до типу int


    class Square
    {
        public int A { get; set; }

        public Square() { A = 0; }
        public Square(int a) { A = a; }

        public override string ToString()
        {

            return $"A: {A}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   A == square.A;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A);
        }

        public static Square operator -(Square square)
        {
            Square res = new Square
            {
                A = -square.A,

            };
            return res;
        }
        public static Square operator --(Square p)
        {
            p.A--;

            return p;
        }
        public static Square operator ++(Square p)
        {
            p.A++;

            return p;
        }


        public static Square operator +(Square p1, Square p2)
        {
            Square res = new Square
            {
                A = p1.A + p2.A,

            };
            return res;
        }
        public static Square operator -(Square p1, Square p2)
        {
            Square res = new Square
            {
                A = p1.A - p2.A,

            };
            return res;
        }
        public static Square operator *(Square p1, Square p2)
        {
            Square res = new Square
            {
                A = p1.A * p2.A,

            };
            return res;
        }
        public static Square operator /(Square p1, Square p2)
        {
            Square res = new Square
            {
                A = p1.A / p2.A,

            };
            return res;
        }







        public static bool operator <(Square p1, Square p2)
        {
            return p1.A < p2.A;
        }

        public static bool operator >(Square p1, Square p2)
        {

            return !(p1 < p2);
        }
        public static bool operator <=(Square p1, Square p2)
        {
            return p1.A <= p2.A;
        }

        public static bool operator >=(Square p1, Square p2)
        {

            return !(p1 <= p2);
        }






        public static bool operator ==(Square p1, Square p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Square p1, Square p2)
        {
            return !(p1 == p2);
        }




        public static bool operator true(Square p)
        {
            return p.A != 0;
        }

        public static bool operator false(Square p)
        {
            return p.A == 0;
        }




        public static implicit operator int(Square p)
        {
            return p.A;
        }
        public static explicit operator double(Square p)
        {
            return p.A;
        }
        public static explicit operator Rectangle(Square p)
        {
            return new Rectangle(p.A, p.A);
        }

    }


    class Rectangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public Rectangle() { A = 0; B = 0; }
        public Rectangle(int a, int b) { A = a; B = b; }
        public override string ToString()
        {

            return $"A: {A}. B : {B}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   A == rectangle.A &&
                   B == rectangle.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public static Rectangle operator -(Rectangle Rectangle)
        {
            Rectangle res = new Rectangle
            {
                A = -Rectangle.A,
                B = -Rectangle.B
            };
            return res;
        }
        public static Rectangle operator ++(Rectangle Rectangle)
        {

            Rectangle.A++;
            Rectangle.B++;
            return Rectangle;
        }
        public static Rectangle operator --(Rectangle Rectangle)
        {
            Rectangle.A--;
            Rectangle.B--;
            return Rectangle;
        }

               

        public static Rectangle operator +(Rectangle p1, Rectangle p2)
        {
            Rectangle res = new Rectangle
            {
                A = p1.A + p2.A,
                B = p1.B + p2.B
            };
            return res;
        }
        public static Rectangle operator -(Rectangle p1, Rectangle p2)
        {
            Rectangle res = new Rectangle
            {
                A = p1.A - p2.A,
                B = p1.B - p2.B
            };
            return res;
        }
        public static Rectangle operator *(Rectangle p1, Rectangle p2)
        {
            Rectangle res = new Rectangle
            {
                A = p1.A * p2.A,
                B = p1.B * p2.B
            };
            return res;
        }
        public static Rectangle operator /(Rectangle p1, Rectangle p2)
        {
            Rectangle res = new Rectangle
            {
                A = p1.A / p2.A,
                B = p1.B / p2.B
            };
            return res;
        }




        public static bool operator <(Rectangle p1, Rectangle p2)
        {
            return p1.A + p1.A < p2.B + p2.B;
        }

        public static bool operator >(Rectangle p1, Rectangle p2)
        {
            
            return !(p1<p2);
        }
        public static bool operator <=(Rectangle p1, Rectangle p2)
        {
            return p1.A + p1.B <= p2.A + p2.B;
        }

        public static bool operator >=(Rectangle p1, Rectangle p2)
        {
            
            return !(p1 <= p2);
        }




			

        public static bool operator ==(Rectangle p1, Rectangle p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Rectangle p1, Rectangle p2)
        {
            return !(p1 == p2);
        }




        public static bool operator true(Rectangle p)
    {
        return p.A != 0 || p.B != 0;
    }

    public static bool operator false(Rectangle p)
    {
        return p.A == 0 && p.B == 0;
    }

        public static implicit operator int(Rectangle p)
    {
        return p.A + p.B;
    }
    public static explicit operator double(Rectangle p)
    {
        return p.A + p.B;
    }
    public static explicit operator Square(Rectangle p)
    {
            return new Square(p.A+p.B);
}







    }







    internal class Program
    {

        static void Main(string[] args)
        {

        }
    }
}

