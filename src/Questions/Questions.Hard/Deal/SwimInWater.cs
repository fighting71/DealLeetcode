using System;
using System.Collections.Generic;
using System.Text;
using Command.Tools;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/23 11:29:55
    /// @source : https://leetcode.com/problems/swim-in-rising-water/
    /// @des : 
    /// </summary>
    public class SwimInWater
    {
        // bug
        [Obsolete("解决了左右点，但未考虑到上下点|_|")]
        public int Solution(int[][] grid, bool showDp = false)
        {
            if (grid == null) return 0;
            int len = grid.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
                dp[i] = new int[len];

            for (int i = len - 1; i >= 0; i--)
            {
                if (i + 1 == len)
                    dp[len - 1][i] = grid[len - 1][i];
                else
                    dp[len - 1][i] = Math.Max(grid[len - 1][i], dp[len - 1][i + 1]);
            }

            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = 0; j < len; j++)
                {
                    dp[i][j] = Math.Max(grid[i][j], dp[i + 1][j]);
                }

                for (int j = 1; j < len; j++)
                {
                    if (j > 0 && dp[i][j] >= grid[i][j - 1] && dp[i][j] > dp[i][j - 1])
                    {
                        dp[i][j] = Math.Max(dp[i][j - 1], grid[i][j]);
                    }
                }

                for (int j = len - 2; j >= 0; j--)
                {
                    if (j + 1 < len && dp[i][j] >= grid[i][j + 1] && dp[i][j] > dp[i][j + 1])
                    {
                        dp[i][j] = Math.Max(dp[i][j + 1], grid[i][j]);
                    }
                }
            }

            if (showDp)
                Console.WriteLine(ShowTools.GetStr(dp));

            return dp[0][0];
        }

        /**
         * 
         * Runtime: 104 ms, faster than 100.00% of C# online submissions for Swim in Rising Water.
         * Memory Usage: 23.4 MB, less than 100.00% of C# online submissions for Swim in Rising Water.
         *
         * nice~~ 有所付出，总会有所收获 yeah~
         * 
         */
        public int Solution2(int[][] grid, bool showTest = false)
        {
            if (grid == null) return 0;
            int len = grid.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
                dp[i] = new int[len];

            // 确定最后一行为基准 
            // because : 最后一行的值是可以通过当前值和后一个路径值确定的 dp[i][j] = Math.Max(grid[i][j], dp[i][j+1]);
            for (int i = len - 1; i >= 0; i--)
            {
                if (i + 1 == len)
                    dp[len - 1][i] = grid[len - 1][i];
                else
                    dp[len - 1][i] = Math.Max(grid[len - 1][i], dp[len - 1][i + 1]);
            }

            // 从倒数第二行往上遍历
            for (int i = len - 2; i >= 0; i--)
            {
                
                // ps 此处之所以使用两个循环拆分是由于改变周边值时由于遍历顺序导致周边值尚未更新从而无法影响，从而导致影响不起作用...
                
                // 确定猜测值 : 当前值 or 下方路径值
                // ps 之所以为猜测值是由于路径还可以选择左右方
                for (int j = 0; j < len; j++)
                    dp[i][j] = Math.Max(grid[i][j], dp[i + 1][j]);
                
                // 从当前点出发，试图改变周边路径值
                for (int j = 0; j < len; j++)
                    ChangeOther(i, j, grid, dp);
            }

            if (showTest)
            {
                Console.WriteLine(ShowTools.GetStr(grid));
                Console.WriteLine("------------------------ dp:");
                Console.WriteLine(ShowTools.GetStr(dp));
            }

            return dp[0][0];
        }

        /// <summary>
        /// 试图改变周边值 top/bottom/left/right
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="grid"></param>
        /// <param name="dp"></param>
        private void ChangeOther(int i, int j, int[][] grid, int[][] dp)
        {
            
            // 如果存在上方，且上方路径值>当前路径值
            if (i > 0 && dp[i - 1][j] > dp[i][j])
            {
                // 路径值 = Math.Max(当前值,上方值)
                dp[i - 1][j] = Math.Max(dp[i][j], grid[i - 1][j]);
                
                // 由于改变了上方值，那么则会影响到上方点的周边点 》》 蝴蝶效应
                ChangeOther(i - 1, j, grid, dp);
            }

            // 同上.
            if (i < grid.Length - 1 && dp[i + 1][j] > dp[i][j])
            {
                dp[i + 1][j] = Math.Max(dp[i][j], grid[i + 1][j]);
                ChangeOther(i + 1, j, grid, dp);
            }

            if (j > 0 && dp[i][j - 1] > dp[i][j])
            {
                dp[i][j - 1] = Math.Max(dp[i][j], grid[i][j - 1]);
                ChangeOther(i, j - 1, grid, dp);
            }

            if (j < grid.Length - 1 && dp[i][j + 1] > dp[i][j])
            {
                dp[i][j + 1] = Math.Max(dp[i][j], grid[i][j + 1]);
                ChangeOther(i, j + 1, grid, dp);
            }
        }
    }
}