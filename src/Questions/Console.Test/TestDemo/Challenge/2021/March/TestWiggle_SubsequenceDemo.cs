using Command.Helper;
using Questions.DailyChallenge._2021.March.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/18/2021 6:53:06 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestWiggle_SubsequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Wiggle_Subsequence instance = new Wiggle_Subsequence();

            Console.WriteLine(instance.Simple(new[] { 1, 7, 4, 9, 2, 5 }));// 6
            Console.WriteLine(instance.Simple(new[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }));// 7
            Console.WriteLine(instance.Simple(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })); // 2

            BaseLibrary.CommonTest(new[]
                {
                        new[] { 0,0 },// 6
                        new[] { 1, 7, 4, 9, 2, 5 },// 6
                        new[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 },// 7
                        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, // 2
                    }, instance.Try
                , checkFunc: instance.Simple
                , generateArg: () => CollectionHelper.GetEnumerable(1000, () => random.Next(1000)).ToArray()
                , showArg: false
                , codeTimeCount: 50
            );

        }

    }
}
