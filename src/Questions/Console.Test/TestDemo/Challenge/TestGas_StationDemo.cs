using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020September.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/24/2020 6:42:53 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestGas_StationDemo : BaseDemo
    {

        public void Test()
        {

            int res = default;

            bool onlySimple = true;
            onlySimple = false;

            { // simple test case

                int[][] gas = new[]
                {
                        new[] { 7, 1, 8, 3, 10, 1, 9, 4, 3, 2, 4, 6, 6, 5 } ,//-1
                        new[] { 6, 1, 2, 4, 1, 2, 9, 4, 3, 3, 1, 8, 4, 7, 5, 6, 2 } ,//-1
                        new[] { 8, 1, 7, 9, 2, 2, 4, 4, 5, 3, 1, 4, 2, 1, 1 } ,//0
                        new[] { 10, 4, 10, 9, 3, 1, 10, 2, 2, 9 } ,// 0
                        new[] { 4, 5, 1, 6, 1, 4, 5, 10, 1, 4, 10, 1 } ,// -1
                        new[] { 6, 6, 3, 8, 5, 8, 4, 5, 8, 2, 8, 3, 8, 6, 8, 8, 7, 1 } ,// 0
                        new[] { 2, 1, 7, 5, 4, 3, 10, 9, 6, 4, 2, 9 } ,// 3
                        new []{ 1, 2, 3, 4, 5 }, // 3
                        new[] { 2, 3, 4 } ,// 1
                    };
                int[][] cost = new[]
                {
                        new[] { 7,2,4,2,10,2,5,2,3,3,4,6,7,5},
                        new[] { 3,2,2,5,2,3,9,4,3,4,2,8,5,8,6,2,2},
                        new[] { 6,2,2,2,2,3,5,5,6,4,2,5,3,2,2},
                        new[] { 9,2,11,2,4,2,9,2,2,8 },
                        new[] { 5,6,2,6,2,5,6,9,2,2,9,2 },
                        new[] { 4,4,4,6,4,5,2,4,8,3,9,2,5,4,6,7,8,2 },
                        new[] { 3,2,8,4,2,3,3,9,3,5,3,2 },
                        new[]{ 3, 4, 5, 1, 2 },
                        new[]{ 3, 4, 5, 1, 2 },
                        new[] { 3, 4, 3 },
                    };

                for (int i = 0; i < gas.Length; i++)
                {
                    if (!onlySimple) break;
                    //res = new Gas_Station().Try(gas[i], cost[i]);
                    //ShowTools.Show(res);

                    var real = new Gas_Station().Solution(gas[i], cost[i]);

                    res = new Gas_Station().Optimize(gas[i], cost[i]);
                    ShowTools.Show(res);

                    if (res != real)
                    {
                        throw bugEx;
                    }

                }

            }

            for (int j = 0; j < 10000; j++)
            { // speed test case
                if (onlySimple) break;
                List<int> gas = new List<int>(), cost = new List<int>();

                for (int i = 0; i < random.Next(20) + 10; i++)
                {
                    int gasNum = random.Next(10) + 1, costNum = random.Next(gasNum) + 2;
                    gas.Add(gasNum);
                    cost.Add(costNum);
                }

                Console.WriteLine($@"
gas:{JsonConvert.SerializeObject(gas)}
cost:{JsonConvert.SerializeObject(cost)}
res:{res}
");

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = new Gas_Station().Optimize(gas.ToArray(), cost.ToArray());
                    //res = new Gas_Station().Solution(gas.ToArray(), cost.ToArray());
                    //res = new Gas_Station().Try(gas.ToArray(), cost.ToArray());
                });

                Console.WriteLine(codeTimerResult);

                if (res != new Gas_Station().Solution(gas.ToArray(), cost.ToArray()))
                {
                    throw bugEx;
                }

            }

        }


    }
}
