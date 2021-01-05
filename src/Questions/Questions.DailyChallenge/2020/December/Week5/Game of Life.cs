using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/31/2020 3:20:16 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/573/week-5-december-29th-december-31st/3586/
    /// @des : 
    /// </summary>
    public class Game_of_Life
    {

        // m == board.length
        // n == board[i].length
        //1 <= m, n <= 25
        //board[i][j] is 0 or 1.

        // Your runtime beats 60.61 %
        public void Simple(int[][] board)
        {
            int maxY = board.Length;
            if (maxY == 0) return;

            int maxX = board[0].Length;
            int[][] clone = new int[maxY][];
            for (int i = 0; i < maxY; i++)
            {
                clone[i] = new int[maxX];
                for (int j = 0; j < maxX; j++)
                {
                    clone[i][j] = board[i][j];
                }
            }

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    int count = GetAround(clone, i, j, maxY, maxX);

                    if (count < 2 || count > 3)
                    {
                        board[i][j] = 0;
                    }
                    else if (count == 3)
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }

        private int GetAround(int[][] board, int i, int j, int maxY, int maxX)
        {

            int alive = 0, startX = Math.Max(j - 1, 0);

            for (int y = Math.Max(i - 1, 0); y <= i + 1 && y < maxY; y++)
            {
                for (int x = startX; x <= j + 1 && x < maxX; x++)
                {
                    if (y == i && x == j) continue;
                    if (board[y][x] == 1) alive++;
                }
            }
            return alive;
        }

    }
}
