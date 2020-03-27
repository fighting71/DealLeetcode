using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/27/2020 5:45:29 PM
    /// @source : https://leetcode.com/problems/search-insert-position/
    /// @des : 
    /// </summary>
    public class SearchInsertPosition
    {

        public int Solution(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
                if (target <= nums[i]) return i;

            return nums.Length;
        }

        /// <summary>
        /// Runtime: 92 ms, faster than 80.33% of C# online submissions for Search Insert Position.
        /// Memory Usage: 24.6 MB, less than 5.26% of C# online submissions for Search Insert Position.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Solution2(int[] nums, int target)
        {

            int l = 0, r = nums.Length - 1;

            while (r > l + 1)
            {
                if (nums[l] >= target) return l;
                if (target == nums[r]) return r;
                if (target > nums[r]) return r + 1;

                var m = (l + r) / 2;

                if (target == nums[m]) return m;
                if (target > nums[m])
                    l = m;
                else
                    r = m;

            }

            if (target > nums[r]) return r + 1;

            return nums[l] >= target ? l : l + 1;

        }
    }
}
