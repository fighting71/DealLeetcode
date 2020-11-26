using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp.Stone_Game
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/24/2020 10:30:09 AM
    /// @source : https://leetcode.com/problems/stone-game/
    /// @des : 
    /// </summary>
    public class Stone_Game
    {
        // Runtime: 100 ms, faster than 38.33% of C# online submissions for Stone Game.
        // Memory Usage: 32.8 MB, less than 11.67% of C# online submissions for Stone Game.
        public bool DpSolution(int[] stones)
        {

            int len = stones.Length;

            int[][] firstDp = new int[len][];
            int[][] sencondDp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                firstDp[i] = new int[len];
                sencondDp[i] = new int[len];
                firstDp[i][i] = stones[i];
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i <= len - l; i++)
                {
                    int j = l + i - 1;
                    int left = stones[i] + sencondDp[i + 1][j];
                    int right = stones[j] + sencondDp[i][j - 1];

                    if(left > right)
                    {
                        firstDp[i][j] = left;
                        sencondDp[i][j] = firstDp[i + 1][j];
                    }
                    else
                    {
                        firstDp[i][j] = right;
                        sencondDp[i][j] = firstDp[i][j - 1];
                    }

                }
            }
            return firstDp[0][len - 1] > sencondDp[0][len - 1];
        }

        #region old
        // than 90%
        public bool StoneGame(int[] piles)
        {
            return IsWin(0, 0, piles, 0, piles.Length - 1);
        }

        private bool IsWin(int alexNum, int leeNum, int[] piles, int start, int end)
        {
            if (start == end)
            {
                return alexNum > leeNum;
            }

            if (end - start > 1)
            {
                var cloneStart = start;
                var cloneEnd = end;

                return IsWin(alexNum + piles[start++], leeNum + piles[start] > piles[end] ? piles[start++] : piles[end--],
                         piles, start, end)
                       || 
                       IsWin(alexNum + piles[cloneEnd--], leeNum + piles[cloneStart] > piles[cloneEnd] ? piles[cloneStart++] : piles[cloneEnd--], piles, cloneStart, cloneEnd);
            }
            else
            {
                alexNum += piles[start] > piles[end] ? piles[start++] : piles[end--];
                leeNum += piles[start] > piles[end] ? piles[start] : piles[end];
                return alexNum > leeNum;
            }
        }
        #endregion

    }
}
