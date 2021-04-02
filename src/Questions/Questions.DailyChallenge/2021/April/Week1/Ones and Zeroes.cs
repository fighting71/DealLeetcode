using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/2/2021 5:01:26 PM
    /// @source : https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3694/
    /// @des : 
    /// </summary>
    public class Ones_and_Zeroes
    {

        // 1 <= strs.length <= 600
        // 1 <= strs[i].length <= 100
        // strs[i] consists only of digits '0' and '1'.
        // 1 <= m, n <= 100

        public int Try2(string[] strs, int m, int n)
        {
            var len = strs.Length;
            int[][] arr = new int[len][];
            for (int i = 0; i < len; i++)
            {
                var item = strs[i];
                var subArr = new int[2];
                foreach (var c in item)
                {
                    subArr[c - '0']++;
                }
                arr[i] = subArr;
            }

            int[][] sort = arr.OrderBy(u => u.Sum()).ToArray();

            int[][] dp = new int[m + 1][];
            for (int i = 0; i < m+1; i++)
            {
                dp[i] = new int[n + 1];
            }

            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {

                    int max = 0;
                    if (i > 0) max = dp[i - 1][j];
                    if (j > 0) max = Math.Max(max, dp[i][j - 1]);

                    foreach (var item in arr)
                    {
                        if(item[0] <= i && item[1] <= j)
                        {

                        }
                    }

                }
            }

            return res;

        }


        // bug
        public int Try(string[] strs, int m, int n)
        {
            var len = strs.Length;
            int[][] arr = new int[len][];
            for (int i = 0; i < len; i++)
            {
                var item = strs[i];
                var subArr = new int[2];
                foreach (var c in item)
                {
                    subArr[c - '0']++;
                }
                arr[i] = subArr;
            }

            int[][] sort = arr.OrderBy(u => u.Sum()).ToArray();

            int zero = 0, one = 0, res = 0;

            foreach (var item in sort)
            {
                int nextZero = zero + item[0], nextOne = one + item[1];
                if (nextZero > m || nextOne > n) continue;
                zero = nextZero;
                one = nextOne;
                res++;
            }

            return res;

        }

        // time limit
        public int Simple(string[] strs, int m, int n)
        {
            var len = strs.Length;
            int[][] arr = new int[len][];
            for (int i = 0; i < len; i++)
            {
                var item = strs[i];
                var subArr = new int[2];
                foreach (var c in item)
                {
                    subArr[c - '0']++;
                }
                arr[i] = subArr;
            }

            int[][] sort = arr.OrderBy(u => u.Sum()).ToArray();

            return Help(0, 0, 0, 0);

            int Help(int i, int zero, int one, int count)
            {
                if (zero > m || one > n) return count - 1;
                if (i == len) return count;
                var curr = sort[i];
                return Math.Max(Help(i + 1, zero + curr[0], one + curr[1], count + 1),
                    Help(i + 1, zero, one, count)
                    );

            }

        }

    }
}
