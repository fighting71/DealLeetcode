using Command.Tools;
using Questions.DailyChallenge._2020.October.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 9:44:43 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNumber_of_Longest_Increasing_SubsequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Number_of_Longest_Increasing_Subsequence instance = new Number_of_Longest_Increasing_Subsequence();
            { // simple
                Console.WriteLine(instance.Optimize(new[] { -85, -13, 44, 55, -35, -50, 12, 53, 104, -93 }));//5
                Console.WriteLine(instance.Simple(new[] { -85, -13, 44, 55, -35, -50, 12, 53, 104, -93 }));//5

                //Console.WriteLine(instance.Optimize(new[] { -68, -80, -104, -79, -98, -32, 46, 13, 55, 16 }));//9
                //Console.WriteLine(instance.Simple(new[] { -68, -80, -104, -79, -98, -32, 46, 13, 55, 16 }));//9

                //Console.WriteLine(instance.Optimize(new[] { -45, -1, 52, -81, -51, 6, 53, -87, 16, 18 }));//2
                //Console.WriteLine(instance.Simple(new[] { -45, -1, 52, -81, -51, 6, 53, -87, 16, 18 }));//2
                //Console.WriteLine(instance.Simple(new[] { 1, 3, 5, 4, 7 }));//2
                //Console.WriteLine(instance.Simple(new[] { 5, 5, 5, 5, 5 }));//5
            }
            for (int j = 0; j < 100; j++)
            { // speed&real
                if (runSimple) break;
                ShowTools.ShowHr();

                CodeTimerResult codeTimerResult;

                //0 <= nums.length <= 2000
                //-106 <= nums[i] <= 106

                var len = random.Next(2001);
                len = 10;

                var arr = new int[len];

                for (int i = 0; i < len; i++)
                {
                    arr[i] = random.Next(106 * 2 + 1) - 106;
                }
                int real = 0, res = 0;
                codeTimerResult = codeTimer.Time(1, () =>
                {
                    real = instance.Simple(arr);
                });

                Console.WriteLine("simple code timer res : " + codeTimerResult);

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Optimize(arr);
                });

                Console.WriteLine("optimize code timer res : " + codeTimerResult);

                if (real != res)
                {

                    Console.WriteLine("real:" + real);
                    Console.WriteLine("arr:" + ShowTools.GetStr(arr));
                    throw bugEx;
                }

            }
        }
    }
}
