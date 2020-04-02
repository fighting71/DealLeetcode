using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/1/2020 10:09:36 AM
    /// @source : https://leetcode.com/problems/dungeon-game/
    /// @des : key:from (n-1,m-1) not (0,0)
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class Dungeon_Game
    {

        public bool IsDebug { get; set; }

        public int Explain(int[][] dungeon)
        {

            /**
             * 
             * summary:
             * 
             * a.why foreach arr from last ele ?
             * 
             *  参考： [[1,-3,3],[0,-2,0],[-3,-3,-3]]
             *  
             *  若是从(0,0)开始 得到的dp便是：[[1,-2,-2],[0,-1,-1],[-3,-4,-5]] expected 3 out 5 可见从(0,0)进行时，需要考虑备选选项才能得到最终结果，存在很多弊端(一开始就是因为设想从(0,0)开始，把自己玩死了...)
             * 
             * b.为什么不考虑连接时多出的部分 
             * 
             *  参考: [[-2,100]]
             *  
             * (0,1)的值100不能抵消(0,0)的-2 因为必须先走(0,0)才能走(0,1),而走(0,0)需要消耗2hp，故后面的值或连接时的hp再大都影响不了所需要的最小hp
             * 
             * over~
             * 
             */

            if (dungeon.Length == 0) return 0;
            int m = dungeon.Length, n = dungeon[0].Length;

            // 由于最后一列/行的特殊性 可以提前处理
            for (int i = m - 2; i >= 0; i--)// 最后一列
                dungeon[i][n - 1] = Math.Min(dungeon[i][n - 1], dungeon[i][n - 1] + dungeon[i + 1][n - 1]);

            for (int i = n - 2; i >= 0; i--)// 最后一行
                dungeon[m - 1][i] = Math.Min(dungeon[m - 1][i], dungeon[m - 1][i] + dungeon[m - 1][i + 1]);

            for (int i = m - 2; i >= 0; i--)
                for (int j = n - 2; j >= 0; j--)
                    // first : 移动最少需要 dungeon[i][j]
                    // second : 获取 right 和 down 所需要的hp  取能保留的最大值
                    dungeon[i][j] = Math.Max(Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i][j + 1]), Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i + 1][j]));

            return dungeon[0][0] >= 0 ? 1 : 1 - dungeon[0][0];
        }

        /// <summary>
        /// Runtime: 96 ms, faster than 67.31% of C# online submissions for Dungeon Game.
        /// Memory Usage: 25.2 MB, less than 100.00% of C# online submissions for Dungeon Game.
        /// 
        /// Runtime: 92 ms, faster than 92.31% of C# online submissions for Dungeon Game.
        /// Memory Usage: 25 MB, less than 100.00% of C# online submissions for Dungeon Game.
        /// 
        /// comfortable~
        /// </summary>
        /// <param name="dungeon"></param>
        /// <returns></returns>
        public int DpSolution4(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;
            int m = dungeon.Length, n = dungeon[0].Length;

            for (int i = m - 2; i >= 0; i--)
            {
                dungeon[i][n-1] = Math.Min(dungeon[i][n - 1], dungeon[i][n - 1] + dungeon[i + 1][n - 1]);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                dungeon[m-1][i] = Math.Min(dungeon[m - 1][i], dungeon[m - 1][i] + dungeon[m - 1][i + 1]);
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    dungeon[i][j] = Math.Max(Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i][j + 1]), Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i + 1][j]));
                }
            }

            return dungeon[0][0] >= 0 ? 1 : 1 - dungeon[0][0];
        }

        /// <summary>
        /// Runtime: 100 ms, faster than 42.31% of C# online submissions for Dungeon Game.
        /// Memory Usage: 25.2 MB, less than 100.00% of C# online submissions for Dungeon Game.
        /// 
        /// oh my gold!!!
        /// 
        /// </summary>
        /// <param name="dungeon"></param>
        /// <returns></returns>
        public int DpSolution3(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;
            int m = dungeon.Length, n = dungeon[0].Length;

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 && j == n - 1) continue;
                    else if (i == m - 1)
                    {
                        dungeon[i][j] = Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i][j + 1]);
                    }
                    else if (j == n - 1)
                    {
                        dungeon[i][j] = Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i + 1][j]);
                    }
                    else
                    {
                        dungeon[i][j] = Math.Max(Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i][j + 1]), Math.Min(dungeon[i][j], dungeon[i][j] + dungeon[i + 1][j]));
                    }
                }
            }

            if (IsDebug)
            {
                ShowTools.ShowMatrix(dungeon);
            }

            return dungeon[0][0] >= 0 ? 1 : 1 - dungeon[0][0];
        }

        // time limit
        public int DpSolution2(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;
            int m = dungeon.Length, n = dungeon[0].Length;
            if (m == 1 && n == 1) return dungeon[0][0];
            int[][][][] dp = new int[m][][][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n][][];
            }

            dp[0][0] = new int[][] { new int[] { dungeon[0][0], dungeon[0][0] } };

            for (int i = 1; i < m; i++)
            {
                var arr = new int[2];
                arr[0] = dungeon[i][0] + dp[i - 1][0][0][0];
                arr[1] = Math.Min(arr[0], dp[i - 1][0][0][1]);
                dp[i][0] = new int[][] { arr };
            }


            for (int i = 1; i < n; i++)
            {
                var arr = new int[2];
                arr[0] = dungeon[0][i] + dp[0][i - 1][0][0];
                arr[1] = Math.Min(arr[0], dp[0][i - 1][0][1]);
                dp[0][i] = new int[][] { arr };
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int[][] top = dp[i - 1][j], left = dp[i][j - 1];
                    if (i == m - 1 && j == n - 1)
                    {
                        int res = int.MaxValue;
                        foreach (var item in dp[i - 1][j])
                        {
                            item[1] = Math.Min(item[0] + dungeon[i][j], item[1]);
                            if (item[1] >= 0) return 1;
                            res = Math.Min(res, 1 - item[1]);
                        }

                        foreach (var item in dp[i][j - 1])
                        {
                            item[1] = Math.Min(item[0] + dungeon[i][j], item[1]);
                            if (item[1] >= 0) return 1;
                            res = Math.Min(res, 1 - item[1]);
                        }

                        return res;

                    }
                    int[][] cur = new int[top.Length + left.Length][];
                    int index = 0;
                    foreach (var item in dp[i - 1][j])
                    {
                        int[] arr = new int[2];
                        arr[0] = item[0] + dungeon[i][j];
                        arr[1] = Math.Min(arr[0], item[1]);
                        cur[index++] = arr;
                    }

                    foreach (var item in dp[i][j - 1])
                    {
                        int[] arr = new int[2];
                        arr[0] = item[0] + dungeon[i][j];
                        arr[1] = Math.Min(arr[0], item[1]);
                        cur[index++] = arr;
                    }

                    dp[i][j] = cur;
                }
            }

            return 0;

        }

        // time limit
        public int DpSolution(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;
            int m = dungeon.Length, n = dungeon[0].Length;
            List<int[]>[][] dp = new List<int[]>[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new List<int[]>[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = new List<int[]>() { new[] { dungeon[0][0], dungeon[0][0] } };
                        continue;
                    }
                    List<int[]> list = new List<int[]>();
                    if (i > 0)
                    {
                        foreach (var item in dp[i - 1][j])
                        {
                            int[] arr = new int[2];
                            arr[0] = item[0] + dungeon[i][j];
                            arr[1] = Math.Min(arr[0], item[1]);
                            list.Add(arr);
                        }
                    }
                    if (j > 0)
                    {
                        foreach (var item in dp[i][j - 1])
                        {
                            int[] arr = new int[2];
                            arr[0] = item[0] + dungeon[i][j];
                            arr[1] = Math.Min(arr[0], item[1]);
                            list.Add(arr);
                        }
                    }
                    dp[i][j] = list;
                }
            }
            int res = int.MaxValue;
            foreach (var item in dp[m - 1][n - 1])
            {
                res = Math.Min(res, item[1] >= 0 ? 1 : 1 - item[1]);
            }

            return res;

        }

        public int Solution(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;
            return Help(dungeon, dungeon.Length - 1, dungeon[0].Length - 1, 0, 0, 0, 0);
        }

        // Time Limit
        // ok 期望的结果 
        private int Help(int[][] matrix, int m, int n, int hp, int need, int i, int j)
        {
            hp += matrix[i][j];
            need = Math.Min(need, hp);
            if (i == m && j == n) return need >= 0 ? 1 : 1 - need;

            if (i == m)
                return Help(matrix, m, n, hp, need, i, j + 1);

            if (j == n)
                return Help(matrix, m, n, hp, need, i + 1, j);

            return Math.Min(Help(matrix, m, n, hp, need, i, j + 1), Help(matrix, m, n, hp, need, i + 1, j));

        }

        // bug
        public int Try2(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;

            if (IsDebug)
            {
                ShowTools.ShowMatrix(dungeon);
            }

            int m = dungeon.Length, n = dungeon[0].Length;
            int[][] need = new int[m][], need2 = new int[m][], back = new int[m][];
            for (int i = 0; i < m; i++)
            {
                need[i] = new int[n];
                need2[i] = new int[n];
                back[i] = new int[n];
            }

            need2[0][0] = need[0][0] = dungeon[0][0];

            for (int i = 1; i < m; i++)
            {
                back[i][0] = dungeon[i][0] += dungeon[i - 1][0];
                need2[i][0] = need[i][0] = Math.Min(dungeon[i][0], need[i - 1][0]);
            }

            for (int i = 1; i < n; i++)
            {
                back[0][i] = dungeon[0][i] += dungeon[0][i - 1];
                need2[0][i] = need[0][i] = Math.Min(dungeon[0][i], need[0][i - 1]);
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int top = dungeon[i][j] + dungeon[i - 1][j], left = dungeon[i][j] + dungeon[i][j - 1],
                        top2 = dungeon[i][j] + back[i - 1][j], left2 = dungeon[i][j] + back[i][j - 1],
                        topNeed = Math.Min(top, need[i - 1][j]), leftNeed = Math.Min(left, need[i][j - 1]),
                        topNeed2 = Math.Min(top2, need2[i - 1][j]), leftNeed2 = Math.Min(left2, need2[i][j - 1]);

                    if (topNeed2 > topNeed)
                    {
                        topNeed = topNeed2;
                        top = top2;
                    }

                    if (leftNeed2 > leftNeed)
                    {
                        leftNeed = leftNeed2;
                        left = left2;
                    }

                    if (topNeed > leftNeed)
                    {
                        need[i][j] = topNeed;
                        dungeon[i][j] = top;
                        back[i][j] = left;
                        need2[i][j] = leftNeed;
                    }
                    else if (topNeed < leftNeed)
                    {
                        need[i][j] = leftNeed;
                        dungeon[i][j] = left;
                        back[i][j] = top;
                        need2[i][j] = topNeed;
                    }
                    else if (top > left)
                    {
                        need[i][j] = topNeed;
                        dungeon[i][j] = top;
                        back[i][j] = left;
                        need2[i][j] = leftNeed;
                    }
                    else if (top < left)
                    {
                        need[i][j] = leftNeed;
                        dungeon[i][j] = left;
                        back[i][j] = top;
                        need2[i][j] = topNeed;
                    }
                    else
                    {
                        need2[i][j] = need[i][j] = leftNeed;
                        back[i][j] = dungeon[i][j] = left;
                    }

                }
            }

            if (IsDebug)
            {
                ShowTools.ShowMatrix(dungeon);
                ShowTools.ShowMatrix(back);
                ShowTools.ShowMatrix(need);
                ShowTools.ShowMatrix(need2);
            }

            return need[m - 1][n - 1] > 0 ? 1 : 1 - need[m - 1][n - 1];
        }

        // bug : [[1,-3,3],[0,-2,0],[-3,-3,-3]] expected 3 out 5
        public int Try(int[][] dungeon)
        {
            if (dungeon.Length == 0) return 0;

            if (IsDebug)
            {
                ShowTools.ShowMatrix(dungeon);
            }

            int m = dungeon.Length, n = dungeon[0].Length;
            int[][] need = new int[m][];
            for (int i = 0; i < m; i++)
            {
                need[i] = new int[n];
            }

            need[0][0] = dungeon[0][0];

            for (int i = 1; i < m; i++)
            {
                dungeon[i][0] += dungeon[i - 1][0];
                need[i][0] = Math.Min(dungeon[i][0], need[i - 1][0]);
            }

            for (int i = 1; i < n; i++)
            {
                dungeon[0][i] += dungeon[0][i - 1];
                need[0][i] = Math.Min(dungeon[0][i], need[0][i - 1]);
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int top = dungeon[i][j] + dungeon[i - 1][j], left = dungeon[i][j] + dungeon[i][j - 1],
                        topNeed = Math.Min(top, need[i - 1][j]), leftNeed = Math.Min(left, need[i][j - 1]);

                    if (topNeed > leftNeed)
                    {
                        need[i][j] = topNeed;
                        dungeon[i][j] = top;
                    }
                    else if (topNeed < leftNeed)
                    {
                        need[i][j] = leftNeed;
                        dungeon[i][j] = left;
                    }
                    else if (top > left)
                    {
                        need[i][j] = topNeed;
                        dungeon[i][j] = top;
                    }
                    else
                    {
                        need[i][j] = leftNeed;
                        dungeon[i][j] = left;
                    }

                }
            }

            if (IsDebug)
            {
                ShowTools.ShowMatrix(dungeon);
                ShowTools.ShowMatrix(need);
            }

            return need[m - 1][n - 1] > 0 ? 1 : 1 - need[m - 1][n - 1];
        }

    }
}
