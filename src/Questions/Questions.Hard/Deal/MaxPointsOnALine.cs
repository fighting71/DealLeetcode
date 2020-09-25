using Command.CusStruct;
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
    /// @des : 比较坑，target:一条直线上最多有几个点。
    ///         因为要求为同一直线，很容易就想到y=ax+b,通过相同的a和b 确定一条直线上的点
    ///         但题目未提供斜率参考值，未考虑斜率非整数 未曾想过：double精度也有不够的一天...
    /// </summary>
    public class MaxPointsOnALine
    {

        // TODO:优化速度。
        public int Clear(int[][] points)
        {
            if (points.Length < 2) return points.Length;

            int res = 2;

            Dictionary<CusVector<decimal, decimal>, ISet<int>> dic = new Dictionary<CusVector<decimal, decimal>, ISet<int>>();
            Dictionary<int, ISet<int>> verticalDic = new Dictionary<int, ISet<int>>();// 垂直线
            Dictionary<int, ISet<int>> horizontalDic = new Dictionary<int, ISet<int>>();// 水平线

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = points[i][0], y = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    int nextX = points[j][0], nextY = points[j][1];

                    if (x == nextX) // 丨
                    {
                        if (!verticalDic.ContainsKey(x)) verticalDic[x] = new HashSet<int>();
                        verticalDic[x].Add(j);
                        verticalDic[x].Add(i);
                        res = Math.Max(res, verticalDic[x].Count);
                    }
                    else if (y == nextY) // -
                    {
                        if (!horizontalDic.ContainsKey(y)) horizontalDic[y] = new HashSet<int>();
                        horizontalDic[y].Add(j);
                        horizontalDic[y].Add(i);
                        res = Math.Max(res, horizontalDic[y].Count);
                    }
                    else
                    {

                        decimal slope = (y - nextY) / (decimal)(x - nextX), a = Math.Max(y - slope * x, nextY - slope * nextX);

                        CusVector<decimal, decimal> vector = new CusVector<decimal, decimal>(slope, a);

                        if (!dic.ContainsKey(vector)) dic[vector] = new HashSet<int>();
                        dic[vector].Add(j);
                        dic[vector].Add(i);

                        res = Math.Max(res, dic[vector].Count);
                    }
                }
            }

            return res;
        }

        //Runtime: 148 ms, faster than 30.14% of C# online submissions for Max Points on a Line.
        //Memory Usage: 33.8 MB, less than 5.48% of C# online submissions for Max Points on a Line.
        // 太难了，太难了...
        public int Try4(int[][] points)
        {
            if (points.Length < 2) return points.Length;
            Dictionary<CusVector<decimal, decimal>, ISet<int>> dic = new Dictionary<CusVector<decimal, decimal>, ISet<int>>();

            Dictionary<int, ISet<int>> verticalDic = new Dictionary<int, ISet<int>>();// 垂直线
            Dictionary<int, ISet<int>> horizontalDic = new Dictionary<int, ISet<int>>();// 水平线

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = points[i][0], y = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    int nextX = points[j][0], nextY = points[j][1];

                    if (x == nextX) // 丨
                    {
                        if (!verticalDic.ContainsKey(x)) verticalDic[x] = new HashSet<int>();
                        verticalDic[x].Add(j);
                        verticalDic[x].Add(i);
                    }
                    else if (y == nextY) // -
                    {
                        if (!horizontalDic.ContainsKey(y)) horizontalDic[y] = new HashSet<int>();
                        horizontalDic[y].Add(j);
                        horizontalDic[y].Add(i);
                    }
                    else
                    {

                        decimal slope = (y - nextY) / (decimal)(x - nextX);

                        decimal a = Math.Max(y - slope * x, nextY - slope * nextX);

                        CusVector<decimal, decimal> vector = new CusVector<decimal, decimal>(slope, a);

                        if (!dic.ContainsKey(vector)) dic[vector] = new HashSet<int>();
                        dic[vector].Add(j);
                        dic[vector].Add(i);
                    }


                }

            }

            int max = 0;
            if (dic.Count > 0)
                max = Math.Max(dic.Select(u => u.Value.Count).Max(), max);
            if (verticalDic.Count > 0)
                max = Math.Max(verticalDic.Select(u => u.Value.Count).Max(), max);
            if (horizontalDic.Count > 0)
                max = Math.Max(horizontalDic.Select(u => u.Value.Count).Max(), max);

            return max;
        }

        [Obsolete("[[0,0],[94911151,94911150],[94911152,94911151]] 斜率相同 却不在同一直线上？")]
        // https://zh.numberempire.com/graphingcalculator.php?functions=0.9999999894638303*x&xmin=94911151&xmax=94911152&ymin=94911150&ymax=94911153&var=x
        // 经绘制确实在同一直线，题有问题？
        // 经验证，是double精确度不够...
        public int Try3(int[][] points)
        {
            if (points.Length < 2) return points.Length;
            Dictionary<CusVector<double,double>, ISet<int>> dic = new Dictionary<CusVector<double, double>, ISet<int>>();

            Dictionary<int, ISet<int>> verticalDic = new Dictionary<int, ISet<int>>();// 垂直线
            Dictionary<int, ISet<int>> horizontalDic = new Dictionary<int, ISet<int>>();// 水平线

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = points[i][0], y = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    int nextX = points[j][0], nextY = points[j][1];

                    if (x == nextX) // 丨
                    {
                        if (!verticalDic.ContainsKey(x)) verticalDic[x] = new HashSet<int>();
                        verticalDic[x].Add(j);
                        verticalDic[x].Add(i);
                    }
                    else if (y == nextY) // -
                    {
                        if (!horizontalDic.ContainsKey(y)) horizontalDic[y] = new HashSet<int>();
                        horizontalDic[y].Add(j);
                        horizontalDic[y].Add(i);
                    }
                    else
                    {

                        double slope = (y - nextY) / (double)(x - nextX);

                        double a = Math.Max(y - slope * x, nextY - slope * nextX);

                        CusVector<double, double> vector = new CusVector<double, double>(slope, a);

                        if (!dic.ContainsKey(vector)) dic[vector] = new HashSet<int>();
                        dic[vector].Add(j);
                        dic[vector].Add(i);
                    }


                }

            }

            foreach (var item in dic.OrderByDescending(u => u.Value.Count).Take(3))
            {
                Console.WriteLine($"vector:{item.Key}," +
                    $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
                    $"({item.Value.Count})");
            }

            foreach (var item in verticalDic.OrderByDescending(u => u.Value.Count).Take(3))
            {
                Console.WriteLine($"vertical:{item.Key}," +
                    $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
                    $"({item.Value.Count})");
            }

            foreach (var item in horizontalDic.OrderByDescending(u => u.Value.Count).Take(3))
            {
                Console.WriteLine($"horizontal:{item.Key}," +
                    $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
                    $"({item.Value.Count})");
            }

            int max = 0;
            if (dic.Count > 0)
                max = Math.Max(dic.Select(u => u.Value.Count).Max(), max);
            if (verticalDic.Count > 0)
                max = Math.Max(verticalDic.Select(u => u.Value.Count).Max(), max);
            if (horizontalDic.Count > 0)
                max = Math.Max(horizontalDic.Select(u => u.Value.Count).Max(), max);

            return max;
        }

        public int Try2(int[][] points)
        {
            if (points.Length < 2) return points.Length;
            Dictionary<Vector2, ISet<int>> dic = new Dictionary<Vector2, ISet<int>>();

            Dictionary<int, ISet<int>> verticalDic = new Dictionary<int, ISet<int>>();// 垂直线
            Dictionary<int, ISet<int>> horizontalDic = new Dictionary<int, ISet<int>>();// 水平线

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = points[i][0], y = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    int nextX = points[j][0], nextY = points[j][1];

                    Vector2 vector; // 精确度不行...
                    if (x == nextX) // 丨
                    {
                        if (!verticalDic.ContainsKey(x)) verticalDic[x] = new HashSet<int>();
                        verticalDic[x].Add(j);
                        verticalDic[x].Add(i);
                    }
                    else if(y == nextY) // -
                    {
                        if (!horizontalDic.ContainsKey(y)) horizontalDic[y] = new HashSet<int>();
                        horizontalDic[y].Add(j);
                        horizontalDic[y].Add(i);
                    }
                    else
                    {

                        float slope = (y - nextY) / (float)(x - nextX);

                        float a = y - slope * x;

                        vector = new Vector2(slope, a);

                        if (!dic.ContainsKey(vector)) dic[vector] = new HashSet<int>();
                        dic[vector].Add(j);
                        dic[vector].Add(i);
                    }


                }

            }

            //foreach (var item in dic.OrderByDescending(u => u.Value.Count).Take(3))
            //{
            //    Console.WriteLine($"vector:{item.Key}," +
            //        $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
            //        $"({item.Value.Count})");
            //}

            //foreach (var item in verticalDic.OrderByDescending(u => u.Value.Count).Take(3))
            //{
            //    Console.WriteLine($"vertical:{item.Key}," +
            //        $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
            //        $"({item.Value.Count})");
            //}

            //foreach (var item in horizontalDic.OrderByDescending(u => u.Value.Count).Take(3))
            //{
            //    Console.WriteLine($"horizontal:{item.Key}," +
            //        $"{string.Join(',', item.Value.Select(u => $"[{points[u][0]},{points[u][1]}]"))}" +
            //        $"({item.Value.Count})");
            //}

            int max = 0;
            if (dic.Count > 0)
                max = Math.Max(dic.Select(u => u.Value.Count).Max(), max);
            if (verticalDic.Count > 0)
                max = Math.Max(verticalDic.Select(u => u.Value.Count).Max(), max);
            if (horizontalDic.Count > 0)
                max = Math.Max(horizontalDic.Select(u => u.Value.Count).Max(), max);

            return max;
        }

        // bug: float 存在无穷大... infinity
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

        [Obsolete("同一条线难以解决(斜率不固定，即任意两点都可连成一线，考虑信息量过大Tv)...")]
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
