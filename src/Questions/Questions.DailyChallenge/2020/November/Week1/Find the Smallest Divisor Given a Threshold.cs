using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/6/2020 4:20:10 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3521/
    /// @des : 
    /// </summary>
    public class Find_the_Smallest_Divisor_Given_a_Threshold
    {
        //1 <= nums.length <= 5 * 10^4
        //1 <= nums[i] <= 10^6
        //nums.length <= threshold <= 10^6

        // Your runtime beats 73.17 % of csharp submissions.
        public int Optimize(int[] nums, int threshold)
        {

            // ** 优化min的获取
            int min = (int)GetMin(nums, threshold);
            if (nums.Length == 0) return min;

            // 感觉再优化下max 差不多了。 todo
            int  max = nums.Max(), mid, res;

            while (max > min + 1)
            {
                mid = (max + min) / 2;

                res = GetSum(nums, threshold, mid);

                if (res > threshold)
                    min = mid;
                else
                    max = mid;
            }

            if (GetSum(nums, threshold, min) > threshold) return max;
            return min;
        }

        private ulong GetMin(int[] nums, int threshold)
        {
            ulong uSum = 0, uthreshold = (ulong)threshold;
            foreach (var num in nums)
            {
                uSum += (ulong)num;
            }

            var res = uSum / uthreshold;

            if (uSum % uthreshold != 0) return res + 1;
            return res;

        }

        // Runtime: 136 ms
        // Memory Usage: 32 MB
        // Your runtime beats 56.10 % of csharp submissions.
        public int Try2(int[] nums, int threshold)
        {

            int min = 1, max = nums.Max(),mid,res;

            //min = 65870;
            //max = 65878;

            while (max > min + 1)
            {
                mid = (max + min) / 2;

                res = GetSum(nums, threshold, mid);

                // 吐了，自己浪费时间。
                if(res > threshold)
                    min = mid;
                else
                    max = mid;

            }

            if (GetSum(nums, threshold, min) > threshold) return max;
            return min;
        }

        public int Simple(int[] nums, int threshold)
        {

            ulong uSum = 0, uthreshold = (ulong)threshold;
            foreach (var num in nums)
            {
                uSum = uSum + (ulong)num;
            }

            ulong uRes = uSum / uthreshold;

            if (uSum % uthreshold != 0) uRes++;

            int res = (int)uRes, sum = GetSum(nums, threshold, res);

            if(sum > threshold)
            {
                int diff = (sum - threshold);

                int newRes = res + (diff / 2);

                sum = GetSum(nums, threshold, newRes);

            }

            return res;
        }

        private int GetSum(int[] nums,int threshold,int res)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num / res + (num % res == 0 ? 0 : 1);
            }
            return sum;
        }

    }
}
