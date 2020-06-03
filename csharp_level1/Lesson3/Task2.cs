using System;
using CommonComponents;

//2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
//Требуется подсчитать сумму всех нечетных положительных чисел.Сами числа и сумму вывести на экран, используя tryParse;
//б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;

namespace Lesson3
{
    public class Task2 : TaskItem
    {
        public override string NameTask => "Задача 3.2 - Использование";
        public override void RunTask()
        {
            base.RunTask();

            int sum = GetSum();
            ConsoleView.PrintWithPause($"Сумма всех нечетных положительных чисел: {sum}.", true);
            
            sum = GetSumWithException();
            ConsoleView.PrintWithPause($"Сумма всех нечетных положительных чисел: {sum}.");

            ConsoleView.Clear();
        }

        private int GetSum()
        {
            int value;
            int sum = 0;
            do
            {
                value = ConsoleView.GetInt("Введите число: ");
                if (value > 0 && value % 2 == 1)
                    sum += value;
            }
            while (value != 0);
            return sum;
        }

        private int GetSumWithException()
        {
            int? value;
            int sum = 0;
            do
            {
                try
                {
                    string text = ConsoleView.GetString("Введите число: ");
                    value = int.Parse(text);
                    if (value != null && value > 0 && value % 2 == 1)
                        sum += (int)value;
                }
                catch (Exception ex)
                {
                    ConsoleView.Print($"Неверный ввод данных! Ошибка: {ex.Message}.\nПопробуйте ещё раз", true);
                    value = null;
                }
            }
            while (value == null || value != 0);
            return sum;
        }
    }
}