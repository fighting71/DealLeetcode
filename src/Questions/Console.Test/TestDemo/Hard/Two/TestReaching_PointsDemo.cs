using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/18/2021 5:53:09 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestReaching_PointsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Reaching_Points instance = new Reaching_Points();
            BaseLibrary.CommonTest(
                new[] {
                        (35, 13, 455955547, 420098884),// f
                        (1, 3, 15, 4),// f
                        (14,3,18,20),// f
                        (1,1,5,3),// t
                },
                //arg => instance.Try(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
                arg => instance.Try2(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
                , generateArg: () =>
                {
                    int x = random.Next(20) + 1;
                    int y = random.Next(20) + 1;
                    int tX = random.Next(20) + x;
                    int ty = random.Next(20) + y;
                    return (x, y, tX, ty);
                }
                 //, checkFunc: arg => instance.CacheSimple(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
                 , formatArg: arg => $"({arg.Item1}, {arg.Item2}, {arg.Item3}, {arg.Item4})"
                 , codeTimeCount: 100
                );
        }
    }
}
