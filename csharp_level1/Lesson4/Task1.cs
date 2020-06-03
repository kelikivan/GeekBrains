using System;
using CommonComponents;

//1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
//   Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
//   В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.

namespace Lesson4
{
    public class Task1 : TaskItem
    {
        public override string NameTask => "Задача 4.1 - Массивы";
        public override void RunTask()
        {
            base.RunTask();

            Random random = new Random();

            var array = new int[20];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);

            int result = GetPairCount(array, 3);
            ConsoleView.PrintArray(array, prefix: "Массив данных:");
            ConsoleView.PrintWithPause($"Ответ: {result}.");
            ConsoleView.Clear();
        }

        private static int GetPairCount(int[] array, int divider)
        {
            int result = 0;
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] % divider == 0 || array[i + 1] % divider == 0)
                    result++;
            return result;
        }
    }
}