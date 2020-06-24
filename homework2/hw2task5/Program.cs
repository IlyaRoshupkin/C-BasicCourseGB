using System;
using System.Collections.Generic;
//5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
//массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
//б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
//Рощупкин
namespace hw2task5
{
    class Program
    {
        const double IDEAL_INDEX = 21.75;
        static void Main(string[] args)
        {
            var data = GetData();
            double index = CalculateIndex(data);
            Console.WriteLine("Ваш индекс массы тела, рассчитанный по формуле:\n" +
                "I = m / h^2 = {0} / {1}^2 = {2:N} [кг / м^2]",
                data["weight"], data["height"] / 100, index);
            string result = GetResult(index);
            Console.WriteLine(result);

            string advice = GetAdvice(data);
            Console.WriteLine(advice);
            Console.ReadLine();
        }

        private static string GetAdvice(Dictionary<string, double> data)
        {
            double idealWeight = IDEAL_INDEX * data["height"] * data["height"] / 10000;
            double diff = Math.Round(idealWeight - data["weight"],MidpointRounding.AwayFromZero);
            if (diff > 1)
                return "Вам необходимо набрать около" + diff+ "  кг для идеальной фигуры";
            else if (diff < -1)
                return "Вам необходимо сбросить примерно " + diff * (-1) + " кг для идеальной фигуры";
            else
                return "Вы - само совершенство!";
        }

        private static string GetResult(double index)
        {
            if (index < 16)
                return "У Вас выраженный дефицит массы тела! Срочно к врачу!";
            else if (index >= 16 && index < 18.5)
                return "У вас недостаточная масса тела. Надо подкачаться!";
            else if (index >= 18.5 && index < 25)
                return "Вы в норме.";
            else if (index >= 25 && index < 30)
                return "Стадия предожирения. Пора взяться за себя!";
            else if (index >= 30 && index < 35)
                return "У Вас резкое ожирение. Большой живот - большие пробелемы.";
            else
                return "Срочно к врачу!";
        }

        private static double CalculateIndex(Dictionary<string, double> data)
        {
            return data["weight"] / ((data["height"] * data["height"]) / 10000);
        }

        private static Dictionary<string, double> GetData()
        {
            var data = new Dictionary<string, double>();
            try
            {
                ReadData(data);
                return data;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные.\n");
                data = GetData();
            }
            return data;
        }

        private static void ReadData(Dictionary<string, double> data)
        {
            Console.Write("Введите Ваш вес (кг): ");
            data.Add("weight", double.Parse(Console.ReadLine()));

            Console.Write("Введите Ваш рост (см): ");
            data.Add("height", double.Parse(Console.ReadLine()));
        }
    }
}
