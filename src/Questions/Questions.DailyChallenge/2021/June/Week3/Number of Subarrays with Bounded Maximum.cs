using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/17/2021 3:20:33 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3782/
    /// @des : 
    /// 
    ///     给定一个由正整数组成的数组，以及左、右两个正整数(left &lt;= right)。
    ///     返回(连续的，非空的)子数组的数目，使该子数组中的最大元素的值至少是左的，最多是右的。
    /// 
    /// </summary>
    [Serie(FlagConst.Special)]
    public class Number_of_Subarrays_with_Bounded_Maximum
    {

        // Note:

        //left, right, and nums[i] will be an integer in the range[0, 10^9].
        //The length of nums will be in the range of[1, 50000].

        // Your runtime beats 62.96 %
        public int Optimize(int[] nums, int left, int right)
        {
            int len = nums.Length, res = 0;

            int count = 0, moreIndex = -1;
            for (int i = 0; i < len; i++)
            {
                var num = nums[i];
                if (num < left)
                {
                    res += count;
                }
                else if (num > right)
                {
                    count = 0;
                    moreIndex = i;
                }
                else
                {
                    res += count = i - moreIndex;
                }
            }

            return res;

        }

        // Your runtime beats 25.93 % of csharp submissions
        public int Try3(int[] nums, int left, int right)
        {
            int len = nums.Length, res = 0;

            // 上一次符合 num >= left num <= right 的下标
            int prevMatchIndex = - 1,
                // 上一次符合 num > right 的下标
                moreIndex = -1;
            for (int i = 0; i < len; i++)
            {
                var num = nums[i];
                if(num < left)
                {
                    if(prevMatchIndex != -1)
                    {
                        res += prevMatchIndex - moreIndex;
                    }
                }
                else if(num > right)
                {
                    prevMatchIndex = -1;
                    moreIndex = i;
                }
                else
                {
                    res += i - moreIndex;
                    prevMatchIndex = i;
                }
            }

            return res;

        }
        public int Simple(int[] nums, int left, int right)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int max = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    var num = nums[j];

                    max = Math.Max(max, num);
                    if (max >= left & max <= right) res++;
                }
            }
            return res;
        }

        // 理解错误。。。
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            int len = nums.Length, res = 0;
            bool[][] dp = new bool[len][];

            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = new bool[len];
                if (nums[i] >= left && nums[i] <= right)
                {
                    dp[i][i] = true;
                    res++;
                }
            }

            for (int count = 2; count < len; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    int rightIndex = i + count - 1;

                    if (dp[i][rightIndex] = dp[rightIndex][rightIndex] && dp[i][rightIndex - 1])
                    {
                        res++;
                    }

                }
            }
            return res;

        }
    }
}
