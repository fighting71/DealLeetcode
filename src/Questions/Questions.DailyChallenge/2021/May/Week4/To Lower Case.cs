using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/24/2021 3:07:42 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3754/
    /// @des : 
    /// </summary>
    public class To_Lower_Case
    {

        // your runtime beats 51.96 % 
        public string Simple(string s)
        {
            char[] arr = s.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                ref char c = ref arr[i];
                if (c >= 'A' && c <= 'Z')
                {
                    c = (char)(c + 'a' - 'A');
                }
            }

            return new string(arr);

        }
    }
}
