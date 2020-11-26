using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/25/2020 6:43:36 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3543/
    /// @des : 
    /// </summary>
    public class Smallest_Integer_Divisible_by_K
    {

        // Runtime: 40 ms
        // Memory Usage: 15.1 MB
        public int Try2(int k)
        {

            if (k % 2 == 0 || k % 5 == 0) return -1;

            if (k == 1) return 1;
            if (k == 11) return 2;

            int remain = 111 % k, res = 3;

            while (remain != 0)
            {
                // next num = num * 10 + 1 so==> next remain(余数) = (remain  * 10 + 1) % k
                remain = (remain * 10 + 1) % k;
                res++;
            }
            return res;

        }

        // Runtime: 36 ms
        // 以前弄过...
        public int OldSolution(int K)
        {
            if (K % 2 == 0 || K % 5 == 0) return -1;

            int yiCount = 0;
            int tempNum = K;

            // 差不多的方案，就是这里是找yiNum而上面直接从111开始...
            // 此种更全面，不用管k的具体范围
            int yiNum = 0;
            while (tempNum > 0)
            {
                tempNum /= 10;
                yiCount++;
                yiNum = yiNum * 10 + 1;
            }

            int yuNum = yiNum % K;
            while (yuNum != 0)
            {
                yuNum = (yuNum * 10 + 1) % K;
                yiCount++;
            }

            return yiCount;
        }

        // 1 <= K <= 105
        // 存在越界bug...
        public int Simple(int k)
        {

            if (k % 2 == 0) return -1;
            if (k % 5 == 0) return -1;

            ulong div = (ulong)k;
            ulong num = 1;
            int res = 1;

            while (num > 0 && num % div != 0)
            {
                num = num * 10 + 1;
                res++;
            }
            return num > 0 ? res : -1;

        }
    }
}
