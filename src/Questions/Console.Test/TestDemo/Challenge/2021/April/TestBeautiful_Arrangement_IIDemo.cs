using Questions.DailyChallenge._2021.April.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/14/2021 10:58:25 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBeautiful_Arrangement_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Beautiful_Arrangement_II instance = new Beautiful_Arrangement_II();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"101-{i+1} : {instance.ConstructArray(101, i + 1).SerieJson()}");
            //}

            BaseLibrary.CommonTest(new[] {
                    (3,1),
                    (3,2),
                }
            , arg =>
            {
                    //int[] res = instance.ConstructArray(arg.Item1, arg.Item2);
                    int[] res = instance.Optimize(arg.Item1, arg.Item2);

                return instance.Check(arg.Item1, arg.Item2, res);
            }
            , checkFunc: arg => true
            , generateArg: () =>
            {
                var n = random.Next(10000) + 2;
                var k = random.Next(n - 1) + 1;
                return (n, k);
            }
            , codeTimeCount: 1000
            );

        }
    }
}
