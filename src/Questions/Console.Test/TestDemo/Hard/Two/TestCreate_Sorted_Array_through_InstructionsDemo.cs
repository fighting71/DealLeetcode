using Command.Helper;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/16/2021 5:13:22 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCreate_Sorted_Array_through_InstructionsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Create_Sorted_Array_through_Instructions instance = new Create_Sorted_Array_through_Instructions();

            BaseLibrary.CommonWithCheckTest(new[] {
                    LargeData_File.Large3, // 49560684
                    JsonConvert.DeserializeObject<int[]>("[1,5,6,2]"), // 1
                    JsonConvert.DeserializeObject<int[]>("[1,2,3,6,5,4]"), // 3
                    JsonConvert.DeserializeObject<int[]>("[1,3,3,3,2,4,2,1,2]"), // 4
                }
            //, instance.Try
            , instance.Try3

            , instance.Try2
            //, () => CollectionHelper.GetEnumerable(1000_00, () => random.Next(1000_00) + 1).ToArray()
            , () => CollectionHelper.GetEnumerable(20, () => random.Next(1000_00) + 1).ToArray()
            , codeTimeCount: 100
            , showArg: false);
        }
    }
}
