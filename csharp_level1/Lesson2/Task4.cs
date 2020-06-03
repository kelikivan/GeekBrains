using CommonComponents;
using System;

//4. Реализовать метод проверки логина и пароля.На вход подается логин и пароль.
//На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
//Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
//С помощью цикла do while ограничить ввод пароля тремя попытками.

namespace Lesson2
{
    public class Task4 : TaskItem
    {
        const string cLogin = "root";
        const string cPassword = "GeekBrains";
        const int cIterationCount = 3;

        public override string NameTask => "Задача 2.4 - Вход в систему.";
        public override void RunTask()
        {
            base.RunTask();

            int i = 0;
            bool isValid;
            do
            {
                string login = ConsoleView.GetString("Введите логин: ");
                string password = ConsoleView.GetString("Введите пароль: ");
                isValid = CheckUserData(login, password);
                i++;

                if (isValid)
                    ConsoleView.PrintWithPause($"Доступ разрешен.");
                else
                    ConsoleView.PrintWithPause($"Неверный ввод данных. Осталось попыток: {cIterationCount - i}", true);
            }
            while (!isValid && i < cIterationCount);
            ConsoleView.Clear();
        }

        private bool CheckUserData(string login, string password)
        {
            return login == cLogin && password == cPassword;
        }
    }
}