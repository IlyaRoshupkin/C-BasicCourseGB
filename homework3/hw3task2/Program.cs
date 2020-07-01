using System;
//2. а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
//Требуется подсчитать сумму всех нечётных положительных чисел.Сами числа и сумму
//вывести на экран, используя tryParse.
//    Рощупкин
namespace hw3task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите числа:");
            double sum = GetPositiveOddSum();
            Console.WriteLine("Сумма нечётных положительных чисел: " + sum);
            Console.ReadLine();
        }

        private static double GetPositiveOddSum()
        {
            double sum = 0;
            int count = 1;
            while (true)
            {
                Console.Write("Число №" + count + " : ");
                bool blNum = double.TryParse(Console.ReadLine(), out double num);
                if (!blNum)
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                else if (num == 0) break;
                else if (num > 0 && num % 2 == 1)
                {
                    sum += num;
                    count++;
                }
                else
                    count++;
            }
            return sum;
        }
    }
}
