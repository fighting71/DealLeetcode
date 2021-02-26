using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/25/2021 4:42:57 PM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3652/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Shortest_Unsorted_Continuous_Subarray
    {

        // 1 <= nums.length <= 10^4
        // -10^5 <= nums[i] <= 10^5
        // Can you solve it in O(n) time complexity?

        // Your runtime beats 50.42 %
        // ...
        public int Try(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return 0;

            int prevIndex = 0, left = len - 1, right = 0;

            for (int i = 1; i < len; i++)
            {
                if (nums[i] < nums[prevIndex])
                {
                    right = i;
                    left = Math.Min(left, prevIndex);
                    for (int j = 0; j < left; j++)
                    {
                        if (nums[i] < nums[j])
                        {
                            left = j;
                            break;
                        }
                    }
                }
                else
                {
                    prevIndex = i;
                }
            }

            if (right == 0) return 0;

            return right - left + 1;
        }

        // Your runtime beats 50.42 %
        // ...
        public int Simple(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return 0;

            int[] copy = new int[len];

            Array.Copy(nums, copy, len);

            Array.Sort(copy);

            int left = len - 1;

            for (int i = 0; i < len; i++)
            {
                if (nums[i] != copy[i])
                {
                    left = i - 1;
                    break;
                }
            }

            if (left == len - 1) return 0;

            int right = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (nums[i] != copy[i])
                {
                    right = i + 1;
                    break;
                }
            }

            return right - left - 1;
        }

    }
}
