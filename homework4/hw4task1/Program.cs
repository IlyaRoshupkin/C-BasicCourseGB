using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые
//значения от –10 000 до 10 000 включительно.Заполнить случайными числами.Написать
//программу, позволяющую найти и вывести количество пар элементов массива, в которых только
//одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих
//элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
//    Рощупкин
namespace hw4task1
{
    class Program
    {
        const int LENGTH = 20;
        const int MIN = -10000;
        const int MAX = 10000;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Полученный массив:");
            int[] array = GetArray(LENGTH);
            PrintArray(array);
            int count = LookForPairs(array);
            Console.Write("\nKоличество пар элементов массива, в которых толькo одно число делится на 3: " + count);
            Console.ReadLine();
        }

        private static void PrintArray(int[] array)
        {
            foreach (int num in array)
                Console.Write(num + " | ");
        }

        private static int LookForPairs(int[] array)
        {
            int count = 0;
            for(int i = 0; i < array.Length-1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 != 0 ||
                    array[i] % 3 != 0 && array[i + 1] % 3 == 0)
                    count++;
            }
            return count;
        }

        private static int[] GetArray(int lENGTH)
        {
            int[] array = new int[20];
            for(int i = 0; i < LENGTH; i++)
                array[i] = rnd.Next(MIN, MAX + 1);
            return array;
        }
    }
}
