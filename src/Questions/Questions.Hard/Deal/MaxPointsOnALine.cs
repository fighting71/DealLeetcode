using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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


        public int Try(int[][] points)
        {
            // test case?
            //Dictionary<Vector2, int> dic = new Dictionary<Vector2, int>();
            Dictionary<Vector2, List<int[]>> dic = new Dictionary<Vector2, List<int[]>>();

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = points[i][0], y = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    int nextX = points[j][0], nextY = points[j][1];

                    float slope = (y - nextY) / (float)(x - nextX);

                    float a = y - slope * x;

                    Vector2 vector = new Vector2(slope, a);

                    if (dic.ContainsKey(vector))
                    {
                        dic[vector].Add(new[] { x, y, nextX, nextY });
                        var value = dic[vector];

                        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(value));

                        //dic[vector]++;
                    }
                    //else dic[vector] = 1;
                    else dic[vector] = new List<int[]> { new[] { x, y }, new[] { nextX, nextY } };

                }

            }

            return 0;
            //return dic.Values.Max();
        }

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
