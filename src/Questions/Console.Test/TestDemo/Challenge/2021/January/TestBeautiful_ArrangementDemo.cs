using Questions.DailyChallenge._2021.January;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/4/2021 3:23:41 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBeautiful_ArrangementDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Beautiful_Arrangement instance = new Beautiful_Arrangement();
            if (runSimple)
            {

                for (int i = 1; i <= 15; i++)
                {
                    Console.WriteLine($"{i}:{instance.CountArrangement(i)}");
                }

            }
            else { }
        }
    }
}
