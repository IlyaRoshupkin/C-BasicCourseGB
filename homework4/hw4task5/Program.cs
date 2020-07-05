using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleArrayClassLib;
//5. * а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать
// конструктор, заполняющий массив случайными числами.Создать методы, которые возвращают
//сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство,
//возвращающее минимальный элемент массива, свойство, возвращающее максимальный
//элемент массива, метод, возвращающий номер максимального элемента массива(через
//параметры, используя модификатор ref или out).
//** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные
// в файл.
// ** в) Обработать возможные исключительные ситуации при работе с файлами.
//    Рощупкин
namespace hw4task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Массив со случайными числами: ");
            var array = new DoubleArray(5, 3);
            array.PrintArray();

            Console.WriteLine("Сумма элементов: " + array.GetSum());
            Console.WriteLine("Сумма элементов, которые больше пяти: " + array.GetSum(5));

            Console.WriteLine("Максимальное число: " + array.Max);
            int[] indexMax = new int[2];
            array.GetMax(ref indexMax);
            Console.WriteLine("Индекс максимума: " + 
                indexMax[0] + " , " + indexMax[1]);

            Console.WriteLine("Минимальное число: " + array.Min);

            Console.WriteLine("Запишем этот массив в файл \"RandomArray.txt\"");
            array.WriteDoubleArray("RandomArray.txt");

            Console.WriteLine("Считаем массив из файла \"Array.txt\"");
            var arrayFromFile = new DoubleArray("Array.txt");
            arrayFromFile.PrintArray();

            Console.WriteLine("Реализован индексатор. Изменяем значение элемента с индексом [1,1] на 10");
            array[1, 1] = 10;
            array.PrintArray();

            Console.ReadLine();
        }
    }
}
