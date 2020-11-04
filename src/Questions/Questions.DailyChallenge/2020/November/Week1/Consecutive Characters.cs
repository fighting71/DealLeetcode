using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/4/2020 11:34:58 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3518/
    /// @des : 
    /// </summary>
    public class Consecutive_Characters
    {
        // 1 <= s.length <= 500
        // s contains only lowercase English letters.
        public int Try2(string s)
        {
            int res = 1, item = 1;
            char prev = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == prev)
                {
                    item++;
                    if (i == s.Length - 1) res = Math.Max(res, item);
                }
                else
                {
                    res = Math.Max(res, item);
                    prev = s[i];
                    item = 1;
                }
            }
            return res;

        }

        // Runtime: 76 ms
        // Memory Usage: 23.5 MB
        // Your runtime beats 63.73 % of csharp submissions.
        public int Simple(string s)
        {
            int res = 1,item = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if(s[i] == s[i - 1])
                {
                    item++;
                    if(i == s.Length -1) res = Math.Max(res, item);
                }
                else
                {
                    res = Math.Max(res, item);
                    item = 1;
                }
            }
            return res;

        }
    }
}
