using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/10/2021 5:18:25 PM
    /// @source : https://leetcode.com/problems/decode-ways-ii/
    /// @des : 
    /// 
    ///     给定一个包含[数字/*]的字符串
    ///         其中*可替代任何数字
    ///     target:
    ///         按照A=1,B=2....,Z=26 拆分成字母  有多少拆分方式
    ///     例:
    ///         str: 1203
    ///         拆分：
    ///             A(1) (20) C(3)
    ///             (12) (0) C(3)  X => 0并没有对应的字母
    ///         故总共有1种拆分方式
    /// 
    /// </summary>
    [Optimize("会有更简单的解法~")]
    public class Decode_Ways_II
    {

        // 1 <= s.length <= 10^5
        // s[i] is a digit or '*'.
        // Since the answer may be very large, return it modulo 10^9 + 7.

        // [A-Z] -> [1,26]
        // * -> [1,9]

        const int mod = 1000_000_007;

        // Runtime: 112 ms, faster than 7.69% of C# online submissions for Decode Ways II.
        // Memory Usage: 36.2 MB, less than 5.13% of C# online submissions for Decode Ways II.
        public int DpSolution2(string s)
        {
            int len = s.Length;

            // [0] 当前数 直接映射成字母 [1,9]
            // [1] 前一位是1与当前数组合 映射成字母 [0,9]
            // [2] 前一位是2与当前数组合 映射成字母 [0,6]
            long[] arr = new long[3];
            var last = s[len - 1];
            if (last == '*')
            {
                arr[0] = 9;
                arr[1] = 9;
                arr[2] = 6;
            }
            else
            {
                int num = last - '0';
                if (num != 0)
                {
                    if (num < 7)
                    {
                        arr[0] = arr[1] = arr[2] = 1;
                    }
                    else
                    {
                        arr[0] = arr[1] = 1;
                    }
                }
                else
                {
                    arr[1] = arr[2] = 1;
                }
            }

            for (int i = len - 2; i >= 0; i--)
            {
                var c = s[i];

                if (c == '*')
                {
                    long empty = arr[1] + arr[2];

                    arr[2] = 6 * arr[0];
                    arr[1] = 9 * arr[0];
                    arr[0] = 9 * arr[0] + empty;
                }
                else
                {
                    int num = c - '0';

                    if (num == 0)
                    {
                        arr[1] = arr[2] = arr[0];
                        arr[0] = 0;
                    }
                    else
                    {
                        if (num < 7)
                        {
                            long add = 0;
                            if(num < 3)
                            {
                                add = arr[num];
                            }
                            arr[1] = arr[2] = arr[0];
                            arr[0] += add;
                        }
                        else
                        {
                            arr[1] = arr[0];
                            arr[2] = 0;
                        }
                    }
                }

                // Runtime: 100 ms, faster than 12.82% of C# online submissions for Decode Ways II.
                // Memory Usage: 35.5 MB, less than 7.69 % of C# online submissions for Decode Ways II.
                if (arr[0] == 0 && arr[1] == 0 && arr[2] == 0) return 0;

                arr[0] %= mod;
                arr[1] %= mod;
                arr[2] %= mod;
            }
            return (int)arr[0];
        }

        public int DpSolution(string s)
        {
            int len = s.Length;
            // [下标][prev] = 组合数
            long[][] dp = new long[len][];

            // base case

            var last = s[len - 1];
            var lastDp = new long[3];
            if (last == '*')
            {
                lastDp[0] = 9;
                lastDp[1] = 9;
                lastDp[2] = 6;
            }
            else
            {
                int num = last - '0';
                if(num != 0)
                {
                    if(num < 7)
                    {
                        lastDp[0] = lastDp[1] = lastDp[2] = 1;
                    }
                    else
                    {
                        lastDp[0] = lastDp[1] = 1;
                    }
                }
                else
                {
                    lastDp[1] = lastDp[2] = 1;
                }
            }

            dp[len - 1] = lastDp;

            for (int i = len - 2; i >= 0; i--)
            {
                var c = s[i];
                var next = dp[i + 1];
                var arr = new long[3];

                if(c == '*')
                {
                    arr[0] = 9 * next[0] + next[1] + next[2];
                    arr[1] = 9 * next[0];
                    arr[2] = 6 * next[0];
                }
                else
                {
                    int num = c - '0';

                    if(num == 0)
                    {
                        arr[1] = arr[2] = next[0];
                    }
                    else
                    {
                        if(num < 7)
                        {
                            arr[0] = next[0] + (num < 3 ? next[num] : 0);
                            arr[1] = arr[2] = next[0];
                        }
                        else
                        {
                            arr[0] = arr[1] = next[0];
                        }
                    }

                    //{
                    //    // bug
                    //    arr[1] = arr[0] = next[0];
                    //    arr[2] = next[2];
                    //    int num = c - '0';
                    //    if (num > 0 && num < 3)
                    //    {
                    //        arr[0] = next[0] + next[num];
                    //    }
                    //    else if (num > 6)
                    //    {
                    //        arr[2] = 0;
                    //    }
                    //}
                }
                arr[0] %= mod;
                arr[1] %= mod;
                arr[2] %= mod;
                dp[i] = arr;
            }
            return (int)(dp[0][0] % mod);
        }

        public int Simple(string s)
        {
            int len = s.Length;

            if (len == 0) return 0;

            int res = Help(0, null);

            return res;

            int Help(int i, int? prev)
            {
                if (i == len) return prev.HasValue ? 0 : 1;
                var c = s[i];

                if(s[i] == '*')
                {
                    if (prev.HasValue)
                    {
                        if(prev.Value == 1)
                        {
                            return 9 * Help(i + 1, null);
                        }
                        //else// if(prev.Value == 2)
                        //{
                            return 6 * Help(i + 1, null);
                        //}
                    }
                    else
                    {
                        return 9 * Help(i + 1, null) + Help(i + 1, 1) + Help(i + 1, 2);
                    }
                }
                else
                {
                    var num = c - '0';
                    if (prev.HasValue)
                    {
                        if (prev.Value == 1)
                        {
                            return Help(i + 1, null);
                        }
                        //else if (prev.Value == 2)
                        //{
                        if (num > 6) return 0;
                        return Help(i + 1, null);
                        //}
                    }
                    else if (num == 0) return 0;
                    else if (num > 0 && num < 3)
                    {
                        return Help(i + 1, null) + Help(i + 1, num);
                    }
                    else
                    {
                        return Help(i + 1, null);
                    }
                }
            }

        }

    }
}
