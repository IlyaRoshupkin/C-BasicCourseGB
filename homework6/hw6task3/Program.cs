using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//3. Переделать программу Пример использования коллекций для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный
//массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента;
//д) разработать единый метод подсчета количества студентов по различным параметрам
//выбора с помощью делегата и методов предикатов.
//Рощупкин
namespace hw6task3
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        public Student(string firstName, string lastName, string university,
        string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class NewProgram
    {
        static List<Student> Operation(Action<List<Student>,List<Student>> countDelegate, 
            List<Student> studentsList, List<Student> newList)
        {
            if (studentsList.Count != 0)
                countDelegate(studentsList, newList);
            return newList;
        }

        static int CompareFirstName(Student st1, Student st2) 
        {
            return String.Compare (st1.firstName, st2.firstName);
        }
        /// <summary>
        ///Создаем метод для сравнения экземпляров по возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int CompareAge(Student st1, Student st2)
        {
            return String.Compare(st1.age.ToString(), st2.age.ToString());
        }

        /// <summary>
        /// Сравнение по курсу и возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int CompareAgeAndCourse(Student st1, Student st2)
        {
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            if (st1.age > st2.age) return 1;
            if (st1.age < st2.age) return -1;
            return 0;
        }

        static void Main(string[] args)
        {
            int numbOfBach = 0;
            int numbOfMast = 0;
            int numbOfFiveCourse = 0;
            int numbOfSixCourse = 0;
            List<Student> listOfStudents = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("Students.txt");
            Dictionary<int, int> courseTwentyYearsOld = new Dictionary<int, int>();
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    listOfStudents.Add(new
                    Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7])
                    , s[8]));
                    FillInDictCourseTwenty(s,ref courseTwentyYearsOld);
                    CountMastAndBach(s,ref numbOfMast, ref numbOfBach);
                    CountFiveAndSixCourse(s, ref numbOfFiveCourse, ref numbOfSixCourse);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            listOfStudents.Sort(new Comparison<Student>(CompareFirstName));
            Console.WriteLine("Всего студентов:" + listOfStudents.Count);
            Console.WriteLine("Магистров:{0}", numbOfMast);
            Console.WriteLine("Бакалавров:{0}", numbOfBach);
            Console.WriteLine("На 5 курсе: {0}", numbOfFiveCourse);
            Console.WriteLine("На 6 курсе: {0}", numbOfSixCourse);
            Console.WriteLine("\nВ возрасте 18 - 20 лет:");
            foreach (int course in courseTwentyYearsOld.Keys)
                Console.Write("На " + course + " курсе: " + courseTwentyYearsOld[course] + " ");
            
            var tempList = listOfStudents;
            tempList.Sort(new Comparison<Student>(CompareAge));
            Console.WriteLine("\n\nСортировка по возрасту:");
            foreach (var student in tempList) 
                Console.WriteLine(student.lastName+" Возраст: "+ student.age);

            Console.WriteLine("\nСортировка по курсу и возрасту:");
            tempList.Sort(new Comparison<Student>(CompareAgeAndCourse));
            foreach (var student in tempList) 
                Console.WriteLine(student.lastName + " Курс: " + student.course + " Возраст: " + student.age);

            Console.WriteLine("\nСортировка по имени:");
            tempList.Sort(new Comparison<Student>(CompareFirstName));
            foreach (var v in listOfStudents) Console.WriteLine(v.firstName);
            Console.WriteLine("Время выполнения: " + (DateTime.Now - dt));

            Console.WriteLine("\nЕдиный метод подсчёта:\n");
            UnitedCountMethod(tempList);
            
            Console.ReadKey();
        }

        private static void UnitedCountMethod(List<Student> studentsList)
        {
            List<Student> newList = studentsList;
            
            bool q = true;
            while (q)
            {
                try
                {
                    PrintMenu();
                    int choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            CountUniv(ref newList);
                            break;
                        case 2:
                            CountFac(ref newList);
                            break;
                        case 3:
                            CountDep(ref newList);
                            break;
                        case 4:
                            CountCourse(ref newList);
                            break;
                        case 5:
                            CountAge(ref newList);
                            break;
                        case 6:
                            CountGroup(ref newList);
                            break;
                        case 7:
                            CountCity(ref newList);
                            break;
                        case 0:
                            newList = studentsList;
                            break;
                        case 9:
                            q = false;
                            Console.WriteLine("\nПрограмма завершила свою работу.");
                            break;
                        default:
                            break;
                    }

                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nВыберите параметр:\n" +
                            "1 - ВУЗ\n" +
                            "2 - Факультет\n" +
                            "3 - Кафедра\n" +
                            "4 - Курс\n" +
                            "5 - Возраст\n" +
                            "6 - Группа\n" +
                            "7 - Город\n" +
                            "0 - Сброс фильтра\n" +
                            "9 - Выход");
        }

        private static void CountCity(ref List<Student> newList)
        {
            Console.Write("Город: ");
            string ct = Console.ReadLine().ToLower();
            newList = newList.FindAll(std => std.city.ToLower() == ct);
            Console.Write($"Студентов из города {ct} учится: {newList.Count}\n");
        }

        private static void CountGroup(ref List<Student> newList)
        {
            Console.Write("Группа: ");
            int grp = int.Parse(Console.ReadLine());
            newList = newList.FindAll(std => std.group == grp);
            Console.Write($"Студентов в группе {grp}: {newList.Count}\n");
        }

        private static void CountAge(ref List<Student> newList)
        {
            Console.Write("Возраст (Например: 23 или 20-26: ");
            string ag = Console.ReadLine();
            newList = (ag.Length == 2) ? newList.FindAll(std => (std.age == Convert.ToInt32(ag)))
                : newList.FindAll(std => std.age >= Convert.ToInt32(ag.Substring(0, 2)) && std.age <= Convert.ToInt32(ag.Substring(3)));
            Console.Write($"Студентов в возрасте {ag}: {newList.Count}\n");
        }

        private static void CountCourse(ref List<Student> newList)
        {
            Console.Write("Курс (Например: 3 , если несколько, то 2-6: ");
            string crs = Console.ReadLine();
            newList = (crs.Length == 1) ? newList.FindAll(std => (std.course >= Convert.ToInt32(crs)))
                : newList.FindAll(std => std.course >= Convert.ToInt32(crs[0]) && std.course <= Convert.ToInt32(crs[2]));
            Console.Write($"Студентов на курсе {crs}: {newList.Count}\n");
        }

        private static void CountDep(ref List<Student> newList)
        {
            Console.Write("Название Кафедры: ");
            string nameOfDep = Console.ReadLine().ToLower();
            newList = newList.FindAll(dep => nameOfDep == dep.department);
            Console.Write($"Студентов учится на кафедре {nameOfDep}: {newList.Count}\n");
        }

        private static void CountUniv(ref List<Student> newList)
        {
            Console.Write("Название ВУЗа(аббревиатура): ");
            string nameOfUniver = Console.ReadLine().ToLower();
            newList = newList.FindAll(std => std.university.ToLower() == nameOfUniver);
            Console.Write($"Студентов учится в {nameOfUniver}: {newList.Count}\n");
        }

        private static void CountFac(ref List<Student> newList)
        {
            Console.Write("Название Факультета: ");
            string nameOfFac = Console.ReadLine().ToLower();
            newList = newList.FindAll(std => std.faculty.ToLower() == nameOfFac);
            Console.Write($"Студентов учится на факультете {nameOfFac}: {newList.Count}\n");
        }

        /// <summary>
        /// Подсчёт 5 и 6 - тикурсников
        /// </summary>
        /// <param name="studentLine"></param>
        /// <param name="numbOfFiveCourse"></param>
        /// <param name="numbOfSixCourse"></param>
        private static void CountFiveAndSixCourse(string[] studentLine, ref int numbOfFiveCourse, ref int numbOfSixCourse)
        {
            if (int.Parse(studentLine[5]) == 5)
                numbOfFiveCourse++;
            else if (int.Parse(studentLine[5]) == 6)
                numbOfSixCourse++;
        }
        /// <summary>
        /// Подсчёт магистров и бакалавров
        /// </summary>
        /// <param name="studentLine"></param>
        /// <param name="numbOfMast"></param>
        /// <param name="numbOfBach"></param>
        private static void CountMastAndBach(string[] studentLine, ref int numbOfMast, ref int numbOfBach)
        {
            if (int.Parse(studentLine[5]) < 5)
                numbOfBach++;               
            else numbOfMast++;
        }
        /// <summary>
        /// Частотный массив "курс - количество 18-20летних"
        /// </summary>
        /// <param name="student"></param>
        /// <param name="courseTwentyYearsOld"></param>
        private static void FillInDictCourseTwenty(string[] student, ref Dictionary<int, int> courseTwentyYearsOld)
        {
            if (int.Parse(student[6]) >= 18 && int.Parse(student[6]) <= 20)
            {
                if (courseTwentyYearsOld.ContainsKey(int.Parse(student[5])))
                    courseTwentyYearsOld[int.Parse(student[5])]++;
                else
                    courseTwentyYearsOld.Add(int.Parse(student[5]), 0);
            }
        }
    }
}
