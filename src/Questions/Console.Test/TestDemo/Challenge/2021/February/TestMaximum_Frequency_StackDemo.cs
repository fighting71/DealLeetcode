using ConsoleTest.LargeData;
using Questions.DailyChallenge._2021.February.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/5/2021 4:17:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMaximum_Frequency_StackDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Maximum_Frequency_Stack instance = new Maximum_Frequency_Stack();

            var arg = LargeArray.Get<string[]>(@"F:\Davis\EmptyTxt\Maximum_Frequency_Stack.txt");
            var arg2 = LargeArray.Get<int[][]>(@"F:\Davis\EmptyTxt\Maximum_Frequency_Stack_arg.txt");

            for (int i = 0; i < arg.Length; i++)
            {
                var key = arg[i];

                if (key == "push")
                {
                    instance.Push(arg2[i][0]);
                }
                else
                {
                    instance.Pop();
                }

            }

        }
    }
}
