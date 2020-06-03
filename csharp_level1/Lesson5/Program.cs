using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskItem[] tasks = new TaskItem[]
            {
                //new Task1(),
                new Task2(),
                //new Task3(),
                //new Task4()
            };

            for (var i = 0; i < tasks.Length; i++)
                tasks[i].RunTask();
        }
    }
}