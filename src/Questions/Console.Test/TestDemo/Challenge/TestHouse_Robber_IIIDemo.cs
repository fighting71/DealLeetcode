using Command.CommonStruct;
using Command.Tools;
using ConsoleTest.LargeData;
using Questions.DailyChallenge._2020.November.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/24/2020 10:54:22 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestHouse_Robber_IIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            House_Robber_III instance = new House_Robber_III();
            if (runSimple)
            { // simple
                var argArr = new[]
                {
                        "[3,2,3,null,3,null,1]",// 7
                        LargeTree.Tree,
                        "[3,4,5,1,3,null,1]", // 9
                    };

                foreach (var arg in argArr)
                {
                    TreeNode root = arg;
                    ShowTools.Show(instance.Optimize2(root));
                    ShowTools.Show(instance.Optimize(root));
                }
            }
            else
                for (int i = 0; i < 3; i++)
                { // speed&real

                    CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { instance.Optimize(LargeTree.Tree); });
                    CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () => { instance.Optimize2(LargeTree.Tree); });
                    Console.WriteLine(codeTimerResult);
                    Console.WriteLine(codeTimerResult2);

                }
        }

    }
}
