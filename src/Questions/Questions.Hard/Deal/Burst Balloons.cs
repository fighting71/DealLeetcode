using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/26/2020 3:52:45 PM
    /// @source : https://leetcode.com/problems/burst-balloons/
    /// @des : 
    /// </summary>
    public class Burst_Balloons
    {

        public int MaxCoins(int[] nums)
        {

            /**
             * think:
             *  
             * 
             * 
             */

            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] * (nums[1] + 1) : nums[1] * (nums[0] + 1);
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2] + MaxCoins(new[] { nums[0], nums[2] });
            var coins = 0;

            var orderArr = nums.Select((num, index) => new { index, num }).OrderBy(u => u.num).ToArray();

            bool[] flag = new bool[nums.Length];
            int count = 0;


            while (nums.Length - count > 3)
            {

            }

            coins += MaxCoins(new[] { orderArr[count++].num, orderArr[count++].num, orderArr[count].num });

            return coins;

        }

        private int GetValue(int[] nums, int index, bool[] flag)
        {

            int i = index - 1;
            while (i >= 0 && flag[i] == true)
            {
                i--;
            }

            var l = i == -1 ? 1 : nums[i];

            i = index + 1;
            while (i < nums.Length && flag[i] == true)
            {
                i++;
            }

            var r = i == nums.Length ? 1 : nums[i];

            flag[index] = true;

            return l * nums[index] + r;
        }

    }
}
