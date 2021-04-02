using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.CountDistinctSubSequences
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2021 10:58:29 AM
    /// @source : 给定一个字符串，获取其不同的子序列的总数
    /// @des : 
    /// </summary>
    public class CountDistinctSubSequences
    {

        public const int mod = 1000_000_007;

        public int Run(string str)
        {
            // 定义一个end,其中下标i表示以i结尾，例如: 0 = 以a结尾
            int[] end = new int[26];
            foreach (var c in str)
            {
                // 每次遍历时，计算之前所有不同的子序列的总数，以c结尾=总数+1
                // end[i] = prev_sum(end) + 1
                /*
                 * 示例: abc
                 *下标\遍历    a   b       c
                 *  a         1   1       1
                 *  b             2(ab,b) 2
                 *  c                     4(c,ac,bc,abc)
                 */
                end[c - 'a'] = end.Sum() + 1;
            }
            return end.Sum();
        }

        public int Run2(string str)
        {
            int[] end = new int[26];
            int sum = 0;
            foreach (var c in str)
            {
                ref int v = ref end[c - 'a'];
                var old = sum - v;
                v = sum + 1;
                sum += v;
                sum %= mod;
            }
            return sum;
        }

    }
}
