using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/11/2020 6:05:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3562/
    /// @des : 
    /// </summary>
    public class Remove_Duplicates_from_Sorted_Array_II
    {
        // 0 <= nums.length <= 3 * 10^4
        //-10^4 <= nums[i] <= 10^4
        //nums is sorted in ascending order.

        // Your runtime beats 21.47 % 
        public int Simple(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;
            int j = 2;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 2])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            return j;
        }
        // bug 
        public int Try2(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;
            int i = 1, j = nums.Length;
            for (; i < nums.Length; i++)
            {
                if(nums[i] == nums[i - 1])
                {
                    j = ++i;
                    break;
                }
            }
            for (; i < nums.Length;)
            {
                if (nums[i] != nums[j - 2])
                {
                    nums[j++] = nums[i++];
                    if (i < nums.Length)
                        nums[j++] = nums[i++];
                }
                else i++;
            }

            return j;
        }
    }
}
