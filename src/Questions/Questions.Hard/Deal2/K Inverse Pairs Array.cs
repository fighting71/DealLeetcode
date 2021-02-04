using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 10:23:13 AM
    /// @source : https://leetcode.com/problems/k-inverse-pairs-array/
    /// @des : 
    ///     给定两个整数n和k，找出有多少个不同的数组由1到n的数字组成，且恰好有k个逆对。
    ///     我们定义逆对如下:对于数组中的第i和第j个元素，如果 if i < j and a[i] > a[j]  否则,它不是。
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class K_Inverse_Pairs_Array
    {

        // The integer n is in the range [1, 1000] and k is in the range [0, 1000].
        // Since the answer may be very large, the answer should be modulo 10^9 + 7.

        // Runtime: 56 ms, faster than 50.00% of C# online submissions for K Inverse Pairs Array.
        // Memory Usage: 19.1 MB, less than 100.00% of C# online submissions for K Inverse Pairs Array.
        public int Optimize2(int n, int k)
        {
            if (k == 0) return 1;

            var prev = new int[k + 1];
            prev[0] = 1;
            const int mod = 1000_000_007;
            for (int i = 2; i <= n; i++)
            {
                var curr = new int[k + 1];
                var limit = Math.Min(k, i - 1);

                curr[0] = 1;
                for (int j = 1; j <= limit; j++)
                {
                    curr[j] = (curr[j - 1] + prev[j]) % mod;
                }
                for (int j = limit + 1; j <= k; j++)
                {
                    curr[j] = (curr[j - 1] + ((prev[j] - prev[j - limit - 1] + mod) % mod)) % mod;
                }

                prev = curr;
            }

            return prev[k];
        }

        // Runtime: 60 ms, faster than 50.00% of C# online submissions for K Inverse Pairs Array.
        // Memory Usage: 19.3 MB, less than 100.00% of C# online submissions for K Inverse Pairs Array.
        public int Optimize(int n, int k)
        {
            if (k == 0) return 1;

            var prev = new int[k + 1];
            prev[0] = 1;
            const int mod = 1000_000_007;
            for (int i = 2; i <= n; i++)
            {
                var curr = new int[k + 1];
                var limit = Math.Min(k, i - 1);

                curr[0] = 1;
                for (int j = 1; j <= k; j++)
                {
                    curr[j] = (curr[j - 1] + (j > limit ? 
                        ((prev[j] - prev[j - limit - 1] + mod) % mod)
                        : prev[j])) % mod;
                }

                prev = curr;
            }

            return prev[k];
        }

        // Runtime: 80 ms, faster than 50.00% of C# online submissions for K Inverse Pairs Array.
        // Memory Usage: 19.4 MB, less than 100.00% of C# online submissions for K Inverse Pairs Array.
        // 简化自Try3，最终版
        public int Try5(int n, int k)
        {
            if (k == 0) return 1;

            var prev = new int[k + 1];
            prev[0] = 1;
            const int mod = 1000_000_007;
            for (int i = 2; i <= n; i++)
            {
                var curr = new int[k + 1];
                var limit = Math.Min(k, i - 1);

                curr[0] = 1;
                for (int j = 1; j <= k; j++)
                {
                    curr[j] = (curr[j - 1] + prev[j]) % mod;

                    // 根据参考输出 简化求和
                    // 210 (next) -> 3210 - 0
                    if (j > limit)
                    {
                        curr[j] = (curr[j] - prev[j - limit - 1] + mod) % mod;
                    }
                }

                prev = curr;
            }

            return prev[k];
        }
        // slow
        // dp solution from Try3
        // 区别不大
        public int Try4(int n, int k)
        {

            if (k == 0) return 1;

            var prev = new int[k + 1];
            prev[0] = 1;
            for (int i = 2; i <= n; i++)
            {
                var curr = new int[k + 1];
                curr[0] = 1;
                for (int count = 1; count <= k; count++)
                {
                    var sum = 0;
                    var limit = Math.Min(count, i - 1);
                    for (int j = 0; j <= limit; j++)
                    {
                        sum += prev[count - j];
                        sum %= 1000_000_007;
                    }
                    curr[count] = sum;
                }
                prev = curr;
            }

            return prev[k];
        }

        // dp solution
        public int Try3(int n, int k)
        {

            if (k == 0) return 1;

            // dp[下标][逆对数量] = 排列数
            int[][] dp = new int[n + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[k + 1];
            }

            for (int i = 1; i <= n; i++)
            {
                // base case:
                dp[i][0] = 1;
                for (int count = 1; count <= k; count++)
                {
                    var sum = 0;
                    // 状态转移：
                    // dp[i][count] = dp[i-1]{count - j}

                    #region 输出参考：
                    /*
                     * n = 10  k = 4
                     * 
                     * 1 <<< 1_1
2 <<< 1_2
3 <<< 1_3
4 <<< 1_4

10 <<< 2_1
21 <<< 2_2
32 <<< 2_3
43 <<< 2_4

10 <<< 3_1
210 <<< 3_2
321 <<< 3_3
432 <<< 3_4

10 <<< 4_1
210 <<< 4_2
3210 <<< 4_3
4321 <<< 4_4

10 <<< 5_1
210 <<< 5_2
3210 <<< 5_3
43210 <<< 5_4

10 <<< 6_1
210 <<< 6_2
3210 <<< 6_3
43210 <<< 6_4

10 <<< 7_1
210 <<< 7_2
3210 <<< 7_3
43210 <<< 7_4

10 <<< 8_1
210 <<< 8_2
3210 <<< 8_3
43210 <<< 8_4

10 <<< 9_1
210 <<< 9_2
3210 <<< 9_3
43210 <<< 9_4

10 <<< 10_1
210 <<< 10_2
3210 <<< 10_3
43210 <<< 10_4 
----------------S------------------
[[0,0,0,0,0],[1,0,0,0,0],[1,1,0,0,0],[1,2,2,1,0],[1,3,5,6,5],[1,4,9,15,20],[1,5,14,29,49],[1,6,20,49,98],[1,7,27,76,174],[1,8,35,111,285],[1,9,44,155,440]]
----------------E------------------
                     * 
                     */
                    #endregion

                    var limit = Math.Min(count, i - 1);
                    for (int j = 0; j <= limit; j++)
                    {
                        //Console.Write(count - j);
                        sum += dp[i - 1][count - j];
                        sum %= 1000_000_007;
                    }
                    //Console.Write($" <<< {i}_{count}");
                    //Console.WriteLine();
                    dp[i][count] = sum;
                }
            }

            //ShowTools.Show(dp);

            return dp[n][k];
        }

        // dp solution from Simple
        public int Try2(int n, int k)
        {

            int res = 0;

            Helper(n, k);

            return res;

            // 因为根本未使用list中的值故直接简化参数
            void Helper(int n, int k)
            {
                if (k == 0)
                {
                    res++;
                    res %= 1000_000_007;
                    return;
                }

                for (int i = 0; i <= k && i < n; i++)
                {
                    Helper(n - 1, k - i);
                }

            }

        }

        // dp solution
        public int Simple(int n, int k)
        {

            int res = 0;

            Helper(Enumerable.Range(1, n).ToList(), k);

            return res;

            // 排列从前到后
            void Helper(List<int> list, int k)
            {
                if (k == 0)
                { // k = 0 , 后面只能按升序，排列方式=1
                    res++;
                    res %= 1000_000_007;
                    return;
                }

                // k < 0 不存在的值
                if (k < 0) return;

                // 遍历list的元素，当前可以选择list中的任一一个元素作为当前项
                for (int i = 0; i < list.Count; i++)
                {
                    // copy arr
                    var clone = new List<int>(list);
                    // 将当前值赋值为list[i] 并移除此项(因为后面的排列无法再次使用此值)
                    clone.RemoveAt(i);
                    // 赋值完后，list中还包含着i个小于此值的元素 排列在当前元素的后面，故必定会出现i个逆对
                    // 递归查找，选择此元素后的结果
                    Helper(clone, k - i);
                }

            }

        }

        // bug
        public int Try(int n, int k)
        {
            if (k == 0) return 1;
            // if i < j and a[i] > a[j] 

            // dp[index][k]
            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[k + 1];
            }

            for (int i = 0; i < n; i++)
            {
                // base case
                dp[i][0] = 1;
                for (int j = 1; j <= k; j++)
                {
                    // state transfer
                    // Math.Max(next[j],next[j-1] + i)
                    var max = 0;
                    for (int next = j; next < i; next++)
                    {
                        max = Math.Max(max, dp[next][j]);
                        max = Math.Max(max, dp[next][j - 1] + i);
                    }
                    dp[i][j] = max;
                }
            }

            return dp[n - 1][k];
        }

    }
}
