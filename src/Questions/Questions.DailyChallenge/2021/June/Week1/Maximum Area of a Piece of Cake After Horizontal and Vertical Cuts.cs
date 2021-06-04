using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/3/2021 4:23:51 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3766/
    /// @des : 
    /// </summary>
    [Optimize(FlagConst.Slow)]
    public class Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts
    {

        // Constraints:
        // 2 <= h, w <= 10^9
        //1 <= horizontalCuts.length<min(h, 10^5)
        //1 <= verticalCuts.length<min(w, 10^5)
        //1 <= horizontalCuts[i] < h
        //1 <= verticalCuts[i] < w
        //It is guaranteed that all elements in horizontalCuts are distinct.
        //It is guaranteed that all elements in verticalCuts are distinct.

        const int mod = 1000_000_007;

        // Runtime: 356 ms
        // Memory Usage: 45.6 MB
        // slow ？？？ 直接疑惑
        public int Simple(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            int[] sort = horizontalCuts.OrderBy(u => u).Distinct().ToArray();

            int prev = 0, maxH = h - sort[^1];

            foreach (var curr in sort)
            {
                maxH = Math.Max(maxH, curr - prev);
                prev = curr;
            }

            prev = 0;
            sort = verticalCuts.OrderBy(u => u).Distinct().ToArray();

            int maxW = w - sort[^1];

            foreach (var curr in sort)
            {
                maxW = Math.Max(maxW, curr - prev);
                prev = curr;
            }

            return (int)((maxW * (long)maxH) % mod);
        }

    }
}
