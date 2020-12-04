using Command.CommonStruct;
using Command.Tools;
using Questions.DailyChallenge._2020.December.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/4/2020 9:56:13 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLinked_List_Random_NodeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            ListNode list = new[] { 1, 2, 3 };

            Linked_List_Random_Node instance = new Linked_List_Random_Node(list);

            if (runSimple)
            { // simple
                ShowTools.Show(instance.GetRandom());
                ShowTools.Show(instance.GetRandom());
                ShowTools.Show(instance.GetRandom());
            }
            else
            { // speed&real
            }
        }

    }
}
