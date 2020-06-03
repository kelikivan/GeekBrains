using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//Продемонстрируйте работу программы на текстовом файле с вашей программой.

namespace Lesson5
{
    public class Task2 : TaskItem
    {
        public override string NameTask => "Задача 5.2 - Проверка ввода логина.";
        public override void RunTask()
        {
            base.RunTask();

            string message = ConsoleView.GetString("Введите сообщение:");
            string newMessage = MessageClass.CutWordsByLenght(message, 3);
            ConsoleView.Print(newMessage);

            ConsoleView.Pause();
            ConsoleView.Clear();
        }
    }
}