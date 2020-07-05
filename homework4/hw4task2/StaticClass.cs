using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4task2
{
    public static class StaticClass
    {
        const int LENGTH = 20;
        const int MIN = -10000;
        const int MAX = 10000;
        static readonly Random rnd = new Random();
        static readonly int[] array = new int[LENGTH];

        public static void PrintArray(int[] arr) 
        {
            foreach (int num in arr)
                Console.Write(num + " | ");
        }

        public static void PrintArray()
        {
            foreach (int num in array)
                Console.Write(num + " | ");
        }

        public static int LookForPairs()
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 != 0 ||
                    array[i] % 3 != 0 && array[i + 1] % 3 == 0)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Метод возвращает массив чисел из файла. Для корректного выполнения операции числа в документы должны располагаться
        /// в следующем порядке:
        /// 23
        /// 1
        /// 34
        /// и т.д.
        /// То есть на одной строке - одно число.
        /// </summary>
        /// <returns></returns>
        public static int[] GetArrayFromFile()
        {
            List<int> nums = new List<int>();
            try
            {
                StreamReader streamReader = new StreamReader("data.txt");
                bool bNum;
                while (true)
                {
                    bNum = int.TryParse(streamReader.ReadLine(), out int num);
                    if (bNum) nums.Add(num);
                    else break;
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при считывании файла.");
            }
            return nums.ToArray();
        }

        public static int[] GetArray()
        {
            for (int i = 0; i < LENGTH; i++)
                array[i] = rnd.Next(MIN, MAX + 1);
            return array;
        }
    }
}

