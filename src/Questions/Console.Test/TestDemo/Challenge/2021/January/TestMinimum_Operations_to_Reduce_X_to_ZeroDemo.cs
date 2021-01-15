using Command.Helper;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/15/2021 3:49:23 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinimum_Operations_to_Reduce_X_to_ZeroDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Minimum_Operations_to_Reduce_X_to_Zero instance = new Minimum_Operations_to_Reduce_X_to_Zero();

            BaseLibrary.CommonTest(new[]
            {
                    (new[] { 3,2,20,1,1,3 },10),
                    (new[] { 1, 1, 4, 2, 3 },5),
                }, arg => instance.Try2(arg.Item1, arg.Item2), () =>
                {

                    int[] arr = CollectionHelper.GetArr(1000_00, () => random.Next(1000_0) + 1).ToArray();

                    return (arr, random.Next(1000_000_000) + 1);

                }, showArg: true);

        }
    }
}
