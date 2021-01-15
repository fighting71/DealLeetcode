using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/15/2021 3:38:57 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3597/
    /// @des : 
    /// </summary>
    public class Check_If_Two_String_Arrays_are_Equivalent
    {

        // 1 <= word1.length, word2.length <= 10^3
        //1 <= word1[i].length, word2[i].length <= 10^3
        //1 <= sum(word1[i].length), sum(word2[i].length) <= 10^3

        // Your runtime beats 84.86 % 
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            int len1 = word1.Length, len2 = word2.Length, i = 0, j = 0, index1 = 0, index2 = 0;

            while (true)
            {
                bool flag = i == len1, flag2 = j == len2;
                if (flag && flag2) return true;
                if (flag || flag2 || word1[i][index1] != word2[j][index2]) return false;

                if (++index1 == word1[i].Length)
                {
                    index1 = 0;
                    i++;
                }
                if (++index2 == word2[j].Length)
                {
                    index2 = 0;
                    j++;
                }

            }
        }

    }
}
