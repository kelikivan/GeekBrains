using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public struct Account
    {
        readonly string login;
        readonly string password;

        public Account(string _login, string _password)
        {
            login = _login;
            password = _password;
        }

        public string Login => login;
        public string Password => password;

        public bool CheckAccountData(string _login, string _password)
        {
            return login.Equals(_login) && password.Equals(_password);
        }
        public bool CheckAccountData(Account acc)
        {
            return CheckAccountData(acc.Login, acc.Password);
        }

        public void WriteToFile(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(login);
                sw.WriteLine(password);
            }
        }
    }
}