using CommonComponents;
using System;

//5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
//б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

namespace Lesson2
{
    public class Task5 : TaskItem
    {
        const double cNormalMassIndex = 0.5;
        public override string NameTask => "Задача 2.5 - Вычисление индекса массы тела";
        public override void RunTask()
        {
            base.RunTask();
            double index = CommonService.GetMassIndexWithDataInput(out double m, out double h);

            string message = null;
            if (index < 18.5)
            {
                message = index < 16
                    ? "У вас выраженный дефицит массы тела. Необходимо набрать вес."
                    : "У вас дефицит массы тела. Необходимо набрать вес.";
                double normalMass = CommonService.GetNormMass(18.5, h);
                message += $"\nНеобходимо набрать {normalMass - m:F2} кг.";
            }
            else if (index <= 25)
            {
                message = "Ваш вес в норме.";
            }
            else
            {
                message = index < 30
                    ? "У вас ожирение. Необходимо сесть на правильное питание."
                    : "У вас сильное ожирение. Вас спасёт только правильное питание и режим тренировок.";
                double normalMass = CommonService.GetNormMass(18.5, h);
                message += $"\nНеобходимо похудеть на {m - normalMass:F2} кг.";
            }

            ConsoleView.PrintWithPause(message);
            ConsoleView.Clear();
        }
    }
}