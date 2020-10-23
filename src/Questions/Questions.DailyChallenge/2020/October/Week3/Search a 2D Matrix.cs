using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week3
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/16/2020 4:49:18 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3497/
    /// @des : Your runtime beats 83.08 % of csharp submissions
    /// </summary>
    public class Search_a_2D_Matrix
    {
        // Runtime: 96 ms
        // Memory Usage: 25.5 MB
        // Your runtime beats 83.08 % of csharp submissions 就这？...
        public bool Simple(int[][] matrix, int target)
        {
            //m == matrix.length
            //n == matrix[i].length
            //0 <= m, n <= 100
            //- 104 <= matrix[i][j], target <= 104

            int row = matrix.Length;

            if (row == 0) return false;

            int cel = matrix[0].Length;

            if (cel == 0) return false;

            for (int i = row - 1; i >= 0; i--)
            {

                if (target == matrix[i][0]) return true;
                else if (target < matrix[i][0]) continue;
                for (int j = cel - 1; j > 0; j--)
                {
                    if (target == matrix[i][j]) return true;
                    else if (target > matrix[i][j]) return false;
                }
                return false;
            }

            return false;

        }

        public bool SolutionByMid(int[][] matrix, int target)
        {
            //m == matrix.length
            //n == matrix[i].length
            //0 <= m, n <= 100
            //- 104 <= matrix[i][j], target <= 104

            int row = matrix.Length, cel = matrix[0].Length,end = cel - 1;

            if (row == 0 || cel == 0) return false;

            int rowL = 0, rowR = row - 1, mid = 0;

            while (rowL < rowR)
            {
                if (target == matrix[rowL][0] || target == matrix[rowL][end]
                    || target == matrix[rowR][0] || target == matrix[rowR][end]) return true;

                if (target > matrix[rowL][0] && target < matrix[rowL][cel - 1])
                {
                    mid = rowL;
                    break;
                }
                if (target > matrix[rowR][0] && target < matrix[rowR][cel - 1])
                {
                    mid = rowR;
                    break;
                }

                if (rowL == rowR + 1) return false;

                mid = (rowL + rowR + 1) / 2;

                if (target == matrix[mid][0] || target == matrix[mid][end]) return true;

                if (target > matrix[mid][0] && target < matrix[mid][cel - 1])
                {
                    break;
                }

                if (target < matrix[mid][0]) rowR = mid;
                else rowL = mid;

            }

            // ...lue lue lue
            return matrix[mid].Any(u => u == target);

        }

    }
}
