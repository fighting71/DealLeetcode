using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/18/2021 11:32:15 AM
    /// @source : https://leetcode.com/problems/cut-off-trees-for-golf-event/
    /// @des : 
    ///     为了打高尔夫球，你被要求砍掉森林里所有的树木。森林用一个m x n矩阵表示。在这个矩阵:
    ///     0表示不能遍历单元格。
    ///     1表示可以遍历的空单元格。
    ///     大于1的数字表示可以遍历的单元格中的树，这个数字是树的高度。
    ///     一步之内，你可以向四个方向走:北、东、南、西。如果你和一棵树站在一个牢房里，你可以选择是否把它砍掉。
    ///     你必须按矮到高的顺序把树砍下来。当你砍掉一棵树时，它的单元格的值变成1(一个空单元格)。
    ///     从点(0,0)开始，返回砍掉所有树木所需的最小步骤。如果你不能砍掉所有的树，就返回-1。
    ///     你可以保证没有两棵树有相同的高度，而且至少有一棵树需要被砍掉。
    /// </summary>
    [Obsolete("bug|slow")]
    public class Cut_Off_Trees_for_Golf_Event
    {

        // m == forest.length
        // n == forest[i].length
        //1 <= m, n <= 50
        //0 <= forest[i][j] <= 10^9

        private struct Point
        {

            public int value;
            public int x;
            public int y;

            public Point(int value, int x, int y)
            {
                this.value = value;
                this.x = x;
                this.y = y;
            }
        }

        public int Try2(IList<IList<int>> forest)
        {
            int res = 0, m = forest.Count, n = forest[0].Count;

            var need = forest.SelectMany((list, y) => list.Select((value, x) => new Point(value, x, y))).Where(u => u.value > 1).OrderBy(u => u.value);

            int currX = 0, currY = 0;

            bool[][] visited = new bool[m][];
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                visited[i] = new bool[n];
            }

            foreach (var item in need)
            {
                for (int i = 0; i < m; i++)
                {
                    Array.Fill(dp[i], 0);
                }
            }

            return 0;

        }

        // slow
        public int Try(IList<IList<int>> forest)
        {
            int res = 0, m = forest.Count, n = forest[0].Count;

            var need = forest.SelectMany((list, y) => list.Select((value, x) => new Point(value, x, y))).Where(u => u.value > 1).OrderBy(u => u.value);

            int x = 0, y = 0;

            bool[][] visited = new bool[m][];
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                visited[i] = new bool[n];
            }

            bool needHelp = true;
            foreach (var item in need)
            {
                if (item.y == y && item.x == x) continue;
                int step;
                if (needHelp)
                {
                    for (int i = 0; i < m; i++)
                    {
                        Array.Fill(dp[i], 0);
                    }
                    Help(item.x, item.y, visited, 0, dp);
                    needHelp = false;
                    step = dp[y][x];
                }
                else
                {
                    needHelp = true;
                    step = dp[item.y][item.x];
                }
                if (step == 0) return -1;
                res += step;
                y = item.y;
                x = item.x;

            }

            return res;

            void Help(int x, int y, bool[][] visited, int step,int[][] stepDp)
            {
                if (x < 0 || x >= n || y < 0 || y >= m || visited[y][x] || forest[y][x] == 0 || (stepDp[y][x] != 0 && stepDp[y][x] <= step)) return;

                stepDp[y][x] = step;
                visited[y][x] = true;

                Help(x + 1, y, visited, step + 1, stepDp);
                Help(x - 1, y, visited, step + 1, stepDp);
                Help(x, y + 1, visited, step + 1, stepDp);
                Help(x, y - 1, visited, step + 1, stepDp);

                visited[y][x] = false;

            }

        }

        public int Simple(IList<IList<int>> forest)
        {
            int res = 0, m = forest.Count, n = forest[0].Count;

            var need = forest.SelectMany((list, y) => list.Select((value, x) => new Point(value, x, y))).Where(u => u.value > 1).OrderBy(u => u.value);

            int x = 0, y = 0;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            foreach (var item in need)
            {
                (bool success, int? minStep) = GetMinStep(x, y, item, visited);

                if (!success) return -1;

                x = item.x;
                y = item.y;
                res += minStep.Value;
            }

            return res;

            (bool success, int? minStep) GetMinStep(int x, int y, Point target, bool[][] visited, int step = 0)
            {
                if (x < 0 || x >= n || y < 0 || y >= m || visited[y][x] || forest[y][x] == 0) return (false, default);

                if (x == target.x && y == target.y)
                {
                    return (true, step);
                }

                visited[y][x] = true;

                bool res = false;
                int? min = null;

                (bool success, int? minStep) = GetMinStep(x + 1, y, target, visited, step + 1);

                if (success)
                {
                    res = true;
                    if (min.HasValue) min = min = Math.Min(minStep.Value, min.Value);
                    else min = minStep;
                }

                (success, minStep) = GetMinStep(x - 1, y, target, visited, step + 1);

                if (success)
                {
                    res = true;
                    if (min.HasValue) min = min = Math.Min(minStep.Value, min.Value);
                    else min = minStep;
                }

                (success, minStep) = GetMinStep(x, y + 1, target, visited, step + 1);

                if (success)
                {
                    res = true;
                    if (min.HasValue) min = min = Math.Min(minStep.Value, min.Value);
                    else min = minStep;
                }

                (success, minStep) = GetMinStep(x, y - 1, target, visited, step + 1);

                if (success)
                {
                    res = true;
                    if (min.HasValue) min = min = Math.Min(minStep.Value, min.Value);
                    else min = minStep;
                }

                visited[y][x] = false;

                return (res, min);

            }

        }

    }
}
