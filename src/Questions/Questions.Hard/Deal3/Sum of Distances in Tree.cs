using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/11/2021 4:16:58 PM
    /// @source : https://leetcode.com/problems/sum-of-distances-in-tree/
    /// @des : 
    /// </summary>
    [Obsolete("don't understand")]
    public class Sum_of_Distances_in_Tree
    {
        // out memory
        public int[] Try2(int n, int[][] edges)
        {

            Stack<(int point, int point2)> curr = new Stack<(int, int)>(), next = new Stack<(int, int)>();
            #region base

            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], n);
                dp[i][i] = 0;
            }

            Dictionary<int, ISet<int>> shortDic = new Dictionary<int, ISet<int>>();

            foreach (var item in edges)
            {
                int l = item[0], r = item[1];

                if (shortDic.TryGetValue(l, out var list))
                {
                    list.Add(r);
                }
                else
                {
                    shortDic[l] = new HashSet<int>() { r };
                }
                if (shortDic.TryGetValue(r, out list))
                {
                    list.Add(l);
                }
                else
                {
                    shortDic[r] = new HashSet<int>() { l };
                }
                curr.Push((l, r));
            }
            #endregion
            int emp = 0;
            int count = 1,point, point2;
            while (curr.Count > 0)
            {
                emp += curr.Count;
                while (curr.Count > 0)
                {
                    (point, point2) = curr.Pop();

                    if (dp[point][point2] <= count) continue;

                    dp[point][point2] = dp[point2][point] = count;

                    ISet<int> join = shortDic[point2];

                    foreach (var item in join)
                    {
                        InnerPush(point, item);
                    }

                    ISet<int> join2 = shortDic[point];

                    foreach (var item in join2)
                    {
                        InnerPush(point2, item);
                    }
                }

                var empty = curr;
                curr = next;
                next = empty;
                count++;
            }

            Console.WriteLine($"总遍历：{emp}");

            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    sum += dp[i][j];
                }
                res[i] = sum;
            }

            return res;

            void InnerPush(int point,int point2)
            {
                if (point != point2 && dp[point][point2] > count)
                {
                    next.Push((point, point2));
                }
            }

        }

        // Note: 1 <= n <= 10000
        // slow
        public int[] Try(int n, int[][] edges)
        {

            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }

            Dictionary<int, ISet<int>> shortDic = new Dictionary<int, ISet<int>>();

            foreach (var item in edges)
            {
                int l = item[0], r = item[1];

                if (shortDic.TryGetValue(l, out var list))
                {
                    list.Add(r);
                }
                else
                {
                    shortDic[l] = new HashSet<int>() { r };
                }
                if (shortDic.TryGetValue(r, out list))
                {
                    list.Add(l);
                }
                else
                {
                    shortDic[r] = new HashSet<int>() { l };
                }
            }

            for (int i = 0; i < n; i++)
            {
                Help(i, i, 0);
            }

            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    sum += dp[i][j];
                }
                res[i] = sum;
            }

            return res;

            void Help(int start, int curr, int count)
            {
                var cache = dp[start][curr];

                if (cache != 0 && cache <= count) return;

                dp[start][curr] = count;

                ISet<int> set = shortDic[curr];

                foreach (var item in set)
                {
                    Help(start, item, count + 1);
                }
            }

        }

        // slow
        public int[] Bfs(int n, int[][] edges)
        {

            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }

            Dictionary<int, ISet<int>> shortDic = new Dictionary<int, ISet<int>>();

            foreach (var item in edges)
            {
                int l = item[0], r = item[1];

                dp[l][r] = dp[r][l] = 1;
                if (shortDic.TryGetValue(l, out var list))
                {
                    list.Add(r);
                }
                else
                {
                    shortDic[l] = new HashSet<int>() { r };
                }
                if (shortDic.TryGetValue(r, out list))
                {
                    list.Add(l);
                }
                else
                {
                    shortDic[r] = new HashSet<int>() { l };
                }
            }

            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    sum += Bfs(i, j);
                }
                res[i] = sum;
            }

            return res;

            int Bfs(int source, int target)
            {
                if (dp[source][target] > 0) return dp[source][target];

                int res = 1;

                Stack<int> curr = new Stack<int>(), next = new Stack<int>();

                bool[] visited = new bool[n];
                visited[source] = true;
                curr.Push(source);

                while (true)
                {
                    while (curr.Count > 0)
                    {
                        int v = curr.Pop();

                        ISet<int> set = shortDic[v];

                        if (set.Contains(target))
                        {
                            return dp[source][target] = dp[target][source] = res;
                        }

                        foreach (var item in set)
                        {
                            if (visited[item]) continue;
                            visited[item] = true;
                            dp[source][item] = res;
                            next.Push(item);
                        }
                    }
                    res++;
                    var empty = curr;
                    curr = next;
                    next = empty;
                }

            }

        }
        public int[] Dfs(int n, int[][] edges)
        {
            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], n);
            }

            foreach (var item in edges)
            {
                int l = item[0], r = item[1];

                dp[l][r] = dp[r][l] = 1;
            }

            bool[] visited = new bool[n];
            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    sum += Dfs(i, j);
                }
                res[i] = sum;
            }

            return res;

            // StackOverflow
            int Dfs(int source, int target)
            {
                int min = dp[source][target];

                if (min != n)
                    return min;

                visited[source] = true;

                var arr = dp[source];
                int res = n;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (visited[j]) continue;
                    var need = arr[j];
                    if (need > 0)
                        res = Math.Min(res, need + Dfs(j, target));
                }
                visited[source] = false;
                return dp[source][target] = dp[target][source] = res;
            }
        }

    }
}
