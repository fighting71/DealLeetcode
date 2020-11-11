using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/11/2020 6:05:40 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3527/
    /// @des : 验证是否为正方形
    /// </summary>
    [Obsolete]
    public class Valid_Square
    {

        // All the input integers are in the range [-10000, 10000].
        // A valid square has four equal sides with positive length and four equal angles(90-degree angles).
        // Input points have no order.

        // Runtime: 96 ms
        // Memory Usage: 27.4 MB
        // Your runtime beats 42.86 % of csharp submissions.
        // source:https://blog.csdn.net/kwinway/article/details/78508282
        // 先蹭波分>...
        public bool OtherSolution(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            int[][] p = new []{ p1, p2, p3, p4 };
            int cnt = 0;
            int[] len = new int[6];
            for (int i = 0; i <= 3; i++)
            {
                for (int j = i + 1; j <= 3; j++)
                {
                    // p[i][0]是第i个点的x坐标;p[j][1]是第j个点的y坐标
                    len[cnt++] = (p[i][0] - p[j][0]) * (p[i][0] - p[j][0]) + (p[i][1] - p[j][1]) * (p[i][1] - p[j][1]);
                }

            }
            //数组排序 最长的是对角线
            Array.Sort(len);
            //相邻两边相等,对角线相等的四边形是正方形;
            if (len[0] == len[1] && len[2] == len[3] && len[0] == len[2] && len[4] == len[5] && len[4] > len[1])
            {
                return true;
            }
            return false;
        }

        // bug : 存在:(菱形...),平面图形还真不简单
        public bool Simple(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            int[] point, point2, flagPoint;
            if (p2[0] != p1[0] && p2[1] != p1[1])
            {
                flagPoint = p2;
                point = p3;
                point2 = p4;
            }
            else if (p3[0] != p1[0] && p3[1] != p1[1])
            {
                flagPoint = p3;
                point = p2;
                point2 = p4;
            }
            else if (p4[0] != p1[0] && p4[1] != p1[1])
            {
                flagPoint = p4;
                point = p3;
                point2 = p2;
            }
            else return false;

            if (point[0] == p1[0] && point[1] == flagPoint[1] && point2[0] == flagPoint[0] && point2[1] == p1[1]) return true;
            if (point[0] == flagPoint[0] && point[1] == p1[1] && point2[0] == p1[0] && point2[1] == flagPoint[1]) return true;

            return false;

        }
    }
}
