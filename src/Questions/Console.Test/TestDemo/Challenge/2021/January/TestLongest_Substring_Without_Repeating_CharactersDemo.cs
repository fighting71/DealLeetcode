using Command.Helper;
using Questions.DailyChallenge._2021.January;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 3:16:25 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_Substring_Without_Repeating_CharactersDemo : BaseDemo, IWork
    {
        public void Run()
        {
            var instance = new Longest_Substring_Without_Repeating_Characters();

            BaseLibrary.CommonTest(
                new[] {
                        "abbba",
                        "abcabcbb",
                        "bbbbb",
                        "pwwkew"
                }
                , instance.OldSolution, () =>
                {
                    var arr = CollectionHelper.GetArr(5000_0, () => (char)(random.Next(26) + 'a'));

                    return string.Concat(arr);
                }
                //, 100, false
                );
        }
    }
}
