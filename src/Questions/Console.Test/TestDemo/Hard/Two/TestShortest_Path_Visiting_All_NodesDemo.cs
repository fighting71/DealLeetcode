using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/24/2021 11:52:00 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestShortest_Path_Visiting_All_NodesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Shortest_Path_Visiting_All_Nodes instance = new Shortest_Path_Visiting_All_Nodes();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>("[[1],[0,2,4],[1,3,4],[2],[1,2]]"), // 4
                    JsonConvert.DeserializeObject<int[][]>(" [[1,2,3],[0],[0],[0]]"), // 4
                }
            //, instance.Try
            , instance.Try2
            );

        }

    }
}
