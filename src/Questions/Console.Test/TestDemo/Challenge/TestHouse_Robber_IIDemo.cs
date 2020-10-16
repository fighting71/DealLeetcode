using Command.Tools;
using Questions.DailyChallenge._2020.October.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/14/2020 4:33:16 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestHouse_Robber_IIDemo : BaseDemo
    {

        public void Run()
        {
            { // simple
            }
            for (int j = 0; j < 20; j++)
            { // speed&real
                CodeTimerResult codeTimerResult;

                /*
                 1 <= nums.length <= 100
0 <= nums[i] <= 1000
                 */

                var arr = new int[random.Next(100) + 1];
                //var arr = new int[20];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(1000);
                }

                //var real = new House_Robber_II().Simple(arr);
                var real = new House_Robber_II().DpSolution(arr);
                var res = new House_Robber_II().OptimizeDpSolution(arr);

                ShowTools.ShowMulti(new Dictionary<string, object>()
                    {
                        {nameof(arr),arr },
                        {nameof(res),res },
                        {nameof(real),real },
                    });

                if (real != res) throw bugEx;

            }
        }

    }
}
