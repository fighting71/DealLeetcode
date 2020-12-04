using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 4:17:50 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/568/week-5-november-29th-november-30th/3549/
    /// @des : 
    /// </summary>
    [Optimize(FlagConst.Complex)]
    public class The_Skyline_Problem
    {
        private IList<IList<int>> Thinking(int[][] buildings)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (buildings.Length == 0) return res;

            int[] curr = buildings[0];

            res.Add(new[] { curr[0], curr[2] });

            for (int i = 1; i < buildings.Length; i++)
            {
                var next = buildings[i];

                /*
                 * |￣|
                 * |￣|￣|
                 */
                if (next[0] == curr[0])
                {

                }
                else if (next[0] >= curr[1]) // _|￣|_|￣|_
                {
                }
                /*
                 *
                 *                      |￣|                   |￣￣￣￣|
                 *     |￣|          |￣    ￣|            |￣￣|￣|    |
                 *  |￣   |￣|    |￣         |￣|_|￣|  |￣        ￣| |
                 */
                else if (next[1] <= curr[1])
                {

                }
                /*
                 *                                 |￣￣￣|
                 *                              |￣|      |
                 *    |￣￣|    |￣￣|      |￣￣|￣|￣￣￣￣|￣|
                 * |￣ ￣| |    | |￣￣|    |    |  |          |
                 */
                else
                {

                }
            }

            return res;

        }

        #region optimize

        public IList<IList<int>> Optimize(int[][] buildings)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (buildings.Length == 0) return res;

            LinkedList<int[]> link = new LinkedList<int[]>(buildings);

            int[] curr = link.First();
            link.RemoveFirst();
            while (link.Count > 0)
            {
                int[] next = link.First();
                link.RemoveFirst();
                curr = Help(curr, next, res, link);
            }
            return res;
        }

        private int[] Help(int[] curr, int[] next, IList<IList<int>> res, LinkedList<int[]> list)
        {
            if (next[0] == curr[1])
            {
                if (next[2] != curr[2])
                    AddItem(new[] { next[0], next[2] }, res);
                curr = next;
            }
            if (next[0] > curr[1])
            {
                AddItem(new[] { curr[1], 0 }, res);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr[0] = next[1];
                AddOne(list, curr);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else
            {
                if (next[2] > curr[2])
                {
                    AddItem(new[] { next[0], next[2] }, res);
                    curr = next;
                }
                else if (next[2] == curr[2])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                }
                else
                {
                    AddOne(list, new[] { curr[1], next[1], next[2] });
                }
            }
            return curr;
        }

        private void AddOne(LinkedList<int[]> list, int[] item)
        {
            if (list.Count == 0 || list.Last.Value[0] < item[0]) list.AddLast(item);
            var node = list.First;
            while (node != null && node.Value[0] <= item[0])
            {
                node = node.Next;
            }
            list.AddBefore(node, item);
        }

        #endregion

        #region try3

        private class SortList : IComparer<int[]>
        {
            public int Compare([AllowNull] int[] x, [AllowNull] int[] y)
            {
                return x[0] - y[0];
            }
        }

        // Your runtime beats 17.44 % of csharp submissions. 
        // 泪了泪了...
        public IList<IList<int>> Try3(int[][] buildings)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (buildings.Length == 0) return res;
            int[] curr = buildings[0], next;
            res.Add(new[] { curr[0], curr[2] });

            List<int[]> list = buildings.ToList();

            while (list.Count > 0)
            {
                next = list[0];
                list.RemoveAt(0);
                curr = Help(curr, next, res, list);
            }
            res.Add(new[] { curr[1], 0 });
            return res;
        }

        private int[] Help(int[] curr, int[] next, IList<IList<int>> res, List<int[]> list)
        {
            if (next[0] == curr[1])
            {
                if (next[2] != curr[2])
                    AddItem(new[] { next[0], next[2] }, res);
                curr = next;
            }
            if (next[0] > curr[1])
            {
                AddItem(new[] { curr[1], 0 }, res);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr[0] = next[1];
                AddOne(list, curr);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else
            {
                if (next[2] > curr[2])
                {
                    AddItem(new[] { next[0], next[2] }, res);
                    curr = next;
                }
                else if (next[2] == curr[2])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                }
                else
                {
                    AddOne(list, new[] { curr[1], next[1], next[2] });
                }
            }
            return curr;
        }

        private void AddOne(List<int[]> list, int[] item)
        {
            int i = 0;
            while (i < list.Count)
            {
                if (list[i][0] > item[0])
                {
                    list.Insert(i, item);
                    return;
                }
                i++;
            }
            list.Add(item);
        }

        // bug : SortedSet 可能存在值不同但key相同 导致添加不进去...?
        private int[] Help(int[] curr, int[] next, IList<IList<int>> res, SortedSet<int[]> set)
        {
            if (next[0] == curr[1])
            {
                if (next[2] != curr[2])
                    AddItem(new[] { next[0], next[2] }, res);
                curr = next;
            }
            if (next[0] > curr[1])
            {
                AddItem(new[] { curr[1], 0 }, res);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr[0] = next[1];
                set.Add(curr);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else
            {
                if (next[2] > curr[2])
                {
                    AddItem(new[] { next[0], next[2] }, res);
                    curr = next;
                }
                else if (next[2] == curr[2])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                }
                else
                {
                    set.Add(new[] { curr[1], next[1], next[2] });
                }
            }
            return curr;
        }
        #endregion

        #region bug solution

        public IList<IList<int>> Try(int[][] buildings)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int[] curr = buildings[0], next;
            res.Add(new[] { curr[0], curr[2] });

            Stack<int[]> stack = new Stack<int[]>();

            for (int index = 1; index < buildings.Length; index++)
            {
                next = buildings[index];
                if (stack.Count > 0)
                {
                    int[] cache = stack.Peek();

                    if (cache[0] < next[0] || (cache[0] == next[0] && cache[1] < next[1]))
                    {
                        stack.Pop();
                        next = cache;
                        index--;
                    }
                }

                curr = Help(curr, next, res, stack);
            }

            while (stack.Count > 0)
            {
                next = stack.Pop();
                curr = Help(curr, next, res, stack);
            }

            res.Add(new[] { curr[1], 0 });
            return res;
        }
        public IList<IList<int>> Try2(int[][] buildings)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (buildings.Length == 0) return res;
            int[] curr = buildings[0], next;
            res.Add(new[] { curr[0], curr[2] });

            Queue<int[]> queue = new Queue<int[]>();

            for (int index = 1; index < buildings.Length; index++)
            {
                next = buildings[index];
                if (queue.Count > 0)
                {
                    int[] cache = queue.Peek();

                    if (cache[0] < next[0] || (cache[0] == next[0] && cache[1] < next[1]))
                    {
                        queue.Dequeue();
                        next = cache;
                        index--;
                    }
                }

                curr = Help(curr, next, res, queue);
            }

            while (queue.Count > 0)
            {
                next = queue.Dequeue();
                curr = Help(curr, next, res, queue);
            }

            res.Add(new[] { curr[1], 0 });
            return res;
        }

        /*  
         *                            |￣￣￣￣￣￣￣|
         *                            |             |
         * |￣￣￣￣￣￣￣￣￣￣￣￣￣￣|￣￣|         |
         * |                  |￣￣￣￣|￣￣|        |
         * |                  |       |    |        |
         * 
         * 
         */

        private int[] BugHelp(int[] curr, int[] next, IList<IList<int>> res, Stack<int[]> stack)
        {
            if (next[0] >= curr[1])
            {
                res.Add(new[] { curr[1], 0 });
                curr = next;
                res.Add(new[] { curr[0], curr[2] });
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                curr = next;
                res.Add(new[] { curr[0], curr[2] });
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                curr[0] = next[1];
                stack.Push(curr);
                curr = next;
                res.Add(new[] { curr[0], curr[2] });
            }
            else
            {
                if (next[2] > curr[2])
                {
                    if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                    res.Add(new[] { next[0], next[2] });
                }
                else
                {
                    res.Add(new[] { curr[1], next[2] });
                }
                curr = next;
            }
            return curr;
        }

        /*
         * bug case:
         * [[0,10,15],[0,10,22],[0,16,26],[0,19,22],[0,9,5],[0,7,8],[0,16,21],[0,17,3],[0,10,2],[0,7,22],[1,12,12],[1,5,20],[1,10,22],[1,5,19],[1,12,4],[1,10,26],[2,13,13],[2,3,30],[2,21,16],[2,20,8],[2,3,5],[2,17,16],[2,19,15],[2,2,6],[3,12,11],[3,5,10],[3,6,4],[3,9,15],[3,16,9],[4,22,21],[4,15,15],[4,7,24],[4,13,18],[4,11,22],[4,4,17],[5,19,9],[5,19,14],[5,5,25],[5,7,1],[5,16,23],[5,13,26],[6,24,3],[6,17,12],[6,7,27],[6,19,13],[6,12,20],[6,10,4],[6,21,17],[7,9,22],[7,13,16],[7,19,27],[7,9,1],[8,19,28],[8,8,14],[8,19,9],[8,12,5],[8,21,19],[8,20,23],[8,8,28],[9,13,16],[9,9,9],[9,19,21],[9,13,1],[10,22,11],[10,12,25],[10,19,7],[10,11,23],[10,19,19],[10,16,9],[10,20,10],[11,17,4],[13,32,28],[13,23,17],[13,23,15],[14,17,3],[14,28,29],[14,16,21],[15,23,25],[15,32,14],[15,25,4],[15,25,24],[16,21,30],[16,16,25],[16,17,7],[16,22,6],[17,24,19],[17,32,15],[17,18,30],[17,31,14],[17,23,28],[18,24,13],[18,32,29],[18,26,28],[18,21,26],[18,22,23],[18,30,19],[18,32,2],[19,19,27],[19,29,18],[19,23,23]]
         * 
         * [[0,26],[2,30],[3,26],[6,27],[7,27],[8,28],[14,29],[16,30],[21,29],[32,0]]
         * 
         * [[0,26],[2,30],[3,15],[4,24],[5,25],[5,26],[6,27],[7,27],[8,28],[14,29],[16,30],[21,23],[23,18],[29,2],[21,19],[30,2],[21,23],[22,2],[21,28],[26,2],[21,29],[32,0]]
         * 
         */

        // stack特性导致-》不连续
        private int[] Help(int[] curr, int[] next, IList<IList<int>> res, Stack<int[]> stack)
        {
            if (next[0] == curr[1])
            {
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            if (next[0] > curr[1])
            {
                AddItem(new[] { curr[1], 0 }, res);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                curr[0] = next[1];
                stack.Push(curr);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else
            {
                if (next[2] > curr[2])
                {
                    if (next[0] == curr[0]) res.RemoveAt(res.Count - 1);
                    AddItem(new[] { next[0], next[2] }, res);
                    curr = next;
                }
                else if (next[2] == curr[2])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                }
                else
                {
                    stack.Push(new[] { curr[1], next[1], next[2] });
                }
            }
            return curr;
        }
        // queue依然存在不连续
        private int[] Help(int[] curr, int[] next, IList<IList<int>> res, Queue<int[]> queue)
        {
            if (next[0] == curr[1])
            {
                if (next[2] != curr[2])
                    AddItem(new[] { next[0], next[2] }, res);
                curr = next;
            }
            if (next[0] > curr[1])
            {
                AddItem(new[] { curr[1], 0 }, res);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] == curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else if (next[1] < curr[1])
            {
                if (next[2] <= curr[2]) return curr;
                curr[0] = next[1];
                queue.Enqueue(curr);
                curr = next;
                AddItem(new[] { curr[0], curr[2] }, res);
            }
            else
            {
                if (next[2] > curr[2])
                {
                    AddItem(new[] { next[0], next[2] }, res);
                    curr = next;
                }
                else if (next[2] == curr[2])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                }
                else
                {
                    queue.Enqueue(new[] { curr[1], next[1], next[2] });
                }
            }
            return curr;
        }
        #endregion

        #region help method

        private void AddItem(int[] item, IList<IList<int>> res)
        {
            while (res.Count > 0)
            {
                var last = res[res.Count - 1];

                if (last[0] > item[0]) res.RemoveAt(res.Count - 1);
                else if (last[0] == item[0])
                {
                    last[1] = Math.Max(last[1], item[1]);
                    return;
                }
                else break;
            }
            res.Add(item);
        }

        #endregion

        public class Tools
        {
            // 无效方法... pass~
            public void Check(int[][] buildings, IList<IList<int>> res)
            {
                int right = buildings.Max(u => u[1]), height = buildings.Max(u => u[2]);

                bool[][] points = new bool[right + 1][];
                for (int i = 0; i < right + 1; i++)
                {
                    points[i] = new bool[height + 1];
                }

                foreach (var item in buildings)
                {
                    for (int i = item[0]; i <= item[1]; i++)
                    {
                        points[i][item[2]] = true;
                    }
                    for (int i = 0; i < item[2]; i++)
                    {
                        points[item[0]][i] = points[item[1]][i] = true;
                    }
                }
                int index = 0;
                int prev = 0;
                for (int i = 0; i <= right; i++)
                {
                    i = 3;
                    if (!points[i][0]) continue;

                    for (int j = height; j > 0; j--)
                    {
                        if(points[i][j])
                        {
                            if (prev != j)
                            {
                                if(!(res[index][0] == i && res[index][1] == j))
                                {
                                    Console.WriteLine("exists bug");
                                    ShowImage(points, height, right);
                                    return;
                                }
                                prev = j;
                                index++;
                            }
                            break;
                        }
                    }
                }

            }
            public void ShowImage(int[][] buildings)
            {
                int right = buildings.Max(u => u[1]), height = buildings.Max(u => u[2]);

                bool[][] points = new bool[right + 1][];
                for (int i = 0; i < right + 1; i++)
                {
                    points[i] = new bool[height + 1];
                }

                foreach (var item in buildings)
                {
                    for (int i = item[0]; i <= item[1]; i++)
                    {
                        points[i][item[2]] = true;
                    }
                    for (int i = 0; i < item[2]; i++)
                    {
                        points[item[0]][i] = points[item[1]][i] = true;
                    }
                }

                ShowImage(points, height, right);

            }

            private void ShowImage(bool[][] points,int height,int right)
            {
                for (int i = height; i >= 0; i--)
                {
                    Console.Write($"i:{AutoFill(i)}---");
                    for (int x = 0; x <= right; x++)
                    {
                        if (points[x][i]) Console.Write(" . ");
                        else Console.Write("   ");
                    }
                    Console.WriteLine();
                }

                Console.Write("  y:----");
                for (int x = 0; x <= right; x++)
                {
                    Console.Write(AutoFill(x));
                }
                Console.WriteLine();
            }

            private string AutoFill(int num)
            {
                if (num >= 10) return " " + num;
                else return " " + num + " ";
            }

        }

    }
}
