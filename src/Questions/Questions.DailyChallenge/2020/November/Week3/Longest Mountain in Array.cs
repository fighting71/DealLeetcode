using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/16/2020 5:35:47 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3533/
    /// @des : 
    /// </summary>
    public class Longest_Mountain_in_Array
    {

        /*
         * 
         * Note:

0 <= A.length <= 10000
0 <= A[i] <= 10000
Follow up:

Can you solve it using only one pass?
Can you solve it in O(1) space?
         */

        // Runtime: 108 ms
        // Memory Usage: 31.3 MB
        // Your runtime beats 75.76 % of csharp submissions.
        public int Simple(int[] A)
        {

            int len = A.Length;
            int[] left = new int[len];
            int[] right = new int[len];

            for (int i = 1; i < len; i++)
            {
                if(A[i] > A[i - 1])
                {
                    left[i] = left[i - 1] + 1;
                }
            }

            for (int i = len - 2; i >= 0; i--)
            {
                if(A[i] > A[i + 1])
                {
                    right[i] = right[i + 1] + 1;
                }
            }

            int res = 0;

            for (int i = 0; i < len; i++)
            {
                if(left[i] > 0 && right[i] > 0) // Mountain is   B[0] ...< B[i] >... B[len-1]
                    res = Math.Max(res, left[i] + right[i]);
            }

            return res > 0 ? res + 1 : res;

        }

        // 更简洁，但更耗时... 
        public int Optimize(int[] A)
        {

            int len = A.Length;
            int[] left = new int[len];

            for (int i = 1; i < len - 1; i++)
            {
                if (A[i] > A[i - 1])
                    left[i] = left[i - 1] + 1;
            }

            int res = 0,prev = 0;
            for (int i = len - 2; i > 0; i--)
            {
                if (A[i] > A[i + 1])
                {
                    prev++;
                    if (left[i] > 0)
                        res = Math.Max(res, left[i] + prev);
                }
                else prev = 0;
            }

            return res > 0 ? res + 1 : res;

        }

    }
}
