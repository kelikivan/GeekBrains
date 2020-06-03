using CommonComponents;
using System;
using System.Diagnostics;

//6. * Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000.
//    Хорошим называется число, которое делится на сумму своих цифр.
//    Реализовать подсчет времени выполнения программы, используя структуру DateTime.

namespace Lesson2
{
    public class Task6 : TaskItem
    {
        public override string NameTask => "Задача 2.6 - Подсчет количества ХОРОШИХ чисел";
        public override void RunTask()
        {
            base.RunTask();

            //DateTime start = DateTime.Now;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int j = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                int sum = GetSumOfNumbers(i);
                if (i % sum == 0)
                    j++;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;// = DateTime.Now - start;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            ConsoleView.PrintWithPause($"Количество ХОРОШТХ чисел: {j}\nВремя выполнения программы: {elapsedTime}");
            ConsoleView.Clear();
        }

        private int GetSumOfNumbers(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}