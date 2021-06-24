using Command.Helper;
using Questions.DailyChallenge._2021.June.Week4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/22/2021 3:57:16 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNumber_of_Matching_SubsequencesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Number_of_Matching_Subsequences instance = new Number_of_Matching_Subsequences();

            BaseLibrary.CommonTest(new[]
            {
                    ("abcde", new [] { "a","bb","acd","ace" }), // 3
                    ("dsahjpjauf", new [] { "ahjpjau","ja","ahbwzgqnuk","tnmlanowax" }), // 2
                }
            , arg => instance.NumMatchingSubseq(arg.Item1, arg.Item2)
            , () =>
            {
                string str = CollectionHelper.GetString(5000_0);
                string[] vs = CollectionHelper.GetEnumerable(5000, () => CollectionHelper.GetString(50)).ToArray();
                return (str, vs);
            }
            , showArg: false
            );

        }
    }
}
