using Command.Tools;
using Questions.DailyChallenge._2020.November.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/27/2020 6:23:19 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_Substring_with_At_Least_K_Repeating_CharactersDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Longest_Substring_with_At_Least_K_Repeating_Characters instance = new Longest_Substring_with_At_Least_K_Repeating_Characters();
            if (runSimple)
            { // simple
                var argArr = new[]
                {
                        ("bbaaacddcaabdbd", 3), // 3
                        ("ababbc", 2), // 5
                        ("ababacb", 3), // 0
                        ("aaabb", 3), // 3
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Simple(item.Item1, item.Item2));
                    ShowTools.Show(instance.Optimize(item.Item1, item.Item2));
                }

            }
            else
            { // speed&real
            }
        }
    }
}
