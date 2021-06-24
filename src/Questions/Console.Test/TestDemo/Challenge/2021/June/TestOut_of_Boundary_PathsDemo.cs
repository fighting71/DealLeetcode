using Questions.DailyChallenge._2021.June.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/24/2021 6:54:31 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestOut_of_Boundary_PathsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Out_of_Boundary_Paths instance = new Out_of_Boundary_Paths();

            BaseLibrary.CommonTest(new[] {
                    (2,2,2,0,0),//6
                    (1,3,3,0,1),//12
                }
            , arg => instance.FindPaths(arg.Item1, arg.Item2, arg.Item3, arg.Item4, arg.Item5)
            , () =>
            {
                    //int m = 50, n = 50;
                    int m = random.Next(50) + 1, n = random.Next(50) + 1;

                return (m, n, 50, random.Next(m), random.Next(n));
            }
            );

        }

    }
}
