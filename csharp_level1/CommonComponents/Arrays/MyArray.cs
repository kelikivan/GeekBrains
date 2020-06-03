using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class MyArray
    {
        int[] array;

        public MyArray(int n, int startValue, int increment)
        {
            array = new int[n];

            int value = startValue;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
                value += (int)increment;
            }
        }

        public MyArray(int n)
        {
            Random random = new Random();

            array = new int[n];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
        }

        public int Get(int index)
        {
            return array[index];
        }

        public void Set(int index, int value)
        {
            array[index] = value;
        }

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public int Max()
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > max) max = array[i];
            return max;
        }

        public int Min()
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] < min) min = array[i];
            return min;
        }

        public int MaxCount()
        {
            int maxCount = 0;
            int max = Max();
            for (int i = 0; i < array.Length; i++)
                if (array[i] == max)
                    maxCount++;
            return maxCount;
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        public void Inverse()
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = -array[i];
        }

        public void Multi(int coef)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = coef * array[i];
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (int v in array)
                s = s + v + " ";
            return s;
        }

        public void Print(string prefix = null)
        {
            ConsoleView.PrintArray(array, prefix: prefix);
        }


        public MyArray(string filename)
        {
            ReadFromFile(filename);
        }

        public void WriteToFile(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(array.Length);
                for (int i = 0; i < array.Length; i++)
                    sw.WriteLine(array[i]);
            }
        }

        public void ReadFromFile(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;

            using (StreamReader sr = new StreamReader(filename))
            {
                int n = int.Parse(sr.ReadLine());
                array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(sr.ReadLine());
                }
            }
        }
    }
}