using System;

namespace CommonComponents
{
    public static class ConsoleView
    {
        public static void SetTitle(string value)
        {
            Console.Title = value + " (Исполнитель: Келик Иван)";
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        #region Print

        public static void Print(string value, bool isNewLine = true, bool toAddEmptyRow = false)
        {
            if (isNewLine)
                Console.WriteLine(value);
            else
                Console.Write(value);

            if (toAddEmptyRow)
                Console.WriteLine();
        }

        public static void PrintWithPause(string value, bool isNewLine = true, bool toAddEmptyRow = false)
        {
            Print(value, isNewLine, toAddEmptyRow);
            Pause();
        }

        public static void Print(string value, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Print(value);
        }

        public static void PrintArray(int[] array, char s = ' ', string prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
                Print(prefix);

            for (int i = 0; i < array.Length; i++)
                Print($"{s}{array[i]}", isNewLine: false);
            Print(" ");
        }

        public static void PrintMatrix(int[,] array, string prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
                Print(prefix);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Print($"  {array[i,j]}", false);
                Print(" ");
            }
        }

        #endregion

        #region Get value

        public static string GetString(string value = null)
        {
            if (value != null)
                Console.Write(value);
            return Console.ReadLine();
        }

        public static int GetInt(string value = null)
        {
            int result;
            bool isValid;
            do
            {
                string text = GetString(value);
                isValid = int.TryParse(text, out result);
                if (!isValid)
                    Print("Неверный ввод данных! Попробуйте ещё раз", true);
            }  
            while (!isValid);      
            return result;
        }

        public static long GetLong(string value = null)
        {
            long result;
            bool isValid;
            do
            {
                string text = GetString(value);
                isValid = long.TryParse(text, out result);
                if (!isValid)
                    Print("Неверный ввод данных! Попробуйте ещё раз", true);
            }
            while (!isValid);
            return result;
        }

        public static double GetDouble(string value = null)
        {
            double result;
            bool isValid;
            do
            {
                string text = GetString(value).Replace('.', ',');
                isValid = double.TryParse(text, out result);
                if (!isValid)
                    Print("Неверный ввод данных! Попробуйте ещё раз", true);
            }  
            while (!isValid);
            return result;
        }
        
        #endregion
    }
}