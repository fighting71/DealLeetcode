using Command.Helper;
using Questions.DailyChallenge._2021.May.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/18/2021 5:00:12 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_String_ChainDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Longest_String_Chain instance = new Longest_String_Chain();

            BaseLibrary.CommonTest(new[] {
                    new []{ "a", "b", "ba", "bca", "bda", "bdca" },// 4
                    new []{ "xbc","pcxbcf","xb","cxbc","pcxbc" },// 5
                }
            , instance.Simple
            , () => CollectionHelper.GetEnumerable(1000
                    , () => CollectionHelper.GetString(random.Next(16) + 1, () => (char)('a' + random.Next(26)))
                ).ToArray()
            );

        }

    }
}
