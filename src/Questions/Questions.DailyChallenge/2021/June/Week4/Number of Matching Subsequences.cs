using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/22/2021 3:36:39 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3788/
    /// @des : 
    ///     给定一个字符串s和一个字符串单词数组，返回作为s的子序列的单词[i]的数量。
    ///     字符串的子序列是从原始字符串生成的新字符串，删除一些字符(可以是none)而不改变其余字符的相对顺序。
    ///     例如，“ace”是“abcde”的子序列。
    /// </summary>
    public class Number_of_Matching_Subsequences
    {

        // Constraints:

        //1 <= s.length <= 5 * 10^4
        //1 <= words.length <= 5000
        //1 <= words[i].length <= 50
        //s and words[i] consist of only lowercase English letters.

        // Your runtime beats 74.51 % of csharp submissions.
        // over~
        public int NumMatchingSubseq(string s, string[] words)
        {
            List<int>[] indexArr = new List<int>[26];

            for (int i = 0; i < indexArr.Length; i++)
            {
                indexArr[i] = new List<int>();
            }

            for (int i = 0; i < s.Length; i++)
            {
                indexArr[s[i] - 'a'].Add(i);
            }

            int res = words.Length;

            foreach (var word in words)
            {

                int currIndex = -1;
                foreach (var c in word)
                {
                    List<int> list = indexArr[c - 'a'];

                    if(list.Count == 0 || currIndex >= list[list.Count - 1])
                    {
                        res--;
                        break;
                    }

                    foreach (var index in list)
                    {
                        if (index > currIndex)
                        {
                            currIndex = index;
                            break;
                        }
                    }

                }

            }
            return res;
        }

    }
}
