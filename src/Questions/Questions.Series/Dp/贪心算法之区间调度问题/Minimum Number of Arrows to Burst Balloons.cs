using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.Dp.贪心算法之区间调度问题
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 10:52:57 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Minimum_Number_of_Arrows_to_Burst_Balloons
    {
        public int FindMinArrowShots(int[][] points)
        {

            if (points.Length < 2) return points.Length;

            points = points.OrderBy(u => u[1]).ToArray();

            int end = points[0][1];
            int count = 1;
            for (int i = 1; i < points.Length; i++)
            {
                if(points[i][0] > end)
                {
                    end = points[i][1];
                    count++;
                }
            }
            return count;
        }
    }
}
