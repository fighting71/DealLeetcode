using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp.Common
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/21/2021 4:40:06 PM
    /// @source : 参考案例
    ///     <see cref="Questions.DailyChallenge._2021.January.Week4.Path_With_Minimum_Effort"/>
    ///     <see cref="Questions.Hard.Deal.SwimInWater"/>
    /// @des : 
    /// 
    ///     《通用解决方案》
    /// 
    ///     n = martix.Length, m = martix[0].Length
    /// 
    ///     给定一个2d矩阵martix,对于任意一点有：
    ///         满足某种条件即可移动到相邻（上、下、左、右）另外一个点
    ///         
    ///     target:
    ///         从位置(0,0)出发，返回到达终点位置(n - 1, m - 1)的最优条件/最小代价
    /// 
    /// </summary>
    public class FindMiniStepIn2DMartix
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="martix">2d矩阵</param>
        /// <param name="getPrice">获取移动的最小代价</param>
        /// <returns></returns>
        public static int TemplateSolution(int[][] martix, Func<(int y, int x), (int nextY, int nextX), int> getPrice)
        {

            int rows = martix.Length, columns = martix[0].Length;

            // dp[y][x] = 到达终点所需要的最小代价
            int[][] dp = new int[rows][];

            for (int i = 0; i < rows; i++)
                dp[i] = new int[columns];

            /**
             * （此处更改为使用其他基准也行，只是方案之一.）
             */
            // 确定最后一行为基准 
            // 往右移动
            for (int i = columns - 2; i >= 0; i--)
            {
                dp[rows - 1][i] = Math.Max(dp[rows - 1][i + 1], getPrice((rows - 1, i), (rows - 1, i + 1)));
            }

            for (int i = rows - 2; i >= 0; i--)
            {

                // ps 此处之所以使用两个循环拆分是由于改变周边值时由于遍历顺序导致周边值尚未更新从而无法影响，从而导致影响不起作用...

                // 获取猜测值 : 当前值 or 下方路径值
                // ps: 之所以定义为猜测值是由于路径还可以选择左右方
                for (int j = 0; j < columns; j++)
                    dp[i][j] = Math.Max(getPrice((i, j), (i + 1, j)), dp[i + 1][j]);

                for (int j = 0; j < columns; j++)
                    ChangeOther(i, j); // 动态改变相邻点
            }

            return dp[0][0];

            void ChangeOther(int i, int j)
            {

                Inner(i + 1, j);
                Inner(i - 1, j);
                Inner(i, j + 1);
                Inner(i, j - 1);

                void Inner(int newI, int newJ)
                {
                    // 越界检查
                    if (newI == -1 || newI == rows || newJ == -1 || newJ == columns) return;

                    var max = Math.Max(dp[i][j], getPrice((i, j), (newI, newJ)));

                    if (dp[newI][newJ] <= max) return;

                    dp[newI][newJ] = max;
                    // 递归动态改变
                    ChangeOther(newI, newJ);
                }
            }

        }

    }
}
