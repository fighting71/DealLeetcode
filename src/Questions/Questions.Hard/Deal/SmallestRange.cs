using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/27 16:58:04
    /// @source : https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists/
    /// @des : time limit
    /// </summary>
    public class SmallestRange
    {
        private int leftRes = 0;
        private int rightRes = Int32.MaxValue;

        public int[] Simple(IList<IList<int>> nums)
        {
            rightRes = int.MaxValue;
            leftRes = 0;
            for (int i = 0; i < nums[0].Count; i++)
            {
                Helper(nums, 1, nums[0][i], nums[0][i]);
            }

            return new[] {leftRes, rightRes};
        }

        // time limit
        private void Helper(IList<IList<int>> nums, int i, int left, int right)
        {
            if (i == nums.Count)
            {
                rightRes = right;
                leftRes = left;
                return;
            }

            int oldLeft = left, oldRight = right;
            for (int j = 0; j < nums[i].Count; j++)
            {
                left = oldLeft;
                right = oldRight;
                if (nums[i][j] < left) left = nums[i][j];
                else if (nums[i][j] > right) right = nums[i][j];

                if (right - left >= rightRes - leftRes) continue;
                Helper(nums, i + 1, left, right);
            }
        }

        protected void HelperOptimize(IList<IList<int>> nums, int i, int left, int right)
        {
            if (right - left > rightRes - leftRes) return;
            if (i == nums.Count)
            {
                rightRes = right;
                leftRes = left;
                return;
            }

            int minDiff = 0, newLeft = left, newRight = right;

            for (int j = 0; j < nums[i].Count; j++)
            {
                if (nums[i][j] <= right && nums[i][j] >= left)
                {
                    break;
                }
                
                if (nums[i][j] < left)
                {
                    if (minDiff > left - nums[i][j])
                    {
                        newLeft = nums[i][j];
                        newRight = right;
                    }
                }
                else if (minDiff > nums[i][j] - right)
                {
                    newLeft = left;
                    newRight = nums[i][j];
                }
            }

            Helper(nums, i + 1, newLeft, newRight);
        }

        public void HelperShow(IList<IList<int>> nums, StringBuilder builder, int i)
        {
            if (i == nums.Count)
            {
                Console.WriteLine(builder);
                return;
            }

            for (int j = 0; j < nums[i].Count; j++)
            {
                builder.Append(nums[i][j]);
                HelperShow(nums, builder, i + 1);
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public int[] Solution(IList<IList<int>> nums)
        {
            rightRes = int.MaxValue;
            leftRes = 0;
            for (int i = 0; i < nums[0].Count; i++)
            {
                HelperOptimize(nums, 1, nums[0][i], nums[0][i]);
            }

            return new[] {leftRes, rightRes};
        }
    }
}