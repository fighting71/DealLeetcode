using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/5/2020 4:42:16 PM
    /// @source : https://leetcode.com/problems/insert-interval/
    /// @des : 
    /// </summary>
    public class InsertInterval
    {

        /**
         * Runtime: 236 ms, faster than 100.00% of C# online submissions for Insert Interval.
         * Memory Usage: 33.3 MB, less than 100.00% of C# online submissions for Insert Interval.
         * 
         * emm... 感觉难度不到hard~
         * 
         */
        public int[][] Solution(int[][] intervals, int[] newInterval)
        {

            int n = intervals.Length;

            if (n == 0) return new[] { newInterval };

            if(newInterval[1] < intervals[0][0])
            {
                var arr = new int[n + 1][];
                arr[0] = newInterval;
                Array.Copy(intervals, 0, arr, 1, n);
                return arr;
            }

            if (newInterval[0] > intervals[n - 1][1])
            {
                var arr = new int[n + 1][];
                arr[n] = newInterval;
                Array.Copy(intervals, 0, arr, 0, n);
                return arr;
            }

            List<int[]> res = new List<int[]>();

            bool flag = false;
            int l = newInterval[0], r = newInterval[1];

            for (int i = 0; i < n; i++)
            {
                if(flag || l > intervals[i][1])
                {
                    res.Add(intervals[i]);
                    continue;
                }
                if (r < intervals[i][0])
                {
                    res.Add(new[] { l, r });
                    res.Add(intervals[i]);
                    flag = true;
                    continue;
                }
                l = Math.Min(intervals[i][0], l);
                if (r < intervals[i][1])
                {
                    res.Add(new[] { l, intervals[i][1] });
                    flag = true;
                    continue;
                }
            }

            if (!flag)
            {
                res.Add(new[] { l, r });
            }

            return res.ToArray();
        }

    }
}
