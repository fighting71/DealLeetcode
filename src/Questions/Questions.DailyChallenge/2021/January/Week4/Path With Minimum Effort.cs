using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 5:43:01 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3617/
    ///     https://leetcode.com/problems/path-with-minimum-effort/
    /// @des : 
    ///     给定一个2d平面 每个值代表高度
    ///     每次可(往上/下/左/右)移动一个单位,
    ///     移动的消耗是当前单位与下一个单位的高度差的绝对值
    ///     target:求从(0,0)到(end,end)的最小消耗.
    /// </summary>
    //[Obsolete("no think")]
    [Serie(FlagConst.Middle, FlagConst.DP, FlagConst.Matrix)]
    public class Path_With_Minimum_Effort
    {
        // rows == heights.length
        // columns == heights[i].length
        //1 <= rows, columns <= 100
        //1 <= heights[i][j] <= 10^6

        public bool Check(int[][] heights,int res)
        {
            int rows = heights.Length, columns = heights[0].Length;

            bool[][] visited = new bool[rows][];

            for (int i = 0; i < rows; i++)
            {
                visited[i] = new bool[columns];
            }

            return Help(0, 0, heights[0][0]);

            bool Help(int y, int x, int prev)
            {
                if (y == rows || y == -1 || x == columns || x == -1 || visited[y][x] || Math.Abs(prev - heights[y][x]) > res) return false;

                if (y == rows - 1 && x == columns - 1) return true;

                visited[y][x] = true;

                return
                    Help(y + 1, x, heights[y][x]) ||
                    Help(y - 1, x, heights[y][x]) ||
                    Help(y, x + 1, heights[y][x]) ||
                    Help(y, x - 1, heights[y][x]);

            }

        }

        // Runtime: 176 ms, faster than 94.21% of C# online submissions for Path With Minimum Effort.
        // Memory Usage: 32.9 MB, less than 95.04% of C# online submissions for Path With Minimum Effort.
        // nice!
        public int Try4(int[][] heights)
        {

            int rows = heights.Length, columns = heights[0].Length;

            int[][] dp = new int[rows][];

            for (int i = 0; i < rows; i++)
                dp[i] = new int[columns];

            for (int i = columns - 2; i >= 0; i--)
            {
                dp[rows - 1][i] = Math.Max(dp[rows - 1][i + 1], Math.Abs(heights[rows - 1][i] - heights[rows - 1][i + 1]));
            }

            for (int i = rows - 2; i >= 0; i--)
            {

                for (int j = 0; j < columns; j++)
                    dp[i][j] = Math.Max(Math.Abs(heights[i][j] - heights[i + 1][j]), dp[i + 1][j]);

                for (int j = 0; j < columns; j++)
                    ChangeOther(i, j);
            }

            return dp[0][0];

            void ChangeOther(int i, int j)
            {

                Inner(i + 1, j);
                Inner(i - 1, j);
                Inner(i, j + 1);
                Inner(i, j - 1);

                void Inner(int newI,int newJ)
                {
                    if (newI == -1 || newI == rows || newJ == -1 || newJ == columns) return;

                    var max = Math.Max(dp[i][j], Math.Abs(heights[newI][newJ] - heights[i][j]));

                    if (dp[newI][newJ] <= max) return;

                    dp[newI][newJ] = max;
                    ChangeOther(newI, newJ);
                }
            }

        }


        public int Try3(int[][] heights)
        {

            int row = heights.Length, col = heights[0].Length;

            bool[][] visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }

            int res = int.MaxValue;

            Helper(0, 0, heights[0][0], 0);

            void Helper(int i,int j,int prev,int maxDiff)
            {
                if (i < 0 || i >= row || j < 0 || j >= col || visited[i][j]) return;

                var curr = heights[i][j];
                maxDiff = Math.Max(maxDiff, Math.Abs(curr - prev));

                if(i == row - 1 && j == col - 1)
                {
                    res = Math.Min(maxDiff, res);
                    return;
                }

                visited[i][j] = true;

                Helper(i + 1, j, curr, maxDiff);
                Helper(i - 1, j, curr, maxDiff);
                Helper(i, j + 1, curr, maxDiff);
                Helper(i, j - 1, curr, maxDiff);

                visited[i][j] = false;

            }
            return res;
        }

        // today 没有think 就很 strange..

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
