using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/14/2020 3:18:39 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3555/
    /// @des : 
    /// </summary>
    public class Can_Place_Flowers
    {

        // 1 <= flowerbed.length <= 2 * 10^4
        // flowerbed[i] is 0 or 1.
        //There are no two adjacent flowers in flowerbed.
        //0 <= n <= flowerbed.length
        // Your runtime beats 93.76 %
        public bool Simple(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            int res = 0;
            bool prevHas = false;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (prevHas) prevHas = flowerbed[i] == 1;
                else if (flowerbed[i] == 1) prevHas = true;
                else if (i + 1 == flowerbed.Length || flowerbed[i + 1] == 0)
                {
                    if (++res == n) return true;
                    prevHas = true;
                }
            }
            return false;
        }
    }
}
