using Command.Tools;
using Questions.DailyChallenge._2020.October.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/29/2020 5:29:21 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSummary_RangesDemo : BaseDemo
    {

        public void Test()
        {
            { // simple
              //IList<string> lists = new Summary_Ranges().Simple(new[] { 0, 1, 2, 4, 5, 7 });
                IList<string> lists = new Summary_Ranges().Optmize(new[] { 0, 1, 2, 4, 5, 7 });

                foreach (var item in lists)
                {
                    Console.WriteLine(item);
                }

            }
            { // speed&real
                CodeTimerResult codeTimerResult;
            }
        }

    }
}
