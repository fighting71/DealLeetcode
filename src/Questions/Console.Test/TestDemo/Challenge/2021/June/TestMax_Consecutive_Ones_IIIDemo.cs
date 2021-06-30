using Command.Helper;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.June.Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/29/2021 5:05:04 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMax_Consecutive_Ones_IIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Max_Consecutive_Ones_III instance = new Max_Consecutive_Ones_III();

            BaseLibrary.CommonTest(new[] {
                    (JsonConvert.DeserializeObject<int[]>("[1,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,0,0,1,1,0,1,1]"), 8) , //25
                    (JsonConvert.DeserializeObject<int[]>("[1,1,1,0,0,0,1,1,1,1,0]"), 2) , //6
                    (JsonConvert.DeserializeObject<int[]>(" [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1]"), 3) , //10
                }
            , arg => instance.Explain(arg.Item1, arg.Item2)
            //, arg => instance.Try(arg.Item1, arg.Item2)
            , () => (CollectionHelper.GetEnumerable(1000_00, () => random.Next(2)).ToArray(), random.Next(1000_00))
            , showArg: false
            , checkFunc: arg => instance.Try2(arg.Item1, arg.Item2)
            );

        }

    }
}
