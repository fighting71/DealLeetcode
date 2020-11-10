using Command.CommonStruct;
using Questions.DailyChallenge._2020.November.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 5:06:47 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestAdd_Two_Numbers_IIDemo : BaseDemo
    {

        public void Run()
        {
            Add_Two_Numbers_II instance = new Add_Two_Numbers_II();
            { // simple
                Console.WriteLine(instance.Optimize(new[] { 1 }, new[] { 1 }));
                ListNode listNode = instance.Optimize(new[] { 7, 2, 4, 3 }, new[] { 5, 6, 4 });

                Console.WriteLine(listNode);

            }
            { // speed&real
            }
        }

    }
}
