using System;
using System.Windows;
//1. Написать метод, возвращающий минимальное из трёх чисел.
//Рощупкин
namespace hw2task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 3 числа, чтобы получить наименьшее из них.");
            var threeNumbers = GetThreeNumbers();
            var min = FindMin(threeNumbers);
            Console.WriteLine($"Наименьшее число: {min}");
            Console.ReadLine();
        }

        private static double FindMin(double[] numbers)
        {
            var min = double.MaxValue;
            for(int i = 0; i < numbers.Length;i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }
            return min;
        }

        private static double[] GetThreeNumbers()
        {
            double[] array = new double[3];
            try
            {
                array[0] = double.Parse(Console.ReadLine());
                array[1] = double.Parse(Console.ReadLine());
                array[2] = double.Parse(Console.ReadLine());
            }
            catch
            {
                MessageBox.Show("Введите корректные значения!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                array = GetThreeNumbers();
            }
            return array;
        }
    }
}
