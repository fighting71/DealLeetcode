using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 5:30:24 PM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3628/
    /// @des : 
    /// 我们将和谐数组定义为最大值和最小值之差恰好为1的数组。
    /// 给定一个整数数组nums，返回其所有可能子序列中最长的和谐子序列的长度。
    /// 数组的子序列是指在不改变其余元素顺序的情况下，通过删除一些元素或不删除任何元素来从数组派生的序列。
    /// </summary>
    public class Longest_Harmonious_Subsequence
    {

        // 1 <= nums.length <= 2 * 10^4
        // -10^9 <= nums[i] <= 10^9

        public int Optimize(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num)) ++dic[num];
                else dic[num] = 1;
            }

            int res = 0;

            foreach (var item in dic)
            {
                if(dic.ContainsKey(item.Key - 1))
                    res = Math.Max(res, item.Value + dic[item.Key - 1]);
                if (dic.ContainsKey(item.Key + 1))
                    res = Math.Max(res, item.Value + dic[item.Key + 1]);
            }

            return res;
        }

        // Your runtime beats 64.29 % 
        // dp想太多.
        // 实际上就是查找范围在[x-1, x] 与 [x, x+1]的区间的最大元素数
        public int Try3(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int res = 0, same;
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num)) same = ++dic[num];
                else same = dic[num] = 1;

                int low = 0, high = 0;
                if (dic.ContainsKey(num - 1)) low = same + dic[num - 1];
                if (dic.ContainsKey(num + 1)) high = same + dic[num + 1];
                res = Math.Max(res, Math.Max(low, high));
            }
            return res;
        }

        // slow
        public int Try2(int[] nums)
        {

            int len = nums.Length;
            int res = 0;
            int[] dp = new int[len];

            for (int i = 0; i < len; i++)
            {
                int low = 0, same = 1, high = 0, curr = nums[i];
                for (int j = 0; j < i; j++)
                {
                    var diff = curr - nums[j];

                    if (diff == -1)
                    {
                        high = Math.Max(high, same + dp[j]);
                    }
                    else if (diff == 0)
                    {
                        same++;
                        if (low > 0)
                            low++;
                        if (high > 0)
                            high++;
                    }
                    else if (diff == 1)
                    {
                        low = Math.Max(low, same + dp[j]);
                    }
                }
                dp[i] = same;
                res = Math.Max(res, Math.Max(low, high));
            }

            return res;
        }

        public int Try(int[] nums)
        {

            int len = nums.Length;
            int res = 0;
            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                // 0  a == b - 1 
                // 1  a == b
                // 2  a == b + 1
                int low = 0, same = 1, high = 0, curr = nums[i];
                for (int j = 0; j < i; j++)
                {
                    var diff = curr - nums[j];

                    if (diff == -1)
                    {
                        high = Math.Max(high, same + dp[j][1]);
                    }
                    else if (diff == 0)
                    {
                        same++;
                        if(low > 0)
                            low++;
                        if(high > 0)
                            high++;
                    }
                    else if(diff == 1)
                    {
                        low = Math.Max(low, same + dp[j][1]);
                    }

                }
                dp[i] = new[] { low, same, high };
                res = Math.Max(res, Math.Max(low, high));
            }

            return res;
        }
    }
}
