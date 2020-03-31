using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 2:21:26 PM
    /// @source : https://leetcode.com/problems/single-number/
    /// @des : 
    /// </summary>
    public class SingleNumber
    {

        /// <summary>
        /// Runtime: 104 ms, faster than 59.22% of C# online submissions for Single Number.
        /// Memory Usage: 27.3 MB, less than 14.29% of C# online submissions for Single Number.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solution(int[] nums)
        {
            ISet<int> set = new HashSet<int>();

            foreach (var num in nums)
            {
                if (set.Contains(num)) set.Remove(num);
                else set.Add(num);
            }
            return set.Count == 0 ? 0 : set.First();
        }

        public int Solution2(int[] nums)
        {

            if (nums.Length == 0) return 0;

            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i+=2)
            {
                if (nums[i] != nums[i - 1]) return nums[i - 1];
            }

            return nums[nums.Length - 1];
        }

    }
}
