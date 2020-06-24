using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//6.	* Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
//Рощупкин
namespace hw1Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 10, c = 10;
            double x1, x2;
            UsefulMethods.SquareEqualSol(a, b, c, out x1, out x2);
            Console.WriteLine($"x1 = {x1:N}, x2 = {x2:N}");
            Console.ReadLine();

            Console.Clear();
            int length = 10;
            string password = UsefulMethods.GeneratePassword(length);
            Console.WriteLine("Сгенерированный пароль: " + password);
            Console.ReadLine();
        }
    }
}
