using Command.Helper;
using Questions.DailyChallenge._2021.May.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Command.Extension;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/21/2021 6:03:44 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFind_and_Replace_PatternDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Find_and_Replace_Pattern instance = new Find_and_Replace_Pattern();

            BaseLibrary.CommonTest(new[] {
                    (new [] {"abc","deq","mee","aqq","dkd","ccc"}, "abb"),// ["mee","aqq"]
                    (new [] {"a","b","c"}, "a"),// "a","b","c"
                }
            , arg => instance.Try3(arg.Item1, arg.Item2)
            , checkFunc: arg => instance.Try2(arg.Item1, arg.Item2)
            //, checkFunc: arg => instance.FindAndReplacePattern(arg.Item1, arg.Item2)
            , generateArg: () =>
            {
                //int len = random.Next(19) + 2;
                int len = 10;

                string[] arr = CollectionHelper.GetEnumerable(50000, () => CollectionHelper.GetString(len)).ToArray();

                return (arr, CollectionHelper.GetString(len));

            }
            //, skipFunc: res => res.Count == 0
            , showArg: false
            , showRes: false
            , formatArg: arg => $"{arg.Item1.SerieJson()}\n\"{arg.Item2}\""
            , equalsFunc: (res, res2) => res.SerieJson() == res2.SerieJson()
            );

        }
    }
}
