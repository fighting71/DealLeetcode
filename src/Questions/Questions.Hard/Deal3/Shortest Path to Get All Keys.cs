using Command.Const;
using Command.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/2/2021 2:15:14 PM
    /// @source : https://leetcode.com/problems/shortest-path-to-get-all-keys/
    /// @des : 
    /// 
    ///     我们有一个二维的网格。“.”是一个空的细胞,“#”是一堵墙,“@”是起点,  ("a", "b", ...) are keys, and ("A", "B", ...) are locks.
    ///     我们从起点开始，每次移动都是在四个基本方向中的一个上走一个空间。我们不能走出网格，也不能撞墙。如果我们走过一把钥匙，我们就把它捡起来。除非我们有钥匙，否则无法通过锁。
    ///     对于一些1 <= K <= 6，在英语字母表的前K个字母中正好有一个小写字母和一个大写字母。这意味着每个锁对应一个键，每个键对应一个锁;而且，用来代表钥匙和锁的字母的选择顺序与英语字母表相同。
    ///     返回获得所有键的最低步数。如果不可能，则返回-1。
    /// 
    /// </summary>
    [Obsolete(FlagConst.Slow)]
    public class Shortest_Path_to_Get_All_Keys
    {

        // Note:

        //1 <= grid.length <= 30
        //1 <= grid[0].length <= 30
        //grid[i][j] contains only '.', '#', '@', 'a'-'f' and 'A'-'F'
        //The number of keys is in [1, 6].  Each key has a different letter and opens exactly one lock.

        // Runtime: 956 ms, faster than 5.88% of C# online submissions for Shortest Path to Get All Keys.
        // Memory Usage: 44.5 MB, less than 5.88% of C# online submissions for Shortest Path to Get All Keys.
        // 泪流雨下...
        public int Try(string[] grid)
        {

            Stack<Item> stack = new Stack<Item>(), next = new Stack<Item>();

            ISet<string> visited = new HashSet<string>();
            int rowCount = grid.Length, celCount = grid[0].Length;
            Item first = new Item();
            // find start
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    var s = grid[i];
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == '@')
                        {
                            first.Y = i;
                            first.X = j;
                        }
                        else if (s[j] >= 'a' && s[j] <= 'z')
                        {
                            first.LostKeyCount++;
                        }
                    }
                }
                stack.Push(first);
                visited.Add(first.ToString());
            }

            if (first.LostKeyCount == 0) return 0;

            int res = 1;
            var success = BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
            {

                return Help(curr.Y + 1, curr.X)
                || Help(curr.Y - 1, curr.X)
                || Help(curr.Y, curr.X + 1)
                || Help(curr.Y, curr.X - 1)
                ;

                bool Help(int y, int x)
                {
                    if (y == -1 || y == rowCount || x == -1 || x == celCount) return false;

                    char c = grid[y][x];
                    if (c == '#') return false;

                    bool[] keys = curr.Keys;
                    int lostKeyCount = curr.LostKeyCount;
                    if (c >= 'a' && c <= 'f')
                    {
                        keys = (bool[])curr.Keys.Clone();
                        ref var key = ref keys[c - 'a'];
                        if (!key)
                        {
                            lostKeyCount--;
                            if (lostKeyCount == 0) return true;
                            key = true;
                        }
                    }
                    else if (c >= 'A' && c <= 'F')
                    {
                        if (!curr.Keys[c - 'A']) return false;
                    }

                    var item = new Item() { LostKeyCount = lostKeyCount, Keys = keys, Y = y, X = x };

                    if (visited.Add(item.ToString()))
                    {
                        next.Push(item);
                    }

                    return false;
                }

            });

            return success ? res : -1;

        }

        public class Item
        {
            public int Y { get; set; }
            public int X { get; set; }
            public int LostKeyCount { get; set; }

            public bool[] Keys { get; set; } = new bool[6];

            public override string ToString()
            {
                var obj = this;
                StringBuilder build = new StringBuilder();
                build.Append(obj.Y);
                build.Append(',');
                build.Append(obj.X);
                build.Append(',');
                foreach (var item in obj.Keys)
                {
                    build.Append($",{item}");
                }

                return build.ToString();
            }
        }

        public class Try1
        {

            // bug => 获取开启所有锁的最小步骤...
            public int Try(string[] grid)
            {

                Stack<Item> stack = new Stack<Item>(), next = new Stack<Item>();

                ISet<string> visited = new HashSet<string>();
                int rowCount = grid.Length, celCount = grid[0].Length;
                Item first = new Item();
                // find start
                {
                    for (int i = 0; i < grid.Length; i++)
                    {
                        var s = grid[i];
                        for (int j = 0; j < s.Length; j++)
                        {
                            if (s[j] == '@')
                            {
                                first.Y = i;
                                first.X = j;
                            }
                            else if (s[j] >= 'A' && s[j] <= 'Z')
                            {
                                first.LockCount++;
                            }
                        }
                    }
                    stack.Push(first);
                    visited.Add(first.ToString());
                }

                if (first.LockCount == 0) return 0;

                int res = 1;
                var success = BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
                {

                    return Help(curr.Y + 1, curr.X)
                    || Help(curr.Y - 1, curr.X)
                    || Help(curr.Y, curr.X + 1)
                    || Help(curr.Y, curr.X - 1)
                    ;

                    bool Help(int y, int x)
                    {
                        if (y == -1 || y == rowCount || x == -1 || x == celCount) return false;

                        char c = grid[y][x];
                        if (c == '#') return false;

                        (bool hasKey, bool hasLock)[] com;
                        int lockCount = curr.LockCount;
                        if (c >= 'a' && c <= 'f')
                        {
                            com = ((bool hasKey, bool hasLock)[])curr.Combination.Clone();
                            ref (bool hasKey, bool hasLock) p = ref com[c - 'a'];

                            if (p.hasKey) return false;

                            p.hasKey = true;
                        }
                        else if (c >= 'A' && c <= 'F')
                        {
                            com = ((bool hasKey, bool hasLock)[])curr.Combination.Clone();
                            ref (bool hasKey, bool hasLock) p = ref com[c - 'A'];

                            if (!p.hasKey) return false;
                            if (p.hasLock) return false;

                            p.hasLock = true;
                            lockCount--;
                        }
                        else
                        {
                            com = curr.Combination;
                        }

                        var item = new Item() { Combination = com, LockCount = lockCount, Y = y, X = x };

                        if (visited.Add(item.ToString()))
                        {
                            next.Push(item);
                        }

                        return false;
                    }

                });

                return success ? res : -1;

            }

            public class Item
            {
                public int Y { get; set; }
                public int X { get; set; }
                public int LockCount { get; set; }

                public (bool hasKey, bool hasLock)[] Combination { get; set; } = new (bool hasKey, bool hasLock)[6];

                public override string ToString()
                {
                    var obj = this;
                    StringBuilder build = new StringBuilder();
                    build.Append(obj.Y);
                    build.Append(',');
                    build.Append(obj.X);
                    build.Append(',');
                    foreach (var item in obj.Combination)
                    {
                        build.Append($",{item.hasKey}-{item.hasLock}");
                    }

                    return build.ToString();
                }
            }

        }
    }
}
