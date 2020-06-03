using System;
using CommonComponents;

//1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;
//б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;

namespace Lesson3
{
    public class Task1 : TaskItem
    {
        public override string NameTask => "Задача 3.1 - Комплексные числа";
        public override void RunTask()
        {
            base.RunTask();

            TestComplexStructure();
            TestComplexReadOnlyStructure();
            TestComplexClass();

            ConsoleView.Clear();
        }
        private void TestComplexStructure()
        {
            var complex1 = new Complex(1, 1);

            Complex complex2;
            complex2.Re = 2;
            complex2.Im = 2;

            Complex result = complex1.Plus(complex2);
            Complex result2 = complex2.Minus(complex1);
            Complex result3 = complex1.Multi(complex2);

            ConsoleView.PrintWithPause($"Результаты работы структуры\nСложение: {result.ToString()}\nВычетание: {result2.ToString()}\nПроизведение:{result3.ToString()}", true);
        }

        private void TestComplexReadOnlyStructure()
        {
            var complex1 = new ComplexReadOnly(1, 1);
            var complex2 = new ComplexReadOnly(2, 2);

            ComplexReadOnly result = complex1.Plus(complex2);
            ComplexReadOnly result2 = complex2.Minus(complex1);
            ComplexReadOnly result3 = complex1.Multi(complex2);

            ConsoleView.PrintWithPause($"Результаты работы структуры\nСложение: {result.ToString()}\nВычетание: {result2.ToString()}\nПроизведение:{result3.ToString()}", true);
        }

        private void TestComplexClass()
        {
            MyComplex complex1 = new MyComplex(1, 1);
            MyComplex complex2 = new MyComplex(2, 2);

            MyComplex result = complex1.Plus(complex2);
            MyComplex result2 = complex2.Minus(complex1);
            MyComplex result3 = complex1.Multi(complex2);

            ConsoleView.PrintWithPause($"Результаты работы класса\nСложение: {result.ToString()}\nВычетание: {result2.ToString()}\nПроизведение:{result3.ToString()}");
        }
    }
}