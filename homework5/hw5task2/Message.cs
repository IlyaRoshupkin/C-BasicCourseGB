using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw5task2
{
    static class Message
    {
        static StringBuilder stringBuilder;

        public static List<string> GetWordsList(string message)
        {
            List<string> listWords = new List<string>();
            if (message != "")
            {
                try
                {
                    string[] words = message.Split(' ');

                    foreach (var word in words)
                    {
                        string newWord = "";
                        foreach (var letter in word)
                            if (char.IsLetterOrDigit(letter))
                                newWord += letter;
                        listWords.Add(newWord.ToLower());
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
                MessageBox.Show("Сообщение не может быть пустым!");
            return listWords;
        }

        public static List<string> GetWordsList(string message, int length)
        {
            List<string> wordsList = GetWordsList(message);
            List<string> newWordsList = new List<string>();
            try
            {
                foreach (var word in wordsList)
                    if (word.Length <= length)
                        newWordsList.Add(word);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return newWordsList;
        }

        public static void PrintWords(List<string> listWords)
        {
            foreach (var word in listWords)
                Console.Write(word + " ");
        }

        public static List<string> GetWordsList(string message, char symbol)
        {
            List<string> wordsList = GetWordsList(message);
            List<string> newWordsList = new List<string>();
            try
            {
                foreach (var word in wordsList)
                    if (word[word.Length - 1] != symbol)
                        newWordsList.Add(word);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return newWordsList;
        }

        public static List<string> GetTheLongestWords(string message)
        {
            List<string> theLongestWords = new List<string>();
            try
            {
                List<string> wordsList = GetWordsList(message);
                int max = 0;
                foreach (var word in wordsList)
                {
                    if (word.Length > max)
                    {
                        max = word.Length;
                        theLongestWords.Add(word.ToLower());
                    }
                    else if (word.Length == max)
                        if (!theLongestWords.Contains(word.ToLower()))
                            theLongestWords.Add(word);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return theLongestWords;
        }

        public static string GetTheLongestWordsLine(string message)
        {
            stringBuilder = new StringBuilder();
            try
            {
                List<string> wordsList = GetWordsList(message);
                List<string> theLongestWords = GetTheLongestWords(message);
                foreach (var word in theLongestWords)
                    stringBuilder.Append(word + " ");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return stringBuilder.ToString();
        }

        public static Dictionary<string,int> MakeFrequencyDict(string[] words,string text)
        {
            Dictionary<string, int> freqDict = GetKeys(words);
            try
            {
                List<string> wordsList = GetWordsList(text);
                foreach (string word in words)
                {
                    for (int i = 0; i < wordsList.Count; i++)
                        if (word.ToLower() == wordsList[i])
                            freqDict[word.ToLower()]++;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return freqDict;
        }

        private static Dictionary<string,int> GetKeys(string[] words)
        {
            Dictionary<string, int> freqDict = new Dictionary<string, int>();
            try
            {
                foreach (var word in words)
                    if (!freqDict.ContainsKey(word.ToLower()))
                        freqDict.Add(word.ToLower(), 0);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return freqDict;
        }

        public static void PrintWords(Dictionary<string,int> freqDict)
        {
            foreach (var word in freqDict.Keys)
                Console.WriteLine(word + " : " + freqDict[word]);
        }
    }
}
