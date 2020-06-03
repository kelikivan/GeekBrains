using CommonComponents;
using System;

//2. Написать метод подсчета количества цифр числа

namespace Lesson2
{
    public class Task2 : TaskItem
    {
        public override string NameTask => "Задача 2.2 - Подсчет количества цифр";
        public override void RunTask()
        {
            base.RunTask();
            long a = ConsoleView.GetLong("Введите число: ");

            int count = GetLongLenght(a);
            ConsoleView.PrintWithPause($"Количество цифр: {count}.");
            ConsoleView.Clear();
        }
        private int GetLongLenght(long number)
        {
            int count = (number == 0) ? 1 : 0;
            while (number != 0)
            {
                count++;
                number /= 10;
            }
            return count;
        }
    }
}