using System;
using System.Collections.Generic;
using System.Text;
using Command.Extension;
using Questions.Hard.Deal3;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/18/2021 4:19:14 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSliding_PuzzleDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Sliding_Puzzle instance = new Sliding_Puzzle();

            BaseLibrary.CommonTest(new[] {
                    "[[4,1,5],[3,2,0]]".ParseJson<int[][]>(),// 10
                    "[[1,2,3],[4,0,5]]".ParseJson<int[][]>(),// 1
                    "[[1,2,3],[5,4,0]]".ParseJson<int[][]>(),// -1
                    "[[4,1,2],[5,0,3]]".ParseJson<int[][]>(),// 5
                }
            , instance.Try3
            //, instance.Try2
            //, instance.Try
            );

        }
    }
}
