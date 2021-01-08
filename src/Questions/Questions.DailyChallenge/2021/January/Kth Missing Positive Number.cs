using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/7/2021 10:47:35 AM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3594/
    /// @des : 查找丢失的第k个数
    /// </summary>
    public class Kth_Missing_Positive_Number
    {

        // Your runtime beats 98.68 %
        // em.
        public int Simple(int[] arr, int k)
        {
            int i = 0, item = 1;

            while (k > 0)
            {
                if (i == arr.Length) return item + k - 1;

                var curr = arr[i++];

                if(curr != item)
                {
                    var diff = curr - item;

                    if (k > diff)
                    {
                        k -= diff;
                    }
                    else
                    {
                        return item + k - 1;
                    }
                }

                item = curr + 1;
            }

            return 0;
        }

    }
}
