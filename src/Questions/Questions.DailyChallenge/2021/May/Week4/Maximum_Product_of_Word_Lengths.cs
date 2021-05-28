using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/28/2021 9:59:11 AM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3757/
    /// @des : 
    ///     给定一个单词列表，获取两个长度最长的单词
    ///     其他要求：
    ///         这两个单词不能拥有相同的字母
    /// </summary>
    public class Maximum_Product_of_Word_Lengths
    {

        // 2 <= words.length <= 1000
        //1 <= words[i].length <= 1000
        //words[i] consists only of lowercase English letters.

        public int Try(string[] words)
        {

        }

        // Runtime: 124 ms
        // Memory Usage: 29.1 MB
        // Your runtime beats 68.18 %  ???
        public int Simple(string[] words)
        {

            int res = 0;

            int len = words.Length;

            bool[][] exists = new bool[len][];

            for (int i = 0; i < len; i++)
            {
                var flag = exists[i] = new bool[26];

                var word = words[i];

                foreach (var c in word)
                {
                    flag[c - 'a'] = true;
                }

            }

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {

                    string word = words[i], word2 = words[j];

                    var count = word.Length * word2.Length;
                    if (count <= res) continue;

                    bool[] flag = exists[i], flag2 = exists[j];
                    bool success = true;
                    for (int k = 0; k < flag.Length; k++)
                    {
                        if(flag[k] && flag2[k])
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success) res = count;
                }
            }

            return res;

        }

    }
}
