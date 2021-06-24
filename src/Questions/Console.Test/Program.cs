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
using Questions.DailyChallenge._2021.May.Week4;
using Questions.DailyChallenge._2021.May.Week5;
using Questions.DailyChallenge._2021.June.Week1;
using Questions.DailyChallenge._2021.June.Week2;
using Questions.DailyChallenge._2021.June.Week3;
using ConsoleTest.TestDemo.Hard.Two;
using Questions.DailyChallenge._2021.June.Week4;

namespace ConsoleTest
{

    [Obsolete]
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

            //Console.WriteLine(1<< 0);
            //Console.WriteLine(1<< 1);
            //Console.WriteLine(1<< 2);

            { if (runSimple) { } else { } }

            {
                Shortest_Path_Visiting_All_Nodes instance = new Shortest_Path_Visiting_All_Nodes();

                BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>("[[1],[0,2,4],[1,3,4],[2],[1,2]]"), // 4
                    JsonConvert.DeserializeObject<int[][]>(" [[1,2,3],[0],[0],[0]]"), // 4
                }
                //, instance.Try
                , instance.Try2
                );

            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}