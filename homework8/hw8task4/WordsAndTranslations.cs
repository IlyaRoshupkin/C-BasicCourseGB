using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace hw8task4
{
    [Serializable]
    public class Words
    {
        string word; 
        string translation; 

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public string Translation
        {
            get { return translation; }
            set { translation = value; }
        }
        public Words()
        {
        }
        public Words(string word, string translation)
        {
            this.word = word;
            this.translation = translation;
        }
    }
    class WordsAndTranslations
    {
        List<Words> list;
        public string FileName { get; set; }
        public WordsAndTranslations(string fileName)
        {
            this.FileName = fileName;
            list = new List<Words>();
        }
        public void Add(string word, string translation)
        {
            list.Add(new Words(word, translation));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }
        public Words this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Words>));
            try
            {
                Stream fStream = new FileStream(FileName, FileMode.Create,
        FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка при сохранении файла");
            }
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Words>));
            try
            {
                Stream fStream = new FileStream(FileName, FileMode.Open,
               FileAccess.Read);
                list = (List<Words>)xmlFormat.Deserialize(fStream);
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

