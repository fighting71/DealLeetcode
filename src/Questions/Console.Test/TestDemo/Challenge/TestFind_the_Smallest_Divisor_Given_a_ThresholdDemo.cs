using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.November.Week1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/6/2020 6:26:49 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFind_the_Smallest_Divisor_Given_a_ThresholdDemo : BaseDemo
    {

        public void Run()
        {
            Find_the_Smallest_Divisor_Given_a_Threshold instance = new Find_the_Smallest_Divisor_Given_a_Threshold();
            { // simple

                Console.WriteLine(instance.Try2(JsonConvert.DeserializeObject<int[]>("[1,2,3]"), 6));

                Console.WriteLine(instance.Try2(JsonConvert.DeserializeObject<int[]>(File.ReadAllText(@"F:\Davis\EmptyTxt\intarr3.txt")), 405207));
                //Console.WriteLine(instance.Try2(JsonConvert.DeserializeObject<int[]>(File.ReadAllText(@"F:\Davis\EmptyTxt\intarr2.txt")), 574401));
                //Console.WriteLine(instance.Try2(JsonConvert.DeserializeObject<int[]>(File.ReadAllText(@"F:\Davis\EmptyTxt\intarr.txt")), 713994));

                //Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[]>("[1,2,5,9]"),6));
                //Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[]>("[2,3,5,7,11]"),11));
            }
            for (int j = 0; j < 2; j++)
            { // speed&real
                if (runSimple) break;
                var arr = new int[5 * 10_000];
                //var arr = new int[20];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(1000_000) + 1;
                    //arr[i] = random.Next(10)+1;
                }

                int threshold = random.Next(1000_000) + 1;
                //int threshold = random.Next(50) + 1;

                int res = 0;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Try2(arr, threshold);
                });

                ShowTools.ShowMulti(new Dictionary<string, object>()
                    {
                        {nameof(arr),arr },
                        {nameof(threshold),threshold },
                        {nameof(res),res },
                        {nameof(codeTimerResult),codeTimerResult }
                    });

            }
        }

    }
}
