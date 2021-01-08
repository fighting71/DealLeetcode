using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 4:26:31 PM
    /// @source : https://leetcode.com/problems/arithmetic-slices-ii-subsequence/
    /// @des : 
    ///     返回数组A中等差子序列片的数量 (等差序列的长度>=3)
    ///     子序列： (P0, P1, ..., Pk) such that 0 ≤ P0 < P1 < ... < Pk < N.
    /// </summary>
    public class Arithmetic_Slices_II___Subsequence
    {

        /*
         * bug : 数字重复问题:
         *  1,2,3,4,4,5
         *  1,2,2,3,4,4,5
         */
        public int Try(int[] arr)
        {
            int len = arr.Length, res = 0;

            // dic[diff] = count
            Dictionary<int, int>[] dp = new Dictionary<int, int>[len];

            int[] mulitiple = new int[len];

            for (int i = len - 2; i >= 0; i--)
            {
                var dic = new Dictionary<int, int>();
                int curr = arr[i];
                for (int j = i + 1; j < len; j++)
                {
                    var diff = arr[j] - curr;

                    if (dic.ContainsKey(diff))
                    {
                        mulitiple[i]++;
                        res += dic[diff] - 2;
                        continue;
                    }

                    if (dp[j] == null || !dp[j].ContainsKey(diff))
                    {
                        dic[diff] = 2;
                    }
                    else
                    {
                        /*
                         * 2,4,6,8,10,12,14
                         * 
                         * 3=1
                         * 4=3  1+2
                         * 5=7  3 + 3 + 1
                         * 6=12 7 + 4 + 1
                         * 7=20 12 + 5 + 1 + 2
                         * 8=29 20 + 6 + ...
                         * 
                         */
                        int count = dp[j][diff] + 1;
                        //if (mulitiple[j] > 0)
                        //    res += mulitiple[j];
                        res += count - 2;
                        dic[diff] = count;
                    }
                }
                dp[i] = dic;
            }

            return res;
        }

    }
}
