using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/24/2020 9:57:14 AM
    /// @source : https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Sort)]
    public class FindMinimumInRotatedSortedArrayII
    {

        

        /// <summary>
        /// Runtime: 100 ms, faster than 30.92% of C# online submissions for Find Minimum in Rotated Sorted Array II.
        /// Memory Usage: 25 MB, less than 100.00% of C# online submissions for Find Minimum in Rotated Sorted Array II.
        /// 
        /// 最简单的方案...
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Simple(int[] nums)
        {
            // [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2] 6,1,2,3,4,5
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1]) return nums[i];
            }

            return nums[0];

        }

        // source: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/discuss/48808/My-pretty-simple-code-to-solve-it
        public int OtherSolution(int[] nums)
        {
            int l = 0, r = nums.Length - 1, mid;

            while (l < r)
            {

                mid = (l + r) / 2;

                if (nums[mid] > nums[r])
                {
                    l = mid + 1;
                }
                else if (nums[mid] < nums[r])
                {
                    r = mid;
                }
                else
                { // when num[mid] and num[hi] are same
                    r--;
                }

            }

            return nums[l];

        }

        [Obsolete("bug")]
        public int Solution(int[] nums)
        {
            int l = 0, r = nums.Length - 1, i;

            while (l < r)
            {

                // bug [10,1,10,10,10] 10 1
                if (nums[r] > nums[l] || (r - l == 1 && nums[r] == nums[l])) return nums[l];
                //if (nums[r] > nums[l]) return nums[l]; bug:[1,1]

                i = (l + r) / 2;

                if (nums[i] > nums[i + 1]) return nums[i + 1];

                //if (nums[i] > nums[l])  bug: [3,3,3,1]
                if (nums[i] >= nums[l])
                {
                    l = i;// 太着急跳跃了...
                }
                else
                {
                    r = i;
                }

            }

            return nums[0];

        }

    }
}
