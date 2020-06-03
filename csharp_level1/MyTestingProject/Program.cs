using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTestingProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Начало Main");

            await RunAsyncMethod();

            var val2 = RunAsyncMethod2();

            var val500100 = GetValue();

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Конец Main");
            Console.ReadKey();
        }

        public static async Task RunAsyncMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(8000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("RunAsyncMethod 3");
            });
        }

        public static async Task<int> RunAsyncMethod2()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(9000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("RunAsyncMethod 4");
                return 2;
            });
        }

        public static Task<int> GetValue()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Начало GetValue 1");

            return Task.Run(() => {
                Thread.Sleep(4000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Метод GetValue 5");
                return 500100;
            });
        }
    }
}