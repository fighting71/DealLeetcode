using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/28/2021 6:04:51 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3794/
    /// @des : 
    /// 
    ///     您将得到一个由小写英文字母组成的字符串s。重复删除包括选择两个相邻和相等的字母并删除它们。
    ///     
    ///     这题多少有点...mb, 只算两两删除   例如：  aab = b   aaab => ab(因为a有3个故保留一个...)
    /// 
    /// </summary>
    public class Remove_All_Adjacent_Duplicates_In_String
    {

        // Constraints:

        //1 <= s.length <= 10^5
        //s consists of lowercase English letters.

        // Your runtime beats 97.23 % of csharp submissions.
        public string RemoveDuplicates(string s)
        {
            char[] chars = new char[s.Length];
            int count = 0;
            char last = default;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if(last != c)
                {
                    last = chars[count++] = c;
                }
                else
                {
                    last = --count == 0 ? default : chars[count - 1];
                }
                
            }

            return new string(chars.Take(count).ToArray());

        }

    }
}
