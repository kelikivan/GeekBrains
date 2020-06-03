using CommonComponents;
using System;

//1. Написать метод, возвращающий минимальное из трех чисел.

namespace Lesson2
{
    public class Task1 : TaskItem
    {
        public override string NameTask => "Задача 2.1 - Минимальное из 3-х чисел";
        public override void RunTask()
        {
            base.RunTask();
            int a = ConsoleView.GetInt("Введите первое число: ");
            int b = ConsoleView.GetInt("Введите второе число: ");
            int c = ConsoleView.GetInt("Введите третье число: ");

            int minValue = GetMinValue(a, b, c);
            ConsoleView.PrintWithPause($"{minValue} - минимальное значение.");
            ConsoleView.Clear();
        }
        private int GetMinValue(int a, int b, int? c)
        {
            if (a < b)
            {
                if (c == null || a < c) return a;
                return (int)c;
            }
            else
            {
                if (c == null || b < c) return b;
                return (int)c;
            }
        }
    }
}