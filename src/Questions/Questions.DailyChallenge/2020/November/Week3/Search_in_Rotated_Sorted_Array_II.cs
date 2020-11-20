using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 8:43:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3537/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Search_in_Rotated_Sorted_Array_II
    {

        // Runtime: 92 ms
        // Memory Usage: 26.3 MB
        // Your runtime beats 81.66 % of csharp submissions
        // oh nice!
        public bool Search(int[] nums, int target)
        {
            int len = nums.Length;
            if (len == 0) return false;
            int first = nums[0], last = nums[len - 1];
            if (first == target || last == target) return true;
            if (len == 1) return false;
            if (target < first && target > last) return false;
            if(target > nums[0])
            {
                int left = 1, right = len - 2;

                while (true)
                {
                    if (nums[right] == first)
                    {
                        if (right == 0) return false;
                        right--;
                    }
                    else break;
                }

                while (right >= left)
                {
                    var mid = left + (right - left) / 2;
                    var num = nums[mid];
                    if (target == num) return true;
                    if (num < first)
                    {
                        right = mid - 1;
                    }
                    else if(num < target)
                    {
                        left = mid + 1;
                    }
                    else if(num > target)
                    {
                        right = mid - 1;
                    }
                }

            }
            else
            {
                int left = 1, right = len - 1;
                while (true)
                {
                    if (nums[left] == last)
                    {
                        if (left == len - 1) return false;
                        left++;
                    }
                    else break;
                }
                while (right >= left)
                {
                    var mid = left + (right - left) / 2;
                    var num = nums[mid];
                    if (target == num) return true;
                    if (num > last)
                    {
                        left = mid + 1;
                    }
                    else if (num < target)
                    {
                        left = mid + 1;
                    }
                    else if (num > target)
                    {
                        right = mid - 1;
                    }
                }
            }
            return false;

        }

    }
}
