using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
//Создайте структуру Account, содержащую Login и Password.
//    Рощупкин
namespace hw4task4
{
    class Program
    {
        const string LOGIN = "root";
        const string PASSWORD = "GeekBrains";
        const string FILE = "Account.txt";

        static void Main(string[] args)
        {
            bool enter;
            int attemps = 3;
            do
            {
                Console.WriteLine("Осталось попыток: " + attemps);
                var logPasswd = GetData();
                enter = EnterSistem(logPasswd);
                attemps--;
                if (attemps == 0) break;
            } while (!enter);

            GetResult(attemps);
            Console.ReadLine();
        }

        private static void GetResult(int attemps)
        {
            if (attemps == 0)
                Console.WriteLine("\nВход в систему неосуществлён. Количество попыток превышено.");
            else
                Console.WriteLine("\nВы успешно вошли в систему.");
        }

        private static bool EnterSistem(string[] logPasswd)
        {
            return logPasswd[0] == LOGIN && logPasswd[1] == PASSWORD;
        }

        private static string[] GetData()
        {
            string[] logPasswd = new string[2];
            var account = new Account(FILE);
            try
            {
                Console.WriteLine("Имя файла: " + FILE);
                logPasswd[0] = account.Login;
                Console.Write("Логин: " + logPasswd[0]);
                logPasswd[1] = account.Password;
                Console.Write("\nПароль: " + logPasswd[1]);
            }
            catch
            {
                MessageBox.Show("Ошибка при считывании файла");
            }           
            return logPasswd;
        }
    }
}
