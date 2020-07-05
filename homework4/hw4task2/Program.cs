using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hw4task2.StaticClass;
//Реализуйте задачу 1 в виде статического класса StaticClass;
//а) Класс должен содержать статический метод, который принимает на вход массив и решает
//задачу 1;
//б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен
// возвращать массив целых чисел;
//в)** Добавьте обработку ситуации отсутствия файла на диске.
//    Рощупкин
namespace hw4task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetArray();
            Console.WriteLine("Полученный массив:");
            PrintArray();
            int count = LookForPairs();
            Console.Write("\nKоличество пар элементов массива, в которых толькo одно число делится на 3: " + count);

            Console.WriteLine("\n\nМассив из файла:");
            int[] arrayFromFile = GetArrayFromFile();
            PrintArray(arrayFromFile);
            
            Console.ReadLine();
        }
    }
}
