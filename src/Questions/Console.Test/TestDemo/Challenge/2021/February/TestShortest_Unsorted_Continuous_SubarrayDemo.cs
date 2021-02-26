using Command.Helper;
using Questions.DailyChallenge._2021.February.Week4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2021 3:46:52 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestShortest_Unsorted_Continuous_SubarrayDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Shortest_Unsorted_Continuous_Subarray instance = new Shortest_Unsorted_Continuous_Subarray();

            BaseLibrary.CommonTest(new[]
            {
                    new []{ 2, 6, 4, 8, 10, 9, 15 },
                    new []{ 1,2,3,4 },
                }, instance.Try
            , generateArg: () => CollectionHelper.GetEnumerable(1000_0, () => random.Next(-1000_00, 1000_00)).ToArray()
            , checkFunc: instance.Simple);

        }
    }
}
