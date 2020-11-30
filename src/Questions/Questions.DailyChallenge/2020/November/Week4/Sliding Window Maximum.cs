using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 2:26:50 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3546/
    /// @des : 
    /// </summary>
    public class Sliding_Window_Maximum
    {

        // 1 <= nums.length <= 105
        //-104 <= nums[i] <= 104
        //1 <= k <= nums.length

        // bug,see:old solution==>Questions.Hard.Deal.Sliding_Window_Maximum
        public int[] Simple(int[] nums, int k)
        {

            if (nums.Length == 1 || k == 1) return nums;

            int len = nums.Length - k + 1;
            int[] res = new int[len];

            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < k - 1; i++)
            {
                list.AddLast(nums[i]);
            }

            for (int i = k - 1, j = 0; i < nums.Length; i++, j++)
            {
                list.AddLast(nums[i]);
                res[j] = list.Max();
                list.RemoveFirst();
            }
            return res;
        }

    }
}
