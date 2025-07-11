using System.Text;

namespace _16_WorkWithFile
{
//    Завдання 1:
//Додаток дозволяє користувачеві переглядати вміст файлу.
//Користувач вводить шлях до файлу. Якщо файл існує, 
//його вміст відображається на екрані.Якщо файл не існує, 
//виведіть повідомлення про помилку.
//Завдання 2:
//Користувач вводить значення елементів масиву з клавіатури.
// Додаток надає можливість зберігати вміст масиву у файл.
//Завдання 3:
//Додайте до другого завдання можливість завантажувати масив із файлу.

    internal class Program
    {

        static void WriteTextFormat(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("Hello!");

            }
        }
        static void ReadTextFormat(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                //sr.Read();
                //sr.ReadBlock();
                //sr.ReadLine();
                //sr.ReadToEnd();

                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }


        static void Main(string[] args)
        {
           string path = Console.ReadLine();
            ReadTextFormat(path);


        }
    }
}
