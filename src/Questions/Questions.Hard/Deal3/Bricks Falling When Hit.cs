using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/29/2021 11:39:57 AM
    /// @source : https://leetcode.com/problems/bricks-falling-when-hit/
    /// @error des : 
    ///     《围棋》
    ///     给你一个棋盘，棋盘中包含 "0"和"1"
    ///     初始棋盘（可以如此相像：给你的棋盘其实并不是完整的棋盘，而是棋盘的一个视图，在视图中你缺少了【第一行】，在此基础上进行下棋）：  // no &最后一行&第一列&最后一列
    ///         第一行为1
    ///         第一列和最后一列和最后一行
    ///         
    ///     hits即为落子的坐标
    ///         每次落子将此位置替换为0，若能够围住1，则将围住的1替换为0且返回1的个数
    ///     (虽然描述完全不是这个，但跟这个的意思一模一样..)
    ///     
    /// @des : 
    /// 
    ///     给定一个m × n的二进制网格，其中每个1代表一个砖块，0代表一个空白空间。砖块是稳定的，如果:
    ///     
    ///     它直接连接到电网的顶部，或者
    ///     
    ///     在相邻的四个单元中至少有一个砖块是稳定的。
    ///     你也得到了一个数组命中，这是一个我们想要应用的擦除序列。每次我们想要擦除砖块的位置命中[i] = (rowi, coli)。该位置上的砖块(如果它存在)将消失。一些其他的砖块可能不再稳定，因为这种擦除，将会掉下来。一旦砖块掉落，它就会立即从网格中消失(也就是说，它不会落在其他稳定的砖块上)。
    ///     返回一个数组结果，其中每个结果[i] 是应用第i次擦除后将下降的砖块的数量。
    /// 
    /// </summary>
    //[Obsolete("time limit,围棋")]
    //[Favorite(FlagConst.Special, "围棋")]
    // 非围棋
    [Optimize(FlagConst.Slow)]
    public class Bricks_Falling_When_Hit
    {

        // Constraints:

        // m == grid.length
        //n == grid[i].length
        //1 <= m, n <= 200
        //grid[i][j] is 0 or 1.
        //1 <= hits.length <= 4 * 104
        //hits[i].length == 2
        //0 <= xi <= m - 1
        //0 <= yi <= n - 1
        //All(xi, yi) are unique.

        // Runtime: 2936 ms, faster than 25.00% of C# online submissions for Bricks Falling When Hit.
        // Memory Usage: 53.1 MB, less than 75.00% of C# online submissions for Bricks Falling When Hit.
        public int[] Try4(int[][] grid, int[][] hits)
        {

            int[] res = new int[hits.Length];
            int m = grid.Length, n = grid[0].Length;

            bool[][] survival = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                survival[i] = new bool[n];
            }

            for (int i = 0; i < n; i++) 
            {
                HelpSurvival(0, i); // 存活过滤
            }

            Stack<(int, int)> removeStack = new Stack<(int, int)>();
            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                int y = hit[0], x = hit[1];

                if (!survival[y][x]) continue;

                survival[y][x] = false;

                res[i] = Common(y, x);

            }

            return res;

            int Common(int y, int x)
            {
                int currCount = 0;
                removeStack.Clear();
                if (!HelpRemove(y - 1, x)) currCount += removeStack.Count;
                removeStack.Clear();
                if (!HelpRemove(y + 1, x)) currCount += removeStack.Count;
                removeStack.Clear();
                if (!HelpRemove(y, x - 1)) currCount += removeStack.Count;
                removeStack.Clear();
                if (!HelpRemove(y, x + 1)) currCount += removeStack.Count;

                return currCount;
            }

            bool HelpRemove(int y, int x)
            {
                if (y == -1 || y == m || x == -1 || x == n || !survival[y][x]) return false;
                if (y == 0)
                { // 满足存活，则撤回所有修改...
                    while (removeStack.Count > 0)
                    {
                        (int, int) p = removeStack.Pop();
                        survival[p.Item1][p.Item2] = true;
                    }
                    return true;
                }

                survival[y][x] = false;

                // 备忘录
                removeStack.Push((y, x));

                var res =
                HelpRemove(y - 1, x) ||
                HelpRemove(y + 1, x) ||
                HelpRemove(y, x - 1) ||
                HelpRemove(y, x + 1);

                if (res) survival[y][x] = true;

                return res;

            }

            void HelpSurvival(int y,int x)
            {
                if (y == -1 || y == m || x == -1 || x == n || grid[y][x] == 0 || survival[y][x]) return;

                survival[y][x] = true;

                HelpSurvival(y + 1, x);
                HelpSurvival(y - 1, x);
                HelpSurvival(y, x + 1);
                HelpSurvival(y, x - 1);
            }

        }
        public int[] Try3(int[][] grid, int[][] hits)
        {
            int[] res = new int[hits.Length];
            int m = grid.Length, n = grid[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            int count;

            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                int y = hit[0], x = hit[1];

                if (grid[y][x] == 0) continue;
                grid[y][x] = 0;

                res[i] = Common(y, x);

                if(res[i] > 0)
                {

                    foreach (var item in grid)
                    {
                        foreach (var sub in item)
                        {
                            Console.Write(sub == 1 ? '+' : '_');
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("------------------------" + res[i]);
                }
            }

            return res;

            int Common(int y, int x)
            {
                int currCount = 0;
                count = 0;
                if (!Help(y - 1, x)) currCount += count;
                count = 0;
                if (!Help(y + 1, x)) currCount += count;
                count = 0;
                if (!Help(y, x - 1)) currCount += count;
                count = 0;
                if (!Help(y, x + 1)) currCount += count;

                return currCount;
            }

            bool Help(int y, int x)
            {
                if (y == -1 || y == m || x == -1 || x == n || visited[y][x] || grid[y][x] == 0) return false;
                if (y == 0) return true;

                count++;

                visited[y][x] = true;

                var res =
                Help(y - 1, x) ||
                Help(y + 1, x) ||
                Help(y, x - 1) ||
                Help(y, x + 1);

                if (res) visited[y][x] = false;

                return res;

            }

        }

        // Time Limit Exceeded
        // 诚不欺我 果然是这思路...
        public int[] Try2(int[][] grid, int[][] hits)
        {
            //TestShow(grid);
            /*
             * 看到Try.TestShow打印的结果后，突然发现，这不就是围棋吗，
             * hit即为落下的子，落下后吃掉所有被孤立的子...
             */

            int[] res = new int[hits.Length];
            int m = grid.Length, n = grid[0].Length;

            int[][] range = new int[m][];
            for (int i = 0; i < m; i++)
            {
                range[i] = new int[2];
            }

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            int count;
            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                int y = hit[0], x = hit[1];

                if (grid[y][x] == 0) continue;

                count = 0;
                Common(y, x);
                grid[y][x] = 0;
                if (count > 0) continue;

                Common(y - 1, x);
                Common(y + 1, x);
                Common(y, x - 1);
                Common(y, x + 1);
                res[i] = count;
                // 找到包围圈
            }

            return res;

            void Common(int i, int j)
            {
                if (i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0) return;
                for (int t = 0; t < m; t++)
                {
                    Array.Fill(visited[t], false);
                }
                if (!Help(i, j)) // 查看是否被包围
                {
                    SetZero(i, j);// 被包围了就全部替换
                }
            }

            void SetZero(int i, int j)
            {
                if (i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0) return;
                grid[i][j] = 0;
                count++;
                SetZero(i - 1, j);
                SetZero(i + 1, j);
                SetZero(i, j - 1);
                SetZero(i, j + 1);
            }

            bool Help(int i, int j)
            {
                if (i == -1) return true;

                if (i == 0 && (j == -1 || j == n || grid[i][j] == 1)) return true;

                if (i == m || j == -1 || j == n || grid[i][j] == 0 || visited[i][j]) return false;
                visited[i][j] = true;
                return Help(i - 1, j) ||
                    Help(i + 1, j) ||
                    Help(i, j - 1) ||
                    Help(i, j + 1);

            }

        }


        void TestShow(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            Console.Write("y: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            for (int t = 0; t < m; t++)
            {
                Console.Write($"{t}: ");
                for (int t2 = 0; t2 < n; t2++)
                {
                    Console.Write(grid[t][t2]);
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
        }

        // bug
        public int[] Try(int[][] grid, int[][] hits)
        {

            int m = grid.Length, n = grid[0].Length;
            Item[][] dp = new Item[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new Item[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = new Item();
                }
            }

            for (int j = 0; j < n; j++)
            {
                Help(0, j, TOP);
            }

            TestShow();

            int[] res = new int[hits.Length];
            int reduceCount;
            for (int i = 0; i < hits.Length; i++)
            {

                reduceCount = 0;
                var hit = hits[i];
                int y = hit[0], x = hit[1];
                var curr = dp[y][x];
                if (curr.Count > 0)
                {
                    curr.Count = 0;
                    HelpReduce(y + 1, x, TOP);
                    HelpReduce(y - 1, x, Bottom);
                    HelpReduce(y, x + 1, Left);
                    HelpReduce(y, x - 1, Right);
                    res[i] = reduceCount;
                }
            }

            return res;

            void TestShow()
            {
                for (int t = 0; t < m; t++)
                {
                    for (int t2 = 0; t2 < n; t2++)
                    {
                        Console.Write(dp[t][t2].Count > 0 ? '1' : '0');
                        Console.Write(", ");
                    }
                    Console.WriteLine();
                }
            }

            void HelpReduce(int i, int j, int direction)
            {
                if (i == -1 || i == m || j == -1 || j == n) return;
                var curr = dp[i][j];
                if (curr.Count == 0 || !curr.Dic[direction]) return;
                curr.Count--;
                curr.Dic[direction] = false;
                if (curr.Count == 0)
                {
                    reduceCount++;
                    HelpReduce(i + 1, j, TOP);
                    HelpReduce(i - 1, j, Bottom);
                    HelpReduce(i, j + 1, Left);
                    HelpReduce(i, j - 1, Right);
                }
            }

            void Help(int i, int j, int direction)
            {
                if (i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0) return;
                var curr = dp[i][j];
                if (curr.Dic[direction]) return;
                curr.Count++;
                curr.Dic[direction] = true;
                Help(i + 1, j, TOP);
                Help(i - 1, j, Bottom);
                Help(i, j + 1, Left);
                Help(i, j - 1, Right);
            }

        }

        private const int TOP = 0;
        private const int Bottom = 1;
        private const int Left = 2;
        private const int Right = 3;

        class Item
        {
            public Item()
            {
                Dic = new bool[4];
            }
            public int Count { get; set; }
            public bool[] Dic { get; set; }

            public override string ToString()
            {
                if (Count == 0) return "not";
                else return $"({Count}{(Dic[TOP] ? ",TOP" : "")}{(Dic[Bottom] ? ",Bottom" : "")}{(Dic[Left] ? ",Left" : "")}{(Dic[Right] ? ",Right" : "")})";
            }
        }

        public int[] Simple(int[][] grid, int[][] hits)
        {
            int m = grid.Length, n = grid[0].Length;

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }
            int count;

            Count();

            int[] res = new int[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];

                int y = hit[0], x = hit[1];
                var prev = count;
                if (visited[y][x])
                {
                    grid[y][x] = 0;

                    for (int t = 0; t < n; t++)
                    {
                        Array.Fill(visited[t], false);
                    }

                    Count();
                    res[i] = prev - count - 1;

                }
            }

            return res;

            void Count()
            {
                count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (grid[0][j] != 0)
                    {
                        Help(0, j);
                    }
                }
            }

            void Help(int i, int j)
            {
                if (i == -1 || i == m || j == -1 || j == n || visited[i][j]) return;
                count++;
                visited[i][j] = true;
                Help(i + 1, j);
                Help(i - 1, j);
                Help(i, j + 1);
                Help(i, j - 1);
                visited[i][j] = false;
            }

        }

    }
}
