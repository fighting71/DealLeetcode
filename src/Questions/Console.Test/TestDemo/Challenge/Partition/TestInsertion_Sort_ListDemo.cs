using Command.Tools;
using Questions.DailyChallenge._2020.November.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/4/2020 5:25:20 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestInsertion_Sort_ListDemo : BaseDemo
    {

        public void Run()
        {
            Insertion_Sort_List instance = new Insertion_Sort_List();
            { // simple
              //Console.WriteLine(instance.Optimize(new[] { 6, 5, 3, 1, 8, 7, 2, 4 }));
                Console.WriteLine(instance.Optimize(new[] { 4, 2, 1, 3 }));
            }
            { // speed&real
                CodeTimerResult codeTimerResult;
            }
        }

    }
}
