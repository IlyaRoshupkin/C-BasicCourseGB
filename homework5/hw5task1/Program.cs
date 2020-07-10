using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//1. Создать программу, которая будет проверять корректность ввода логина.Корректным
//логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита
//или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) ** с использованием регулярных выражений.
//    Рощупкин
namespace hw5task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                if (login == "0") break;

                if (Check(login))
                    Console.WriteLine("\nЭто корректный логин.\n");
                else
                    Console.WriteLine("\nЭто некорректный логин.\n");
                Console.WriteLine("Для выхода введите \"0\"");

            }

            Console.WriteLine("\nТеперь пароль проверяется с помощью регулярных выражений.\n");
            while (true)
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                if (login == "0") break;

                if (CheckWithRegex(login))
                    Console.WriteLine("\nЭто корректный логин.\n");
                else
                    Console.WriteLine("\nЭто некорректный логин.\n");
                Console.WriteLine("Для выхода введите \"0\"");

            }

            Console.ReadLine();
        }

        private static bool CheckWithRegex(string login)
        {
            Regex login_regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{2,9}$");
            return login_regex.IsMatch(login);
        }

        private static bool Check(string login)
        {
            if (login.Length < 2 || login.Length > 10)
                return false;
            if (char.IsDigit(login[0]))
                return false;
            login = login.ToLower();
            foreach (char symb in login)
            {
                if (char.IsLetterOrDigit(symb))
                    if (char.IsLetter(symb))
                        if (symb < 'a' || symb > 'z')
                            return false;
            }
            return true;
        }
    }
}
