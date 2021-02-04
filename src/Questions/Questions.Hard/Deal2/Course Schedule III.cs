using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 3:28:43 PM
    /// @source : https://leetcode.com/problems/course-schedule-iii/
    /// @des : 
    ///     一共有n门不同的在线课程，编号从1到n。每门课程都有一定的时间(课程长度)t，并在第d天关闭。课程必须连续学习t天，并在第d天前或当天完成。你将从第一天开始。
    ///     给定n门在线课程，用对(t, d)表示，你的任务是找到可以选修的最大课程数。
    /// </summary>
    [Optimize]
    public class Course_Schedule_III
    {

        // The integer 1 <= d, t, n <= 10,000.
        // You can't take two courses simultaneously.

        public int Optimize(int[][] courses)
        {
            // 主要是排序耗时...
            return 0;
        }

        // Runtime: 540 ms, faster than 60.00% of C# online submissions for Course Schedule III.
        // Memory Usage: 44.5 MB, less than 100.00% of C# online submissions for Course Schedule III.
        // emmm...  提示到位，法力无边
        public int Simple(int[][] courses)
        {
            // 当前学习的天数
            int currentTotalTime = 0;
            int count = 0;
            List<int> needList = new List<int>();
            int maxTime = 0;
            // 按结束日期排序
            foreach (var item in courses.OrderBy(u => u[1]))
            {
                int need = item[0], end = item[1];
                if (currentTotalTime + need > end) // 结束日期不符合
                {
                    if(need < maxTime && currentTotalTime - maxTime + need <= end) // 查看是否可由之前花费时长最大的课程替换(替换后，课程数不变，总时长减少)
                    {
                        currentTotalTime = currentTotalTime - maxTime + need;
                        // 重新计算最大时长
                        needList.Remove(maxTime);
                        needList.Add(need);
                        maxTime = needList.Max();
                    }
                }
                else
                {
                    currentTotalTime += need;
                    count++;
                    needList.Add(need);
                    maxTime = Math.Max(maxTime, need);
                }
            }

            return count;
        }

        public int RecursionSolution(int[][] courses)
        {
            courses = courses.OrderBy(u => u[1]).ToArray();

            return Helper(0, 0);

            int Helper(int i,int total)
            {
                if (i == courses.Length) return 0;

                var curr = courses[i];
                if(curr[0] + total > curr[1])
                {
                    return Helper(i + 1, total);
                }
                else
                {
                    return Math.Max(Helper(i + 1, total), Helper(i + 1, total + curr[0]) + 1);
                }

            }

        }

    }
}
