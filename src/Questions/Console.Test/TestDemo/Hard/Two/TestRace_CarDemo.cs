using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/27/2021 4:54:49 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRace_CarDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Race_Car instance = new Race_Car();

            BaseLibrary.CommonTest(new[] {
                    //0,
                    10000, // 45
                    664, // 30
                    5, // 7
                    4, // 5
                    110, // 17
                    1, // 1
                    2, // 4
                    3,// 2
                    4, // 5
                    5, // 7
                    6, // 7
                    7, // 7
                    8, // 7
                    9, // 7
                }
            , instance.Clear
            , () => random.Next(10_0000)
            , checkFunc: instance.Try5
            );

        }

    }
}
