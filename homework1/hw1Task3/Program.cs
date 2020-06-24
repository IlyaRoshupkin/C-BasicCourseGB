using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3.	а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
//б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
//Рощупкин

namespace hw1Task3
{
    class Program
    {
        private static double x1, y1, x2, y2;

        static void Main(string[] args)
        {
            GetPoints();
            // a) double dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками: {0:F2}",/* a) dist*/ CalculateDistance(x1, y1, x2, y2));
            Console.ReadLine();
        }

        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        private static void GetPoints()
        {
            bool correctX1, correctY1, correctX2, correctY2;
            do
            {
                Console.Write("Введите координаты точки 1:\n X = ");
                correctX1 = double.TryParse(Console.ReadLine(), out x1);

                Console.Write(" Y = ");
                correctY1 = double.TryParse(Console.ReadLine(), out y1);

                Console.Write("\nВведите координаты точки 2:\n X = ");
                correctX2 = double.TryParse(Console.ReadLine(), out x2);

                Console.Write(" Y = ");
                correctY2 = double.TryParse(Console.ReadLine(), out y2);
            }
            while (!correctX1 || !correctY1 || !correctY1 || !correctY2);
        }
    }
}
