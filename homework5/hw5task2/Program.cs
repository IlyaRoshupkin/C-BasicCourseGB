using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2. Разработать статический класс Message, содержащий следующие статические методы для
//обработки текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//д) *** Создать метод, который производит частотный анализ текста.В качестве параметра в
//него передается массив слов и текст, в качестве результата метод возвращает сколько раз
//каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.
//    Рощупкин
namespace hw5task2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string message = "Разработать статический класс Message, содержащий следующие статические методы для обработки текста: " +
            "Вывести только те слова текста, которые содержат не более n букв. " +
             "Удалить из сообщения все слова, которые заканчиваются на заданный символ. " +
             "Найти самое длинное слово сообщения. " +
             "Сформировать строку с помощью StringBuilder из самых длинных слов текста.";

                    Console.WriteLine("Пример текста: " + message);

                    Console.Write("Введите количество букв: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nа) Вывести только те слова сообщения, которые содержат не более {0} букв.", number);
                    List<string> listWords = Message.GetWordsList(message, number);
                    Message.PrintWords(listWords);

                    Console.Write("\n\nВведите символ: ");
                    char symb = char.Parse(Console.ReadLine());
                    Console.WriteLine("\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ: " +
                        " " + symb);
                    var newMessage = Message.GetWordsList(message, symb);
                    Message.PrintWords(newMessage);

                    Console.WriteLine("\n\nв) Найти самое длинное слово сообщения.");
                    List<string> theLongestWord = Message.GetTheLongestWords(message);
                    Message.PrintWords(theLongestWord);

                    Console.WriteLine("\n\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.");
                    string theLongestWordsLine = Message.GetTheLongestWordsLine(message);
                    Console.WriteLine(theLongestWordsLine);

                    Console.WriteLine("\n\nВведите слово для частотного анализа. Нажмите Enter для выхода.");
                    string[] wordsArr = CreateWordsArr();

                    Console.WriteLine("\nд) *** Создать метод, который производит частотный анализ текста.\nРезультат:");
                    Dictionary<string, int> freqDict = Message.MakeFrequencyDict(wordsArr, message);
                    Message.PrintWords(freqDict);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private static string[] CreateWordsArr()
        {
            List<string> wordsList = new List<string>();
            while (true)
            {
                string word = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(word))
                    break;
                else wordsList.Add(word);
            }
            return wordsList.ToArray();
        }
    }
}
