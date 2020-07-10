using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//4. * Задача ЕГЭ.
// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
//школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
//превосходит 100, каждая из следующих N строк имеет следующий формат:
//<Фамилия> <Имя> <оценки>,
//где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
//более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
//пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом.
//Пример входной строки:
//Иванов Петр 4 5 3
//Требуется написать как можно более эффективную программу, которая будет выводить на экран
//фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
//набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
//    Рощупкин
namespace hw5task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> averagePoints = CreateAvrPointsDict("ExamsResult.txt");
            

            string[] theWorst = GetThreeTheWorst(averagePoints);
            
            foreach(var people in theWorst)
            {
                Console.WriteLine(people);
            }
            Console.ReadLine();
        }

        private static string[] GetThreeTheWorst(Dictionary<string, double> averagePoints)
        {
            string[] theWorst = new string[3];
            double[] minPoints = new double[3];
            for (int i = 0; i < minPoints.Length; i++)
                minPoints[i] = double.MaxValue;
            foreach (string people in averagePoints.Keys)
            {
                if (averagePoints[people] < minPoints[0])
                    ArraysMovingOnThree(theWorst, minPoints,averagePoints,people);                  
                else if (averagePoints[people] == minPoints[0])
                    theWorst[0] = theWorst[0].Substring(0,theWorst[0].IndexOf(' ')) 
                        + " " + people.Split(' ')[0] + " " + averagePoints[people];
                else if (averagePoints[people] < minPoints[1])
                    ArraysMovingOnTwo(theWorst, minPoints, averagePoints, people);            
                else if (averagePoints[people] == minPoints[1])
                    theWorst[1] = theWorst[1].Substring(0, theWorst[1].IndexOf(' '))
                        + " " + people.Split(' ')[0] + " " + averagePoints[people];
                else if (averagePoints[people] < minPoints[2])
                { 
                    minPoints[2] = averagePoints[people];
                    theWorst[2] = people.Split(' ')[0] + " " + averagePoints[people];
                }
                else if (averagePoints[people] == minPoints[2])
                    theWorst[2] = theWorst[2].Substring(0, theWorst[2].IndexOf(' '))
                       + " " + people.Split(' ')[0] + " " + averagePoints[people];
            }
            return theWorst;
        }

        private static void ArraysMovingOnTwo(string[] theWorst, double[] minPoints, Dictionary<string, double> averagePoints, string people)
        {
            minPoints[2] = minPoints[1];
            minPoints[1] = averagePoints[people];
            theWorst[2] = theWorst[1];
            theWorst[1] = people.Split(' ')[0] + " " + averagePoints[people];
        }

        private static void ArraysMovingOnThree(string[] theWorst, double[] minPoints, Dictionary<string, double> averagePoints, string people)
        {
            minPoints[2] = minPoints[1];
            minPoints[1] = minPoints[0];
            minPoints[0] = averagePoints[people];
            theWorst[2] = theWorst[1];
            theWorst[1] = theWorst[0];
            theWorst[0] = people.Split(' ')[0] + " " + averagePoints[people];
        }

        private static Dictionary<string, double> CreateAvrPointsDict(string path)
        {
            Dictionary<string, double> averagePoints = new Dictionary<string, double>();
            if (!File.Exists(path))
                MessageBox.Show("Файл " + path + "не найден.");
            else
            {
                try
                {
                    StreamReader str = new StreamReader(path);
                    Regex correctLine = new Regex(@"[А-ЯЁ][а-яё]{2,19}\s[А-ЯЁ][а-яё]{2,14}\s[2-5]\s[2-5]\s[2-5]");
                    int numberOfPeoples = int.Parse(str.ReadLine());
                    if (numberOfPeoples < 10 || numberOfPeoples > 100)
                        MessageBox.Show("Некорректное количество учеников.");
                    else
                    {
                        for (int i = 0; i < numberOfPeoples; i++)
                        {
                            string line = str.ReadLine();
                            if (correctLine.IsMatch(line))
                            {
                                string[] lines = line.Split(' ');
                                double avrPoint = Math.Round(
                                    (double.Parse(lines[2]) + double.Parse(lines[3]) + double.Parse(lines[4])) / 3, 2);
                                averagePoints.Add(lines[0] + " " + lines[1], avrPoint);
                            }
                            else
                                MessageBox.Show("Ошибка при считывании файла.\nСтрока № " + i +
                                    ": " + line);
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message );
                }
            }
            return averagePoints;
        }
    }
}
