using Questions.DailyChallenge._2021.June.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/7/2021 5:00:56 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_Consecutive_SequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Longest_Consecutive_Sequence instance = new Longest_Consecutive_Sequence();

            Console.WriteLine(instance.Try(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }));
            Console.WriteLine(instance.Try(new[] { 4, 0, -4, -2, 2, 5, 2, 0, -8, -8, -8, -8, -1, 7, 4, 5, 5, -4, 6, 6, -3 }));

        }

    }
}
