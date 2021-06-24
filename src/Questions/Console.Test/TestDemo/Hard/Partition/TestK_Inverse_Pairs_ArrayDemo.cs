using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 3:07:16 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestK_Inverse_Pairs_ArrayDemo : BaseDemo, IWork
    {
        public void Run()
        {
            K_Inverse_Pairs_Array instance = new K_Inverse_Pairs_Array();

            BaseLibrary.CommonTest(new[] {
                    (500,1000), // 544867054
                    //(1000,1000), // 9
                    (100,2), // 4949
                    (5,2), // 9
                    (10,4), // 440
                    (10,5), // 1068
                    (3,0), // 1
                    (3,1), // 2
                }
            , arg => instance.Optimize2(arg.Item1, arg.Item2)
            //, () => (random.Next(1000) + 1, random.Next(1000) + 1)
            , () => (1000, random.Next(10000) + 1)
            , checkFunc: arg => instance.Optimize(arg.Item1, arg.Item2)
            , codeTimeCount: 100
            );

        }
    }
}
