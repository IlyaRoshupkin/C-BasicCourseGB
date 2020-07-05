using System;
using System.Collections.Generic;

namespace ArrayClassLib
{
    /// <summary>
    /// Библиотека создана для задания №3
    /// </summary>
    public class ArrayClass
    {
        readonly Dictionary<double, int> frequency = new Dictionary<double, int>();

        public double Sum
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < array.Length; i++)
                    sum += array[i];
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                double max = double.MinValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= max)
                    {
                        max = array[i];
                        count++;
                    }
                }
                return count;
            }
        }

        readonly double[] array;

        public ArrayClass(int length, double startValue, double step)
        {
            array = new double[length];
            array[0] = startValue;
            for (int i = 1; i < array.Length; i++)
                array[i] = array[i - 1] + step;
        }

        public ArrayClass(double[] oldArr)
        {
            this.array = oldArr;
        }

        public void PrintArray()
        {
            foreach (double num in array)
                Console.Write(num + " | ");
        }

        public double[] Inverse()
        {
            double[] inverseArr = new double[array.Length];
            for (int i = 0; i < inverseArr.Length; i++)
                inverseArr[i] = -1 * array[i];
            return inverseArr;
        }

        public double[] Multi(double num)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= num;
            return array;
        }

        public Dictionary<double,int> Frequency()
        {
            foreach(var num in array)
            {
                if (frequency.ContainsKey(num))
                    frequency[num]++;
                else
                    frequency.Add(num, 1);
            }
            return frequency;
        }

        public void PrintFrequency()
        {
            if (frequency.Count == 0)
                Frequency();
            foreach (double num in array)
                Console.WriteLine(num + " : " + frequency[num]);
        }
    }
}
