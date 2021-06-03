using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/1/2021 3:41:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3764/
    /// @des : 
    ///     你有一个m x n的二进制矩阵网格。一个岛是一组1(代表陆地)，在4个方向上(水平或垂直)相连。您可以假设网格的所有四个边都被水包围着。
    ///     岛的面积是岛上值为1的单元格数。
    ///     返回网格中岛屿的最大面积。如果没有岛，则返回0。
    /// </summary>
    [Serie(FlagConst.Matrix)]
    public class Max_Area_of_Island
    {

        // Constraints:

        //m == grid.length
        //n == grid[i].length
        //1 <= m, n <= 50
        //grid[i][j] is either 0 or 1.

        class Item
        {
            public int Area { get; set; }

            // 添加key无法解决一次相连改变两个相同key的Item ： 因为引用不一样
            //public int Key { get; set; }
        }

        [Obsolete("半成品")]
        public int Try(int[][] grid)
        {

            int res = 0;

            int m = grid.Length, n = grid[0].Length;

            Item[][] arr = new Item[m][];
            for (int i = 0; i < m; i++)
            {
                arr[i] = new Item[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        Item top = null, left = null;

                        if (i > 0)
                        {
                            top = arr[i - 1][j];
                        }
                        if (j > 0)
                        {
                            left = arr[i][j - 1];
                        }

                        if (top == null && left == null)
                        {
                            arr[i][j] = new Item { Area = 1 };
                            res = Math.Max(res, 1);
                        }
                        else if (top == null)
                        {
                            left.Area++;
                            arr[i][j] = left;
                            res = Math.Max(left.Area, res);
                        }
                        else if (left == null)
                        {
                            top.Area++;
                            arr[i][j] = top;
                            res = Math.Max(top.Area, res);
                        }
                        else if (left == top)// || left.Key == top.Key)
                        {
                            top.Area++;
                            arr[i][j] = top;
                            res = Math.Max(top.Area, res);
                        }
                        else
                        {
                            var curr = arr[i][j] = new Item { Area = 1 + top.Area + left.Area };
                            res = Math.Max(curr.Area, res);
                            // todo: 替换left or top相连的数据，或者Item中再做一次转接... ==> 二次索引
                        }

                    }
                }
            }
            return res;
        }
        // Your runtime beats 57.89 %
        public int Simple(int[][] grid)
        {
            int res = 0;

            int m = grid.Length, n = grid[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res = Math.Max(res, GetArea(i, j));
                }
            }

            return res;

            int GetArea(int i, int j)
            {
                if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0 || visited[i][j]) return 0;
                visited[i][j] = true;

                return 1 + GetArea(i + 1, j) + GetArea(i - 1, j) + GetArea(i, j + 1) + GetArea(i, j - 1);
            }

        }

    }
}
