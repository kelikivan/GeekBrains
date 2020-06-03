using System;
using CommonComponents;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskItem[] tasks = new TaskItem[]
            {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4(),
                new Task5(),
                new Task6(),
                new Task7()
            };

            for (var i = 0; i < tasks.Length; i++)
                tasks[i].RunTask();
        }
    }
}