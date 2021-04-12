using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 5:52:44 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3705/
    /// @des : 
    /// </summary>
    public class Beautiful_Arrangement_II
    {

        // The n and k are in the range 1 <= k < n <= 10^4.
        public int[] ConstructArray(int n, int k)
        {
            // 123 3 2 1
            // 1234    1423

            var list = Enumerable.Range(1, n).ToList();

            if (k == 1) return list.ToArray();

            int[] res = new int[n];

            int i = 1, prev = res[0] = 1, diff = n - 1;
            while (--k > 0)
            {
                int curr = prev - (--diff);
                res[i++] = curr;
            }

            for (int j = list.Count - 1; j >= 0; j--)
            {
                res[i++] = list[j];
            }

            return res;
        }
    }
}
