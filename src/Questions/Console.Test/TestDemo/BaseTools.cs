using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo
{
    public class BaseTools
    {

        public static CodeTimer codeTimer = new CodeTimer();

        static BaseTools()
        {
            codeTimer.Initialize();
        }

        public static Random random = new Random();

    }
}
