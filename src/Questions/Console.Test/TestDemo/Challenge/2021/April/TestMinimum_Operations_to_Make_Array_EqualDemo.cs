using Questions.DailyChallenge._2021.April.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 4:23:46 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinimum_Operations_to_Make_Array_EqualDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Minimum_Operations_to_Make_Array_Equal instance = new Minimum_Operations_to_Make_Array_Equal();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(i * 2 + 1);
            //}

            BaseLibrary.CommonTest(new[] {
                    3, // 2
                    6, // 9
                }
            , instance.Solution2
            , checkFunc: instance.Simple
            );

        }

    }
}
