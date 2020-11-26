using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.Dp.Stone_Game
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 3:04:00 PM
    /// @source : https://leetcode.com/problems/stone-game-ii/
    /// @des :
    ///     初始 M = 1
    ///     存在若干石头堆，每次只能拿 x 个堆的石头 (1=<x<=2M) , 拿完之后M=MAX(M,x)
    /// </summary>
    public class Stone_Game_II
    {

        /**
         * desc
         * 
         * 以[当前坐标][M][先手/后手]为状态
         * 
         * base case :
         *  dp[1][1] = 2;
         *  
         * 状态转移:
         *  
         *  选择：拿取x个堆   0=<x<=2M
         *  
         *      dp[i][j][0] = sum(x) + dp[i+x][MAX(x,M)][1]
         * 
         */
        // 1 <= piles.length <= 100
        // 1 <= piles[i] <= 104
        public int StoneGameII(int[] piles)
        {

            int len = piles.Length;
            int[][][] dp = new int[len][][];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len][];
            }


            return default;
        }

        public int Simple(int[] piles)
        {
            _dic.Clear();
            return Recursion(piles, 0, 1)[0];
        }

        private Dictionary<(int, int), int[]> _dic = new Dictionary<(int, int), int[]>();

        // Runtime: 292 ms, faster than 11.76% 
        // 这解法真难...
        // return arr [0] = 最多的石头，[1] = 下一个坐标, [2] = 当前的M值
        private int[] Recursion(int[] piles, int i, int m)
        {
            var key = (i, m);
            if (_dic.ContainsKey(key)) return _dic[key];
            if (i > piles.Length - 1) return _dic[key] = new[] { 0, i, 0 };
            if (i + 2 * m >= piles.Length)
            {
                return _dic[key] = new[] { piles.Skip(i).Sum(), piles.Length, m };
            }

            int sum = 0, res = 0, resI = i, resM = m, emp;

            for (int j = 0; j < m; j++)
            {
                sum += piles[i + j];
                int[] other = Recursion(piles, i + j + 1, m);
                emp = sum + Recursion(piles, other[1], Math.Max(m, other[2]))[0];

                if (emp > res)
                {
                    res = emp;
                    resI = j + 1;
                    resM = m;
                }
            }

            for (int j = m; j < 2 * m; j++)
            {
                sum += piles[i + j];
                int[] other = Recursion(piles, i + j + 1, j + 1);
                emp = sum + Recursion(piles, other[1], Math.Max(m, other[2]))[0];

                if (emp > res)
                {
                    res = emp;
                    resI = j + 1;
                    resM = j + 1;
                }
            }
            return _dic[key] = new[] { res, i + resI, resM };
        }

        public int DpSolution(int[] piles)
        {

        }

    }
}
