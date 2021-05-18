using Command.CommonStruct;
using Command.CusStruct;
using Command.Helper;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Challenge;
using ConsoleTest.TestDemo.Challenge._2021.February.Week1;
using ConsoleTest.TestDemo.Hard;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.December.Week1;
using Questions.DailyChallenge._2020.December.Week2;
using Questions.DailyChallenge._2020.December.Week3;
using Questions.DailyChallenge._2020.December.Week4;
using Questions.DailyChallenge._2020.December.Week5;
using Questions.DailyChallenge._2020.November.Week1;
using Questions.DailyChallenge._2020.November.Week2;
using Questions.DailyChallenge._2020.November.Week3;
using Questions.DailyChallenge._2020.November.Week4;
using Questions.DailyChallenge._2020.November.Week5;
using Questions.DailyChallenge._2020.October.Week2;
using Questions.DailyChallenge._2020.October.Week4;
using Questions.DailyChallenge._2020.October.Week5;
using Questions.DailyChallenge._2021.February.Week1;
using Questions.DailyChallenge._2021.January;
using Questions.DailyChallenge._2021.January.Week2;
using Questions.DailyChallenge._2021.January.Week3;
using Questions.DailyChallenge._2021.January.Week4;
using Questions.DailyChallenge._2021.January.Week5;
using Questions.Easy.Algorithms;
using Questions.Hard.Deal;
using Questions.Hard.Deal2;
using Questions.Middle.Deal;
using Questions.Series.AlgorithmThinking;
using Questions.Series.Common_Think;
using Questions.Series.Common_Think.BinarySearch;
using Questions.Series.Dp;
using Questions.Series.Dp.Stone_Game;
using Questions.Series.Dp.动态规划之正则表达;
using Questions.Series.Dp.贪心算法之区间调度问题;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Command.Extension;
using Questions.DailyChallenge._2021.February.Week4;
using Questions.DailyChallenge._2021.March.Week1;
using Questions.DailyChallenge._2021.March.Week2;
using Questions.DailyChallenge._2021.March.Week3;
using Questions.Hard.Deal3;
using Questions.DailyChallenge._2021.March.Week4;
using Questions.DailyChallenge._2021.March.Week5;
using ConsoleTest.TestDemo.Challenge._2021.January;
using Questions.Series.CountDistinctSubSequences;
using Questions.DailyChallenge._2021.April.Week1;
using Questions.DailyChallenge._2021.April.Week2;
using Questions.DailyChallenge._2021.April.Week3;
using Questions.DailyChallenge._2021.April.Week4;
using ConsoleTest.TestDemo.Challenge._2021.April;
using Questions.DailyChallenge._2021.April.Week5;
using Questions.DailyChallenge._2021.May.Week2;
using Questions.DailyChallenge._2021.May.Week1;
using Questions.DailyChallenge._2021.May.Week3;

namespace ConsoleTest
{

    class Program
    {

        #region base node

        // 子序列： 不连续
        // 子串: 连续
        //例如：
        //    123456789：
        //        (137)-子序列
        //        (123)-子串
        #endregion

