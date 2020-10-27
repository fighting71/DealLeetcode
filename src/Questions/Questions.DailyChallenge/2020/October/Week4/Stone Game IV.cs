using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/26/2020 12:17:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3507/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Stone_Game_IV
    {

        private static Dictionary<int, bool> _cache = new Dictionary<int, bool>();

        //Runtime: 212 ms
        //Memory Usage: 24.4 MB
        public bool Simple(int n)
        {
            if (_cache.ContainsKey(n)) return _cache[n];
            bool res = false;
            double sqrt = Math.Sqrt(n);
            if (sqrt % 1 == 0) res = true;
            else
            {

                int floor = (int)sqrt;

                for (int i = 1; i <= floor; i++)
                {
                    var extra = n - (i * i);
                    if (!Simple(extra))
                    {
                        res = true;
                        break;
                    }
                }

            }

            return _cache[n] = res;
        }

    }
}
