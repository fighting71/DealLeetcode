using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/18/2021 6:06:41 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3676/
    /// @des : 
    ///     给定一个整数数组nums，返回最长的摆动序列的长度。
    ///     摆动序列是连续数之间的差严格地在正数和负数之间交替的序列。第一个差异(如果存在的话)可以是正的，也可以是负的。少于两个元素的序列通常是摆动序列。
    /// </summary>
    public class Wiggle_Subsequence
    {

        //1 <= nums.length <= 1000
        //0 <= nums[i] <= 1000


        // Your runtime beats 86.79 % of csharp submissions
        public int Try(int[] nums)
        {
            /**
             * O(n)算法
             * 
             * 根据规则制定的另一种解法:
             *  其实所谓摆动就是去除中间递增或者连续重复的部分的最大长度，例如:
             *  1,{2,3,4},1  = 3
             * 
             */
            int count = nums.Length;
            if (count == 1) return count;

            int? first = nums[0]; // 考虑到重复的情况，初始不一定有first
            int second = nums[1];
            if (first == second)
            {
                first = null;
                count--;
            }

            for (int i = 2; i < nums.Length; i++)
            {
                var num = nums[i];
                if(second == num)
                {
                    count--;
                    continue;
                }

                if (first.HasValue)
                {
                    if ((second - first > 0) == (num - second > 0)) count--;
                }

                first = second;
                second = num;

            }
            return count;
        }

        public int Simple(int[] nums)
        {

            /*
             * 
             * 使用dp作答，
             * 最大摆动长度 = dp[index][isUp : 是否递增]   例如: 1,2 -> isUp   2,1 -> not isUp  此处用1表示true  用0表示false
             * 
             */

            int len = nums.Length;
            if (len < 3) return len;

            int res = 2;
            int[][] dp = new int[len][];

            dp[0] = new[] { 1, 1 };

            for (int i = 1; i < len; i++)
            {
                int[] arr = new[] { 1, 1 };
                int num = nums[i];
                for (int j = 0; j < i; j++) // 遍历前面的元素
                {
                    int prev = nums[j];
                    if (num == prev) continue; // 此处有个坑：差值为0并不会算作正数 即 [0,0] => 需要返回0  ==> 差值为0即跳过此值
                    if (num > prev) // 若大于 则表示 isUp 为 true    dp = 1 + dp[j][not isUp]   前一个是not isUp 后一个是isUp 则构成了摆动
                    {
                        arr[1] = Math.Max(arr[1], 1 + dp[j][0]);
                    }
                    else
                    {
                        arr[0] = Math.Max(arr[0], 1 + dp[j][1]);
                    }
                }
                dp[i] = arr;
                // 计算最大长度
                res = Math.Max(res, Math.Max(arr[0], arr[1]));
            }
            return res;
        }
    }
}
