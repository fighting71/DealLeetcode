using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/3/2020 11:23:40 AM
    /// @source : https://leetcode.com/problems/jump-game-ii/submissions/
    /// @des : 
    /// </summary>
    public class JumpII
    {

        // 1 <= nums.length <= 3 * 10^4
        // 0 <= nums[i] <= 10^5

        // 效率差不多，减少了数组的增加和删除操作...
        public int Optimize3(int[] nums)
        {
            int len = nums.Length;

            if (len == 1) return 0;

            int first = nums[0];
            if (first >= len - 1) return 1;

            int[] cache = new int[len];
            int cacheCount = 0;

            for (int i = len - 2; i > 0; i--)
            {
                int jumpLen = nums[i];
                if (jumpLen == 0) continue;
                if (jumpLen + i >= len - 1)
                {
                    cache[0] = i;
                    cacheCount = 1;
                    continue;
                }
                if (cacheCount == 0) continue;
                if (cacheCount == 1)
                {
                    cache[1] = i;
                    cacheCount = 2;
                    continue;
                }
                if (i + jumpLen > cache[cacheCount - 2])
                {
                    cache[cacheCount++] = i;
                    continue;
                }
                int res = Help(i + jumpLen, cache, cacheCount);

                cache[res + 1] = i;
                cacheCount = res + 2;
            }

            //ShowTools.Show(cache.Where(u => u > 0).ToArray());
            return Help(first, cache, cacheCount) + 2;

        }

        // 使用二分法替换.
        private int Help(int range, int[] cache, int cacheCount)
        {
            int left = 0, right = cacheCount - 1;

            while (right > left + 1)
            {
                int mid = (left + right) / 2;

                if (cache[mid] > range) left = mid;
                else right = mid;

            }

            int res = left;
            if (cache[left] > range) res = right;
            return res;
        }

        // Runtime: 104 ms, faster than 54.46% of C# online submissions for Jump Game II.
        // Memory Usage: 28.9 MB, less than 5.36% of C# online submissions for Jump Game II.
        // haha
        public int Optimize2(int[] nums)
        {
            int len = nums.Length;

            if (len == 1) return 0;

            int first = nums[0];
            if (first >= len - 1) return 1;

            List<int> cache = new List<int>();

            for (int i = len - 2; i > 0; i--)
            {
                int jumpLen = nums[i];
                if (jumpLen == 0) continue;
                if (jumpLen + i >= len - 1)
                {
                    cache.Clear();// 后面的值无意义
                    cache.Add(i);
                    continue;
                }
                if (cache.Count == 0) continue;
                if (cache.Count == 1)
                {
                    cache.Add(i);
                    continue;
                }

                int res = Help(i + jumpLen, cache);

                if (cache.Count > res + 1)
                {
                    cache[res + 1] = i;
                    for (int j = res + 2; j < cache.Count;)
                    {
                        cache.RemoveAt(j);// 后面的值无意义
                    }
                }
                else cache.Add(i);
            }

            //ShowTools.Show(cache);

            return Help(first, cache) + 2;

        }

        private int Help(int range, List<int> cache)
        {
            int left = 0, right = cache.Count - 1;

            while (right > left + 1)
            {
                int mid = (left + right) / 2;

                if (cache[mid] > range)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }

            }

            int res = left;
            if (cache[left] > range) res = right;
            return res;
        }

        // time limit : 当nums[i] 全部是1时....
        public int Optimize(int[] nums)
        {
            int len = nums.Length;

            if (len == 1) return 0;

            int first = nums[0];
            if (first >= len - 1) return 1;

            int[] cache = new int[len];

            for (int i = len - 2; i > 0; i--)
            {
                int jumpLen = nums[i];
                if (jumpLen == 0) continue;
                if (jumpLen + i >= len - 1)
                {
                    cache[0] = i;
                    continue;
                }

                // 比较耗时.
                for (int j = 0; j < len && cache[j] != 0; j++)
                {
                    if (cache[j] <= i + jumpLen)
                    {
                        cache[j + 1] = i;
                        break;
                    }
                }
            }

            ShowTools.Show(cache.Where(u => u > 0).ToArray());

            for (int i = 0; i < len; i++)
            {
                if (cache[i] <= first)
                {
                    return i + 2;
                }
            }

            return default;
        }

        // to slow
        // Runtime: 892 ms, faster than 5.09% of C# online submissions for Jump Game II.
        // Memory Usage: 28.2 MB, less than 20.36% of C# online submissions for Jump Game II.
        public int Solution(int[] nums)
        {
            int len = nums.Length;

            if (len == 1) return 0;

            int[] dp = new int[len - 1];

            for (int i = len - 2; i >= 0; i--)
            {
                dp[i] = len;
                if (nums[i] + i >= len - 1)
                {
                    dp[i] = 1;
                    continue;
                }
                for (int j = nums[i]; j > 0; j--)
                {
                    dp[i] = Math.Min(dp[i], 1 + dp[i + j]);
                }
            }
            return dp[0];
        }

        // Time Limit
        public int Try(int[] nums)
        {
            int n = nums.Length;

            if (n == 1) return 0;
            if (nums[0] >= n - 1) return 1;
            int[] dp = new int[n];

            dp[0] = 1;

            for (int i = 1; i < n; i++)
            {
                dp[i] = int.MaxValue;

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] + j >= i)
                    {
                        dp[i] = Math.Min(dp[j] + 1, dp[i]);
                    }
                }
                if (nums[i] + i >= n - 1) return dp[i];
            }

            return dp[n - 1];
        }

        public int Simple(int[] nums)
        {
            return Helper(nums, 0, int.MaxValue);
        }

        private int Helper(int[] nums, int i, int step)
        {
            for (int j = i + 1; j <= i + nums[i]; j++)
            {
                step = Math.Min(step, Helper(nums, j, step == int.MaxValue ? step : step + 1));
            }

            return step;
        }

    }
}
