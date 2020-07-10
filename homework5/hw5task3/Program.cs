using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3. * Для двух строк написать метод, определяющий, является ли одна строка перестановкой
//другой.
//Например:
//badc являются перестановкой abcd.
//    Рощупкин
namespace hw5task3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nВведите корректно две строки для их сравнения.");
                string[] lines = GetLines();
                PrintResultOfComparing(lines);
            }
        }

        private static bool CheckTwoLines(string[] lines)
        {
            if (lines[0] == lines[1])
            {
                Console.WriteLine("Строки полностью совпадают.");
                return true;
            }
            Dictionary<char, int> firstLineSymbs = CreateDict(lines[0]);
            Dictionary<char, int> secondLineSymbs = CreateDict(lines[1]);

            return CompareLines(firstLineSymbs,secondLineSymbs);
        }

        private static void PrintResultOfComparing(string[] lines)
        {
            if (CheckTwoLines(lines))
                Console.WriteLine("\""+lines[0] + "\" является перестановкой \"" + lines[1]+"\"");
            else
                Console.WriteLine("\""+lines[0] + "\" не является перестановкой \"" + lines[1]+"\"");
        }

        private static string[] GetLines()
        {
            string firstLine, secondLine;
            do
            {
                Console.Write("\nПервая строка: ");
                firstLine = Console.ReadLine();
                Console.Write("\nВторая строка: ");
                secondLine = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(firstLine) || String.IsNullOrWhiteSpace(secondLine));

 
            return new[] { firstLine, secondLine };
        }
         /// <summary>
        /// Метод сравнения строк. Выглядит не очень красиво, но принцип работы прост.
        /// Если количество символов одинаково, то проверяется каждый символ и подсчитывается их количество.
        /// В случае любого отличия возвращается "false". Иначе - "true".
        /// </summary>
        /// <param name="firstLineSymbs"></param>
        /// <param name="secondLineSymbs"></param>
        /// <returns></returns>
        private static bool CompareLines(Dictionary<char, int> firstLineSymbs, Dictionary<char, int> secondLineSymbs)
        {
            if (firstLineSymbs.Keys.Count == secondLineSymbs.Keys.Count)
            {
                foreach (var keySymb in firstLineSymbs.Keys)
                    if (secondLineSymbs.ContainsKey(keySymb))
                    {
                        if (firstLineSymbs[keySymb] != secondLineSymbs[keySymb])
                            return false;
                    }
                    else
                        return false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Метод преобразует строку в словарь.
        /// Символ - ключ. Его количество повторений - значение.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static Dictionary<char, int> CreateDict(string line)
        {
            Dictionary<char, int> lineSymbs = new Dictionary<char, int>();
            foreach (char symb in line)
            {
                if (lineSymbs.ContainsKey(symb))
                    lineSymbs[symb]++;
                else
                    lineSymbs.Add(symb, 0);
            }
            return lineSymbs;
        }
    }
}
