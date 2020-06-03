using CommonComponents;
using System;

//4. Написать программу обмена значениями двух переменных
//а) с использованием третьей переменной;
//б) * без использования третьей переменной.
//Исполнитель: Келик Иван

namespace Lesson1
{
    public class Task4 : TaskItem
    {
        public override string NameTask => "Задача 1.4 - Обмен значений";
        public override void RunTask()
        {
            base.RunTask();

            int a = ConsoleView.GetInt("Введите первое число (a): "); ;
            int b = ConsoleView.GetInt("Введите второе число (b): "); ;

            ConsoleView.PrintWithPause($"а={a}, b={b}");

            ExchangeValues(ref a, ref b);
            ConsoleView.PrintWithPause($"а={a}, b={b}");

            ExchangeValues(ref a, ref b, true);
            ConsoleView.PrintWithPause($"а={a}, b={b}");
            ConsoleView.Clear();
        }
        private void ExchangeValues(ref int a, ref int b, bool withoutThirdVariable = false)
        {
            if (withoutThirdVariable)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            else
            {
                var t = a;
                a = b;
                b = t;
            }
        }
    }
}