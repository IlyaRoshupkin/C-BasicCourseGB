using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayClassLib;
//3. а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий
//массив определенного размера и заполняющий массив числами от начального значения с
//заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, метод
//Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый
//массив, остается без изменений), метод Multi, умножающий каждый элемент массива на
//определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
//б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу
//библиотеки
//е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
//    Рощупкин
namespace hw4task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Дан массив: ");
            var array = new ArrayClass(23, 31.2, 2.9);
            array.PrintArray();
            Console.WriteLine("\nСумма элементов: "+array.Sum);

            Console.WriteLine("\nИнвентированный массив: ");
            var invArr = new ArrayClass(array.Inverse());
            invArr.PrintArray();

            Console.WriteLine("\nУмножаем элементы на 3:");
            invArr.Multi(3);
            invArr.PrintArray();

            Console.WriteLine("\nKоличество максимальных элементов: " + invArr.MaxCount);

            Console.WriteLine("Частота вхождения каждого элемента в массив:");
            array.PrintFrequency();
            Console.ReadLine();
        }
    }
}
