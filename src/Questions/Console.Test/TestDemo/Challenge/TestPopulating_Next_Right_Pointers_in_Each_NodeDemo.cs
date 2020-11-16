using Command.CommonStruct;
using Questions.DailyChallenge._2020.November.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/16/2020 10:46:58 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPopulating_Next_Right_Pointers_in_Each_NodeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Populating_Next_Right_Pointers_in_Each_Node instance = new Populating_Next_Right_Pointers_in_Each_Node();
            { // simple

                TreeNode res = instance.Simple("[1,2,3,4,5,6,7]");
                Console.WriteLine(res);
            }
            { // speed&real
            }
        }

    }
}
