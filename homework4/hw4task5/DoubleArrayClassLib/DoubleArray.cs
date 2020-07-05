using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoubleArrayClassLib
{
    public class DoubleArray
    {
        readonly double[,] array;
        readonly Random rnd = new Random();
        StreamWriter streamWriter;
        int[] index = new int[2];

        public double this[int i,int j]
        {
            get { return array[i, j]; }
            set { array[i, j] = value; }
        }

        public double Min
        {
            get
            {
                double min = double.MaxValue;
                foreach(var num in array)
                {
                    if (num < min)
                        min = num;
                }
                return min;
            }
        }

        public double Max
        {
            get { return GetMax(ref index); }
        }

        public DoubleArray(int lengthX, int lengthY)
        {
            array = new double[lengthX, lengthY];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = Math.Round(rnd.NextDouble() * rnd.Next(-100,101),2);
        }

        public void PrintArray()
        {
            for(int i = 0; i < array.GetLength(0); i++)
            { 
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public DoubleArray(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    array = new double[lines.Length, lines[0].Split(' ').Length];

                    for (int i = 0; i < array.GetLength(0); i++)
                        for (int j = 0; j < array.GetLength(1); j++)
                            array[i, j] = double.Parse(lines[i].Split(' ')[j]);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
                MessageBox.Show($"Файл \"{path}\" не найден.");
        }

        public void WriteDoubleArray(string path)
        {
            try
            {
                streamWriter = new StreamWriter(path);
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        streamWriter.Write(array[i, j] + " ");
                    }
                    streamWriter.WriteLine();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            streamWriter.Close();
         
        }

        public double GetSum(double moreThen)
        {
            double sum = 0;
            foreach (var num in array)
                if(num>moreThen)
                    sum += num;
            return sum;
        }

        public double GetSum()
        {
            double sum = 0;
            foreach (var num in array)
                sum += num;
            return sum;
        }

        public double GetMax(ref int[] index)
        {
            double max = double.MinValue;
            for(int i = 0; i < array.GetLength(0); i++)
                for(int j = 0; j < array.GetLength(1);j++)
                {
                    if (array[i,j] > max)
                    {
                        max = array[i,j];
                        index = new[] { i, j };
                    }
                }
            return max;
        }
    }
}
