using System;
using System.Collections.Generic;
//3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
//положительных чисел.
//Рощупкин
namespace hw2task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа. \"0\" - выход.");
            var numbers = GetNumbers();
            var sum = CalculateSumEvenPositive(numbers);
            Console.WriteLine("Сумма всех нечетных положительных чисел: " + sum);
            Console.ReadLine();
        }

        private static int CalculateSumEvenPositive(List<double> numbers)
        {
            int sum = 0;
            foreach(double number in numbers)
            {
                if (number % 2 == 1 && number > 0)
                    sum += (int)number;
            }
            return sum;
        }

        private static List<double> GetNumbers()
        {
            int i = 0;
            double number;
            List<double> numbers = new List<double>();
            while (true)
            {
                Console.Write($"Число № {i + 1} : ");
                bool blNumber = double.TryParse(Console.ReadLine(),out number);
                if (!blNumber)
                {
                    Console.WriteLine("Введено не число!");
                    continue;
                }
                if (number == 0) break; 
                numbers.Add(number);
                i++;
                //Console.WriteLine();
            }
            return numbers;
        }
    }
}
