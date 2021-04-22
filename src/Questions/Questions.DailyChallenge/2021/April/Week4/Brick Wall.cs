using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/22/2021 5:53:56 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3717/
    /// @des : 
    /// </summary>
    public class Brick_Wall
    {

        // Note:

        // The width sum of bricks in different rows are the same and won't exceed INT_MAX.
        // The number of bricks in each row is in range[1, 10, 000]. The height of wall is in range[1, 10, 000]. Total number of bricks of the wall won't exceed 20,000.


        // Runtime: 136 ms
        // Memory Usage: 36.4 MB
        // Your runtime beats 75.00 % o
        public int Try2(IList<IList<int>> wall)
        {

            int rowCount = wall.Count;

            if(rowCount == 1)
            {
                return wall[0].Count == 1 ? 1 : 0;
            }

            int res = rowCount;
            Dictionary<long, int> dic = new Dictionary<long, int>();


            foreach (var row in wall)
            {
                long sum = 0;
                for (int i = 0; i < row.Count - 1; i++)
                {
                    sum += row[i];
                    int minRes;
                    if (dic.ContainsKey(sum))
                    {
                        minRes = --dic[sum];
                    }
                    else
                    {
                        minRes = dic[sum] = rowCount - 1;
                    }
                    res = Math.Min(res, minRes);
                }
            }
            return res;
        }

        // out memory
        // 宽度太长导致太多不必要的空间占用...
        public int LeastBricks(IList<IList<int>> wall)
        {
            int[] dp = new int[wall[0].Sum() + 1];

            foreach (var row in wall)
            {
                int sum = 0;
                foreach (var item in row)
                {
                    sum += item;
                    dp[sum]++;
                }
            }

            int len = wall.Count, res = len;

            for (int i = 1; i < dp.Length - 1; i++)
            {
                res = Math.Min(res, len - dp[i]);
            }
            return res;
        }

    }
}
