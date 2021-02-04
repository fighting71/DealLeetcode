using Command.Helper;
using ConsoleTest.LargeData;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.February.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 6:22:48 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_Harmonious_SubsequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Longest_Harmonious_Subsequence instrance = new Longest_Harmonious_Subsequence();

            BaseLibrary.CommonTest(new[] {
                    LargeArray.Empty,// 2090
                    JsonConvert.DeserializeObject<int[]>("[1,3,2,2,5,2,3,7]"), // 5
                    JsonConvert.DeserializeObject<int[]>("[1,1,1,1]"), // 0
                    JsonConvert.DeserializeObject<int[]>("[1,2,3,4]"), // 2
                }, instrance.Optimize
            , () => CollectionHelper.GetEnumerable(2000_000, () => random.Next(-10, 10)).ToArray()
            //, () => CollectionHelper.GetEnumerable(2000_0, () => random.Next(-1000_000_000, 1000_000_000)).ToArray()
            , checkFunc: instrance.Try3
            , showArg: false
            );

        }

    }
}
