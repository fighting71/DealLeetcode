using Command.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/24/2020 3:00:06 PM
    /// @source : https://leetcode.com/problems/maximum-gap/
    /// @des : 
    /// </summary>
    [Description(FlagConst.Sort)]
    public class MaximumGap
    {

        /// <summary>
        /// Runtime: 92 ms, faster than 95.00% of C# online submissions for Maximum Gap.
        /// Memory Usage: 24.5 MB, less than 100.00% of C# online submissions for Maximum Gap.
        /// 
        /// ??? 排序代表作
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Simple(int[] nums)
        {

            if (nums.Length < 2) return 0;
            var diff = 0;

            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                diff = Math.Max(diff, nums[i] - nums[i - 1]);
            }

            return diff;

        }



    }
}
