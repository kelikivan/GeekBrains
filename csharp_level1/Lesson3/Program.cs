using System;
using CommonComponents;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskItem[] tasks = new TaskItem[]
            {
                new Task1(),
                new Task2(),
                //new Task3()
            };

            for (var i = 0; i < tasks.Length; i++)
                tasks[i].RunTask();
        }
    }
}