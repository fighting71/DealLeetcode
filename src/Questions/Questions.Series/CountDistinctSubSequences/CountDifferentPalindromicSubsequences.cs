using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 5:04:00 PM
    /// @source : https://leetcode.com/problems/count-different-palindromic-subsequences/
    /// @des : 给定一个字符串S，找出S中不同的非空回文子序列的数量，并以10^9 + 7求模返回该数字。
    /// </summary>
    public class CountDifferentPalindromicSubsequences
    {

        public const int mod = 1000_000_007;

        // The length of S will be in the range [1, 1000].
        // Each character S[i] will be in the set {'a', 'b', 'c', 'd'}.

        // Runtime: 428 ms, faster than 45.45% of C# online submissions for Count Different Palindromic Subsequences.
        // Memory Usage: 75.6 MB, less than 9.09% of C# online submissions for Count Different Palindromic Subsequences.
        // 泪目( Ĭ ^ Ĭ ).
        public int Try4(string S)
        {
            int len = S.Length;

            // dp[最左下标][最右下标][结尾字符] = 不同的回文数

            int[][][] dp = new int[len][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[len][];
            }

            // base case: dp[i][i][S[i]] = 1
            for (int i = 0; i < len; i++)
            {
                var arr = new int[4];
                arr[S[i] - 'a'] = 1;
                dp[i][i] = arr;
            }

            var emptyArr = new int[4];

            /*
             * 状态转移:
             * 
             *      对于区间[l, r] 有：
             *          1.S[l] != S[r] ==>
             *              dp[l][r][x] = dp[l - 1][r + 1][x] (x != l && x != r)  不以S[l]、S[r] 结尾的照常添加
             *              
             *              dp[l][r][S[l]] = Math.Max(1, dp[l][x][S[l]]) (x < r && S[x] == S[l])  在范围内找到最靠后的一个 S[l]
             *              
             *              dp[l][r][S[r]] = Math.Max(1, dp[x][r][S[r]]) (x > l && S[x] == S[r])  在范围内找到最靠前的一个 S[r]
             *              
             *              为啥要最靠前/靠后?
             *                  以b结尾的
             *                  sum(ababbb) > sum(abbb)
             *                  
             *          2.S[l] == S[r] ==>
             *              dp[l][r][x] = dp[l - 1][r + 1][x] (x != l && x != r)  不以S[l] 结尾的照常添加
             *              
             *              dp[l][r][S[l]] = dp[l - 1][r + 1][S[l]] + 2 + sum(dp[l - 1][r + 1][x])  (x != S[i])
             * 
             * Think
             *      a.利用结尾去重
             *      b.利用动态规划复用计算结果 父区间 = 子区间 + ?
             * 
             */

            for (int wid = 1; wid < len; wid++)
            {
                for (int l = 0; l < len - wid; l++)
                {
                    var r = l + wid;
                    int lKey = S[l] - 'a', rKey = S[r] - 'a';
                    var inner = dp[l + 1][r - 1] ?? emptyArr;

                    int[] arr = new int[4];
                    if (lKey != rKey)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == lKey || i == rKey) continue;
                            arr[i] = inner[i];
                        }
                        arr[rKey] = 1;
                        arr[lKey] = 1;
                        for (int i = l + 1; i < r; i++)
                        {
                            if(S[i] -'a' == rKey)
                            {
                                arr[rKey] = dp[i][r][rKey];
                                break;
                            }
                        }

                        for (int i = r - 1; i > l; i--)
                        {
                            if (S[i] - 'a' == lKey)
                            {
                                arr[lKey] = dp[l][i][lKey];
                                break;
                            }
                        }
                    }
                    else
                    {
                        int sum = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == lKey) continue;
                            arr[i] = inner[i];
                            sum = (sum + arr[i]) % mod;
                        }
                        arr[lKey] = (inner[lKey] + 2 + sum) % mod;
                    }
                    dp[l][r] = arr;
                }
            }

            var emp = dp[0][len - 1];
            int res = emp[0];
            for (int i = 1; i < emp.Length; i++)
            {
                res = (res + emp[i]) % mod;
            }

            return res;

        }


    }
}
