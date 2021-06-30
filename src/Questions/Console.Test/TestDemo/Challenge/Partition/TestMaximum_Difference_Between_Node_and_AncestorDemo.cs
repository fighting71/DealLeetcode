using Questions.DailyChallenge._2020.November.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/10/2020 10:05:53 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMaximum_Difference_Between_Node_and_AncestorDemo : BaseDemo
    {

        public void Run()
        {
            Maximum_Difference_Between_Node_and_Ancestor instance = new Maximum_Difference_Between_Node_and_Ancestor();
            { // simple

                Console.WriteLine(instance.Simple("[8,3,10,1,6,null,14,null,null,4,7,13]"));
                Console.WriteLine(instance.Simple("[1,2,null,0,null,3]"));

            }
            { // speed&real
            }
        }

    }
}
