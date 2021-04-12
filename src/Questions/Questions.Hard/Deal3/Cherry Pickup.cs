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
    /// @since : 4/8/2021 2:40:06 PM
    /// @source : https://leetcode.com/problems/cherry-pickup/solution/
    /// @des : 
    ///     给你一个n × n的网格，代表一个樱桃场，每个细胞是三种可能的整数之一。
    ///     0表示单元格是空的，所以你可以通过，
    ///     1表示细胞中含有一颗樱桃，你可以捡起并穿过，或者
    ///     -1表示细胞中有一根刺挡住你的路。
    ///     按照以下规则返回你可以收集到的最大樱桃数量:
    ///     从位置(0,0)开始，通过右或向下移动有效路径单元格(值为0或1的单元格)到达(n - 1, n - 1)。
    ///     到达(n - 1, n - 1)后，通过向左或向上移动有效路径单元格返回(0,0)。
    ///     当你穿过一个含有樱桃的路径细胞时，你捡起它，这个细胞就变成了一个空细胞0。
    ///     如果在(0,0)和(n - 1, n - 1)之间没有有效路径，则不能收集樱桃。

    /// </summary>
    [Obsolete("bug|slow")]
    [Favorite(FlagConst.DP)]
    public class Cherry_Pickup
    {

        // n == grid.length
        // n == grid[i].length
        //1 <= n <= 50
        //grid[i][j] is -1, 0, or 1.
        //grid[0][0] != -1
        //grid[n - 1][n - 1] != -1

        #region other solution

        // source:https://www.cnblogs.com/grandyang/p/8215787.html
        // https://leetcode.com/problems/cherry-pickup/discuss/109903/step-by-step-guidance-of-the-on3-time-and-on2-space-solution
        // 太强了...,能想出来也是神奇，理解都不好理解...
        public int OtherSolution(int[][] grid)
        {
            int n = grid.Length, max = 2 * n - 1;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], -1);
            }

            // dp[i][p] = 能获取的最大值
            dp[0][0] = grid[0][0];

            // 复用的关键: k递增
            for (int k = 1; k < max; k++) // k即步数，从(0,0)到(n-1,n-1) 最多需要2 * n - 2 步
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    for (int p = n - 1; p >= 0; p--)
                    {
                        // k = i + j = p + q
                        // 合理==>每次移动都是 i++ 或者 j++  故步数= i+j
                        int j = k - i, q = k - p;
                        // 若index out or point = -1  即此点在此步数无法到达
                        if (j < 0 || j >= n || q < 0 || q >= n || grid[i][j] < 0 || grid[p][q] < 0)
                        {
                            dp[i][p] = -1;
                            continue;
                        }
                        /*
                         * 
                        (i, j) 即go所到达的终点
                        (p, q) 即回来的起点
                        Case 1: (0, 0) ==> (i-1, j) ==> (i, j); (p, q) ==> (p-1, q) ==> (0, 0)
                        Case 2: (0, 0) ==> (i-1, j) ==> (i, j); (p, q) ==> (p, q-1) ==> (0, 0)
                        Case 3: (0, 0) ==> (i, j-1) ==> (i, j); (p, q) ==> (p-1, q) ==> (0, 0)
                        Case 4: (0, 0) ==> (i, j-1) ==> (i, j); (p, q) ==> (p, q-1) ==> (0, 0)

                        Case 1 is equivalent to T(i-1, j, p-1, q) + grid[i][j] + grid[p][q];
                        Case 2 is equivalent to T(i-1, j, p, q-1) + grid[i][j] + grid[p][q];
                        Case 3 is equivalent to T(i, j-1, p-1, q) + grid[i][j] + grid[p][q];
                        Case 4 is equivalent to T(i, j-1, p, q-1) + grid[i][j] + grid[p][q];

                        T(i, j, p, q) = grid[i][j] + grid[p][q] + max{T(i-1, j, p-1, q), T(i-1, j, p, q-1), T(i, j-1, p-1, q), T(i, j-1, p, q-1)}

                         * 
                         */
                        // i > 0 dp[i-1][p] ==> 由于i,p递减，故i-1 or p-1 获取的都是k-1 即上一步的值
                        // dp[i][p] = i,j-1 p,q-1 =  T(i, j-1, p, q-1)

                        // i - 1,j
                        // dp[i - 1][p] = T(i-1, j, p, q-1)
                        if (i > 0) dp[i][p] = Math.Max(dp[i][p], dp[i - 1][p]);

                        // i,j-1 p -1
                        // dp[i][p - 1] = T(i, j-1, p-1, q)
                        if (p > 0) dp[i][p] = Math.Max(dp[i][p], dp[i][p - 1]);

                        // i - 1,j p-1,q
                        // dp[i - 1][p - 1] = T(i-1, j, p-1, q)
                        if (i > 0 && p > 0) dp[i][p] = Math.Max(dp[i][p], dp[i - 1][p - 1]);

                        // 若可移动， + grid[i][j] + grid[p][q](i != p[防止重复计算]), 由于步数原因，grid[i][j] 、 grid[p][q] 是上一步无法访问的点，故无需考虑去重
                        //  grid[i][j] + grid[p][q]
                        if (dp[i][p] >= 0) dp[i][p] += grid[i][j] + (i != p ? grid[p][q] : 0);
                    }
                }
            }
            return Math.Max(dp[n - 1][n - 1], 0);

        }

        #endregion


        // 明显的动态规划，不做浪费
        // 有坑 wc...

        struct Item
        {
            public int Count { get; set; }
            public List<(int y, int x)> visited { get; set; }
        }

        // slow ==> 如何快速合并数据
        // 淘汰 ==> 即便快速合并，需要遍历的次数也非常大...
        public int Try5(int[][] grid)
        {
            /*
             * think:
             *      记录下每条从(0,0) 到 (n-1,n-1)的路径，保存每条路径上的樱桃
             * 最终，将路径进行两两组合，去除路径上的樱桃再获取总数，从而取得最大值
             */

            int n = grid.Length;

            HashSet<string>[][] dp = new HashSet<string>[n + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new HashSet<string>[n + 1];
            }

            if (grid[n - 1][n - 1] == 1)
            {
                dp[n - 1][n - 1] = new HashSet<string>() { $"({n - 1},{n - 1})" };
            }
            else
            {
                dp[n - 1][n - 1] = new HashSet<string>();
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == n - 1 && j == n - 1) continue;
                    var curr = grid[i][j];
                    if (curr == -1) continue;
                    HashSet<string> down = dp[i + 1][j], right = dp[i][j + 1];
                    if (down == null && right == null) continue;
                    if (curr == 0)
                    {
                        if (down == null) dp[i][j] = right;
                        else if (right == null) dp[i][j] = down;
                        else
                        {
                            HashSet<string> currItem = new HashSet<string>();
                            foreach (var item in right)
                            {
                                currItem.Add(item);
                            }
                            foreach (var item in down)
                            {
                                currItem.Add(item);
                            }
                            dp[i][j] = currItem;
                        }
                    }
                    else if (curr == 1)
                    {
                        HashSet<string> currItem = new HashSet<string>();
                        if (down != null)
                        {
                            foreach (var item in down)
                            {
                                currItem.Add(item + $",({i},{j})");
                            }
                        }
                        if (right != null)
                        {
                            foreach (var item in right)
                            {
                                currItem.Add(item + $",({i},{j})");
                            }
                        }
                        if (currItem.Count == 0)
                        {
                            currItem.Add($"({i},{j})");
                        }
                        dp[i][j] = currItem;
                    }
                }
            }

            var roadArr = dp[0][0];
            if (roadArr == null) return 0;

            if (roadArr.Count == 1)
            {
                return roadArr.First().Split(',').Length;
            }

            int max = 0;

            foreach (var item in roadArr)
            {
                foreach (var other in roadArr)
                {
                    if (item == other) continue;

                    var count = new[] { item.Split(',').ToArray(), item.Split(',').ToArray() }.SelectMany(u => u).Distinct().Count();
                    max = Math.Max(max, count);

                }
            }

            return max;

        }

        public int Try4(int[][] grid)
        {
            int n = grid.Length;

            Try4Item[][] dp = new Try4Item[n + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new Try4Item[n + 1];
            }

            if (grid[n - 1][n - 1] == 1)
            {
                dp[n - 1][n - 1] = new Try4Item
                {
                    RoadArr = new List<ISet<(int y, int x)>>()
                    {
                        new HashSet<(int y, int x)>(){ (n-1,n-1) }
                    }
                };
            }
            else
            {
                dp[n - 1][n - 1] = new Try4Item
                {
                    RoadArr = new List<ISet<(int y, int x)>>() {
                        new HashSet<(int y, int x)>()
                    }
                };
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == n - 1 && j == n - 1) continue;
                    var curr = grid[i][j];
                    if (curr == -1) continue;
                    Try4Item down = dp[i + 1][j], right = dp[i][j + 1];
                    if (down == null && right == null) continue;
                    if (curr == 0)
                    {
                        if (down == null) dp[i][j] = right;
                        else if (right == null) dp[i][j] = down;
                        else
                        {
                            IList<ISet<(int y, int x)>> currItem = new List<ISet<(int y, int x)>>();
                            foreach (var item in right.RoadArr)
                            {
                                currItem.Add(item);
                            }
                            foreach (var item in down.RoadArr)
                            {
                                currItem.Add(item);
                            }
                            dp[i][j] = new Try4Item { RoadArr = currItem };
                        }
                    }
                    else if (curr == 1)
                    {
                        var newItem = (i, j);
                        IList<ISet<(int y, int x)>> currItem = new List<ISet<(int y, int x)>>();
                        if (down != null)
                        {
                            foreach (var item in down.RoadArr)
                            {
                                var copy = new HashSet<(int y, int x)>(item);
                                copy.Add(newItem);
                                currItem.Add(copy);
                            }
                        }
                        if (right != null)
                        {
                            foreach (var item in right.RoadArr)
                            {
                                var copy = new HashSet<(int y, int x)>(item);
                                copy.Add(newItem);
                                currItem.Add(copy);
                            }
                        }
                        if (currItem.Count == 0)
                        {
                            currItem.Add(new HashSet<(int y, int x)>() { newItem });
                        }
                        dp[i][j] = new Cherry_Pickup.Try4Item()
                        {
                            RoadArr = currItem
                        };
                    }
                }
            }

            if (dp[0][0] == null) return 0;

            var roadArr = dp[0][0].RoadArr;

            int max = 0;

            for (int i = 0; i < roadArr.Count; i++)
            {
                var own = roadArr[i];
                max = Math.Max(max, own.Count);
                for (int j = 0; j < roadArr.Count; j++)
                {
                    var other = roadArr[j];
                    if (i == j) continue;
                    int count = new[] { own, other }.SelectMany(u => u).Distinct().Count();
                    max = Math.Max(max, count);
                }
            }

            return max;

        }

        class Try4Item
        {
            public IList<ISet<(int y, int x)>> RoadArr { get; set; }
        }

        // bug... go影响着back.
        public int Try3(int[][] grid)
        {
            int n = grid.Length;

            DpItem[][] goItems = HelpGo();

            if (goItems[0][0] == null) return 0;

            DpItem[][] backItems = HelpBack();

            List<(int y, int x)> onePoint = new List<(int y, int x)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && goItems[i][j] != null && backItems[i][j] != null) onePoint.Add((i, j));
                }
            }

            int max = 0;
            for (int i = 0; i < onePoint.Count; i++)
            {
                var item = onePoint[i];
                DpItem go = goItems[item.y][item.x], back = backItems[item.y][item.x];

                max = Math.Max(go.Count + back.Count - 1, max);

                for (int j = 0; j < onePoint.Count; j++)
                {
                    if (i == j) continue;
                    var other = onePoint[j];
                    DpItem goOther = goItems[other.y][other.x], backOther = backItems[other.y][other.x];

                    int count = new[] { go, back, goOther, backOther }.SelectMany(u => u.visited).Distinct().Count();
                    max = Math.Max(max, count);

                }
            }

            return max;

            DpItem[][] HelpGo()
            {

                DpItem[][] dp = new DpItem[n][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new DpItem[n];
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        var curr = grid[i][j];
                        if (curr == -1) continue;
                        if (i == n - 1 && j == n - 1)
                        {
                            if (curr == 1)
                            {
                                dp[i][j] = new DpItem { Count = 1, visited = new HashSet<(int y, int x)>() { (i, j) } };
                            }
                            else if (curr == 0)
                            {
                                dp[i][j] = new DpItem { Count = 0, visited = new HashSet<(int y, int x)>() };
                            }
                        }
                        else if (i == n - 1)
                        {
                            var right = dp[i][j + 1];
                            if (right == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = right;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new DpItem() { Count = 1 + right.Count, visited = new HashSet<(int y, int x)>(right.visited) { (i, j) } };
                            }
                        }
                        else if (j == n - 1)
                        {
                            var down = dp[i + 1][j];
                            if (down == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = down;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new DpItem() { Count = 1 + down.Count, visited = new HashSet<(int y, int x)>(down.visited) { (i, j) } };
                            }
                        }
                        else
                        {
                            var right = dp[i][j + 1];
                            var down = dp[i + 1][j];
                            if (down == null && right == null) continue;

                            DpItem maxItem;
                            if (right == null) maxItem = down;
                            else if (down == null) maxItem = right;
                            else
                            {
                                if (right.Count > down.Count) maxItem = right;
                                else maxItem = down;
                            }

                            if (curr == 0)
                            {
                                dp[i][j] = maxItem;
                            }
                            else
                                dp[i][j] = new DpItem() { Count = 1 + maxItem.Count, visited = new HashSet<(int y, int x)>(maxItem.visited) { (i, j) } };

                        }
                    }
                }

                return dp;

            }

            DpItem[][] HelpBack()
            {

                DpItem[][] dp = new DpItem[n][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new DpItem[n];
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var curr = grid[i][j];
                        if (curr == -1) continue;
                        if (i == 0 && j == 0)
                        {
                            if (curr == 1)
                            {
                                dp[i][j] = new DpItem { Count = 1, visited = new HashSet<(int y, int x)>() { (i, j) } };
                            }
                            else if (curr == 0)
                            {
                                dp[i][j] = new DpItem { Count = 0, visited = new HashSet<(int y, int x)>() };
                            }
                        }
                        else if (i == 0)
                        {
                            var left = dp[i][j - 1];
                            if (left == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = left;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new DpItem() { Count = 1 + left.Count, visited = new HashSet<(int y, int x)>(left.visited) { (i, j) } };
                            }
                        }
                        else if (j == 0)
                        {
                            var up = dp[i - 1][j];
                            if (up == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = up;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new DpItem() { Count = 1 + up.Count, visited = new HashSet<(int y, int x)>(up.visited) { (i, j) } };
                            }
                        }
                        else
                        {
                            var left = dp[i][j - 1];
                            var up = dp[i - 1][j];
                            if (up == null && left == null) continue;

                            DpItem maxItem;
                            if (left == null) maxItem = up;
                            else if (up == null) maxItem = left;
                            else
                            {
                                if (left.Count > up.Count) maxItem = left;
                                else maxItem = up;
                            }

                            if (curr == 0)
                            {
                                dp[i][j] = maxItem;
                            }
                            else
                                dp[i][j] = new DpItem() { Count = 1 + maxItem.Count, visited = new HashSet<(int y, int x)>(maxItem.visited) { (i, j) } };

                        }
                    }
                }

                return dp;

            }

        }

        class DpItem
        {
            public int Count { get; set; }
            public ISet<(int y, int x)> visited { get; set; }
        }
        // bug
        public int Try2(int[][] grid)
        {
            int n = grid.Length;

            GoItem goItem = HelpGo();

            if (goItem == null) return 0;

            foreach (var item in goItem.visited)
            {
                grid[item.y][item.x] = 0;
            }

            return goItem.Count + HelpBack();

            GoItem HelpGo()
            {

                GoItem[][] dp = new GoItem[n][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new GoItem[n];
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        var curr = grid[i][j];
                        if (curr == -1) continue;
                        if (i == n - 1 && j == n - 1)
                        {
                            if (curr == 1)
                            {
                                dp[i][j] = new GoItem { Count = 1, visited = new List<(int y, int x)>() { (i, j) } };
                            }
                            else if (curr == 0)
                            {
                                dp[i][j] = new GoItem { Count = 0, visited = new List<(int y, int x)>() };
                            }
                        }
                        else if (i == n - 1)
                        {
                            var right = dp[i][j + 1];
                            if (right == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = right;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new GoItem() { Count = 1 + right.Count, visited = new List<(int y, int x)>(right.visited) { (i, j) } };
                            }
                        }
                        else if (j == n - 1)
                        {
                            var down = dp[i + 1][j];
                            if (down == null) continue;
                            if (curr == 0)
                            {
                                dp[i][j] = down;
                            }
                            else if (curr == 1)
                            {
                                dp[i][j] = new GoItem() { Count = 1 + down.Count, visited = new List<(int y, int x)>(down.visited) { (i, j) } };
                            }
                        }
                        else
                        {
                            var right = dp[i][j + 1];
                            var down = dp[i + 1][j];
                            if (down == null && right == null) continue;

                            GoItem maxItem;
                            if (right == null) maxItem = down;
                            else if (down == null) maxItem = right;
                            else
                            {
                                if (right.Count > down.Count) maxItem = right;
                                else maxItem = down;
                            }

                            if (curr == 0)
                            {
                                dp[i][j] = maxItem;
                            }
                            else
                                dp[i][j] = new GoItem() { Count = 1 + maxItem.Count, visited = new List<(int y, int x)>(maxItem.visited) { (i, j) } };

                        }
                    }
                }

                return dp[0][0];

            }

            int HelpBack()
            {
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new int[n + 1];
                }

                for (int i = 2; i < n + 1; i++)
                {
                    dp[0][i] = int.MinValue;
                    dp[i][0] = int.MinValue;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var curr = grid[i][j];
                        if (curr == -1)
                        {
                            dp[i + 1][j + 1] = int.MinValue;
                        }
                        else if (curr == 0)
                        {
                            dp[i + 1][j + 1] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
                        }
                        else
                        {
                            dp[i + 1][j + 1] = 1 + Math.Max(dp[i][j + 1], dp[i + 1][j]);
                        }
                    }
                }
                return dp[n][n];
            }

        }

        class GoItem
        {
            public int Count { get; set; }
            public List<(int y, int x)> visited { get; set; }
        }

        public int Try(int[][] grid)
        {
            int n = grid.Length;

            Item[][] dp = new Item[n + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new Item[n + 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    var curr = grid[i][j];
                    var down = dp[i + 1][j];
                    var right = dp[i][j + 1];
                    Item currItem;
                    if (curr == -1)
                    {
                        dp[i][j] = new Item { Count = int.MinValue };
                        continue;
                    }
                    if (down.Count > right.Count)
                    {
                        currItem = down;
                    }
                    else
                    {
                        currItem = right;
                    }
                    if (curr == 1)
                    {
                        if (currItem.Count >= 0)
                        {
                            var old = currItem;
                            currItem = new Item { Count = 1 + old.Count, visited = new List<(int y, int x)>() { (i, j) } };
                            if (old.visited != null)
                            {
                                currItem.visited.AddRange(old.visited);
                            }
                        }
                    }
                    dp[i][j] = currItem;
                }
            }

            var res = dp[0][0];
            if (res.Count < 0) return 0;

            int v = Simple(grid);

            foreach (var item in dp[0][0].visited)
            {
                grid[item.y][item.x] = 0;
            }

            return res.Count + Help();

            int Help()
            {
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new int[n + 1];
                }

                for (int i = 2; i < n + 1; i++)
                {
                    dp[0][i] = int.MinValue;
                    dp[i][0] = int.MinValue;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var curr = grid[i][j];
                        if (curr == -1)
                        {
                            dp[i + 1][j + 1] = int.MinValue;
                        }
                        else if (curr == 0)
                        {
                            dp[i + 1][j + 1] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
                        }
                        else
                        {
                            dp[i + 1][j + 1] = 1 + Math.Max(dp[i][j + 1], dp[i + 1][j]);
                        }
                    }
                }
                return dp[n][n];
            }

        }

        public int Think(int[][] grid)
        {
            int n = grid.Length;

            int[][] dp = new int[n + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    var curr = grid[i][j];
                    if (curr == -1)
                    {
                        dp[i][j] = int.MinValue;
                    }
                    else if (curr == 0)
                    {
                        dp[i][j] = Math.Max(dp[i + 1][j], dp[i][j + 1]);
                    }
                    else
                    {
                        dp[i][j] = 1 + Math.Max(dp[i + 1][j], dp[i][j + 1]);
                    }
                }
            }
            return dp[0][0];
        }

        public int Simple(int[][] grid)
        {
            int n = grid.Length;

            return HelpGo(0, 0, 0);

            int HelpGo(int i, int j, int count)
            {
                if (i == n || j == n) return 0;
                var curr = grid[i][j];
                if (curr == -1) return 0;
                if (i == n - 1 && j == n - 1) return HelpBack(i, j, count + curr);
                else
                {
                    grid[i][j] = 0;
                    var res = Math.Max(HelpGo(i + 1, j, count + curr), HelpGo(i, j + 1, count + curr));
                    grid[i][j] = curr;
                    return res;
                }

            }

            int HelpBack(int i, int j, int count)
            {
                if (i == -1 || j == -1) return 0;
                var curr = grid[i][j];
                if (curr == -1) return 0;
                if (i == 0 && j == 0) return count + curr;
                else
                {
                    return Math.Max(HelpGo(i - 1, j, count + curr), HelpGo(i, j - 1, count + curr));
                }
            }
        }

    }
}
