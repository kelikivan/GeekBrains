using System;
using System.IO;
using CommonComponents;

//3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
//    Создайте структуру Account, содержащую Login и Password.

namespace Lesson4
{
    public class Task3 : TaskItem
    {
        public override string NameTask => "Задача 4.3 - Вход в систему, считать данные из файла";
        public override void RunTask()
        {
            base.RunTask();

            Account account = new Account("root", "GeekBrains");

            int iterationCount = 3;
            Account[] accountArray = new Account[iterationCount];
            using (StreamReader sr = new StreamReader("data.txt"))
            {
                for(int j = 0; j < iterationCount; j++)
                {
                    if ((sr.EndOfStream))
                    {
                        accountArray[j] = new Account("", "");
                        continue;
                    }
                    string login = sr.ReadLine();
                    string password = sr.ReadLine();
                    accountArray[j] = new Account(login, password);
                }
            }

            int i = 0;
            bool isValid;
            do
            {
                isValid = account.CheckAccountData(accountArray[i]);
                i++;

                if (isValid)
                    ConsoleView.PrintWithPause($"Доступ разрешен.");
                else
                    ConsoleView.PrintWithPause($"Неверный ввод данных. Осталось попыток: {iterationCount - i}", true);
            }
            while (!isValid && i < iterationCount);
            ConsoleView.Clear();
        }
    }
}
