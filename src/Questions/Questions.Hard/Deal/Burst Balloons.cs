using Command.Attr;
using Command.Const;
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
    [Favorite(FlagConst.DP)]
    [Obsolete("on thinking")]
    public class Burst_Balloons
    {

        public int Try(int[] nums)
        {
            int len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];
            if (len == 2) return nums[0] > nums[1] ? nums[0] * (nums[1] + 1) : nums[1] * (nums[0] + 1);
            if (len == 3) return nums[0] * nums[1] * nums[2] + MaxCoins(new[] { nums[0], nums[2] });

            int first = nums[0], last = nums[len - 1];

            var coins = first > last ? first * (last + 1) : last * (first + 1);

            var arr = nums.Select((value, index) => new { index, value }).Where(u => u.index != 0 && u.index != len - 1).OrderBy(u => u.value).Select(u => u.index).ToArray();

            bool[] flag = new bool[len];

            int minIndex, prev, next;
            for (int i = 0; i < len - 4; i++)
            {
                minIndex = arr[i];
                prev = minIndex - 1;
                next = minIndex + 1;
                while (flag[prev])
                {
                    prev--;
                }

                while (flag[next])
                {
                    next++;
                }

                coins += nums[prev] * nums[minIndex] * nums[next];

                flag[minIndex] = true;
            }

            int numA = arr[len - 3], numB = arr[len - 4], valueA = nums[numA], valueB = nums[numB];

            if (numA > numB)
            {
                coins += Math.Max(valueA * last * valueB + first * valueB * last, valueA * valueB * first + first * valueB * last);
            }
            else
            {
                coins += Math.Max(valueA * first * valueB + first * valueB * last, valueA * valueB * last + first * valueA * last);
            }

            return coins;

        }

        public int MaxCoins(int[] nums)
        {

            /**
             * think:
             *  
             * first get center.
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
