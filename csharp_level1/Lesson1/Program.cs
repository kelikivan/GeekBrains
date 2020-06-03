using System;
using CommonComponents;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            //сделано для комплексной проверки ДЗ
            TaskItem[] tasks = new TaskItem[] 
            {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4(),
                new Task5()
            };

            for (var i = 0; i < tasks.Length; i++)
                tasks[i].RunTask();
        }
    }
}