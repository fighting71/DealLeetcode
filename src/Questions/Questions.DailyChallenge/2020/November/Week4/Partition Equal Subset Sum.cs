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
    [Obsolete("time limit，dp.")]
    public class Partition_Equal_Subset_Sum
    {

        #region other solution
        // source: https://leetcode.com/problems/partition-equal-subset-sum/discuss/90592/01-knapsack-detailed-explanation
        public bool canPartition(int[] nums)
        {
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num;
            }

            if ((sum & 1) == 1)
            {
                return false;
            }
            sum /= 2;

            int n = nums.Length;
            bool[][] dp = new bool[n + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[sum + 1];
            }

            dp[0][0] = true;

            for (int i = 1; i < n + 1; i++)
            {
                dp[i][0] = true;
            }
            for (int j = 1; j < sum + 1; j++)
            {
                dp[0][j] = false;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    if (j >= nums[i - 1]) dp[i][j] = (dp[i - 1][j] || dp[i - 1][j - nums[i - 1]]);
                    else dp[i][j] = dp[i - 1][j];
                }
            }

            return dp[n][sum];
        }
        #endregion

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


        public bool Try2(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            var sum = 0;
            var max = 0;
            foreach (var num in nums)
            {
                sum += num;
                max = Math.Max(max, num);
                if (dic.ContainsKey(num))
                    dic[num]++;
                else dic[num] = 1;
            }
            if (sum % 2 != 0) return false;

            var target = sum / 2;

            if (max > target) return false;
            return GetResult(target, dic, new bool[100 + 1]);
        }

        public bool GetResult(int target, Dictionary<int, int> dic, bool[] used)
        {
            foreach (var item in dic)
            {
                if (used[item.Key]) continue;
                if(item.Key == target)
                {
                    return true;
                }
                if(item.Key < target)
                {
                    used[item.Key] = true;
                    for (int i = item.Value; i > 0; i--)
                    {
                        var emp = target - item.Key * i;
                        if (emp < 0) continue;
                        if (emp == 0) return true;
                        if (GetResult(emp, dic, used)) return true;
                    }
                    used[item.Key] = false;
                }
            }
            return false;
        }

    }
}
