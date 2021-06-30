using Command.Tools;
using Questions.DailyChallenge._2020.October.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/30/2020 4:47:58 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMaximize_Distance_to_Closest_Person : BaseDemo
    {

        public void Test()
        {
            Maximize_Distance_to_Closest_Person instance = new Maximize_Distance_to_Closest_Person();
            { // simple

                Console.WriteLine(instance.Solution(new[] { 1, 0, 1 }));// 1
                Console.WriteLine(instance.Solution(new[] { 1, 0, 0, 0, 1, 0, 1 })); // 2

            }
            { // speed&real
                CodeTimerResult codeTimerResult;

                int[] arr = new int[2 * 104];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(2);
                }

                int res = instance.Solution(arr);

                ShowTools.ShowMulti(new Dictionary<string, object>
                    {
                        {nameof(arr),arr },
                        {nameof(res),res }
                    });

            }
        }

    }
}
