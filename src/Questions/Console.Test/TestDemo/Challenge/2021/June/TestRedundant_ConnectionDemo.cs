using Newtonsoft.Json;
using Questions.DailyChallenge._2021.June.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/25/2021 6:28:48 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRedundant_ConnectionDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Redundant_Connection instance = new Redundant_Connection();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>("[[1,2],[1,3],[2,3]]"), // [2,3]
                    JsonConvert.DeserializeObject<int[][]>("[[1,2],[2,3],[3,4],[1,4],[1,5]]"), //[1,4]
                }
            , instance.FindRedundantConnection
            );

        }
    }
}
