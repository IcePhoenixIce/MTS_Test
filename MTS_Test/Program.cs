using System;
using System.Runtime.InteropServices;

namespace MTS_Test_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FailProcess();
            }
            catch { }
            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }
        static void FailProcess()
        {
        // 1 вариант, завершение процесса без запуска обработчиков исключений и без финализаторов.
            //Environment.FailFast("Fail process successfully");
        // 2 вариант, завершение процесса.
            Environment.Exit(-2);
        // 3 вариант, очистка памяти, ожидание завершения финализаторов и завершение.
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //Environment.Exit(0);
        }
    }
}