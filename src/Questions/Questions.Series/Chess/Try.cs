using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Chess
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/21/2021 2:07:59 PM
    /// @source : 
    /// @des : 围棋
    /// </summary>
    public class Try
    {

        // bug
        public int[] Try4(int[][] grid, int[][] hits)
        {

            int[] res = new int[hits.Length];
            int m = grid.Length, n = grid[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            int count = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                int y = hit[0], x = hit[1];

                if (grid[y][x] == 0) continue;
                grid[y][x] = 0;

                res[i] = Common(y, x);

            }

            return res;

            int Common(int y, int x)
            {
                for (int i = 0; i < m; i++)
                {
                    visited[i] = new bool[n];
                }
                int currCount = 0;
                count = 0;
                if (!Help(y - 1, x)) currCount += count;
                count = 0;
                if (!Help(y + 1, x)) currCount += count;
                count = 0;
                if (!Help(y, x - 1)) currCount += count;
                count = 0;
                if (!Help(y, x + 1)) currCount += count;
                count = 0;
                if (!Help(y + 1, x + 1)) currCount += count;
                count = 0;
                if (!Help(y + 1, x - 1)) currCount += count;
                count = 0;
                if (!Help(y - 1, x + 1)) currCount += count;
                count = 0;
                if (!Help(y - 1, x - 1)) currCount += count;

                return currCount;
            }

            bool Help(int y, int x)
            {
                if (y == -1 || y == m || x == -1 || x == n || visited[y][x] || grid[y][x] == 0) return false;
                if (y == 0) return true;

                count++;

                visited[y][x] = true;

                return
                Help(y - 1, x) ||
                Help(y + 1, x) ||
                Help(y, x - 1) ||
                Help(y, x + 1) ||
                Help(y + 1, x + 1) ||
                Help(y + 1, x - 1) ||
                Help(y - 1, x + 1) ||
                Help(y - 1, x - 1);


            }

        }

        // bug
        public int[] Try3(int[][] grid, int[][] hits)
        {

            int[] res = new int[hits.Length];
            int m = grid.Length, n = grid[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                int y = hit[0], x = hit[1];

                if (grid[y][x] == 0) continue;

                ISet<(int, int)> target = new HashSet<(int, int)>()
                {
                    (y-1,x),
                    (y+1,x),
                    (y,x-1),
                    (y,x+1),
                    (y-1,x+1),
                    (y-1,x-1),
                    (y+1,x+1),
                    (y+1,x-1),
                };

                int count = 0;

                visited[y][x] = true;

                foreach (var item in target)
                {
                    Help(item.Item1, item.Item2, true);
                }

                visited[y][x] = false;

                grid[y][x] = 0;

                void Help(int currY, int currX, bool isFirst = false)
                {
                    if (currY == -1 || currY == m || currX == -1 || currX == n || visited[currY][currX] || grid[currY][currX] == 1) return;

                    visited[currY][currX] = true;

                    if (!isFirst && target.Contains((currY, currX)))
                    {
                        foreach (var item in visited)
                        {
                            foreach (var sub in item)
                            {
                                Console.Write(sub ? '+' : '_');
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("-------------------------------------");
                    }

                    Help(currY - 1, currX);
                    Help(currY + 1, currX);
                    Help(currY, currX - 1);
                    Help(currY, currX + 1);
                    Help(currY + 1, currX + 1);
                    Help(currY + 1, currX - 1);
                    Help(currY - 1, currX + 1);
                    Help(currY - 1, currX - 1);

                    visited[currY][currX] = false;

                }

            }

            // todo: 围棋

            return res;


        }


    }
}
