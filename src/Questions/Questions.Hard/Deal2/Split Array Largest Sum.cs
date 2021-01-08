using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/7/2021 4:51:22 PM
    /// @source : https://leetcode.com/problems/split-array-largest-sum/
    /// @des : 
    ///     给定一个数组arr和数字m,将数组分割为不为空的m个序列(序列是连续的)
    ///     分割后将子序列求和即为sum,获得所有子序列sum的最大值=>max(sum)
    ///     target: 怎样分割能获得最小的max(sum)
    /// </summary>
    [Favorite(FlagConst.DP), Optimize]
    public class Split_Array_Largest_Sum
    {

        // 1 <= nums.length <= 1000
        //0 <= nums[i] <= 106
        //1 <= m <= min(50, nums.length)

        // bug
        public int Optimize(int[] nums, int m)
        {
            if (m == 1) return nums.Sum();
            if (m == nums.Length) return nums.Max();
            int len = nums.Length;

            //ShowTools.Show(nums);

            // dp[i][j] = max  i=>index j=> m
            int[][] dp = new int[len][];
            for (int i = 0; i < len; i++)
                dp[i] = new int[m + 1];

            int sum = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                int curr = nums[i];
                sum += curr;
                dp[i][1] = sum;

                var maxM = Math.Min(len - i, m);

                for (int j = 2; j <= maxM; j++)
                {
                    dp[i][j] = Math.Max(curr, dp[i + 1][j - 1]); 
                }

                for (int k = i + 1; k < len && (len - k >= maxM); k++)
                {
                    curr += nums[k];

                    for (int j = maxM; j >= 2; j--)
                    {
                        if (curr > dp[i][j] || len - k < j) continue;
                        dp[i][j] = Math.Min(Math.Max(curr, dp[k + 1][j - 1]), dp[i][j]);
                    }

                }

            }

            return dp[0][m];
        }

        // Runtime: 192 ms, faster than 29.35% of C# online submissions for Split Array Largest Sum.
        // Memory Usage: 25.1 MB, less than 7.61% of C# online submissions for Split Array Largest Sum.
        public int Try(int[] nums, int m)
        {
            if (m == 1) return nums.Sum();
            if (m == nums.Length) return nums.Max();
            int len = nums.Length;

            //ShowTools.Show(nums);

            // dp[i][j] = max  i=>index j=> m
            int[][] dp = new int[len][];
            for (int i = 0; i < len; i++)
                dp[i] = new int[m + 1];

            int sum = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                int curr = nums[i];
                sum += curr;
                dp[i][1] = sum;

                var maxM = Math.Min(len - i, m);

                for (int j = 2; j <= maxM; j++)
                {
                    int res = Math.Max(curr, dp[i + 1][j - 1]); // join 0 ele

                    int join = curr;
                    for (int k = i + 1; k < len && (len - k >= j); k++)
                    {
                        join += nums[k];
                        if (join > res) break; // 33.70% 
                        res = Math.Min(Math.Max(join, dp[k + 1][j - 1]), res);
                    }
                    dp[i][j] = res;
                }

            }

            return dp[0][m];
        }
        public int Simple(int[] nums, int m)
        {
            return Helper(nums, m, 0, 0);
        }

        private int Helper(int[] nums, int m, int i, int curr)
        {
            if (m == 0 || i == nums.Length) return int.MaxValue;
            if (m == 1)
            {
                return nums.Skip(i).Sum() + curr;
            }

            if (m == nums.Length - i)
            {
                if (curr == 0)
                {
                    return nums.Skip(i).Max();
                }
                else
                {
                    return Math.Max(curr + nums[i], nums.Skip(i + 1).Max());
                }
            }

            return Math.Min(Helper(nums, m, i + 1, curr + nums[i]),
                Math.Max(curr, Helper(nums, m - 1, i + 1, 0)));

        }

    }
}
