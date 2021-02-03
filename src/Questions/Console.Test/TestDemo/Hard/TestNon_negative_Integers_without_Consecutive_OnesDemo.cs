using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 7:04:38 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNon_negative_Integers_without_Consecutive_OnesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Non_negative_Integers_without_Consecutive_Ones instance = new Non_negative_Integers_without_Consecutive_Ones();

            BaseLibrary.CommonTest(new[] {
                    5,
                    10,
                    1000,
                    8748974
                }
            , instance.Try3
            , () => random.Next(1000_000_000) + 1
            , checkFunc: instance.Simple
            , codeTimeCount: 30
            );

        }
    }
}
