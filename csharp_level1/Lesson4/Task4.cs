using System;
using System.IO;
using CommonComponents;

//4. * а) Реализовать класс для работы с двумерным массивом.
//    Реализовать конструктор, заполняющий массив случайными числами.
//    Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
//    возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
//    возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
//* б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
// Дополнительные задачи
//в) Обработать возможные исключительные ситуации при работе с файлами.

namespace Lesson4
{
    public class Task4 : TaskItem
    {
        public override string NameTask => "Задача 4.4 - Двумерный массив";
        public override void RunTask()
        {
            base.RunTask();

            var myArray = new MyArrayTwoDim(5, -10000, 10000);
            myArray.Print("Двумерный массив данных:");

            ConsoleView.Print($"Сумма: {myArray.Sum()}");
            ConsoleView.Print($"Сумма элементов, значение которых больше 100: {myArray.Sum(100)}");
            myArray.GetMaxValueIndex(out int i, out int j);
            ConsoleView.Print($"Максимальное значение: {myArray.Max}, его расположение: [{i},{j}]");
            ConsoleView.Print($"Минимальное значение: {myArray.Min}");
            ConsoleView.Pause();

            myArray.WriteToFile("data.txt");

            myArray = new MyArrayTwoDim(5, -10000, 10000);
            myArray.Print("Новый массив данных:");

            myArray.ReadFromFile("data.txt");
            myArray.Print("Прошлый массив данных:");

            ConsoleView.Pause();
            ConsoleView.Clear();
        }
    }
}