using System;
using System.Runtime;

namespace _05_StructRefOut
{
    //    Завдання 1:
    //Описати клас з ім'ям Worker, що містить наступні поля:
    //прізвище та ініціали працівника;
    //    вік працівника;
    //    ЗП працівника;
    //    дата прийняття на роботу.
    //Написати програму, що виконує наступні дії:
    //    введення з клавіатури даних в масив, що складається 
    //з п'яти елементів типу Worker (записи повинні бути впорядковані за алфавітом);

    //    якщо значення якогось параметру введено не в відповідному 
    //форматі - згенерувати відповідний exception.

    //    вивід на екран прізвища працівника, стаж 
    //роботи якого перевищує введене з клавіатури значення.

    //Рекомендація: перевірку формата даних та 
    //    генерацію винятку виконуйте в блоці set{ }
    //    для кожної властивості класа Worker.

    class Worker
    {
        

        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Name cannot be null or empty.");
                }

            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set 
            {
                if (age<18 && age>100)
                {
                    throw new Exception("Age cannot be lower than 18 and higher than 60");
                }
                age = value; 
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private DateTime hireDate;
        public DateTime HireDate
        {
            get { return hireDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Hire date cannot be in the future.");
                }
                hireDate = value;
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
