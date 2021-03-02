using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/1/2021 4:18:56 PM
    /// @source : https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3657/
    /// @des : simple
    /// </summary>
    public class Distribute_Candies
    {
        // n == candyType.length
        //2 <= n <= 10^4
        //n is even.
        //-10^5 <= candyType[i] <= 10^5
        // Your runtime beats 93.02 % 
        public int DistributeCandies(int[] candyType)
        {
            int len = candyType.Length;
            ISet<int> set = new HashSet<int>();
            foreach (var item in candyType)
            {
                set.Add(item);
                if (set.Count == len / 2) break;
            }
            return set.Count;
        }

        public int Simple(int[] candyType)
        {
            return Math.Min(candyType.Length / 2, candyType.Distinct().Count());
        }
    }
}
