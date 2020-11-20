using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.Dp.贪心算法之区间调度问题
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 10:34:02 AM
    /// @source : https://leetcode.com/problems/non-overlapping-intervals/
    /// @des : 
    /// </summary>
    public class Non_overlapping_Intervals
    {

        // Runtime: 108 ms, faster than 49.31% of C# online submissions for Non-overlapping Intervals.
        // Memory Usage: 27.8 MB, less than 6.94% of C# online submissions for Non-overlapping Intervals.
        public int Solution(int[][] intervals)
        {
            if (intervals.Length < 2) return 0;
            intervals = intervals.OrderBy(u => u[1]).ToArray();

            int count = 0;

            int end = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < end)
                {
                    count++;
                }
                else
                {
                    end = intervals[i][1];
                }
            }
            return count;
        }

    }
}
