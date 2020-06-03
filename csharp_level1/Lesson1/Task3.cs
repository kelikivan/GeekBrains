using CommonComponents;
using System;

//3.а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
//по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
//Вывести результат используя спецификатор формата .2f(с двумя знаками после запятой);
//б) * Выполните предыдущее задание оформив вычисления расстояния между точками в виде метода;
//Исполнитель: Келик Иван

namespace Lesson1
{
    public class Task3 : TaskItem
    {
        public override string NameTask => "Задача 1.3 - Вычисление расстояния между координатами";
        public override void RunTask()
        {
            base.RunTask();
            int x1 = ConsoleView.GetInt("Введите x-координату точки A: ");
            int y1 = ConsoleView.GetInt("Введите y-координату точки A: ");

            int x2 = ConsoleView.GetInt("Введите x-координату точки B: ");
            int y2 = ConsoleView.GetInt("Введите y-координату точки B: ");

            double r = CalculateDistance(x1, y1, x2, y2);
            ConsoleView.PrintWithPause($"Расстояние между точками A({x1},{y1}) и B({x2},{y2}): {r:F2}");
            ConsoleView.Clear();
        }
        private static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
