using Command.Helper;
using Questions.DailyChallenge._2021.May.Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/31/2021 12:10:10 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMaximum_GapDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Maximum_Gap instance = new Maximum_Gap();

            BaseLibrary.CommonTest(new[] {
                    new []{3,6,9,1}
                }
            , instance.Optimize
            , checkFunc: instance.Simple
            , generateArg: () => CollectionHelper.GetEnumerable(10_000, () => random.Next(1000_000_000)).ToArray()
            , showArg: false
            );

        }

    }
}
