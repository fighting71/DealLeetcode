using Command.CommonStruct;
using Command.CusStruct;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Challenge;
using ConsoleTest.TestDemo.Hard;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.December.Week1;
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

            {
                Increasing_Order_Search_Tree instance = new Increasing_Order_Search_Tree();
                if (runSimple)
                { // simple
                    TreeNode treeNode = instance.Simple("[5,3,6,2,4,null,8,1,null,null,null,7,9]");
                    Console.WriteLine(treeNode);
                }
                else
                { // speed&real
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

            //{
            //    Stone_Game_II instance = new Stone_Game_II();
            //    ShowTools.Show(instance.Simple(new[] { 8, 6, 9, 1, 7, 9 }));// 25
            //    ShowTools.Show(instance.Simple(new[] { 1, 2, 3, 4, 5, 100 }));// 104
            //    ShowTools.Show(instance.Simple(new[] { 2, 7, 9, 4, 4 }));// 10
            //}

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}