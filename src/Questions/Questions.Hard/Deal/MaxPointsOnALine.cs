using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/23/2020 3:56:51 PM
    /// @source : https://leetcode.com/problems/max-points-on-a-line/
    /// @des : 
    /// </summary>
    [Obsolete("同一条线难以解决(斜率不固定，即任意两点都可连成一线，考虑信息量过大Tv)...")]
    public class MaxPointsOnALine
    {

        public int Simple(int[][] points)
        {

            // bug: y=ax+b a={∞,∞} ...
            //  [[1,1],[1,1],[2,3]] Expected:3 Output:2
            // ——
            Dictionary<int,int> across = new Dictionary<int, int>(), 
                // |
                vertical = new Dictionary<int, int>(),
               // \
                leftOblique = new Dictionary<int, int>(),
                // /
                rightOblique = new Dictionary<int, int>();

            var res = 0;

            for (int i = 0; i < points.Length; i++)
            {
                int x = points[i][0], y = points[i][1];

                if (across.ContainsKey(y))
                    across[y]++;
                else across[y] = 1;

                if (vertical.ContainsKey(x))
                    vertical[x]++;
                else vertical[x] = 1;

                if (rightOblique.ContainsKey(x - y))
                    rightOblique[x - y]++;
                else rightOblique[x - y] = 1;


                if (leftOblique.ContainsKey(x + y))
                    leftOblique[x + y]++;
                else leftOblique[x + y] = 1;

                res = Math.Max(res, across[y]);
                res = Math.Max(res, vertical[x]);
                res = Math.Max(res, rightOblique[x - y]);
                res = Math.Max(res, leftOblique[x + y]);

            }

            return res;

        }

    }
}
