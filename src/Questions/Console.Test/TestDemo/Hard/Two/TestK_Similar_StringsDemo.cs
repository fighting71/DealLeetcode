using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/25/2021 4:34:23 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestK_Similar_StringsDemo : BaseDemo, IWork
    {
        public void Run()
        {

            K_Similar_Strings instance = new K_Similar_Strings();

            BaseLibrary.CommonTest(new[] {
                    ("defc", "cdef"),// 3
                    ("baedfca", "acdaefb"),// 5
                    //("beaedfca", "eacdaefb"),// 6
                    //("bedfaedafca", "edaacdafefb"),// 8
                    ("bedeafedafca", "edaacedafefb"),// 9
                    ("abedfafefafcedcffcab", "fedaacfabcecdafeffbf"),// 12
                    ("aabc", "abca"),// 2
                    ("abccaacceecdeea", "bcaacceeccdeaae"),// 9
                }
            , arg => instance.Try4(arg.Item1, arg.Item2)
            //, arg => instance.Try3(arg.Item1, arg.Item2)
            //, arg => instance.Try2(arg.Item1, arg.Item2)
            //, arg => instance.KSimilarity(arg.Item1, arg.Item2)
            , () =>
            {
                var str = CollectionHelper.GetString(20, 'a', 6);

                var target = str.ToCharArray();

                for (int i = 0; i < 40; i++)
                {
                    var t = random.Next(target.Length);
                    var t2 = random.Next(target.Length);

                    var e = target[t];
                    target[t] = target[t2];
                    target[t2] = e;

                }

                return (str, new string(target));
            }
            , formatArg: arg => $"{arg.Item1}\n{arg.Item2}"
            );

        }

    }
}
