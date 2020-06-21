using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame.Basics
{
    public static class Journal
    {
        public static void AddMessageToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void AddMessageToLogFile(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", append: true))
                {
                    sw.Write(DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss "));
                    sw.WriteLine(message);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
