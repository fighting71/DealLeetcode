using Questions.DailyChallenge._2020.December.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/8/2020 10:59:07 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPopulating_Next_Right_Pointers_in_Each_Node_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Populating_Next_Right_Pointers_in_Each_Node_II instance = new Populating_Next_Right_Pointers_in_Each_Node_II();
            if (runSimple)
            { // simple
                Console.WriteLine(instance.Connect("[1,2,3,4,5,null,7]"));
            }
            else
            { // speed&real
            }
        }

    }
}
