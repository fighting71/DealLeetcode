using Questions.DailyChallenge._2021.June.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/11/2021 4:00:20 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStone_Game_VIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Stone_Game_VII instance = new Stone_Game_VII();

            BaseLibrary.CommonTest(new[] {
                    new []{ 5, 3, 1, 4, 2 },// 6
                    new []{ 7,90,5,1,100,10,10,2 }, // 122
                }
            , instance.Try
            , checkFunc: instance.Simple
            );

        }

    }
}
