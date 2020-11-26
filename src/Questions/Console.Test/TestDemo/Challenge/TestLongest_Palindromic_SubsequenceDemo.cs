using Command.Tools;
using Questions.Series.Dp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 2:25:39 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLongest_Palindromic_SubsequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Longest_Palindromic_Subsequence instance = new Longest_Palindromic_Subsequence();
            if (runSimple)
            { // simple

                var argArr = new[]
                {
                        "bbbab", // 4
                        "cbbd", // 2
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Solution(item));
                    ShowTools.Show(instance.Solution2(item));
                }

            }
            else
            { // speed&real
            }
        }

    }
}
