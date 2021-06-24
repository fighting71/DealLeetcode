using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/24/2021 6:03:59 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3790/
    /// @des : 
    /// 
    ///     有一个带球的mxn网格。球最初在位置[startRow, startColumn]。您可以将球移动到网格中相邻的4个单元格中的一个(可能是越过网格边界的网格外)。你最多可以应用maxMove移动到球。
    ///     给定5个整数m, n, maxMove, startRow, startColumn，返回将球移出网格边界的路径数。因为答案可能很大，所以对109 + 7取模返回。
    /// 
    /// </summary>
    [Serie(FlagConst.DP, FlagConst.Middle)]
    public class Out_of_Boundary_Paths
    {

        // Constraints:

        //1 <= m, n <= 50
        //0 <= maxMove <= 50
        //0 <= startRow <= m
        //0 <= startColumn <= n

        const int Mod = 1000_000_007;

        public int Explain(int m, int n, int maxMove, int startRow, int startColumn)
        {

            // defind dp[index][index][moveCount] = number of paths
            int[][][] dp = new int[m + 2][][];

            // base case: 
            int[] outside = new int[maxMove + 1];
            Array.Fill(outside, 1);

            bool flag;
            for (int i = 0; i < dp.Length; i++)
            {
                flag = i == 0 || i == m + 1;
                dp[i] = new int[n + 2][];
                for (int j = 0; j < n + 2; j++)
                {
                    dp[i][j] = flag || j == 0 || j == n + 1 ? outside : new int[maxMove + 1];
                }
            }

            for (int move = 1; move <= maxMove; move++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // state transition : curr[move] = top[move-1] + left[move-1] + right[move-1] + bottom[move-1]
                        dp[i + 1][j + 1][move] = (((dp[i][j + 1][move - 1]
                            + dp[i + 2][j + 1][move - 1]) % Mod
                            + dp[i + 1][j][move - 1]) % Mod
                            + dp[i + 1][j + 2][move - 1]) % Mod;

                    }
                }
            }
            return dp[startRow + 1][startColumn + 1][maxMove];
        }

        // Your runtime beats 96.15 % of csharp submissions
        // Runtime: 44 ms
        // Memory Usage: 17.4 MB
        // optimize => 不必计算所有的[maxMove] 直接用[maxMove-1] 求和
        // oh yeah
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {

            /**
             * dp[i][j][move]
             * 
             * 四边：
             * 
             *  dp[][][1] = 1
             *  
             * 状态转移：
             * 
             *  dp[][][move] = 四周 dp[][][move - 1]
             * 
             */

            int[][][] dp = new int[m + 2][][];

            int[] outside = new int[maxMove + 1];
            Array.Fill(outside, 1);

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 2][];
                for (int j = 0; j < n + 2; j++)
                {
                    dp[i][j] = i == 0 || j == 0 || i == m + 1 || j == n + 1 ? outside : new int[maxMove + 1];
                }
            }

            for (int move = 1; move <= maxMove; move++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dp[i + 1][j + 1][move] = (((dp[i][j + 1][move - 1]
                            + dp[i + 2][j + 1][move - 1]) % Mod
                            + dp[i + 1][j][move - 1]) % Mod
                            + dp[i + 1][j + 2][move - 1]) % Mod;

                    }
                }
            }
            return dp[startRow + 1][startColumn + 1][maxMove];
        }

    }
}
