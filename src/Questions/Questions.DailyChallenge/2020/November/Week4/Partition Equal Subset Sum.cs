using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/27/2020 6:27:12 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3545/
    /// @des : 
    /// </summary>
    public class Partition_Equal_Subset_Sum
    {

        #region old solution
        public bool CanPartition(int[] nums)
        {
            var sum = 0;
            var max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (nums[i] > max) max = nums[i];
            }

            if (sum % 2 != 0) return false;

            var target = sum / 2;

            if (max > target) return false;

            Array.Sort(nums);

            return GetResult(nums, target, nums.Length - 1);
        }

        public bool GetResult(int[] arr, int target, int startIndex)
        {
            if (startIndex == -1) return false;
            if (0 == target) return true;

            for (; startIndex >= 0; startIndex--)
            {
                if (target >= arr[startIndex])
                {
                    if (GetResult(arr, target - arr[startIndex], startIndex - 1)) return true;
                }
            }

            return false;
        }
        #endregion

        // 1 <= nums.length <= 200
        // 1 <= nums[i] <= 100
        // time limit
        public bool Simple(int[] nums)
        {

            int len = nums.Length;

            if (len == 1) return false;

            var sum = nums.Sum();

            if (sum % 2 == 1) return false;

            // ==> 求nums任意组合能不能达到平均值...

            return Help(0, nums, sum / 2);
        }

        private bool Help(int i, int[] nums, int target)
        {
            if (target == 0) return true;
            if (target < 0) return false;
            if (i == nums.Length) return false;
            // 每路过一个target都有两个选择，加入 or 不加入
            return Help(i + 1, nums, target - nums[i]) || Help(i + 1, nums, target);
        }

    }
}
