using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/18/2021 5:57:24 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSmallest_Rotation_with_Highest_ScoreDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Smallest_Rotation_with_Highest_Score instance = new Smallest_Rotation_with_Highest_Score();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[]>("[0, 0, 0, 0, 0]"),
                    JsonConvert.DeserializeObject<int[]>("[2, 3, 1, 4, 0]"), // 3
                    JsonConvert.DeserializeObject<int[]>(" [1, 3, 0, 2, 4]"), // 0
                }
            , instance.OtherSolution
            //, instance.Simple
            );
        }
    }
}
