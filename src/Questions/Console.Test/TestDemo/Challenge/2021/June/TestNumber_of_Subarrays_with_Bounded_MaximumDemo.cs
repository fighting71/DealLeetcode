using Command.Helper;
using Questions.DailyChallenge._2021.June.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/17/2021 4:13:30 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNumber_of_Subarrays_with_Bounded_MaximumDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Number_of_Subarrays_with_Bounded_Maximum instance = new Number_of_Subarrays_with_Bounded_Maximum();

            BaseLibrary.CommonTest(new[] {
                    (new []{ 2,1,4,3 },2,3),//3
                }
            , arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3)
            , () =>
            {
                var arr = CollectionHelper.GetEnumerable(500, () => random.Next((int)Math.Pow(10, 9))).ToArray();

                var left = random.Next(arr.Min(), arr.Max());
                var right = random.Next(left + 1, arr.Max());
                return (arr, left, right);
            }
            , checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
            //, arg => instance.NumSubarrayBoundedMax(arg.Item1, arg.Item2, arg.Item3)
            );

        }

    }
}
