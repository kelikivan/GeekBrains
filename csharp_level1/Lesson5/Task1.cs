using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//1. Создать программу, которая будет проверять корректность ввода логина.
//    Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) с использованием регулярных выражений.

namespace Lesson5
{
    public class Task1 : TaskItem
    {
        public override string NameTask => "Задача 5.1 - Проверка ввода логина.";
        public override void RunTask()
        {
            base.RunTask();

            string login = ConsoleView.GetString("Введите логин:");
            bool isValid = CheckLogin(login);
            ConsoleView.Print(isValid ? "Логин введён верно!" : "Логин не верный.");

            isValid = CheckLoginByRegex(login);
            ConsoleView.Print(isValid ? "Логин введён верно!" : "Логин не верный.");

            ConsoleView.Pause();
            ConsoleView.Clear();
        }

        private bool CheckLogin(string value)
        {
            if (value.Length < 2 || value.Length > 10)
                return false;

            if (char.IsDigit(value[0]))
                return false;

            return value.All(Char.IsLetterOrDigit);
        }

        private bool CheckLoginByRegex(string value)
        {
            Regex regex = new Regex(@"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");
            return regex.IsMatch(value);
        }
    }
}