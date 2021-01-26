using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 5:43:01 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3617/
    /// @des : 
    /// </summary>
    public class Path_With_Minimum_Effort
    {
        // today 没有think 就很 strange..

        // rows == heights.length
        // columns == heights[i].length
        //1 <= rows, columns <= 100
        //1 <= heights[i][j] <= 106

        public int Try2(int[][] heights)
        {

            int row = heights.Length, col = heights[0].Length;

            int[][] dp = new int[row][];
            for (int i = 0; i < row; i++)
            {
                dp[i] = new int[col];
            }

            dp[row][col] = 0;

            for (int i = row - 2; i >= 0; i--)
            {
                dp[i][col - 1] = Math.Max(Math.Abs(heights[i][col - 1] - heights[i + 1][col - 1]),
                    dp[i + 1][col - 1]);
            }

            for (int j = col - 2; j >= 0; j--)
            {
                dp[row - 1][j] = Math.Max(Math.Abs(heights[row - 1][j] - heights[row - 1][j + 1]),
                    dp[row - 1][j + 1]);
            }

            for (int i = row-2; i >= 0; i--)
            {
                for (int j = col - 2; j >= 0; j--)
                {
                    dp[i][j] = Math.Min(
                        Math.Max(dp[i + 1][j], Math.Abs(heights[i][j] - heights[i + 1][j])),
                        Math.Max(dp[i][j + 1], Math.Abs(heights[i][j] - heights[i + 1][j + 1]))
                        );
                }
            }

            return dp[0][0];

        }

        // bug
        public int Try(int[][] heights)
        {
            int row = heights.Length, col = heights[0].Length;

            var visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }

            int left = 0, right = 105;

            while (right > left)
            {
                var mid = (right + left) / 2;
                if (CanToEnd(0, 0, heights[0][0], mid, visited))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;

            bool CanToEnd(int i, int j, int prev, int k, bool[][] visited)
            {
                if (i == row && j == col) return true;
                if (i < 0 || i >= row || j < 0 || j >= col || visited[i][j]) return false;

                var curr = heights[i][j];
                if (Math.Abs(curr - prev) > k) return false;

                visited[i][j] = true;
                var res = CanToEnd(i + 1, j, curr, k, visited) ||
                     CanToEnd(i, j + 1, curr, k, visited) ||
                      CanToEnd(i - 1, j, curr, k, visited) ||
                       CanToEnd(i, j - 1, curr, k, visited);
                visited[i][j] = false;
                return res;

            }

            int GetMaxDiff(int i, int j)
            {
                var curr = heights[i][j];
                var max = 0;
                if (i > 0) max = Math.Max(max, Math.Abs(curr - heights[i - 1][j]));
                if (i < row - 1) max = Math.Max(max, Math.Abs(curr - heights[i + 1][j]));
                if (j > 0) max = Math.Max(max, Math.Abs(curr - heights[i][j - 1]));
                if (j < col - 1) max = Math.Max(max, Math.Abs(curr - heights[i][j + 1]));
                return max;
            }

            return 0;

        }

        // stack overflow
        public int RecursionSolution(int[][] heights)
        {
            int row = heights.Length, col = heights[0].Length;
            var visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }
            visited[0][0] = true;
            dic = new Dictionary<(int, int), int>();
            var curr = heights[0][0];
            return Math.Min(Helper(heights, 1, 0, visited, curr), Helper(heights, 0, 1, visited, curr));
        }

        Dictionary<(int, int), int> dic;

        private int Helper(int[][] heights, int i, int j, bool[][] visited, int height)
        {
            if (i < 0 || i >= heights.Length || j < 0 || j >= heights[0].Length || visited[i][j]) return -1;

            var key = (i, j);
            if (dic.ContainsKey(key)) return dic[key];

            var curr = heights[i][j];
            var diff = Math.Abs(curr - height);

            if (i == heights.Length && j == heights[0].Length) return diff;

            visited[i][j] = true;

            int move = Helper(heights, i - 1, j, visited, curr);
            move = Math.Min(move, Helper(heights, i + 1, j, visited, curr));
            move = Math.Min(move, Helper(heights, i, j - 1, visited, curr));
            move = Math.Min(move, Helper(heights, i, j + 1, visited, curr));

            visited[i][j] = false;

            return dic[key] = Math.Max(diff, move);

        }

    }
}
