using Questions.DailyChallenge._2021.May.Week2;
using System;
using System.Collections.Generic;
using System.Text;
using Command.Extension;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/14/2021 3:22:02 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestAmbiguous_Coordinates : BaseDemo, IWork
    {
        public void Run()
        {
            Ambiguous_Coordinates instance = new Ambiguous_Coordinates();

            //IList<string> list = instance.Simple("(0123)");
            IList<string> list = instance.Optimize("(0123)");

            Console.WriteLine(list.SerieJson());
        }
    }
}