        static void Main(string[] args)
        {
            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            Exception bugEx = new Exception("bug");
            bool runSimple = true;
            runSimple = false;

            { if (runSimple) { } else { } }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        private static void TestBricks_Falling_When_HitDemo(Random random)
        {
            Bricks_Falling_When_Hit instance = new Bricks_Falling_When_Hit();

            BaseLibrary.CommonTest(new[] {
                    ("[[1,1,1,1,1,0,0,1,0,1],[0,1,0,0,0,1,0,1,0,0],[1,1,0,1,1,1,1,0,0,1],[0,1,1,1,1,0,1,1,1,1],[1,0,0,1,1,1,1,1,0,0],[1,1,1,0,1,0,1,0,1,0],[1,1,1,0,1,0,1,0,1,1],[1,0,1,0,0,1,0,1,1,0],[1,1,0,0,0,1,1,0,0,1],[1,1,0,1,1,0,1,1,1,0]]".ParseJson<int[][]>(),
                    "[[8,7],[2,3],[4,3],[6,5],[2,9],[8,2],[0,5],[6,0],[8,3],[1,1],[4,6],[6,7],[3,0],[9,2],[4,1],[7,2],[1,9],[5,6],[6,8]]".ParseJson<int[][]>()),// [0,0,0,0,0,0,0,0,0,22,0,0,0,0,0,0,0,0,0]
                    ("[[1,0,0,0],[1,1,1,0]]".ParseJson<int[][]>(),"[[1,0]]".ParseJson<int[][]>()), // [2]
                    ("[[0,1,0,0],[1,1,1,0]]".ParseJson<int[][]>(),"[[1,0]]".ParseJson<int[][]>()), // [0]
                    ("[[1,0,0,0],[1,1,0,0]]".ParseJson<int[][]>(),"[[1,1],[1,0]]".ParseJson<int[][]>()),// [0,0]
                },
            //arg => instance.Try(arg.Item1, arg.Item2)
            arg => instance.Try2(arg.Item1, arg.Item2)
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

        private static void TestSmallest_Rotation_with_Highest_ScoreDemo()
        {
            Smallest_Rotation_with_Highest_Score instance = new Smallest_Rotation_with_Highest_Score();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[]>("[0, 0, 0, 0, 0]"),
                    JsonConvert.DeserializeObject<int[]>("[2, 3, 1, 4, 0]"), // 3
                    JsonConvert.DeserializeObject<int[]>(" [1, 3, 0, 2, 4]"), // 0
                }
            , instance.OtherSolution
            //, instance.Simple
            );

        }

        private static void TestReaching_Points(Random random)
        {
            Reaching_Points instance = new Reaching_Points();
            BaseLibrary.CommonTest(
                new[] {
                        (1, 3, 15, 4),// f
                        (14,3,18,20),// f
                        (1,1,5,3),// t
                },
                arg => instance.Try(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
                , generateArg: () =>
                {
                    int x = random.Next(20) + 1;
                    int y = random.Next(20) + 1;
                    int tX = random.Next(20) + x;
                    int ty = random.Next(20) + y;
                    return (x, y, tX, ty);
                }
                 , checkFunc: arg => instance.CacheSimple(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
                 , formatArg: arg => $"({arg.Item1}, {arg.Item2}, {arg.Item3}, {arg.Item4})"
                 , codeTimeCount: 100
                );
        }

        #region todo

        private static void TestSliding_Puzzle(Random random)
        {

            #region Sliding_Puzzle
            //{
            //    Sliding_Puzzle instance = new Sliding_Puzzle();

            //    BaseLibrary.CommonTest(new[] {
            //        "[[4,1,5],[3,2,0]]".ParseJson<int[][]>(),// -1
            //        "[[1,2,3],[4,0,5]]".ParseJson<int[][]>(),// 1
            //        "[[1,2,3],[5,4,0]]".ParseJson<int[][]>(),// -1
            //        "[[4,1,2],[5,0,3]]".ParseJson<int[][]>(),// 5
            //    }
            //    , instance.Try
            //    );

            //}
            #endregion
        }

        private static void TestCount_The_Repetitions(Random random)
        {
            Count_The_Repetitions instance = new Count_The_Repetitions();
            BaseLibrary.CommonTest(new[] {
                    ("bacaba",3,"abacab",1), // 2
                    ("aaa",3,"aa",1), // 4
                    ("acb",4,"ab",2),// 2
                }, arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , () =>
            {
                return (
                    string.Concat(CollectionHelper.GetEnumerable(10, () => (char)(random.Next(10) + 'a'))),
                    (random.Next(10) + 1) * 3,

                    string.Concat(CollectionHelper.GetEnumerable(5, () => (char)(random.Next(10) + 'a'))),
                    (random.Next(5) + 1) * 2
                );
            });

        }

        private static void TestCreate_Sorted_Array_through_Instructions(Random random)
        {
            Create_Sorted_Array_through_Instructions instance = new Create_Sorted_Array_through_Instructions();

            BaseLibrary.CommonWithCheckTest(new[] {
                    JsonConvert.DeserializeObject<int[]>("[1,5,6,2]"), // 1
                    JsonConvert.DeserializeObject<int[]>("[1,2,3,6,5,4]"), // 3
                    JsonConvert.DeserializeObject<int[]>("[1,3,3,3,2,4,2,1,2]"), // 4
                }, instance.Try, instance.Optimize, () => CollectionHelper.GetEnumerable(1000_00, () => random.Next(1000_00) + 1).ToArray(), showArg: false);
        }
        #endregion
    }
}