using Command.Helper;
using Command.Tools;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 2:47:58 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBoats_to_Save_PeopleDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Boats_to_Save_People instance = new Boats_to_Save_People();

            BaseLibrary.CommonTest(new[] {
                    //(new []{1,2},3),// 1
                    //(new []{3,2,2,1},3),// 3
                    //(new []{3,5,3,4},5),// 4
                    (new []{31,67,65,57,54,67,48,63,31,42,28,48,31,47,10,21,11,7,69,11 },70)//13
                }, arg => instance.NumRescueBoats(arg.Item1, arg.Item2), () =>
                {
                    int limit = random.Next(100) + 1;
                    var arr = CollectionHelper.GetArr(20, () => random.Next(limit) + 1).ToArray();
                    ShowTools.Show(arr);
                    return (arr, limit);
                });

        }
    }
}
