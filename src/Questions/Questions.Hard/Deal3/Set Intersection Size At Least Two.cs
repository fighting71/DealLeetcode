using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2021 3:01:09 PM
    /// @source : https://leetcode.com/problems/set-intersection-size-at-least-two/
    /// @des : 
    ///     一个整数区间[a, b](对于整数a &lt;b)是从a到b的所有连续整数的集合，包括a和b。
    ///     求集合S的最小大小，使得对于每一个整数区间a, S与a的交集的大小至少为2。
    /// </summary>
    [Obsolete("贪婪.")]
    public class Set_Intersection_Size_At_Least_Two
    {

        // 1 <= intervals.length <= 3000
        // intervals[i].length == 2
        // 0 <= ai<bi <= 10^8

        // source: https://www.cnblogs.com/grandyang/p/8503476.html
        public int OtherSolution(int[][] intervals)
        {
            // 过了...
            // 题目隐藏坑:没说明S不需要连续...
            int len = intervals.Length;

            if (len == 1) return 2;

            // 先遍历靠前且区间范围较小的
            int[][] sort = intervals.OrderBy(u => u[1]).ThenByDescending(u => u[0]).ToArray();

            List<int> list = new List<int>();

            foreach (var interval in sort)
            {
                int count = list.Count;
                if (interval[0] <= list[count - 2]) continue;
                if (interval[0] > list[list.Count - 1])
                {
                    list.Add(interval[1] - 1);
                }
                list.Add(interval[1]);
            }

            return list.Count - 2;

        }

    }
}
