using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 11:52:34 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSmallest_String_With_A_Given_Numeric_ValueDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Smallest_String_With_A_Given_Numeric_Value instance = new Smallest_String_With_A_Given_Numeric_Value();

            BaseLibrary.CommonWithCheckTest(new[] {
                    (3,27), // “aay”
                    (5,73), // “aaszz”
                    //(53168,485414), // “aaszz”
                }
            , arg => instance.Try4(arg.Item1, arg.Item2)
            , arg => instance.Try3(arg.Item1, arg.Item2)
            , () => {

                    //var n = random.Next(1000_00) + 1;
                    var n = 1000_0000;
                var k = (random.Next(n) + 1) * (random.Next(26) + 1);
                return (n, k);
            },
            showRes: false,
            showArg: false,
            codeTimeCount: 20
            );

        }
    }
}
