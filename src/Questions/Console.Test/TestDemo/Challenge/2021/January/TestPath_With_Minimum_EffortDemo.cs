using Command.Helper;
using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 4:46:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPath_With_Minimum_EffortDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Path_With_Minimum_Effort instance = new Path_With_Minimum_Effort();

            BaseLibrary.CommonTest(new[] {
                    CollectionHelper.GetEnumerable(5, () => CollectionHelper.GetEnumerable(5, () => random.Next(1000_000) + 1).ToArray()).ToArray()
                }, instance.Try3,
                () => CollectionHelper.GetEnumerable(100, () => CollectionHelper.GetEnumerable(100, () => random.Next(1000_000) + 1).ToArray()).ToArray()
                );

        }
    }
}
