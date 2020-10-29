using Command.CommonStruct;
using Command.Tools;
using Questions.DailyChallenge._2020.October.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/28/2020 4:53:22 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLinked_List_Cycle_IIDemo : BaseDemo
    {
        
        public void Test()
        {
            { // simple
              // 3,2,0,-4
                ListNode node = new[] { 3, 2, 0, -4 };

                ListNode last = node;
                while (last.next != null) last = last.next;
                last.next = node;

                Console.WriteLine(new Linked_List_Cycle_II().Optimize(node).val);
            }
            { // speed&real
                CodeTimerResult codeTimerResult;
            }
        }

    }
}
