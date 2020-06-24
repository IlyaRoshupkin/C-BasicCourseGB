using System;
//6. * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
//000. «Хорошим» называется число, которое делится на сумму своих цифр.Реализовать
//подсчёт времени выполнения программы, используя структуру DateTime.
//Рощупкин
namespace hw2task6
{
    class Program
    {
        const int MIN = 1;
        const int MAX = 1000000000;
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int count = CountGoodNumbers(MIN, MAX);
            Console.WriteLine($"Количество \"хороших\" чисел в диапазоне от {MIN} до {MAX} - {count}");
            Console.WriteLine((DateTime.Now - start));
            Console.ReadLine();
            //выполняется около 2 минут
        }

        private static int CountGoodNumbers(int min, int max)
        {
            int count = 0;
            for(int number = min;number <= max; number++)
            {
                int temp = number;
                int sum = 0;
                while (temp != 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }
                if (number % sum == 0)
                    count++;
            }
            return count;
        }
    }
}
