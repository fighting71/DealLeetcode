using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/22/2021 2:06:38 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3679/
    /// @des : 
    /// </summary>
    public class Reordered_Power_of_2
    {

        // 1 &lt;= N &lt;= 10^9

        // Runtime: 44 ms
        // Memory Usage: 17.2 MB
        // Runtime: 44 ms, faster than 87.50% of C# online submissions for Reordered Power of 2.
        // Memory Usage: 17.1 MB, less than 25.00% of C# online submissions for Reordered Power of 2.

        // 取巧法。耗内存
        public bool Simple(int N)
        {
            return _set.Contains(GetKey(N));
        }

        private static ISet<string> _set = new HashSet<string>();

        static Reordered_Power_of_2()
        {
            int i = 1;
            while (i <= 1000_000_000)
            {
                _set.Add(GetKey(i));
                i *= 2;
            }
        }
        private static string GetKey(int num)
        {
            char[] chars = num.ToString().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        #region other solution 
        // 更快
        public bool OldSolution(int N)
        {
            long c = counter(N);
            for (int i = 0; i < 32; i++)
                if (counter(1 << i) == c) return true;
            return false;
        }

        // 1 = 10 2 = 100 3=1000 4=10^4 n = 10^n
        public long counter(int N)
        {
            long res = 0;
            for (; N > 0; N /= 10) res += (int)Math.Pow(10, N % 10);
            return res;
        }
        #endregion

    }
}
