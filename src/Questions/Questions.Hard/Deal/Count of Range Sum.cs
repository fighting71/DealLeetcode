using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/29/2020 11:36:54 AM
    /// @source : https://leetcode.com/problems/count-of-range-sum/
    /// @des : 
    /// </summary>
    [Obsolete("slow")]
    public class Count_of_Range_Sum
    {

        // 0 <= nums.length <= 10^4

        public int Optimize(int[] nums, int lower, int upper)
        {

            int len = nums.Length, res = 0;

            var diff = upper - lower;

            Dictionary<long, int> cache = new Dictionary<long, int>();

            for (int i = len - 1; i >= 0; i--)
            {

                var num = nums[i];

                if (num >= lower && num <= upper)
                {
                    res++;
                }

                var newCache = new Dictionary<long, int>();

                foreach (var item in cache)
                {
                    if (num >= item.Key && num <= item.Key + diff)
                    {
                        res += item.Value;
                    }
                    newCache.Add(item.Key - num, item.Value);
                }

                var key = lower - num;
                if (newCache.ContainsKey(key)) newCache[key]++;
                else newCache[key] = 1;
                cache.Clear();
                cache = newCache;
                ShowTools.Show(cache);
            }

            return res;

        }

        public int Solution(int[] nums, int lower, int upper)
        {
            int len = nums.Length, res = 0;
            // OPUF*(@*#(F
            return res;
        }

        // 能过，但太慢了.
        public int Simple(int[] nums, int lower, int upper)
        {

            int len = nums.Length, res = 0;

            for (int i = 0; i < len; i++)
            {
                long num = 0;
                for (int j = i; j < len; j++)
                {
                    num += nums[j];

                    if(num >= lower && num <= upper)
                    {
                        res++;
                    }
                }
            }

            return res;
        }

    }
}
