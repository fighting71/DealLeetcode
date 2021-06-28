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

            { if (runSimple) { } else { } }

            {

                Minimum_Cost_to_Hire_K_Workers instance = new Minimum_Cost_to_Hire_K_Workers();

                BaseLibrary.CommonTest(new[] {
                    (new []{ 10,20,5 },new []{ 70,50,30 },2), // 105
                    (new []{ 3,1,10,10,1 },new []{ 4,8,2,2,7 },3), // 30.66667
                }
                , arg => instance.Try4(arg.Item1, arg.Item2, arg.Item3)
                //, arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3)
                //, arg => instance.Try(arg.Item1, arg.Item2, arg.Item3)
                , () =>
                {
                    int n = 10000;
                    //int n = 10;
                    int k = random.Next(n) + 1;

                    int maxV = 10000;

                    int[] quality = CollectionHelper.GetEnumerable(n, () => random.Next(maxV) + 1).ToArray(),
                    wage = CollectionHelper.GetEnumerable(n, () => random.Next(maxV) + 1).ToArray();

                    return (quality, wage, k);

                }
                //, checkFunc: arg => instance.Try2(arg.Item1, arg.Item2, arg.Item3)
                //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
                //, arg => instance.MincostToHireWorkers(arg.Item1, arg.Item2, arg.Item3)
                , equalsFunc: (res, res2) => (int)res == (int)res2
                //, showArg: false
                //, codeTimeCount: 20
                , formatArg: arg => $"{JsonConvert.SerializeObject(arg.Item1)}\n{JsonConvert.SerializeObject(arg.Item2)}\n{arg.Item3}"
                );

            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}