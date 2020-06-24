using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2. Написать метод подсчета количества цифр числа.
//Рощупкин
namespace hw2task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolNumber;
            double number;
            do
            {
                Console.Write("Введите число: ");
                boolNumber = double.TryParse(Console.ReadLine(), out number);
            } while (!boolNumber);
            
            int amountFigures = CountFigures(number);
            Console.WriteLine($"Количество цифр в числе: {amountFigures}");
            Console.ReadLine();
        }

        private static int CountFigures(double number)
        {
            string strNumber = number.ToString();
            if (strNumber.Contains(','))
                return strNumber.Length - 1;
            return strNumber.Length;
        }
    }
}
