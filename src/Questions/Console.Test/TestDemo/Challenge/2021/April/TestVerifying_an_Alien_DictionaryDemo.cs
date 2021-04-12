using Questions.DailyChallenge._2021.April.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2021 4:27:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestVerifying_an_Alien_DictionaryDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Verifying_an_Alien_Dictionary instance = new Verifying_an_Alien_Dictionary();

            BaseLibrary.CommonTest(new[] {
                    (new []{"app","apple"}, "abcdefghijklmnopqrstuvwxyz"),// t
                    (new []{ "hello","leetcode"}, "hlabcdefgijkmnopqrstuvwxyz"),// t
                    (new []{"word","world","row"}, "worldabcefghijkmnpqstuvxyz"),// f
                    (new []{"apple","app"}, "abcdefghijklmnopqrstuvwxyz"),// f
                }
            , arg => instance.IsAlienSorted(arg.Item1, arg.Item2)
            );

        }
    }
}
