using CommonComponents;
using System;

//1. Написать программу “Анкета”. Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). 
//В результате вся информация выводится в одну строчку.
//Исполнитель: Келик Иван

namespace Lesson1
{
    public class Task1 : TaskItem
    {
        public override string NameTask => "Задача 1.1 - Анкета";
        public override void RunTask()
        {
            base.RunTask();
            string name = ConsoleView.GetString("Введите своё имя: ");
            string surname = ConsoleView.GetString("Введите свою фамилию: ");
            int age = ConsoleView.GetInt("Введите свой возраст: ");
            double growth = ConsoleView.GetDouble("Введите свой рост: ");
            double weight = ConsoleView.GetDouble("Введите свой вес: ");

            //а) используя склеивание;
            ConsoleView.PrintWithPause(surname + " " + name + " возраст: " + age + " лет; рост: " + growth + " см;  вес: " + weight + " кг.");

            //б) используя форматированный вывод;
            Console.WriteLine("{0} {1} возраст: {2} лет; рост: {3:F0} см;  вес: {4:F0} кг.", surname, name, age, growth, weight);
            ConsoleView.Pause();

            //в) * используя вывод со знаком $.
            ConsoleView.PrintWithPause($"{surname} {name} возраст: {age} лет; рост: {growth} см;  вес: {weight} кг.");
            ConsoleView.Clear();
        }
    }
}