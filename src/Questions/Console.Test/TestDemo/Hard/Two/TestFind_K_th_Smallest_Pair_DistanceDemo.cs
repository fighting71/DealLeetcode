using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 4:12:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFind_K_th_Smallest_Pair_DistanceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Find_K_th_Smallest_Pair_Distance instance = new Find_K_th_Smallest_Pair_Distance();

            //int[] arg = new int[3];
            //arg[0] = 1;
            //for (int i = 2; i < 10; i++)
            //{
            //    arg[1] = i;
            //    arg[2] = i + 1;
            //    Console.WriteLine(instance.Simple(arg, 1));
            //}

            Console.WriteLine(instance.Simple(new[] { 1, 3, 5, 6, 10 }, 1));
            Console.WriteLine(instance.Try(new[] { 1, 3, 5, 6, 10 }, 1));

            BaseLibrary.CommonTest(new[] {
                    (new []{1,3,1},1)
                }
            , arg => instance.OtherSolution(arg.Item1, arg.Item2)
            , () =>
            {
                //var arr = CollectionHelper.GetEnumerable(10, () => random.Next(20)).ToArray();
                var arr = CollectionHelper.GetEnumerable(10000, () => random.Next(1000000)).ToArray();
                var index = arr.Length * (arr.Length - 1) / 2;
                return (arr, random.Next(index) + 1);
            }
            );

        }

    }
}
