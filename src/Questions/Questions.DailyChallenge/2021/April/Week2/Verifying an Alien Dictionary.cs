using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2021 4:02:24 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3702/
    /// @des : 
    /// </summary>
    public class Verifying_an_Alien_Dictionary
    {

        // 1 <= words.length <= 100
        // 1 <= words[i].length <= 20
        // order.length == 26
        // All characters in words[i] and order are English lowercase letters.

        // Your runtime beats 31.68 %
        public bool IsAlienSorted(string[] words, string order)
        {

            int[] indexArr = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                indexArr[order[i] - 'a'] = i;
            }

            for (int i = 1; i < words.Length; i++)
            {
                string curr = words[i], prev = words[i - 1];

                bool flag = false;
                for (int j = 0; j < curr.Length && j < prev.Length; j++)
                {
                    int sequence = indexArr[curr[j] - 'a'], sequence2 = indexArr[prev[j] - 'a'];
                    if (sequence > sequence2)
                    {
                        flag = true;
                        break;
                    }
                    else if (sequence < sequence2)
                    {
                        return false;
                    }
                }

                if (!flag && curr.Length < prev.Length) return false;

            }

            return true;
        }
    }
}
