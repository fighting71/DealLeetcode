using Questions.DailyChallenge._2021.January.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/18/2021 2:42:38 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_Sorted_Vowel_StringsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Count_Sorted_Vowel_Strings instance = new Count_Sorted_Vowel_Strings();

            for (int i = 50; i <= 50; i++)
            {
                int res = instance.Optimize2(i);
                int real = instance.Optimize(i);

                Console.WriteLine($"i:{i},res:{res},real:{real}");

                if (res != real) throw bugEx;

            }

            BaseLibrary.CommonTest(new[] {
                    1,
                    2,
                    33
                }, instance.Simple);
        }
    }
}
