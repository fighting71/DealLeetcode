using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 3:42:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3535/
    /// @des : 
    /// </summary>
    public class Merge_Intervals
    {

        // 1 <= intervals.length <= 104
        // intervals[i].length == 2
        // 0 <= starti <= endi <= 104

        // 以前写过的老方案
        // old:13%...  new:77%
        public int[][] Simple(int[][] intervals)
        {
            List<int[]> res = new List<int[]>();

            int[] prev = null;

            foreach (var interval in intervals.OrderBy(u => u[0]))
            {
                if (prev != null && interval[0] <= prev[1])
                {
                    if (prev[1] < interval[1])
                        prev[1] = interval[1];
                }
                else
                {
                    prev = interval;
                    res.Add(prev);
                }
            }

            return res.ToArray();
        }

    }
}
