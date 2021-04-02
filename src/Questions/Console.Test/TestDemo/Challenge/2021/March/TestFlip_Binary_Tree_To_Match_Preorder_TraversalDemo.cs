using Questions.DailyChallenge._2021.March.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/29/2021 5:44:02 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFlip_Binary_Tree_To_Match_Preorder_TraversalDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Flip_Binary_Tree_To_Match_Preorder_Traversal instance = new Flip_Binary_Tree_To_Match_Preorder_Traversal();

            BaseLibrary.CommonTest(new[] {
                    ("[1,2]",new []{2,1}), // -1
                    ("[1,2,3]",new []{1,3,2}), // -1
                    ("[1,2,3]",new []{1,2,3}), // 
                    ("[1,2,3,4,5,6,7]",new []{1,2,5,4,3,6,7}), // 2
                }
            , arg => instance.FlipMatchVoyage(arg.Item1, arg.Item2)
            );

        }
    }
}
