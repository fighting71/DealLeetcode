using Questions.DailyChallenge._2020.November.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 3:27:03 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBinary_Tree_TiltDemo : BaseDemo
    {

        public void Run()
        {
            Binary_Tree_Tilt instance = new Binary_Tree_Tilt();
            { // simple
                Console.WriteLine(instance.FindTilt("[4,2,9,3,5,null,7]"));
                Console.WriteLine(instance.FindTilt("[1,2,3]"));
            }
            { // speed&real
            }
        }

    }
}
