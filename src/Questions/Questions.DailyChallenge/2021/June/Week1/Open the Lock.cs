using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/4/2021 4:29:27 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3767/
    /// @des : 
    ///     你面前有一把锁，上面有四个圆形的轮子。每个轮子有10个槽:“0”,“1”、“2”、“3”、“4”、“5”、“6”、“7”、“8”,“9”。轮子可以自由旋转和旋转:例如，我们可以将“9”变为“0”，或将“0”变为“9”。每一步都包括转动一个轮子和一个槽。
    ///     锁最初从“0000”开始，这是一个表示4个轮子状态的字符串。
    ///     你会得到一个死胡同的列表死胡同，意思是如果锁显示了这些代码中的任何一个，锁的轮子就会停止转动，你就无法打开它。
    ///     给定一个目标，代表将解锁的车轮值，返回打开锁所需的最小总轮数，如果不可能，则返回-1。
    /// </summary>
    [Serie(FlagConst.BFS)]
    public class Open_the_Lock
    {

        // Constraints:

        //1 <= deadends.length <= 500
        //deadends[i].length == 4
        //target.length == 4
        //target will not be in the list deadends.
        //target and deadends[i] consist of digits only.

        // Your runtime beats 92.25 % of csharp submissions.
        // 果不其然... cbdl
        public int Optimize(string[] deadends, string target)
        {

            int tar = int.Parse(target);

            if (tar == 0) return 0;

            HashSet<int> visited = deadends.Select(u => int.Parse(u)).ToHashSet();

            if (!visited.Add(0)) return -1;

            Stack<int> curr = new Stack<int>();
            Stack<int> next = new Stack<int>();

            curr.Push(0);
            int res = 1;
            while (curr.Count > 0)
            {
                while (curr.Count > 0)
                {
                    int num = curr.Pop();

                    int mod = 10000;
                    while (mod != 1)
                    {
                        int mul = mod / 10;
                        int slot = num % mod / mul;

                        var newSlot = (slot + 1) % 10;

                        var newLock = num - slot * mul + newSlot * mul;

                        if (visited.Add(newLock))
                        {
                            if (newLock == tar) return res;
                            next.Push(newLock);
                        }

                        newSlot = (slot + 9) % 10;
                        newLock = num - slot * mul + newSlot * mul;

                        if (visited.Add(newLock))
                        {
                            if (newLock == tar) return res;
                            next.Push(newLock);
                        }
                        mod /= 10;
                    }

                }
                var t = curr;
                curr = next;
                next = t;
                res++;
            }

            return -1;

        }


        // Your runtime beats 55.81 %
        // optimize => 结构优化，使用int代替string,避免产生大量的字符串拼接...
        public int OpenLock(string[] deadends, string target)
        {
            /*
             * 这是一个典型的dfs => 每次转动一个轮子和一个槽，穷举所有可能，并获取最短路径
             * 
             *          0000 ->
             *              转动第一个轮子(转动第(1/2/3....10)个槽) , 转动第2个轮子, 转动第3个轮子, 转动第4个轮子 
             *              
             * 每次操作时，我们有4*10种可能
             * 
             * 若使用dfs 由于存在重复的可能性，不能保证搜索到的必定是最优解
             * 
             * 故采用bfs：先穷举第一转动的可能性，再穷举第二次转动的可能性.... 直到找到答案或不存在可能性
             * 
             */
            ISet<string> set = deadends.ToHashSet();

            Stack<string> curr = new Stack<string>();
            Stack<string> next = new Stack<string>();

            var first = "0000";

            if (first == target) return 0;

            if (set.Add(first))
                curr.Push(first);

            int res = 1;

            while (curr.Count > 0)
            {
                while (curr.Count > 0)
                {
                    string str = curr.Pop();

                    ReadOnlySpan<char> now = str.AsSpan();

                    for (int i = 0; i < now.Length; i++)
                    {
                        var n = now[i] - '0';

                        // 向上转
                        var newLock = now.Slice(0, i).ToString() + (n + 1) % 10 + now.Slice(i + 1, now.Length - i - 1).ToString();

                        if (newLock == target) return res;
                        if (set.Add(newLock))
                        {
                            next.Push(newLock);
                        }

                        // 向下转 考虑轮回情况 n-1 替换为 n+9
                        newLock = now.Slice(0, i).ToString() + (n + 9) % 10 + now.Slice(i + 1, now.Length - i - 1).ToString();
                        if (newLock == target) return res;
                        if (set.Add(newLock))
                        {
                            next.Push(newLock);
                        }

                    }

                }
                var t = curr;
                curr = next;
                next = t;
                res++;
            }

            return -1;
        }
    }
}
