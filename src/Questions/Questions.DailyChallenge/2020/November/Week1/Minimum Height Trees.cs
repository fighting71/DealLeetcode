using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/4/2020 4:53:44 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3519/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.BFS, FlagConst.Complex)]
    public class Minimum_Height_Trees
    {
        // 1 <= n <= 2 * 104
        //  edges.length == n - 1
        //0 <= ai, bi<n
        //ai != bi
        //All the pairs (ai, bi) are distinct.
        //The given input is guaranteed to be a tree and there will be no repeated edges.

        // 参考其他解决方案
        // source:https://blog.csdn.net/xinqrs01/article/details/55503068?locationNum=6&fps=1
        // beats 92.96 % of nb
        public IList<int> OtherSolution(int n, int[][] edges)
        {
            if (n == 1) return new List<int>() { 0 };
            // 记录 node -> other node
            List<int>[] dic = new List<int>[n];

            for (int i = 0; i < n; i++)
                dic[i] = new List<int>();

            // 记录 node 与 other node 的连接数
            int[] degree = new int[n];

            foreach (var item in edges)
            {
                dic[item[0]].Add(item[1]);
                dic[item[1]].Add(item[0]);
                degree[item[0]]++;
                degree[item[1]]++;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (degree[i] == 1) // 将连接数为1 即一定是叶子节点
                    queue.Enqueue(i);
            }

            // why root is 1 or 2?
            while (n > 2)// 从叶子节点出发，寻找根节点
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int cur = queue.Dequeue();
                    n--;
                    foreach (var item in dic[cur])
                    {
                        if ((--degree[item]) == 1)
                        {
                            queue.Enqueue(item);
                        }
                    }
                }
            }

            return queue.ToArray();

        }

        // time limit
        public IList<int> Clear(int n, int[][] edges)
        {
            if (n == 1) return new List<int>() { 0 };
            List<int>[] dic = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                dic[i] = new List<int>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int node = edges[i][0], node2 = edges[i][1];

                dic[node].Add(node2);
                dic[node2].Add(node);
            }

            int[] deepDic = new int[n];

            int minDeep = int.MaxValue;
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                var deep = GetDeep(i, dic, 0, visited);
                deepDic[i] = deep;
                minDeep = Math.Min(deep, minDeep);
            }

            List<int> res = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (deepDic[i] == minDeep) res.Add(i);
            }

            return res;
        }

        // bfs.
        private int GetDeep(int key, List<int>[] dic, int deep, bool[] visited,int maxDeep = int.MinValue)
        {
            if (deep > maxDeep) return maxDeep;
            visited[key] = true;
            int res = deep;
            bool isFirst = true;
            foreach (var item in dic[key])
            {
                if (!visited[item])
                {
                    if (isFirst)
                    {
                        res = GetDeep(item, dic, deep + 1, visited);
                        isFirst = false;
                    }
                    else
                        res = GetDeep(item, dic, deep + 1, visited, res);
                }
            }
            visited[key] = false;
            return res;
        }

        public IList<int> Simple(int n, int[][] edges)
        {
            if (n == 1) return new List<int>() { 0 };
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < edges.Length; i++)
            {
                int node = edges[i][0], node2 = edges[i][1];

                if (dic.ContainsKey(node))
                {
                    dic[node].Add(node2);
                }
                else
                {
                    dic[node] = new List<int>() { node2 };
                }

                if (dic.ContainsKey(node2))
                {
                    dic[node2].Add(node);
                }
                else
                {
                    dic[node2] = new List<int>() { node };
                }
            }
            Dictionary<int, int> deepDic = new Dictionary<int, int>();
            int minDeep = int.MaxValue;
            bool[] visited = new bool[n];
            foreach (var item in dic.Keys)
            {
                var deep = GetDeep(item, dic, 0, visited);
                deepDic[item] = deep;
                minDeep = Math.Min(deep, minDeep);
            }

            return deepDic.Where(u => u.Value == minDeep).Select(u => u.Key).ToArray();
        }

        private int GetDeep(int key,Dictionary<int,List<int>> dic,int deep,bool[] visited)
        {
            visited[key] = true;
            var old = deep;
            foreach (var item in dic[key])
            {
                if (!visited[item])
                    deep = Math.Max(deep, GetDeep(item, dic, old + 1, visited));
            }
            visited[key] = false;
            return deep;
        }

    }
}
