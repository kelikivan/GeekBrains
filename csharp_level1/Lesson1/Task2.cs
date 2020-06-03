using CommonComponents;
using System;

//2. Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); 
//где m-масса тела в килограммах, h - рост в метрах
//Исполнитель: Келик Иван

namespace Lesson1
{
    public class Task2 : TaskItem
    {
        public override string NameTask => "Задача 1.2 - Вычисление индекса массы тела";
        public override void RunTask()
        {
            base.RunTask();

            double l = CommonService.GetMassIndexWithDataInput(out double m, out double h) ;
            ConsoleView.PrintWithPause($"\nИндекс массы тела(ИМТ): {l:F3}\nРасчитано по формуле ИМТ=m/(h*h)\n, где m - масса тела в килограммах\n      h - рост в метрах");
            ConsoleView.Clear();
        }
    }
}