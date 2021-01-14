using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 2:13:20 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3602/
    /// @des : 
    /// </summary>
    public class Boats_to_Save_People
    {
        // 1 <= people.length <= 50000
        // 1 <= people[i] <= limit <= 30000

        // Your runtime beats 94.34 % 
        public int NumRescueBoats(int[] people, int limit)
        {
            int res = 0;

            Array.Sort(people);

            int l = 0, r = people.Length - 1;

            while (r > l)
            {
                if (people[r] + people[l] <= limit)
                {
                    l++;
                }

                r--;
                res++;

            }

            if (r == l) res++;

            return res;
        }
    }
}
