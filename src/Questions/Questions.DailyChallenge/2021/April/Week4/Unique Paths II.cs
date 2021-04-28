using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/28/2021 4:06:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3723/
    /// @des : 简单的矩阵dp
    /// 
    ///     一个机器人位于一个m x n网格的左上角(在下面的图表中标记为“Start”)。
    ///     机器人只能在任何时间点向下或右移动。机器人正试图到达网格的右下角(在下面的图表中标有“完成”)。
    ///     现在考虑是否在网格中添加了一些障碍。有多少条路径能够到达终点?
    /// 
    /// </summary>
    [Serie(FlagConst.DP, FlagConst.Matrix)]
    public class Unique_Paths_II
    {

        // m == obstacleGrid.length
        // n == obstacleGrid[i].length
        // 1 <= m, n <= 100
        // obstacleGrid[i][j] is 0 or 1.


        public int Try2(int[][] obstacleGrid)
        {

            int m = obstacleGrid.Length, n = obstacleGrid[0].Length;

            if (obstacleGrid[m - 1][n - 1] == 1 || obstacleGrid[0][0] == 1) return 0;

            int[][] dp = new int[m + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 1];
            }

            dp[0][1] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var curr = obstacleGrid[i][j];
                    if (curr == 0)
                    {
                        dp[i + 1][j + 1] = dp[i][j + 1] + dp[i + 1][j];
                    }
                }
            }
            return dp[m][n];

        }

        // Your runtime beats 88.28 %
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {

            int m = obstacleGrid.Length, n = obstacleGrid[0].Length;

            if (obstacleGrid[m - 1][n - 1] == 1 || obstacleGrid[0][0] == 1) return 0;

            int[][] dp = new int[m + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 1];
            }

            dp[1][1] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var curr = obstacleGrid[i][j];
                    if(curr == 0)
                    {
                        dp[i + 1][j + 1] = dp[i][j + 1] + dp[i + 1][j];
                    }
                }
            }
            return dp[m][n];

        }

    }
}
