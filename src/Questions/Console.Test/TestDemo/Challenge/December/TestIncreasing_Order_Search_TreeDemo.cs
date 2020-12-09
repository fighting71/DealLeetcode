using Command.CommonStruct;
using Questions.DailyChallenge._2020.December.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/7/2020 2:57:28 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestIncreasing_Order_Search_TreeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Increasing_Order_Search_Tree instance = new Increasing_Order_Search_Tree();
            if (runSimple)
            { // simple
                TreeNode treeNode = instance.Simple("[5,3,6,2,4,null,8,1,null,null,null,7,9]");
                Console.WriteLine(treeNode);
            }
            else
            { // speed&real
            }
        }

    }
}
