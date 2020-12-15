using Questions.DailyChallenge._2020.December.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/14/2020 3:31:44 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSmallest_Subtree_with_all_the_Deepest_NodesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Smallest_Subtree_with_all_the_Deepest_Nodes instance = new Smallest_Subtree_with_all_the_Deepest_Nodes();
            if (runSimple)
            { // simple
                var argArr = new[]
                {
                        "[3,5,1,6,2,0,8,null,null,7,4]"
                    };
                foreach (var item in argArr)
                {
                    Console.WriteLine(instance.SubtreeWithAllDeepest(item));
                }
            }
            else
            { // speed&real
            }
        }
    }
}
