using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;
using Command.Extension;
using System.Linq;
using Command.Helper;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/21/2021 2:58:18 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBricks_Falling_When_HitDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Bricks_Falling_When_Hit instance = new Bricks_Falling_When_Hit();

            BaseLibrary.CommonTest(new[] {
                    ("[[1,1,1,1,1,0,0,1,0,1],[0,1,0,0,0,1,0,1,0,0],[1,1,0,1,1,1,1,0,0,1],[0,1,1,1,1,0,1,1,1,1],[1,0,0,1,1,1,1,1,0,0],[1,1,1,0,1,0,1,0,1,0],[1,1,1,0,1,0,1,0,1,1],[1,0,1,0,0,1,0,1,1,0],[1,1,0,0,0,1,1,0,0,1],[1,1,0,1,1,0,1,1,1,0]]".ParseJson<int[][]>(), "[[8,7],[2,3],[4,3],[6,5],[2,9],[8,2],[0,5],[6,0],[8,3],[1,1],[4,6],[6,7],[3,0],[9,2],[4,1],[7,2],[1,9],[5,6],[6,8]]".ParseJson<int[][]>()),// [0,0,0,0,0,0,0,0,0,22,0,0,0,0,0,0,0,0,0]
                    ("[[1,0,0,0],[1,1,1,0]]".ParseJson<int[][]>(),"[[1,0]]".ParseJson<int[][]>()), // [2]
                    ("[[0,1,0,0],[1,1,1,0]]".ParseJson<int[][]>(),"[[1,0]]".ParseJson<int[][]>()), // [0]
                    ("[[1,0,0,0],[1,1,0,0]]".ParseJson<int[][]>(),"[[1,1],[1,0]]".ParseJson<int[][]>()),// [0,0]
                },
            //arg => instance.Try(arg.Item1, arg.Item2)
            //arg => instance.Try2(arg.Item1, arg.Item2)
            arg => instance.Try4(arg.Item1, arg.Item2)
            //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2)
            , equalsFunc: (real, res) => real.Select((v, i) => res[i] != v).Any()
            , generateArg: () =>
            {
                int m = 200, n = 200, hitLen = 40_000;
                //int m = 10, n = 10, hitLen = 20;
                //int m = 20, n = 20,hitLen = 5;
                //int[][] grid = CollectionHelper.GetEnumerable(m, () => CollectionHelper.GetEnumerable(n, () => random.Next(2)).ToArray()).ToArray();
                int[][] grid = CollectionHelper.GetEnumerable(m, () => CollectionHelper.GetEnumerable(n, () => random.Next(9) > 3 ? 1 : 0).ToArray()).ToArray();

                int[][] hits = CollectionHelper.GetEnumerable(hitLen, () => (random.Next(m), random.Next(n))).Distinct().Select(u => new[] { u.Item1, u.Item2 }).ToArray();

                return (grid, hits);
            }
            ,
            codeTimeCount: 2,
            //showRes: false,
            skipFunc: res => res.All(u => u == 0)
            , formatArg: arg => $"{arg.Item1.SerieJson()}\n{arg.Item2.SerieJson()}"
            );

        }
    }
}
