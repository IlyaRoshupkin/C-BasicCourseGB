using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
/*1.	Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
а) используя склеивание;
б) используя форматированный вывод;
	в) используя вывод со знаком $.*/
//Рощупкин

namespace hw1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> data = Ask();
            GetInformation1Var(data);
            GetInformation2Var(data);
            GetInformation3Var(data);
            Console.ReadLine();
        }

        private static void GetInformation3Var(Dictionary<string,string> data)
        {
            Console.WriteLine($"в)\nИмя: {data["firstName"]} Фамилия: {data["lastName"]}" +
                $" Возраст: {data["age"]} Рост: {data["height"]} см Вес: {data["weight"]} кг");
        }

        private static void GetInformation2Var(Dictionary<string, string> data)
        {
            Console.WriteLine("б)\nИмя: {0} Фамилия: {1} Возраст: {2} Рост: {3} см Вес: {4} кг",
                data["firstName"], data["lastName"], data["age"], data["height"], data["weight"]);
        }

        private static void GetInformation1Var(Dictionary<string, string> data)
        {
            Console.WriteLine("а)\nИмя: " + data["firstName"] + " Фамилия: " + data["lastName"] +
                " Возраст: " + data["age"] +
                " Рост: " + data["height"] + " см Вес: " + data["weight"] + " кг");
        }

        private static Dictionary<string,string> Ask()
        {
            var data = new Dictionary<string, string>();
            Console.Write("Введите Ваше имя: ");
            data.Add("firstName", Console.ReadLine());
            Console.WriteLine();

            Console.Write($"{data["firstName"]}, введите Вашу фамилию: ");
            data.Add("lastName", Console.ReadLine());
            Console.WriteLine();

            Console.Write($"{data["firstName"]} {data["lastName"]}, введите Ваш возраст: ");
            data.Add("age", Console.ReadLine());
            Console.WriteLine();

            Console.Write($"{data["firstName"]} {data["lastName"]}, введите Ваш рост (см): ");
            data.Add("height", Console.ReadLine());
            Console.WriteLine();

            Console.Write($"{data["firstName"]} {data["lastName"]}, введите Ваш вес (кг): ");
            data.Add("weight", Console.ReadLine());
            Console.WriteLine();

            return data;
        }
    }
}
