using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2020 10:43:54 AM
    /// @source : https://leetcode.com/problems/maximum-subarray/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class MaximumSubarray
    {
        // bug...
        public int Simple(int[] nums)
        {

            var res = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int num = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    num += nums[j];
                    res = Math.Max(res, num);// bug:存在 int.MinValue + -1 出现的数值错误
                }
            }

            return res;
        }

        /// <summary>
        /// Runtime: 84 ms, faster than 99.22% of C# online submissions for Maximum Subarray.
        /// Memory Usage: 25.5 MB, less than 10.00% of C# online submissions for Maximum Subarray.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solution(int[] nums)
        {

            int n = nums.Length;

            int[] left = new int[n], right = new int[n];

            left[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                left[i] = nums[i] + (left[i - 1] > 0 ? left[i - 1] : 0);
            }

            right[n - 1] = nums[n - 1];

            int res = left[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = nums[i] + (right[i + 1] > 0 ? right[i + 1] : 0);
                res = Math.Max(res, right[i] - nums[i] + left[i]);
            }

            return res;
        }

        /// <summary>
        /// Runtime: 84 ms, faster than 99.22% of C# online submissions for Maximum Subarray.
        /// Memory Usage: 25.5 MB, less than 10.00% of C# online submissions for Maximum Subarray.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private int Explain(int[] nums)
        {

            // target:获取一个范围 使得此范围内的数字总和最大

            // solution:既然范围内的数字总和最大 那么就存在一个i 使得 i + i的左范围最大总和 + i的右范围最大总和 最大
            //  ==> 若区间[l,j]的总和最大 那么存在 x  x ∈ [i,j] 使得  (区间[l,x]总和 + 区间[x,r]总和 - x) 的总和最大

            int n = nums.Length;

            int[] left = new int[n], right = new int[n];

            left[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                // 若前一个范围的总和 > 0 则进行连接
                left[i] = nums[i] + (left[i - 1] > 0 ? left[i - 1] : 0);
            }

            right[n - 1] = nums[n - 1];

            int res = left[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = nums[i] + (right[i + 1] > 0 ? right[i + 1] : 0);
                // 由于left[i] 和 right[i] 都包括了 nums[i] 故需要先减去一次再进行计算.
                res = Math.Max(res, right[i] - nums[i] + left[i]);// bug: 存在left+right>int.MaxValue 但由于题目定义返回最大为int.MaxValue 故无需考虑     v 
            }

            return res;
        }

    }
}
