using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции
//типа double (double, double). Продемонстрировать работу на функции с функцией a* x^2 и
// функцией a* sin(x).
//    Рощупкин
namespace hw6task1
{
    public delegate double Fun(double x0,double a);
    class Program
    {
        public static void Table(Fun F, double[] values)
        {
            double x = values[0];
            Console.WriteLine("----- X ----- Y -----");
            while (x <= values[1])
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", values[0], F(x,values[3]));
                x += values[2];
            }
            Console.WriteLine("---------------------");
        }

        public static double SqureXTimesAFunc(double x, double a)
        {
            return  x * x * a;
        }

        public static double SinXTimesAFunc(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            while (true)
            {
                try
                {
                    double[] values = GetValues();
                    
                    Console.WriteLine("Таблица функции a * x^2:");
                    Table(SqureXTimesAFunc, values);

                    Console.WriteLine("Таблица функции a * sin(x):");
                    Table(SinXTimesAFunc, values);

                    Console.ReadLine();
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private static double[] GetValues()
        {
            Console.Write("Введите диапазон значений х.\nx0 = ");
            double x0 = double.Parse(Console.ReadLine());
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Шаг между значениями х: ");
            double dx = double.Parse(Console.ReadLine());
            Console.Write("Коэфициент а = ");
            double a = double.Parse(Console.ReadLine());
            return new[] { x0, x1, dx, a };
        }
    }
}
