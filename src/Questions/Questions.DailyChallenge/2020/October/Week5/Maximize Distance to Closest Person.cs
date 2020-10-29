using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week5
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/29/2020 5:14:29 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3512/
    /// @des : 
    /// </summary>
    public class Maximize_Distance_to_Closest_Person
    {

        public int Clear(int[] seats)
        {
            int start = -1, res = 1;
            bool hasSitting = false; // 前面是否有person sitting

            for (int i = 0; i < seats.Length - 1; i++)
                if (seats[i] == 1)
                {
                    if (hasSitting) res = Math.Max(res, (i - start) / 2);
                    else
                    {
                        res = Math.Max(res, i);
                        hasSitting = true;
                    }
                    start = i;
                }

            if (!hasSitting) return seats.Length - 1;

            if (seats[^1] == 0)
                res = Math.Max(seats.Length - 1 - start, res);
            else
                res = Math.Max((seats.Length - 1 - start) / 2, res);

            return res;
        }

        //2 <= seats.length <= 2 * 104
        //seats[i] is 0 or 1.
        //At least one seat is empty.
        //At least one seat is occupied.

        // Runtime: 96 ms
        // Memory Usage: 28.6 MB
        // Your runtime beats 95.59 % of csharp submissions.
        // heihei,pass two error
        public int Solution(int[] seats)
        {
            //[1,0,1] , error②

            int start = -1, res = 1; // -1 为了识别 {0,0,....}1的情况

            for (int i = 0; i < seats.Length - 1; i++)
            {
                if (seats[i] == 1)// 1{0,0,0...}1 构成一个区间
                {
                    res = Math.Max(res, start == -1 ? i : ((i - start) / 2));
                    start = i;
                }
            }

            // [0,0,1] , error①
            if (start == -1) return seats.Length - 1;

            if (seats[^1] == 0)
            {
                res = Math.Max(seats.Length - 1 - start, res);
            }
            else
            {
                res = Math.Max((seats.Length - 1 - start) / 2, res);
            }

            return res;
        }

    }
}
