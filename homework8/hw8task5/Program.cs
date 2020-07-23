using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//5. ** Написать программу-преобразователь из CSV в XML-файл с информацией о студентах(6
//урок).
//    Рощупкин
namespace hw8task5
{
        [Serializable]
        public class Student
        {
        string lastName;
        string firstName;
        string university;
        string faculty;
        int course;
        string department;
        int group;
        string city;
        int age;
        
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string University
        {
            get { return university; }
            set { university = value; }
        }
        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }
        public int Course
        {
            get { return course; }
            set { if (value > 0) course = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }
        public int Group
            {
                get { return group; }
                set { if (value > 0) group = value; }
            }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
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
        public Student()
        {
        }
        
        class Program
        {
            static void SaveAsXmlFormat(List<Student> obj, string fileName)
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                Stream fStream = new FileStream(fileName, FileMode.Create,
                FileAccess.Write);
                xmlFormat.Serialize(fStream, obj);
                fStream.Close();
            }
            static void LoadFromXmlFormat(ref List<Student> obj, string fileName)
            {
            XmlSerializer xmlFormat = new XmlSerializer( typeof (List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read);
            obj = (List<Student>) xmlFormat.Deserialize(fStream );
            fStream.Close();
            }
        static void Main(string[] args)
        {
            List<Student> list = ReadList();
            
            SaveAsXmlFormat(list, "data.xml");
            LoadFromXmlFormat(ref list, "data.xml");
            foreach (var std in list)
            {
                Console.WriteLine("{0} {1} {2} {3}", 
                    std.firstName, std.lastName, std.Age,std.city);
            }
            Console.ReadKey();
        }

            private static List<Student> ReadList()
            {
                List<Student> list = new List<Student>();
                StreamReader sr = new StreamReader("Students.txt");
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        list.Add(new Student(s[0], s[1], s[2], s[3], s[4],
                            int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7])
                        , s[8]));

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                sr.Close();
                return list;
            }
        }
}
}
