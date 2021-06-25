using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/25/2021 4:35:51 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3791/
    /// @des : 
    /// 
    ///     给定一个图
    /// 
    ///     edges[i] = 边 = []{x,x} 连接的两个点
    ///     
    ///     target : 删除某条边来使图转成树
    ///     
    ///     ps: 若存在多条这样的边，这返回按数组顺序的最后一条边
    /// 
    /// </summary>
    [Serie(FlagConst.Graph, FlagConst.Tree, FlagConst.DFS)]
    [Optimize]
    public class Redundant_Connection
    {

        // Constraints:

        //n == edges.length
        //3 <= n <= 1000
        //edges[i].length == 2
        //1 <= ai<bi <= edges.length
        //ai != bi
        //There are no repeated edges.
        //The given graph is connected.

        // Your runtime beats 41.88 % of csharp submissions.
        // llll
        public int[] FindRedundantConnection(int[][] edges)
        {
            int len = edges.Length;

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            foreach (var item in edges)
            {
                int a = item[0], b = item[1];
                if(dic.TryGetValue(a,out var list))
                {
                    list.Add(b);
                }
                else
                {
                    dic[a] = new List<int> { b };
                }
                if (dic.TryGetValue(b, out list))
                {
                    list.Add(a);
                }
                else
                {
                    dic[b] = new List<int>() { a };
                }
            }

            int target;
            bool[] visited = new bool[dic.Count + 1];

            for (int i = len - 1; i >= 0; i--)
            {
                var item = edges[i];
                int a = item[0], b = item[1];

                dic[a].Remove(b);
                dic[b].Remove(a);
                target = b;
                if (Help(a)) return item;
                dic[a].Add(b);
                dic[b].Add(a);
            }

            return default;

            bool Help(int node)
            {
                if (node == target) return true;
                if (visited[node]) return false;
                visited[node] = true;

                bool res = false;

                var link = dic[node];

                foreach (var item in link)
                {
                    if(Help(item))
                    {
                        res = true;
                        break;
                    }
                }

                visited[node] = false;

                return res;

            }

        }

    }
}
