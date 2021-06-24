using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/18/2021 3:08:37 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3783/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.Design)]
    public class Range_Sum_Query___Mutable
    {

        // Constraints:

        //1 <= nums.length <= 3 * 10^4
        //-100 <= nums[i] <= 100
        //0 <= index<nums.length
        //-100 <= val <= 100
        //0 <= left <= right<nums.length
        //At most 3 * 10^4 calls will be made to update and sumRange.

        #region other solution
        // source : https://leetcode.com/problems/range-sum-query-mutable/discuss/75724/17-ms-Java-solution-with-segment-tree
        // 搬来吃分，使用类似于平衡树来进行二分 
        public class NumArray
        {

            class SegmentTreeNode
            {
                public int start, end;
                public SegmentTreeNode left, right;
                public int sum;

                public SegmentTreeNode(int start, int end)
                {
                    this.start = start;
                    this.end = end;
                    this.left = null;
                    this.right = null;
                    this.sum = 0;
                }
            }

            SegmentTreeNode root = null;

            public NumArray(int[] nums)
            {
                root = buildTree(nums, 0, nums.Length - 1);
            }

            private SegmentTreeNode buildTree(int[] nums, int start, int end)
            {
                if (start > end)
                {
                    return null;
                }
                else
                {
                    SegmentTreeNode ret = new SegmentTreeNode(start, end);
                    if (start == end)
                    {
                        ret.sum = nums[start];
                    }
                    else
                    {
                        int mid = start + (end - start) / 2;
                        ret.left = buildTree(nums, start, mid);
                        ret.right = buildTree(nums, mid + 1, end);
                        ret.sum = ret.left.sum + ret.right.sum;
                    }
                    return ret;
                }
            }

            void update(int i, int val)
            {
                update(root, i, val);
            }

            void update(SegmentTreeNode root, int pos, int val)
            {
                if (root.start == root.end)
                {
                    root.sum = val;
                }
                else
                {
                    int mid = root.start + (root.end - root.start) / 2;
                    if (pos <= mid)
                    {
                        update(root.left, pos, val);
                    }
                    else
                    {
                        update(root.right, pos, val);
                    }
                    root.sum = root.left.sum + root.right.sum;
                }
            }

            public int sumRange(int i, int j)
            {
                return sumRange(root, i, j);
            }

            private int sumRange(SegmentTreeNode root, int start, int end)
            {
                if (root.end == end && root.start == start)
                {
                    return root.sum;
                }
                else
                {
                    int mid = root.start + (root.end - root.start) / 2;
                    if (end <= mid)
                    {
                        return sumRange(root.left, start, end);
                    }
                    else if (start >= mid + 1)
                    {
                        return sumRange(root.right, start, end);
                    }
                    else
                    {
                        return sumRange(root.right, mid + 1, end) + sumRange(root.left, start, mid);
                    }
                }
            }
        }
        #endregion

        // time limit
        public class Simple
        {
            private readonly int[] nums;

            public Simple(int[] nums)
            {
                this.nums = nums;
            }

            public void Update(int index, int val)
            {
                nums[index] = val;
            }

            public int SumRange(int left, int right)
            {
                int sum = 0;
                for (int i = left; i <= right; i++)
                {
                    sum += nums[i];
                }
                return sum;
            }
        }

    }
}
