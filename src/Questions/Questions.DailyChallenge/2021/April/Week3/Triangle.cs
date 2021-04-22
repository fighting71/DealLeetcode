using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/22/2021 10:37:13 AM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3715/
    /// @des : 
    /// </summary>
    public class Triangle
    {

        //Constraints:

        //1 <= triangle.length <= 200
        //triangle[0].length == 1
        //triangle[i].length == triangle[i - 1].length + 1
        //-10^4 <= triangle[i][j] <= 10^4


        //Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?

        public int Solution3(IList<IList<int>> triangle)
        {
            int[] dp = new int[triangle.Count + 2];

            Array.Fill(dp, int.MaxValue);

            int min = dp[1] = triangle[0][0];

            for (int i = 1; i < triangle.Count; i++)
            {
                var curr = triangle[i];

                for (int j = curr.Count - 1; j >= 0; j--)
                {
                    min = Math.Min(dp[j + 1] = curr[j] + Math.Min(dp[j + 1], dp[j]), min);
                }
            }
            return dp.Min();
        }

        // Runtime: 128 ms
        // Memory Usage: 25.2 MB
        // slow
        public int Try2(IList<IList<int>> triangle)
        {
            int[] dp = new int[triangle.Count + 2];

            Array.Fill(dp, int.MaxValue);

            dp[1] = triangle[0][0];

            for (int i = 1; i < triangle.Count; i++)
            {
                var curr = triangle[i];

                for (int j = curr.Count - 1; j >= 0; j--)
                {
                    dp[j + 1] = curr[j] + Math.Min(dp[j + 1], dp[j]);
                }
            }
            return dp.Min();
        }

        // Runtime: 148 ms
        // Memory Usage: 25 MB
        // slow
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int[] dp = new int[triangle[triangle.Count - 1].Count];

            dp[0] = triangle[0][0];

            for (int i = 1; i < triangle.Count; i++)
            {
                var curr = triangle[i];

                dp[curr.Count - 1] = curr[curr.Count - 1] + dp[curr.Count - 2];
                for (int j = curr.Count - 2; j > 0; j--)
                {
                    dp[j] = curr[j] + Math.Min(dp[j], dp[j - 1]);
                }
                dp[0] = curr[0] + dp[0];
            }
            return dp.Min();
        }
    }
}
