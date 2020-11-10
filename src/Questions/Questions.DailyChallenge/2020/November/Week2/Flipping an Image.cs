using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week2
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/10/2020 5:22:37 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3526/
    /// @des : 
    /// </summary>
    public class Flipping_an_Image
    {
        // 1 <= A.length = A[0].length <= 20
        // 0 <= A[i][j] <= 1

        // Runtime: 244 ms
        // Memory Usage: 32.7 MB
        // Your runtime beats 67.48 % of csharp submissions.
        // 送分题?.
        public int[][] FlipAndInvertImage(int[][] A)
        {
            var len = A.Length;

            int[][] res = new int[len][];

            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
                for (int j = 0; j < len; j++)
                    res[i][j] = A[i][len - j - 1] == 0 ? 1 : 0;
            }
            return res;
        }

    }
}
