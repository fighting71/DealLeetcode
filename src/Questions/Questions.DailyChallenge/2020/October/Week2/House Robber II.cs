using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week2
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/14/2020 3:14:34 PM
    /// @source : https://leetcode.com/explore/featured/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3494/
    /// @des : 
    /// </summary>
    public class House_Robber_II
    {
        // 减少一次循环
        // Runtime: 84 ms
        // Memory Usage: 24.6 MB
        // Your runtime beats 94.86 % of csharp submissions.
        public int Clear(int[] nums)
        {
            if (nums.Length < 4)
            {
                int max = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                return max;
            }

            int len = nums.Length, next = nums[len - 1], last = 0;

            // no zero
            for (int i = len - 2; i > 1; i--)
            {
                int max = Math.Max(next, nums[i] + last);
                last = next;
                next = max;
            }

            int res = Math.Max(next, nums[1] + last);

            // has zero
            next = nums[len - 2];
            last = 0;

            for (int i = len - 3; i > 0; i--)
            {
                int max = Math.Max(next, nums[i] + last);
                last = next;
                next = max;
            }

            return Math.Max(Math.Max(next, nums[0] + last), res);

        }

        // 简化dp
        // Runtime: 88 ms
        // Memory Usage: 24.7 MB
        // beats 83.43 % of csharp submissions
        public int OptimizeDpSolution(int[] nums)
        {
            if (nums.Length < 4)
            {
                int max = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                return max;
            }

            int len = nums.Length, next = nums[len - 1], last = 0; // 实际只用了 dp[i+1]和dp[i+2]

            // no zero
            for (int i = len - 2; i > 0; i--)
            {
                int max = Math.Max(next, nums[i] + last);
                last = next;
                next = max;
            }

            int res = next;

            // has zero
            next = nums[len - 2];
            last = 0;

            for (int i = len - 3; i >= 0; i--)
            {
                int max = Math.Max(next, nums[i] + last);
                last = next;
                next = max;
            }

            return Math.Max(next, res);
        }

        public int DpSolution(int[] nums)
        {
            if (nums.Length < 4)
            {
                int max = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                return max;
            }

            // 真理：能recursion的99.9%都能dp

            int len = nums.Length;
            // no zero
            int[] dp = new int[len + 1];
            dp[len - 1] = nums[len - 1];

            for (int i = len - 2; i > 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }

            //ShowTools.ShowLine(dp);

            var res = dp[1];

            // has zero
            dp = new int[len + 1];

            for (int i = len - 2; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }

            Console.WriteLine($"{nums[0] - nums[len - 1]} diff {dp[0] - res}");
            //ShowTools.ShowLine(dp);

            return Math.Max(dp[0], res);
        }

        public int Simple(int[] nums)
        {

            if (nums.Length < 4)
            {
                int max = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                return max;
            }

            // 由于首尾相连，且不能窃取相连的两个元素
            //  ==>需特殊处理首位。 因为首位的选取也影响了末位的选取。
            //      ==>而末位的选取也间接影响着第[1->倒数第二位]的选取与否.
            return Math.Max(Help(nums, 1), nums[0] + HelpTakeZero(nums, 2));
        }

        // 不窃取第一个
        private int Help(int[] nums, int index)
        {
            if (index > nums.Length - 1) return 0;
            if(index == nums.Length - 1)
            {
                return nums[index];
            }

            int res = Help(nums, index + 1);

            res = Math.Max(res, nums[index] + Help(nums, index + 2));
            return res;
        }

        // 窃取第一个
        private int HelpTakeZero(int[] nums, int index)
        {
            if (index >= nums.Length - 1)
            {
                return 0;
            }

            int res = HelpTakeZero(nums, index + 1);

            res = Math.Max(res, nums[index] + HelpTakeZero(nums, index + 2));
            return res;
        }

    }
}
