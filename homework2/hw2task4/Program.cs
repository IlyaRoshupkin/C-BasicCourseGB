using System;
//4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На
//выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password:
//GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь
//вводит логин и пароль, программа пропускает его дальше или не пропускает.С помощью
//цикла do while ограничить ввод пароля тремя попытками.
//Рощупкин
namespace hw2task4
{
    class Program
    {
        const string LOGIN = "root";
        const string PASSWORD = "GeekBrains";

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
                Console.WriteLine("Вход в систему неосуществлён. Количество попыток превышено.");
            else
                Console.WriteLine("Вы успешно вошли в систему.");
        }

        private static bool EnterSistem(string[] logPasswd)
        {
            return logPasswd[0] == LOGIN && logPasswd[1] == PASSWORD;
        }

        private static string[] GetData()
        {
            string[] logPasswd = new string[2];
            Console.Write("Логин: ");
            logPasswd[0] = Console.ReadLine();
            Console.Write("Пароль: ");
            logPasswd[1] = Console.ReadLine();
            return logPasswd;
        }
    }
}
