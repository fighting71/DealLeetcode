using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 11:16:07 AM
    /// @source : https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists/
    /// @des : 
    /// 
    ///     你有k个升序排序的整数列表。找出k个列表中至少包含一个数的最小范围。
    ///     定义范围[a, b] 小于范围[c, d]，如果b - a &lt;d - c或a &lt;如果b - a == d - c，就等于c。
    /// 
    /// old limit solution <see cref="Questions.Hard.Deal.SmallestRange"/>
    /// </summary>
    [Obsolete("bug")]
    public class Smallest_Range_Covering_Elements_from_K_Lists
    {

        //nums.length == k
        //1 <= k <= 3500
        //1 <= nums[i].length <= 50
        //-10^5 <= nums[i][j] <= 10^5
        //nums[i] is sorted in non-decreasing order.

        class Item
        {
            public int Diff { get; set; }
            public int Low { get; set; }
            public int High { get; set; }
        }

        // bug
        public int[] Try3(IList<IList<int>> nums)
        {

            int len = nums.Count;

            if (len == 1)
            {
                var first = nums[0][0];
                return new[] { first, first };
            }

            /*
             * 突发奇想
             * 
             * state defind
             *  dp[开始下标][结束下标] = ?
             * 
             * 状态转移:
             *  dp[start][end] = dp[start+1][end] + find_start_min  or dp[start][end-1] + find_end_min or dp[start+1][end-1] + find_start&end_min
             * 
             */
            // 突发奇想
            // state defind
            // dp[开始下标][结束下标]

            Item[][] dp = new Item[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new Item[len];
            }

            for (int start = 0; start < len - 1; start++)
            {
                var end = start + 1;
                IList<int> startArr = nums[start], endArr = nums[end];
                var empty = new Item { Diff = int.MaxValue };
                foreach (var item in startArr)
                {
                    foreach (var endItem in endArr)
                    {
                        int low = Math.Min(item, endItem), high = Math.Max(item, endItem), diff = high - low;
                        if (empty.Diff > diff || (empty.Diff == diff && empty.Low > low))
                        {
                            empty.Diff = diff;
                            empty.Low = low;
                            empty.High = high;
                        }
                    }
                }
                dp[start][end] = empty;

            }

            for (int i = 2; i < len; i++)
            {
                for (int start = 0; start < len - i; start++)
                {
                    var end = start + i;
                    IList<int> startArr = nums[start], endArr = nums[end];
                    Item min, minInfo;

                    #region dp[start+1][end] + find_start_min
                    min = minInfo = dp[start + 1][end];
                    int than = int.MaxValue, less = int.MaxValue;

                    foreach (var item in startArr)
                    {
                        if (item > minInfo.High)
                        {
                            than = Math.Min(item - minInfo.High, than);
                        }
                        else if (item < minInfo.Low)
                        {
                            less = Math.Min(minInfo.Low - item, less);
                        }
                        else
                        {
                            than = less = 0;
                            break;
                        }
                    }

                    if (than > less)
                    {
                        minInfo.Low -= less;
                        minInfo.Diff += less;
                    }
                    else
                    {
                        minInfo.High += than;
                        minInfo.Diff += than;
                    }
                    #endregion

                    #region dp[start][end-1] + find_end_min
                    than = less = int.MaxValue;
                    minInfo = dp[start][end - 1];
                    foreach (var item in endArr)
                    {
                        if (item > minInfo.High)
                        {
                            than = Math.Min(item - minInfo.High, than);
                        }
                        else if (item < minInfo.Low)
                        {
                            less = Math.Min(minInfo.Low - item, less);
                        }
                        else
                        {
                            than = less = 0;
                            break;
                        }
                    }

                    if (than > less)
                    {
                        minInfo.Low -= less;
                        minInfo.Diff += less;
                    }
                    else
                    {
                        minInfo.High += than;
                        minInfo.Diff += than;
                    }

                    if (min.Diff > minInfo.Diff || (min.Diff == minInfo.Diff && min.Low > minInfo.Low))
                    {
                        min = minInfo;
                    }

                    #endregion

                    #region dp[start+1][end-1] + find_start&end_min
                    // todo bug.......
                    #endregion

                    dp[start][end] = min;

                }
            }

            var res = dp[0][len - 1];

            return new[] { res.Low, res.High };

        }

        // bug.
        public int[] Try2(IList<IList<int>> nums)
        {
            int len = nums.Count;

            if (len == 0) return null;

            var first = nums[0];
            Item[] prev = new Item[first.Count];
            for (int i = 0; i < first.Count; i++)
            {
                var num = first[i];
                prev[i] = new Item() { High = num, Low = num, Diff = 0 };
            }


            for (int i = 1; i < len; i++)
            {
                var item = nums[i];
                var curr = new Item[item.Count];
                for (int j = 0; j < item.Count; j++)
                {
                    var num = item[j];

                    Item info = null;

                    foreach (var summary in prev)
                    {
                        int low = summary.Low, high = summary.High, diff;
                        if (summary.Low > num)
                        {
                            low = num;
                        }
                        else if (summary.High < num)
                        {
                            high = num;
                        }
                        diff = high - low;

                        if (info == null || info.Diff > diff || (info.Diff == diff && info.Low > low))
                        {
                            info = new Item { Low = low, High = high, Diff = diff };
                        }
                    }
                    curr[j] = info;
                }
                prev = curr;
                ShowTools.Show(curr);
            }

            var res = prev.OrderBy(u => u.Diff).ThenBy(u => u.Low).First();

            return new[] { res.Low, res.High };
        }

        // slow 慢中最快
        public int[] Try(IList<IList<int>> nums)
        {
            int[] res = null;

            ISet<(int, int, int)> visited = new HashSet<(int, int, int)>();
            int resDiff = int.MaxValue;
            int minLow = int.MaxValue;
            foreach (var num in nums[0])
            {
                Helper(1, num, num);
            }
            return res;

            void Helper(int i, int low, int high)
            {
                var key = (i, low, high);
                if (visited.Contains(key)) return;
                visited.Add(key);
                int diff = high - low;
                if (diff > resDiff) return;

                if (diff == resDiff && low >= minLow) return;

                if (i == nums.Count)
                {
                    minLow = low;
                    res = new[] { low, high };
                    resDiff = diff;
                    return;
                }

                var curr = nums[i];

                foreach (var num in curr)
                {
                    if (num > high)
                    {
                        Helper(i + 1, low, num);
                    }
                    else if (num < low)
                    {
                        Helper(i + 1, num, high);
                    }
                    else
                    {
                        Helper(i + 1, low, high);
                    }
                }

            }
        }
        public int[] Simple(IList<IList<int>> nums)
        {
            int[] res = null;

            foreach (var num in nums[0])
            {
                Helper(1, num, num);
            }

            return res;

            void Helper(int i, int low, int high)
            {

                //Console.WriteLine($"{i} - [{low}, {high}]");

                if (i == nums.Count)
                {
                    if (res == null) res = new[] { low, high };
                    else
                    {
                        int diff = high - low, resDiff = res[1] - res[0];
                        if (diff < resDiff)
                        {
                            res = new[] { low, high };
                        }
                        else if (diff == resDiff && low < res[0])
                        {
                            res = new[] { low, high };
                        }
                    }
                    return;
                }

                var curr = nums[i];

                foreach (var num in curr)
                {
                    if (num > high)
                    {
                        Helper(i + 1, low, num);
                    }
                    else if (num < low)
                    {
                        Helper(i + 1, num, high);
                    }
                    else
                    {
                        Helper(i + 1, low, high);
                    }
                }

            }

        }
    }
}
