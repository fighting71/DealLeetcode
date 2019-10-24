using System;
using Command.Tools;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/9/17 16:03:22
    /// @source : https://leetcode.com/problems/max-increase-to-keep-city-skyline/
    /// @des : 保持建筑的原有风格(上下左右的高低) 使得建筑高度总合最大
    ///         风格：例如从上往下看的风景线-排列
    /// </summary>
    public class MaxIncreaseKeepingSkyline
    {
        /**
         * Runtime: 88 ms, faster than 100.00% of C# online submissions for Max Increase to Keep City Skyline.
         * Memory Usage: 24.8 MB, less than 12.50% of C# online submissions for Max Increase to Keep City Skyline.
         */
        public int Solution(int[][] grid)
        {
            int len = grid.Length, colLen = grid[0].Length;

            int[] vertical = new int[colLen], across = new int[len];

            for (int i = 0; i < len; i++)
            {
                var max = 0;
                for (int j = 0; j < colLen; j++)
                {
                    max = Math.Max(max, grid[i][j]);
                }

                across[i] = max;
            }

            for (int i = 0; i < colLen; i++)
            {
                var max = 0;
                for (int j = 0; j < len; j++)
                {
                    max = Math.Max(max, grid[j][i]);
                }

                vertical[i] = max;
            }

            int sum = 0;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    sum -= grid[i][j];
                    grid[i][j] = Math.Min(vertical[j], across[i]);
                    sum += grid[i][j];
                }
            }

            Console.WriteLine(ShowList.GetStr(grid));

            return sum;
        }

        [Obsolete("don't understand")]
        public int Try(int[][] grid)
        {
            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j] = Helper(grid, i, j);
                    sum += grid[i][j];
                }
            }

            Console.WriteLine(ShowList.GetStr(grid));

            return sum;
        }

        // bug
        private int Helper(int[][] grid, int i, int j)
        {
            var value = grid[i][j];

            var res = GetLeft(grid, i, j);

            res = Math.Min(GetRight(grid, i, j), res);

            res = Math.Min(GetTop(grid, i, j), res);

            res = Math.Min(GetBottom(grid, i, j), res);

            return res;
        }

        private int GetLeft(int[][] grid, int i, int j)
        {
            int res = int.MaxValue;
            for (int k = 0; k < j; k++)
            {
                if (grid[i][k] > grid[i][j])
                {
                    if (grid[i][k] < res) res = grid[i][k];
                }
            }

            return res;
        }

        private int GetRight(int[][] grid, int i, int j)
        {
            int res = int.MaxValue;
            for (int k = j + 1; k < grid[0].Length; k++)
            {
                if (grid[i][k] > grid[i][j])
                {
                    if (grid[i][k] < res) res = grid[i][k];
                }
            }

            return res;
        }

        private int GetTop(int[][] grid, int i, int j)
        {
            int res = int.MaxValue;
            for (int k = 0; k < i; k++)
            {
                if (grid[k][j] > grid[i][j])
                {
                    if (grid[k][j] < res) res = grid[k][j];
                }
            }

            return res;
        }

        private int GetBottom(int[][] grid, int i, int j)
        {
            int res = int.MaxValue;
            for (int k = i + 1; k < grid.Length; k++)
            {
                if (grid[k][j] > grid[i][j])
                {
                    if (grid[k][j] < res) res = grid[k][j];
                }
            }

            return res;
        }
    }
}