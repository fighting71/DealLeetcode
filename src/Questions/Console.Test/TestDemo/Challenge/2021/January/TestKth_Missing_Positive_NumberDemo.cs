using Questions.DailyChallenge._2021.January;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/7/2021 11:42:55 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestKth_Missing_Positive_NumberDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Kth_Missing_Positive_Number instance = new Kth_Missing_Positive_Number();
            if (runSimple)
            {
                Console.WriteLine(instance.Simple(new[] { 1, 2, 3, 4 }, 2));
                Console.WriteLine(instance.Simple(new[] { 2, 3, 4, 7, 11 }, 5));
            }
            else { }
        }
    }
}
