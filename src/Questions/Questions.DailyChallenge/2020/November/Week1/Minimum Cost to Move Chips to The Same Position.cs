using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/5/2020 4:28:45 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3520/
    /// @des : 
    /// </summary>
    public class Minimum_Cost_to_Move_Chips_to_The_Same_Position
    {
        // 1 <= position.length <= 100
        // 1 <= position[i] <= 10^9
        // Runtime: 92 ms
        // Memory Usage: 24.8 MB
        // our runtime beats 55.17 % of csharp submi
        // 题是很简单.
        public int Simple(int[] position)
        {

            int zeroNum = 0, oneNum = 0;

            foreach (var item in position)
            {
                if (item % 10 % 2 == 0) zeroNum++;
                else oneNum++;
            }

            return Math.Min(zeroNum, oneNum);
        }

    }
}
