using CommonComponents;
using System;

//7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b);
//   б) * Разработать рекурсивный метод, который считает сумму чисел от a до b

namespace Lesson2
{
    public class Task7 : TaskItem
    {
        public override string NameTask => "Задача 2.7 - Рекурсивный метод.";
        public override void RunTask()
        {
            base.RunTask();

            int a = 0;
            int b = 0;
            GetTwoNumbers(ref a, ref b);

            int sum = 0;
            GetSum(ref sum, a, b);

            ConsoleView.PrintWithPause($"Сумма чисел от a до b: {sum}");
            ConsoleView.Clear();
        }

        private void GetTwoNumbers(ref int a, ref int b)
        {
            a = ConsoleView.GetInt("Введите первое число(a): ");
            b = ConsoleView.GetInt("Введите второе число(b), где b > a: ");
            if (a >= b)
            {
                Console.WriteLine("Неверный ввод данных!\n");
                GetTwoNumbers(ref a, ref b);
            }
        }

        private void GetSum(ref int sum, int i, int max)
        {
            sum += i;
            if (i < max)
                GetSum(ref sum, i + 1, max);
        }
    }
}