using Questions.DailyChallenge._2021.April.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/30/2021 5:20:39 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPowerful_IntegersDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Powerful_Integers instance = new Powerful_Integers();

            BaseLibrary.CommonTest(new[] {
                    (2,1,10),// 不考虑特殊参数“1”时会死循环
                    (2,3,10),// [2,3,4,5,7,9,10]
                }
            , arg => instance.PowerfulIntegers(arg.Item1, arg.Item2, arg.Item3)
            );

        }
    }
}
