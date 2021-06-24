using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/21/2021 3:20:34 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3786/
    /// @des : 
    /// </summary>
    public class Pascal_s_Triangle
    {

        // Constraints:
        // 1 <= numRows <= 30

        // Your runtime beats 25.57 %
        public IList<IList<int>> Generate(int numRows)
        {

            int[] arr = new int[numRows];

            IList<IList<int>> res = new List<IList<int>>()
            {
                new List<int>(){1}
            };
            arr[0] = 1;
            for (int i = 2; i < numRows; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    arr[j] += arr[j - 1];
                }
                res.Add(arr.Take(i).ToArray());
            }
            return res;
        }

    }
}
