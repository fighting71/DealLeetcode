using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/25/2021 10:37:55 AM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3719/
    /// @des : 
    /// </summary>
    [Obsolete("Use Tarjan's algorithm. ")]
    public class Critical_Connections_in_a_Network
    {

        // 1 <= n <= 10^5
        // n-1 <= connections.length <= 10^5
        // connections[i][0] != connections[i][1]
        // There are no repeated connections.

        
        public IList<IList<int>> Try2(int n, IList<IList<int>> connections)
        {

            List<int>[] dic = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                dic[i] = new List<int>();
            }

            foreach (var conn in connections)
            {
                int a = conn[0], b = conn[1];
                dic[a].Add(b);
                dic[b].Add(a);
            }

            bool[] visited = new bool[n];

            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                visited[i] = true;

                var curr = dic[i];

                if(curr.Count == 1)
                {
                    if (curr[0] > i)
                        res.Add(new List<int>() { i, curr[0] });
                }
                else
                {
                    // 过于复杂
                }

                visited[i] = false;
            }
            return res;

            bool Help(int i,int target)
            {
                foreach (var item in dic[i])
                {
                    if (visited[item]) continue;

                    if (item == target) continue;

                }
                return false;
            }

        }

        // bug 是要找出 如果被删除，将使某些服务器无法访问其他服务器之一
        public IList<IList<int>> Try(int n, IList<IList<int>> connections)
        {

            int[] count = new int[n];
            int[] join = new int[n];

            foreach (var conn in connections)
            {
                int a = conn[0], b = conn[1];
                count[a]++;
                count[b]++;
                join[a] = b;
                join[b] = a;
            }
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                if (count[i] == 1)
                {
                    res.Add(new List<int>() { i, join[i] });
                }
            }
            return res;
        }

    }
}
