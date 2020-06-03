using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class MyArrayTwoDim
    {
        int[,] array;

        public MyArrayTwoDim(int n, int min, int max)
        {
            array = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = rnd.Next(min, max);
        }

        public MyArrayTwoDim(int n, int m, int min, int max)
        {
            array = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    array[i, j] = rnd.Next(min, max);
        }

        public int Min
        {
            get
            {
                int min = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] < min) min = array[i, j];
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] > max) max = array[i, j];
                return max;
            }
        }

        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] > 0) count++;
                return count;
            }
        }

        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        sum += array[i, j];
                return sum / array.GetLength(0) / array.GetLength(1);
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    s += array[i, j] + " ";
                s += "\n";
            }
            return s;
        }

        public void Print(string prefix = null)
        {
            ConsoleView.PrintMatrix(array, prefix: prefix);
        }

        public int Sum(int? val = null)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (val != null && array[i, j] <= val) continue;
                    sum += array[i, j];
                }
            return sum;
        }
        public void GetMaxValueIndex(out int mi, out int mj)
        {
            mi = mj = 0;
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        mi = i;
                        mj = j;
                    }
        }


        public MyArrayTwoDim(string filename)
        {
            ReadFromFile(filename);
        }

        public void WriteToFile(string filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine(array.GetLength(0));
                    sw.WriteLine(array.GetLength(1));
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                            sw.WriteLine(array[i, j]);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ConsoleView.PrintWithPause(ex.Message);
            }
            catch (Exception ex)
            {
                ConsoleView.PrintWithPause(ex.Message);
            }
        }

        public void ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    int n = int.Parse(sr.ReadLine());
                    int m = int.Parse(sr.ReadLine());
                    array = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                            array[i, j] = int.Parse(sr.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ConsoleView.PrintWithPause(ex.Message);
            }
            catch (Exception ex)
            {
                ConsoleView.PrintWithPause(ex.Message);
            }
        }
    }
}