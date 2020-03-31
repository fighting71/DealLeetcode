using Command.Tools;
using System;

namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {

            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            Console.WriteLine("success");

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }

    }
}