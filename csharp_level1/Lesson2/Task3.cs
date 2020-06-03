using CommonComponents;
using System;

//С клавиатуры вводятся числа, пока не будет введен 0.
//Подсчитать сумму всех нечетных положительных чисел.

namespace Lesson2
{
    public class Task3 : TaskItem
    {
        public override string NameTask => "Задача 2.3";
        public override void RunTask()
        {
            base.RunTask();

            int value;
            int sum = 0;
            do
            {
                value = ConsoleView.GetInt("Введите число: ");
                if (value > 0 && value % 2 == 1)
                    sum += value;
            }
            while (value != 0);         

            ConsoleView.PrintWithPause($"Сумма всех нечетных положительных чисел: {sum}.");
            ConsoleView.Clear();
        }
    }
}