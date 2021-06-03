using Command.Helper;
using Questions.DailyChallenge._2021.May.Week5;
using System;
using System.Collections.Generic;
using System.Text;
using Command.Extension;
using System.Linq;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/1/2021 11:25:01 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSearch_Suggestions_SystemDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Search_Suggestions_System instance = new Search_Suggestions_System();

            BaseLibrary.CommonTest(new[] {
                    (new []{ "mobile","mouse","moneypot","monitor","mousepad" }, "mouse"),
                }
            , arg => instance.SuggestedProducts(arg.Item1, arg.Item2)
            , () =>
            {
                string[] products = CollectionHelper.GetEnumerable(1000, () => CollectionHelper.GetString(1_020)).ToArray();
                string searchWord = CollectionHelper.GetString(1_000);
                return (products, searchWord);
            }
            //, showArg: false
            , showRes: false
            , formatArg: arg => $"{arg.Item1.SerieJson()}\n\"{arg.Item2}\""
            );

        }
    }
}
