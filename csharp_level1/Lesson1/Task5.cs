using CommonComponents;
using System;

//5. а)Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
//б) Сделать задание, только вывод организуйте в центре экрана
//в) * Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
//Исполнитель: Келик Иван

namespace Lesson1
{
    public class Task5 : TaskItem
    {
        public override string NameTask => "Задача 1.5";
        public override void RunTask()
        {
            base.RunTask();
            string name = ConsoleView.GetString("Введите своё имя: ");
            string surname = ConsoleView.GetString("Введите свою фамилию: ");
            string city = ConsoleView.GetString("Введите свой город проживания: ");

            string result = $"{surname} {name} ({city})";

            Console.WriteLine();
            ConsoleView.PrintWithPause(result);
            ConsoleView.Print(result, (Console.WindowWidth - result.Length) / 2, Console.WindowHeight / 2);
            ConsoleView.Clear();
        }
        private static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}