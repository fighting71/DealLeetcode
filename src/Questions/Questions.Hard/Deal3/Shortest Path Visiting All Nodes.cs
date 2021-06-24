using Command.Attr;
using Command.Const;
using Command.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/23/2021 5:49:24 PM
    /// @source : https://leetcode.com/problems/shortest-path-visiting-all-nodes/
    /// @des : 
    /// 
    ///     你有一个无向连通图有n个节点，标记从0到n - 1。给定一个数组图，其中图[i]是一条边连接到节点i的所有节点的列表。
    ///     返回访问每个节点的最短路径的长度。您可以在任何节点上启动和停止，可以多次重新访问节点，还可以重用边。
    /// 
    /// </summary>
    [Serie(FlagConst.Tree, FlagConst.BFS)]
    [Optimize]
    public class Shortest_Path_Visiting_All_Nodes
    {

        // Constraints:

        //n == graph.length
        //1 <= n <= 12
        //0 <= graph[i].length<n
        //graph[i] does not contain i.
        //If graph[a] contains b, then graph[b] contains a.
        //The input graph is always connected.

        // Runtime: 248 ms, faster than 8.57% of C# online submissions for Shortest Path Visiting All Nodes.
        // Memory Usage: 39.6 MB, less than 5.72% of C# online submissions for Shortest Path Visiting All Nodes.
        // 使用其他方式代替字符串去重
        public int Try2(int[][] graph)
        {
            int len = graph.Length;

            if (len < 2) return 0;

            Stack<(int curr, string visited)> stack = new Stack<(int curr, string visited)>(), next = new Stack<(int curr, string visited)>();

            ISet<(int curr, string visited)> visited = new HashSet<(int curr, string visited)>();

            char[] chars = new char[len];
            Array.Fill(chars, '0');

            for (int i = 0; i < len; i++)
            {
                chars[i] = '1';
                stack.Push((i, new string(chars)));
                chars[i] = '0';
            }

            Array.Fill(chars, '1');

            string target = new string(chars);

            int res = 1;
            BfsHelper.Bfs(stack, next, () =>
            {
                res++;
            }, (next, curr) =>
            {

                var join = graph[curr.curr];

                char[] vs = curr.visited.ToCharArray();

                foreach (var item in join)
                {
                    var old = vs[item];
                    vs[item] = '1';
                    var newItem = (item, new string(vs));
                    if (visited.Add(newItem))
                    {
                        if (newItem.Item2 == target)
                            return true;
                        next.Push(newItem);
                    }
                    vs[item] = old;
                }

                return false;
            });
            return res;
        }

        // bug ,使用二进制作为去重依据==> 使用有误
        public int Try(int[][] graph)
        {
            int len = graph.Length;

            if (len < 2) return 0;

            Stack<(int curr, int visited)> stack = new Stack<(int curr, int visited)>(), next = new Stack<(int curr, int visited)>();

            ISet<(int curr, int visited)> visited = new HashSet<(int curr, int visited)>();

            int target = 0;

            for (int i = 0; i < len; i++)
            {
                target += (1 << i);
                stack.Push((i, 1 << i));
            }

            int res = 1;
            BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
            {

                var join = graph[curr.curr];

                foreach (var item in join)
                {
                    var newItem = (item, curr.visited + 1 << item);
                    if (visited.Add(newItem))
                    {
                        if (newItem.Item2 == target) return true;
                        next.Push(newItem);
                    }
                }

                return false;
            });
            return res;
        }

    }
}
