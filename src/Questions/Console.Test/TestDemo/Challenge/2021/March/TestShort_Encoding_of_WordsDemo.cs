using Command.Helper;
using Questions.DailyChallenge._2021.March.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/9/2021 12:24:06 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestShort_Encoding_of_WordsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Short_Encoding_of_Words instance = new Short_Encoding_of_Words();

            BaseLibrary.CommonTest(new[] {
                    new []{ "time", "me", "bell" }, // 10
                    new []{ "timea", "me", "bell" }, // 14
                }, instance.MinimumLengthEncoding
            , generateArg: () => CollectionHelper.GetEnumerable(7, () => CollectionHelper.GetString(() => random.Next(100) + 1, () => (char)('a' + random.Next(10)))).ToArray()
            );

        }
    }
}
