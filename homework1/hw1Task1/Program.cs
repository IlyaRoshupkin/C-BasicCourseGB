using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2.	Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах.
//Рощупкин

namespace hw1Task2
{
    class Program
    {
        static double weight, height;
        static void Main(string[] args)
        {
            GetData();
            double index = CalculateIndex(weight, height);
            Console.WriteLine("Ваш индекс массы тела, рассчитанный по формуле:\n" +
                "I = m / h^2 = {0} / {1}^2 = {2:N} кг / м^2",
                weight,height / 100,index);
            Console.ReadLine();
        }

        private static double CalculateIndex(double weight, double length)
        {
            return weight / ((length * length) / 10000);
        }

        private static void GetData()
        {
            bool isRightWeight, isRightLength;
            do
            {
                Console.Write("Введите Ваш вес (кг): ");
                isRightWeight = double.TryParse(Console.ReadLine(), out weight);

                Console.Write("Введите Ваш рост (см): ");
                isRightLength = double.TryParse(Console.ReadLine(), out height);
                Console.WriteLine();
            }
            while (!isRightWeight || !isRightLength);
        }
    }
}
