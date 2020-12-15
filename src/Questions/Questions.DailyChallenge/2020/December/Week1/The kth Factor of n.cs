using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/14/2020 3:36:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3554/
    /// @des : 
    /// </summary>
    public class The_kth_Factor_of_n
    {

        // 1 <= k <= n <= 1000

        // Your runtime beats 65.17 %.
        public int Simple(int n, int k)
        {
            for (int i = 1; i <= n; i++) if (n % i == 0 && --k == 0) return i;
            return -1;
        }

        public int OtherSolution(int n, int k)
        {
            for (int i = 1; i <= n / 2; i++) if (n % i == 0 && --k == 0) return i;
            return k == 1 ? n : -1;
        }

        // Your runtime beats 18.16 %
        // n&k值较小，无法体现
        public int Optimize(int n, int k)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (list.Count > 0 && i == list[0]) break;
                    var min = n / i;
                    if (--k == 0) return i;
                    if (i == min) break;
                    list.Insert(0, min);
                }
            }

            if (k < list.Count) return list[k - 1];

            return -1;
        }
    }
}
