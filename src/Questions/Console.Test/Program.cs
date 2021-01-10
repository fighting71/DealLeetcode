using Command.CommonStruct;
using Command.CusStruct;
using Command.Helper;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Challenge;
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
using Questions.DailyChallenge._2021.January;
using Questions.DailyChallenge._2021.January.Week2;
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

namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {
            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            Exception bugEx = new Exception("bug");
            bool runSimple = true;
            runSimple = false;

            checked
            {
                var num = 1;
                Console.WriteLine(int.MinValue - num);
            }

            { if (runSimple) { } else { } }

            //{
            //    Stone_Game_II instance = new Stone_Game_II();
            //    ShowTools.Show(instance.Simple(new[] { 8, 6, 9, 1, 7, 9 }));// 25
            //    ShowTools.Show(instance.Simple(new[] { 1, 2, 3, 4, 5, 100 }));// 104
            //    ShowTools.Show(instance.Simple(new[] { 2, 7, 9, 4, 4 }));// 10
            //}

            TestArithmetic_Slices_II___Subsequence(random);

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        private static void TestArithmetic_Slices_II___Subsequence(Random random)
        {
            Arithmetic_Slices_II___Subsequence instance = new Arithmetic_Slices_II___Subsequence();

            BaseLibrary.CommonTest(new[] {
                    new []{1,2,3},
                    new []{1,2,3,4},
                    new []{1,2,3,4,5},
                    new []{1,2,3,4,5,6},
                    new []{1,2,3,4,5,6,7},
                    new []{1,2,3,4,5,6,7,8},
                    new []{1,2,3,4,5,6,7,8,9},
                    new []{1,2,3,4,5,6,7,8,9,10},
                    new []{3,4,4,5}, // 2
                    new []{2,3,4,4,5}, // 6
                    new []{1,2,3,4,4,5}, // 12
                    new []{1,2,2,3,4,4,5}, // 21
                    //JsonConvert.DeserializeObject<int[]>("[18,2,0,0,12,8,17,15,4,14,1,18,18,12,5,10,15,13,1,6]"),// 24
                    JsonConvert.DeserializeObject<int[]>("[2147483638,2147483639,2147483640,2147483641,2147483642,2147483643,2147483644,2147483645,2147483646,2147483647,-2147483648,-2147483647,-2147483646,-2147483645,-2147483644,-2147483643,-2147483642,-2147483641,-2147483640,-2147483639]"),// 110
                }, instance.Try3, () => CollectionHelper.GetArr(1000, () => random.Next(100)).ToArray());

            ShowTools.ShowHr();

            //BaseLibrary.CommonTest(new[] {
            //        new []{1,2,3},
            //        new []{1,2,3,4},
            //        new []{1,2,3,4,5},
            //        new []{1,2,3,4,5,6},
            //        new []{1,2,3,4,5,6,7},
            //        new []{1,2,3,4,5,6,7,8},
            //        new []{1,2,3,4,5,6,7,8,9},
            //        new []{1,2,3,4,5,6,7,8,9,10},
            //        new []{3,4,4,5}, // 2
            //        new []{2,3,4,4,5}, // 6
            //        new []{1,2,3,4,4,5}, // 12
            //        new []{1,2,2,3,4,4,5}, // 21
            //        JsonConvert.DeserializeObject<int[]>("[18,2,0,0,12,8,17,15,4,14,1,18,18,12,5,10,15,13,1,6]"),// 24
            //    }, instance.Simple, () => CollectionHelper.GetArr(20, () => random.Next(20)).ToArray());
        }
    }
}