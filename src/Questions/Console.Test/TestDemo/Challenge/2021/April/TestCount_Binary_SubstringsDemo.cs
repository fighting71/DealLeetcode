using Command.Helper;
using Questions.DailyChallenge._2021.April.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/25/2021 9:52:19 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_Binary_SubstringsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Count_Binary_Substrings instance = new Count_Binary_Substrings();

            BaseLibrary.CommonTest(new[] {
                    "00110011",// 6  // "0011", "01", "1100", "10", "0011", and "01".
                    "10101",// 4
                },
            instance.Try3
            //instance.Simple
            , generateArg: () => CollectionHelper.GetString(50_000, () => (char)(random.Next(2) + '0'))
            , showArg: false
            );

        }
    }
}
