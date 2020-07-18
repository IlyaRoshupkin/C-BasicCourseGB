using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2. Модифицировать программу нахождения минимума функции так, чтобы можно было
//передавать функцию в виде делегата.
//а) Сделать меню с различными функциями и представить пользователю выбор, для какой
//функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов,
//в котором хранятся различные функции.
//б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она
//возвращает минимум через параметр(с использованием модификатора out).
//    Рощупкин

namespace hw6task2
{
    class Program
    {
        public delegate double Functions(double x);

        private static double Sin(double x)
        {
            return Math.Sin(x);
        }

        private static double Cos(double x)
        {
            return Math.Cos(x);
        }

        private static double Tan(double x)
        {
            return Math.Tan(x);
        }

        private static double Cotan(double x)
        {
            return Math.Atan(x); 
        }

        private static double Sinc(double x)
        {
            return Math.Sin(x) / x;
        }

        public static void SaveFunc(string fileName, Functions func, double [] data)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = data[0];
            while (x <= data[1])
            {
                bw.Write(func(x));
                x += data[2]; 
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            double[] values = new double[fs.Length / sizeof(double)];

            for (int i = 0; i < values.GetLength(0); i++)
            {
                values[i] = d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return values;
        }
        static void Main(string[] args)
        {
            Functions[] functions = CreateFunctions();
            
            while (true)
            {
                try
                {
                    PrintMenu();
                    
                    int choise = int.Parse(Console.ReadLine());
                    double[] data = GetData();
                    
                    if(data[0]>=data[1] || data[2] <= 0)
                    {
                        Console.WriteLine("Некорректные значения.");
                        continue;
                    }
                    SaveFunc("data.bin", functions[choise - 1], data);
                    double[] results = Load("data.bin", out double min);
                    Console.WriteLine("Минимум функции: " + min);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private static double[] GetData()
        {
            Console.Write("Левый интервал \"a\": ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Правый интервал \"b\": ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Шаг \"dx\": ");
            double dx = double.Parse(Console.ReadLine());
            return new[] { a, b, dx };
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Выберете функцию:");
            Console.WriteLine("1 - Синус");
            Console.WriteLine("2 - Косинус");
            Console.WriteLine("3 - Тангенс");
            Console.WriteLine("4 - Котангенс");
            Console.WriteLine("5 - Синус Котельникова");
        }

        private static Functions[] CreateFunctions()
        {
            return new Functions[] { Sin, Cos, Tan, Cotan, Sinc };
        }
    }
}

