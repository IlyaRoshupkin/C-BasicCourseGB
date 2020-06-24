using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5.	а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
//б) * Сделать задание, только вывод организовать в центре экрана.
// в) ** Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
//Рощупкин

namespace hw1Task5
{
    class Program
    {
        static string firstName, lastName, city;
        static void Main(string[] args)
        {
            GetData();

            //а) 
            Console.Clear();
            Console.WriteLine($"Имя: {firstName} Фамилия: {lastName} Город проживания: {city}");
            Console.ReadKey();

            //б) 
            string txt = "Имя: " + firstName + " Фамилия: " + lastName + " Город проживания: " + city;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - txt.Length / 2, Console.WindowHeight / 2);
            Console.WriteLine(txt);
            Console.ReadKey();

            //в)
            Print();
            Console.ReadLine();
        }

        private static void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            string txt = "Имя: " + firstName + " Фамилия: " + lastName + " Город проживания: " + city;
            Console.SetCursorPosition(Console.WindowWidth / 2 - txt.Length / 2, Console.WindowHeight / 2);
            Console.WriteLine(txt);
        }

        private static void GetData()
        {
            Console.Write("Введите Ваше имя: ");
            firstName = Console.ReadLine();
            Console.Write("Введите Вашу фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Введите Ваш город проживания: ");
            city = Console.ReadLine();
        }
    }
}
