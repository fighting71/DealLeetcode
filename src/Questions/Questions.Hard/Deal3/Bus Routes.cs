using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/25/2021 10:31:57 AM
    /// @source : https://leetcode.com/problems/bus-routes/
    /// @des : 
    ///     你得到了一个表示公共汽车路线的数组，其中[i]是第i个公共汽车永远重复的公共汽车路线。
    ///     例如，如果路由[0]=[1,5,7]，这意味着第0路总线以序列1→5→7→1→5→7→1→...直到永远。
    ///     您将从公交车站源(您最初没有在任何公交车上)开始，并想去公交车站目标。你只能在公共汽车站之间乘坐公共汽车。
    ///     从出发地到目的地必须乘坐最少的公交车。如果不可能，则返回-1。
    /// </summary>
    [Serie(FlagConst.DFS, "疑似dfs")]
    public class Bus_Routes
    {
        // Constraints:
        // 1 <= routes.length <= 500.
        //1 <= routes[i].length <= 10^5
        //All the values of routes[i] are unique.
        //sum(routes[i].length) <= 10^5
        //0 <= routes[i][j] < 10^6
        //0 <= source, target< 10^6

        public int Clear(int[][] routes, int source, int target)
        {

            if (source == target) return 0;

            int len = routes.Length;

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < len; i++)
            {
                var arr = routes[i];
                foreach (var item in arr)
                {
                    if (dic.TryGetValue(item, out var list))
                    {
                        list.Add(i);
                    }
                    else
                    {
                        dic[item] = new List<int>() { i };
                    }
                }
            }

            if (!dic.TryGetValue(source, out var sourceList)) return -1;
            if (!dic.TryGetValue(target, out var targetList)) return -1;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            foreach (var v in dic.Values)
            {
                if (v.Count > 0)
                {
                    foreach (var item in v)
                    {
                        foreach (var item2 in v)
                        {
                            dp[item][item2] = dp[item2][item] = 1;
                        }
                    }
                }
            }

            bool[] visited = new bool[len];
            int min = int.MaxValue;
            foreach (var start in sourceList)
            {
                foreach (var end in targetList)
                {
                    if (start == end) return 1;

                    min = Math.Min(min, Help(start, end, 1));
                }
            }

            return min == int.MaxValue ? -1 : min;

            int Help(int start, int end, int count)
            {
                var cache = dp[start][end];
                if (cache == int.MaxValue) return int.MaxValue;
                if (cache != 0) return count + cache;
                visited[start] = true;
                int res = int.MaxValue;
                for (int i = 0; i < len; i++)
                {
                    if (visited[i]) continue;
                    int transfer = dp[start][i];
                    if (transfer != 0 && transfer != int.MaxValue)
                        res = Math.Min(Help(i, end, count + transfer), res);
                }
                visited[start] = false;
                dp[start][end] = res - count;
                return res;

            }

        }

        // Runtime: 208 ms, faster than 96.30% of C# online submissions for Bus Routes.
        // Memory Usage: 48 MB, less than 55.56% of C# online submissions for Bus Routes.
        // 芜湖起飞~
        public int Try(int[][] routes, int source, int target)
        {

            /*
             *      routes->线路
             *      routes[i][j]->站点
             * 根据Constraints可知：
             * 
             * 线路的数量远大于站点的数量
             * 
             * 故=》通过站点来找寻最短路径 效率低于 通过线路来寻找最短路径
             * 
             */

            // 人在终点 无需上车
            if (source == target) return 0;

            /**
             * 在获取最短路径 => 两个站点之间相通即为最短
             *  => 两条路线拥有相同的站点
             */
            int len = routes.Length;

            // dic[站点] => list (线路)
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < len; i++)
            {
                var arr = routes[i];
                foreach (var item in arr)
                {
                    if (dic.TryGetValue(item, out var list))
                    {
                        list.Add(i);
                    }
                    else
                    {
                        dic[item] = new List<int>() { i };
                    }
                }
            }

            // 检测起点&终点是否在线路上并获取相应的线路
            if (!dic.TryGetValue(source, out var sourceList)) return -1;
            if (!dic.TryGetValue(target, out var targetList)) return -1;

            // dp[起始站点][目标站点]=所需换乘数
            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            foreach (var v in dic.Values)
            {
                if (v.Count > 0)
                {
                    foreach (var item in v)
                    {
                        foreach (var item2 in v)
                        {
                            dp[item][item2] = dp[item2][item] = 1;// 两个线路拥有相同的站点 即只要换乘1次
                        }
                    }
                }
            }

            // visited[i] 是否已经走过过i线路  =》 最短路径不会出现 线路1->线路2->线路1->....
            bool[] visited = new bool[len];
            int min = int.MaxValue;
            foreach (var start in sourceList)
            {
                foreach (var end in targetList)
                {
                    // 获取一组 start -> end 
                    if (start == end) return 1;

                    min = Math.Min(min, Help(start, end, 1));
                }
            }

            return min == int.MaxValue ? -1 : min;

            // 辅助方法
            int Help(int start, int end, int count)
            {
                var cache = dp[start][end];
                // int.MaxValue -> 无法到达
                if (cache == int.MaxValue) return int.MaxValue;
                // 已计算出最短路径 直接求和
                if (cache != 0) return count + cache;
                visited[start] = true;
                int res = int.MaxValue;
                for (int i = 0; i < len; i++) // 遍历所有未访问的线路
                {
                    if (visited[i]) continue;
                    int transfer = dp[start][i];
                    if (transfer != 0 && transfer != int.MaxValue) // 若与此线路相连
                        res = Math.Min(Help(i, end, count + transfer), res);// 递归寻找最短路径
                }
                visited[start] = false;
                // 此处是错误的，因为包含了count 的值...
                //      =》 不过不影响提交
                //          =》说明只有dp[.][,.]== 1 有意义？否  因为每次都会遍历所有未访问的线路，故不影响最终答案... [可优化]
                return dp[start][end] = res;

            }

        }

        // time limit
        public int Simple(int[][] routes, int source, int target)
        {
            if (source == target) return 0;

            int len = routes.Length;

            bool[] visited = new bool[len];

            int min = Help(source, 0);

            return min == int.MaxValue ? -1 : min;

            int Help(int curr, int count)
            {
                int res = int.MaxValue;
                for (int i = 0; i < len; i++)
                {
                    if (visited[i]) continue;
                    var arr = routes[i];
                    if (arr.Contains(curr))
                    {
                        if (arr.Contains(target)) return count + 1;
                        visited[i] = true;
                        foreach (var item in arr)
                        {
                            res = Math.Min(res, Help(item, count + 1));
                        }
                        visited[i] = false;
                    }
                }
                return res;
            }

        }

    }
}
