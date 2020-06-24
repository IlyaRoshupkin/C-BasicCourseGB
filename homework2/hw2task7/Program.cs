using System;
//7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
//б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
//Рощупкин
namespace hw2task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 числа для определения диапазона.");
            int[] numbers = GetNumbers();
            PrintNumbers(numbers);
            Console.ReadLine();
            int sum = CalculateSum(numbers,0);
            Console.WriteLine("Сумма чисел диапазона: " + sum);
            Console.ReadLine();
        }

        public static int CalculateSum(int [] numbers, int sum)
        {
            int temp = numbers[0];
            if (numbers[0] <= numbers[1])
            {
                sum = sum + numbers[0];
                temp++;
                return CalculateSum(new[] { temp, numbers[1] }, sum);
            }
            return sum;
        }

        private static void PrintNumbers(int[] numbers)
        {
            int first = numbers[0];
            Console.Write(first + " ");
            if(first < numbers[1])
            {
                first++;
                PrintNumbers(new[] { first, numbers[1] });  
            }
            return;
        }

        private static int[] GetNumbers()
        {
            bool blFirst, blSec;
            int firstNum, secNum;
            do
            {
                Console.Write("Нижняя граница диапазона: ");
                blFirst = int.TryParse(Console.ReadLine(), out firstNum);
                Console.Write("Верхняя граница диапазона: ");
                blSec = int.TryParse(Console.ReadLine(), out secNum);
            } while (!(blFirst && blSec) || firstNum >= secNum);
            return new[] { firstNum, secNum };
        }
    }
}
