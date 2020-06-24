using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//4.	Написать программу обмена значениями двух переменных:
//а) с использованием третьей переменной;
//б) * без использования третьей переменной.
//Рощупкин
namespace hw1Task4
{
    class Program
    {
        private static int a, b;

        static void Main(string[] args)
        {
            GetData();
            MixUp1();
            Console.WriteLine($"После обмена \"а\" = {a} \"b\" = {b}");
            MixUp2();
            Console.WriteLine($"После обмена \"а\" = {a} \"b\" = {b}");
            Console.ReadLine();
        }

        private static void MixUp2()
        {
            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
        }

        private static void MixUp1()
        {
            int t = a;  
            a = b;       
            b = t;
        }

        private static void GetData()
        {
            try
            {
                Console.WriteLine("Введите целочисленные переменные.");
                Console.Write("Введите переменную \"а\" = ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Введите переменную \"b\" = ");
                b = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nНекорректные переменные. Попробуйте ещё раз.");
                GetData();
            }
        }
    }
}
