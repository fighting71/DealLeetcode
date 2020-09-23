using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 2:57:02 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class BaseDemo
    {
        protected CodeTimer codeTimer = new CodeTimer();

        public BaseDemo()
        {
            codeTimer.Initialize();
        }

        protected Random random = new Random();

        protected CodeTimerResult codeTimerResult;
    }
}
