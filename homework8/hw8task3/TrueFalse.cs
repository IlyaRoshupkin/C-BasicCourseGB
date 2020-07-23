using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace BelieveOrNotBelieve
{
    // Класс для вопроса
    [Serializable]
    public class Question
    {
        string text; // Текст вопроса
        bool trueFalse; // Правда или нет

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public bool TrueFalse
        {
            get { return trueFalse; }
            set { trueFalse = value; }
        }
        // Для сериализации должен быть пустой конструктор.
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
    // Класс для хранения списка вопросов. А также для сериализации в XML и десериализации из XML
class TrueFalse
    {
        List<Question> list;
        public string FileName { get; set; }
        public TrueFalse(string fileName)
        {
            FileName = fileName;
            list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            try
            {
                Stream fStream = new FileStream(FileName, FileMode.Create,
        FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,"Ошибка при сохранении файла");
            }
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            try
            {
                Stream fStream = new FileStream(FileName, FileMode.Open,
               FileAccess.Read);
                list = (List<Question>)xmlFormat.Deserialize(fStream);
                fStream.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка при чтении файла");
            }
        }
        public int Count
        {
            get { return list.Count; }
        }
    }
}
