using System;
using System.Reflection;
//1. С помощью рефлексии выведите все свойства структуры DateTime
//    Рощупкин
namespace hw8task1
{
    
class Program
    {
        static void Main()
        {
            Type props = typeof(DateTime);
            foreach (var prop in props.GetProperties())
                Console.WriteLine(prop.Name);
            Console.ReadLine();
        }
    }
}

