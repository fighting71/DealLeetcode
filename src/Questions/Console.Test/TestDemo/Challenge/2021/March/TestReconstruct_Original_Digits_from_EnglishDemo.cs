using Questions.DailyChallenge._2021.March.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/29/2021 12:22:19 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestReconstruct_Original_Digits_from_EnglishDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Reconstruct_Original_Digits_from_English instance = new Reconstruct_Original_Digits_from_English();

            //int[] count = new int[26];

            //foreach (var item in instance.Map)
            //{
            //    foreach (var c in item)
            //    {
            //        count[c - 'a']++;
            //    }
            //}

            //for (int i = 0; i < count.Length; i++)
            //{
            //    Console.WriteLine($"{(char)(i + 'a')}-{count[i]}");
            //}

            BaseLibrary.CommonTest(new[] {
                    "owoztneoer", // 012
                    "fviefuro", // 45
                }
            , instance.OriginalDigits
            );

        }
    }
}
