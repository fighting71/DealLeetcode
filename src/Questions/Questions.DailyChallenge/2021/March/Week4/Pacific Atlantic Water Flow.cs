using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/25/2021 5:20:40 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3684/
    /// @des : 
    /// </summary>
    public class Pacific_Atlantic_Water_Flow
    {
        // Your runtime beats 58.97 % of cs
        // old solution
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (matrix.Length == 0) return res;

            int rowLen = matrix.Length, colLen = matrix[0].Length;

            bool[][] pacificFlag = new bool[matrix.Length][], atlanticFlag = new bool[matrix.Length][];

            for (int i = 0; i < rowLen; i++)
            {
                pacificFlag[i] = new bool[colLen];
                atlanticFlag[i] = new bool[colLen];
            }

            for (int i = 0; i < rowLen; i++)
            {
                pacificFlag[i][0] = true;
                atlanticFlag[i][colLen - 1] = true;
            }

            for (int i = 0; i < colLen; i++)
            {
                pacificFlag[0][i] = true;
                atlanticFlag[rowLen - 1][i] = true;
            }

            for (int i = 0; i < rowLen; i++)
            {
                SetCanFlow(i, 1, matrix, pacificFlag);
                SetCanFlow(i, colLen - 2, matrix, atlanticFlag);
            }

            for (int i = 0; i < colLen; i++)
            {
                SetCanFlow(1, i, matrix, pacificFlag);
                SetCanFlow(rowLen - 2, i, matrix, atlanticFlag);
            }

            for (int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if (pacificFlag[i][j] && atlanticFlag[i][j]) res.Add(new[] { i, j });
                }
            }
            return res;
        }

        private void SetCanFlow(int i, int j, int[][] matrix, bool[][] flag)
        {
            if (i == matrix.Length || j == matrix[0].Length || i == -1 || j == -1 || flag[i][j]) return;

            if (i > 0 && matrix[i][j] >= matrix[i - 1][j] && flag[i - 1][j])
                flag[i][j] = true;
            else if (j > 0 && matrix[i][j] >= matrix[i][j - 1] && flag[i][j - 1])
                flag[i][j] = true;
            else if (i < matrix.Length - 1 && matrix[i][j] >= matrix[i + 1][j] && flag[i + 1][j])
                flag[i][j] = true;
            else if (j < matrix[0].Length - 1 && matrix[i][j] >= matrix[i][j + 1] && flag[i][j + 1])
                flag[i][j] = true;

            if (flag[i][j])
            {
                SetCanFlow(i + 1, j, matrix, flag);
                SetCanFlow(i, j + 1, matrix, flag);
                SetCanFlow(i - 1, j, matrix, flag);
                SetCanFlow(i, j - 1, matrix, flag);
            }
        }
    }
}
