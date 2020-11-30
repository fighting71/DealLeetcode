using Command.CommonStruct;
using Command.CusStruct;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Challenge;
using ConsoleTest.TestDemo.Hard;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.November.Week1;
using Questions.DailyChallenge._2020.November.Week2;
using Questions.DailyChallenge._2020.November.Week3;
using Questions.DailyChallenge._2020.November.Week4;
using Questions.DailyChallenge._2020.November.Week5;
using Questions.DailyChallenge._2020.October.Week2;
using Questions.DailyChallenge._2020.October.Week4;
using Questions.DailyChallenge._2020.October.Week5;
using Questions.Easy.Algorithms;
using Questions.Hard.Deal;
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
            //runSimple = false;

            //{
            //    Stone_Game_II instance = new Stone_Game_II();
            //    ShowTools.Show(instance.Simple(new[] { 8, 6, 9, 1, 7, 9 }));// 25
            //    ShowTools.Show(instance.Simple(new[] { 1, 2, 3, 4, 5, 100 }));// 104
            //    ShowTools.Show(instance.Simple(new[] { 2, 7, 9, 4, 4 }));// 10
            //}

            {
                var instance = new The_Skyline_Problem();
                The_Skyline_Problem.Test tools = new The_Skyline_Problem.Test();
                if (runSimple)
                { // simple
                    var argArr = new[]
                    {
                        JsonConvert.DeserializeObject<int[][]>("[[0,10,15],[0,10,22],[0,16,26],[0,19,22],[0,9,5],[0,7,8],[0,16,21],[0,17,3],[0,10,2],[0,7,22],[1,12,12],[1,5,20],[1,10,22],[1,5,19],[1,12,4],[1,10,26],[2,13,13],[2,3,30],[2,21,16],[2,20,8],[2,3,5],[2,17,16],[2,19,15],[2,2,6],[3,12,11],[3,5,10]]"), // [[0,26],[2,30],[3,26],[16,22],[19,16],[21,0]]
                        //JsonConvert.DeserializeObject<int[][]>("[[0,15,30],[2,14,12],[6,16,16],[9,14,21],[11,16,7],[14,24,21],[14,15,21],[15,30,14],[18,32,13],[19,23,23]]"), // [[0,30],[15,21],[19,23],[23,21],[24,14],[30,13],[32,0]]
                        //JsonConvert.DeserializeObject<int[][]>("[ [2,9,10], [3 ,7 ,15], [5 ,12 ,12], [15, 20, 10], [19, 24, 8] ]"), // [ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].
                        //JsonConvert.DeserializeObject<int[][]>("[[1,5,2],[2,3,3]]"),// [[1, 2],[2,3],[3,2],[5,0]]
                    };

                    foreach (var item in argArr)
                    {
                        tools.ShowImage(item);
                        ShowTools.Show(instance.Try(item));
                    }

                }
                else
                //for (int j = 0; j < 10; j++)
                { // speed&real

                    int len = 10;
                    int[][] arr = new int[len][],oldArr = new int[len][];

                    for (int i = 0; i < len; i++)
                    {
                        int[] item = new int[3];
                        item[0] = random.Next(20);
                        item[1] = random.Next(20) + item[0];
                        item[2] = random.Next(30) + 1;
                        arr[i] = item;
                        oldArr[i] = new[] { item[0], item[1], item[2] };
                    }
                    arr = arr.OrderBy(u => u[0]).ToArray();
                    oldArr = oldArr.OrderBy(u => u[0]).ToArray();

                    IList<IList<int>> res = null;
                    CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                    {
                        res = instance.Try(arr);
                    });

                    ShowTools.ShowMulti(new Dictionary<string, object> {
                        {nameof(arr),oldArr },
                        {nameof(res),res },
                        {nameof(codeTimerResult),codeTimerResult },
                    });

                }
            }

            {
                if (runSimple)
                { // simple

                }
                else
                { // speed&real
                }
            }
            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}