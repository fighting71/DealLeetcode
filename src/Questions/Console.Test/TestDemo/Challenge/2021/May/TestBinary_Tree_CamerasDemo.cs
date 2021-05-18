using Command.CommonStruct;
using Questions.DailyChallenge._2021.May.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/17/2021 4:16:39 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBinary_Tree_CamerasDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Binary_Tree_Cameras instance = new Binary_Tree_Cameras();

            BaseLibrary.CommonTest(new TreeNode[] {
                    "[0,0,null,null,0,0,null,null,0,0]",// 2
                    "[0]",// 1
                    "[0,0,null,0,0]",// 1
                    "[0,0,null,0,null,0,null,null,0]",// 2
                }
            , instance.Try
            //, instance.MinCameraCover
            );

        }

    }
}
