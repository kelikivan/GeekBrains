using System;
using CommonComponents;

//2. а) Дописать класс для работы с одномерным массивом.
//    Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
//    Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, 
//    метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.
//    В Main продемонстрировать работу класса.
//б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

namespace Lesson4
{
    public class Task2 : TaskItem
    {
        public override string NameTask => "Задача 4.2 - Индексатор";
        public override void RunTask()
        {
            base.RunTask();

            var myArray = new MyArray(5, 2, 2);
            myArray.Print("Массив данных:");

            ConsoleView.Print($"Сумма: {myArray.Sum()}");

            myArray.Inverse();
            myArray.Print("Массив данных с измененным знаком:");

            myArray.Multi(5);
            myArray.Print("Массив данных с увеличенными значениями:");

            ConsoleView.Print($"Количество максимальных элементов: {myArray.MaxCount()}");
            ConsoleView.Pause();

            myArray.WriteToFile("data.txt");

            myArray = new MyArray(20);
            myArray.Print("Новый массив данных:");

            myArray.ReadFromFile("data.txt");
            myArray.Print("Прошлый массив данных:");

            ConsoleView.Pause();
            ConsoleView.Clear();
        }
    }
}