using Command.Helper;
using Command.Extension;
using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTest.LargeData;
using Command.Tools;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 4:46:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPath_With_Minimum_EffortDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Path_With_Minimum_Effort instance = new Path_With_Minimum_Effort();

            BaseLibrary.CommonTest(new[] {
                    "[[70,88,6,33,79],[61,31,36,85,2],[34,48,55,68,52],[9,88,18,48,42],[63,88,55,41,38]]".ParseJson<int[][]>(), // 
                    "[[862197,510254,914735,843901,742011],[317706,186497,394769,17975,953664],[747240,114886,901624,754441,613142],[465532,206528,795783,411846,639196],[277532,417732,172560,380569,232413]]".ParseJson<int[][]>(), // 
                    LargeString.Data2.ParseJson<int[][]>(),// 430152
                    "[[10,8],[10,8],[1,2],[10,3],[1,3],[6,3],[5,2]]".ParseJson<int[][]>(), // 6
                    CollectionHelper.GetEnumerable(5, () => CollectionHelper.GetEnumerable(5, () => random.Next(1000_000) + 1).ToArray()).ToArray(), // 380116
                }
                //, instance.Try3,
                , arg =>
                {
                    int res = instance.Try4(arg);

                    bool check = instance.Check(arg, res - 1);

                    if (check)
                    {
                        ShowTools.Show($"error arg : {arg.SerieJson()}\nres:{res}");
                    }

                    return check;
                }
                ,() => CollectionHelper.GetEnumerable(5, () => CollectionHelper.GetEnumerable(5, () => random.Next(100) + 1).ToArray()).ToArray()
                //,() => CollectionHelper.GetEnumerable(100, () => CollectionHelper.GetEnumerable(100, () => random.Next(1000_000) + 1).ToArray()).ToArray()
                , skipFunc: res => !res
                );

        }
    }
}
