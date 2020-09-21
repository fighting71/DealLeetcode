using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/15/2020 10:54:50 AM
    /// @source : https://leetcode.com/problems/palindrome-partitioning-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class Palindrome_Partitioning_II
    {
        //Runtime: 80 ms, faster than 79.22% of C# online submissions for Palindrome Partitioning II.
        //Memory Usage: 24.7 MB, less than 20.78% of C# online submissions for Palindrome Partitioning II.
        // 貌似还慢点，可能是存在 "-1" 运算的原因?
        public int Optimize(string str)
        {

            int len = str.Length;

            bool[][] isPalindrome = new bool[len - 1][];
            for (int i = 0; i < len - 1; i++)
                isPalindrome[i] = new bool[len - i - 1];

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j + i < len; j++)
                {
                    if (i < 3 || isPalindrome[j + 1][i - 3]) isPalindrome[j][i - 1] = str[j] == str[j + i];
                }
            }

            //ShowTools.ShowMatrix(isPalindrome);

            int[] dp = new int[len + 1];

            for (int i = len - 2; i >= 0; i--)
            {
                dp[i] = dp[i + 1];
                for (int j = len - i - 1; j > 0; j--)
                {
                    if (isPalindrome[i][j - 1])
                    {
                        dp[i] = Math.Max(dp[i], (j) + dp[i + j + 1]);
                    }
                }
                //Console.WriteLine($"dp[{i}] = {dp[i]}");
            }

            return len - dp[0] - 1;

        }

        //Runtime: 76 ms, faster than 96.10% of C# online submissions for Palindrome Partitioning II.
        //Memory Usage: 23.4 MB, less than 64.94% of C# online submissions for Palindrome Partitioning II.
        // optimize : 空间占用优化 wow~
        public int Solution(string str)
        {

            int len = str.Length;

            bool[][] isPalindrome = new bool[len][];
            for (int i = 0; i < len; i++)
                isPalindrome[i] = new bool[len - i];

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j + i < len; j++)
                {
                    if (i < 3 || isPalindrome[j + 1][i - 2]) isPalindrome[j][i] = str[j] == str[j + i];
                }
            }

            //ShowTools.ShowMatrix(isPalindrome);

            int[] dp = new int[len + 1];

            for (int i = len - 2; i >= 0; i--)
            {
                dp[i] = dp[i + 1];
                for (int j = len - 1; j > i; j--)
                {
                    if (isPalindrome[i][j - i])
                    {
                        dp[i] = Math.Max(dp[i], j - i + dp[j + 1]);
                    }
                }
            }

            return len - dp[0] - 1;

        }

        //Runtime: 80 ms, faster than 79.22% of C# online submissions for Palindrome Partitioning II.
        //Memory Usage: 24.6 MB, less than 20.78% of C# online submissions for Palindrome Partitioning II.
        // nice!
        public int Clear(string str)
        {

            int len = str.Length;

            bool[][] isPalindrome = new bool[len][];
            for (int i = 0; i < len; i++)
                isPalindrome[i] = new bool[len];

            for (int width = 1; width < len; width++)
            {
                for (int index = 0; index + width < len; index++)
                {
                    if (width < 3 || isPalindrome[index + 1][index + width - 1]) isPalindrome[index][index + width] = str[index] == str[index + width];
                }
            }

            //ShowTools.ShowMatrix(isPalindrome);

            int[] dp = new int[len + 1];

            for (int start = len - 2; start >= 0; start--)
            {
                dp[start] = dp[start + 1];
                for (int end = len - 1; end > start; end--)
                {
                    if (isPalindrome[start][end])
                    {
                        dp[start] = Math.Max(dp[start], end - start + dp[end + 1]);
                    }
                }
                //Console.WriteLine($"dp[{i}] = {dp[i]}");
            }

            return len - dp[0] - 1;

        }

        /// <summary>
        /// 以<see cref="Clear(string)"/> 为源的说明版
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Explain(string str)
        {

            // 经历重重困难，终于解出来了!...

            int len = str.Length;

            // a. 定义isPalindrome用于存放是否回文的验证结果
            bool[][] isPalindrome = new bool[len][];
            for (int i = 0; i < len; i++)
                isPalindrome[i] = new bool[len];

            // *** 第一个关键点: 如何快速检索是否回文.
            // 由于比较长的回文是由比较短的回文组合而成,故此处:
            //  从最短长度(2)出发,
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j + i < len; j++)
                {
                    if (i < 3 // 若长度小于3 即 : aba ab 的形式 直接验证最边上是否相等即可
                        || isPalindrome[j + 1][j + i - 1] // 否则 a...b  验证a的后一位元素到b的前一位元素是否相等  由于距离是从短至长，所以可直接使用之前的结果进行验证.
                        ) 
                        isPalindrome[j][j + i] = str[j] == str[j + i];
                }
            }

            //ShowTools.ShowMatrix(isPalindrome);


            // *** 第二个关键点：如何返回总长
            //      a.计算切割次数
            //          在经过反复修改测试后，舍弃了此方案...
            //          因为在发现一个新组合时，可能会影响之前的所有计算结果(切割次数),没有固定的模式，难以优化(个人认为)
            //      b.计算最佳组合的总长

            // *** 第三个关键点：如何获取最长的组合，来使我们的切割次数最小
            //  可能的情况：
            //      1.[区间1] 与 [区间2] 不重合 -- 简单，直接求合
            //      2.[区间1] 与 [区间2] 重合 -- 复杂，可能舍弃[区间1]也有可能舍弃[区间2]  舍弃后还要考虑舍弃的区间内是否有可用的部分...
            //    ps:建议先用递归去慢慢寻找思路.

            // 这里我们掌握递归的思路后，将递归改造成dp来提升性能》
            int[] dp = new int[len + 1];

            // 从后半段部分出发
            for (int i = len - 2; i >= 0; i--)
            {
                // 初始复制为上一次的结果
                dp[i] = dp[i + 1];
                for (int j = len - 1; j > i; j--)
                {
                    // 如果 [i-j]为回文
                    if (isPalindrome[i][j])
                    {
                        // 那么比较 dp[i] 与 j-i + （j以后的部分的总长） 
                        //  因为最佳组合就是 [区间1] 与 [区间2] 不重合 故 " + （j以后的部分的总长） " 即为最佳组合！
                        dp[i] = Math.Max(dp[i], j - i + dp[j + 1]);
                    }
                }
                //Console.WriteLine($"dp[{i}] = {dp[i]}");
            }

            // 返回 总长 - 回文组合的总长 - 1(第一个无须切割)
            return len - dp[0] - 1;

        }

        /// <summary>
        /// 还看得过去的版本.
        /// 具有参考价值.
        /// </summary>
        public class Normal
        {

            //Runtime: 472 ms, faster than 20.78% of C# online submissions for Palindrome Partitioning II.
            //Memory Usage: 24.2 MB, less than 28.57% of C# online submissions for Palindrome Partitioning II.
            public int Solution(string str)
            {

                int len = str.Length;

                bool[][] isPalindrome = new bool[len][];
                for (int i = 0; i < len; i++)
                {
                    isPalindrome[i] = new bool[len];
                }

                for (int i = 0; i < len - 1; i++)
                {
                    for (int j = len - 1; j > i; j--)
                    {
                        if (isPalindrome[i][j]) continue;
                        for (int start = i + (j - i + 1) / 2 - 1, end = start + 1 + ((j - i + 1) % 2); start >= i; start--, end++)
                        {
                            if (str[start] != str[end])
                            {
                                break;
                            }
                            if (start == 0 && end == len - 1)
                            {
                                return 0;
                            }
                            isPalindrome[start][end] = true;
                        }
                    }
                }
                int max = 0;
                int[] dp = new int[len + 1];

                for (int i = len - 2; i >= 0; i--)
                {
                    dp[i] = dp[i + 1];
                    for (int j = len - 1; j > i; j--)
                    {
                        if (isPalindrome[i][j])
                        {
                            dp[i] = Math.Max(dp[i], j - i + dp[j + 1]);
                        }
                    }
                    max = Math.Max(dp[i], max);
                }

                return len - max - 1;

            }

            public int Explain(string str)
            {

                int len = str.Length;
                bool[][] isPalindrome = new bool[len][];
                for (int i = 0; i < len; i++)
                {
                    isPalindrome[i] = new bool[len];
                }

                List<(int start, int end, int wid)> list = new List<(int start, int end, int wid)>();

                for (int i = 0; i < len; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        isPalindrome[i][j] = true;

                        for (int start = i, end = j; start < end; start++, end--)
                        {
                            if (str[start] != str[end])
                            {
                                isPalindrome[i][j] = false;
                                break;
                            }
                        }
                        if (isPalindrome[i][j])
                        {
                            list.Add((i, j, j - i));
                            // 找到后去移除len 
                            // 然后如果palindrome中包含已删除的palindrome则增加回来

                            // point:解决两个palindrome 包含重复区间的取舍问题。
                        }
                    }
                }

                //int[][] dp = new int[len][];
                //for (int i = 0; i < len; i++)
                //{
                //    dp[i] = new int[len];
                //}

                int max = 0;
                int[] dp = new int[list.Count];
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    dp[i] = list[i].wid;

                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[j].start > list[i].end)
                        {
                            dp[i] = Math.Max(dp[i], list[i].wid + dp[j]);
                        }
                    }
                    max = Math.Max(dp[i], max);
                }

                //foreach (var item in list)
                //{
                //    Console.WriteLine($"{item.start}-{item.end}");
                //}

                var res = len - max - 1;
                //var res = len - Help(list, 1, 0) - 1;

                return res;

                //Console.WriteLine(res);

                {
                    //List<(int index, int min,int wid)> cache = new List<(int index, int min, int wid)>();
                    //int index = 1, prev = 0, min = 0;
                    //for (; index < list.Count; index++)
                    //{
                    //    if (list[prev].end < list[index].start)
                    //    {
                    //        // 结算
                    //        prev = min = index;
                    //    }
                    //    else if (list[prev].start == list[index].start)
                    //    {
                    //        prev = index;
                    //    }
                    //    else if (list[prev].start <= list[index].start && list[prev].end >= list[index].end)
                    //    {
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        cache.Add((prev, min, list[prev].end - list[prev].start));
                    //        prev = min = index;
                    //    }
                    //}

                    //cache.Add((prev, min, list[prev].end - list[prev].start));

                    //foreach (var item in cache)
                    //{
                    //    Console.WriteLine($"{list[item.index].start}-{list[item.index].end}");
                    //}

                    // point:解决两个palindrome 包含重复区间的取舍问题。
                }

                return 0;

            }

            private int Help(List<(int start, int end, int wid)> list, int index, int prev)
            {
                if (index == list.Count) return list[prev].wid;

                if (list[index].start > list[prev].end)
                {
                    return list[prev].wid + Help(list, index + 1, index);
                }
                else if (list[prev].start <= list[index].start && list[prev].end >= list[index].end)
                {
                    return Help(list, index + 1, prev);
                }
                else
                {
                    return Math.Max(
                        Help(list, index + 1, prev),
                         Help(list, index + 1, index)
                        );
                }

            }

        }

        [Obsolete("烂大街版...")]
        public class Check {

            //untime: 2336 ms, faster than 7.81% of C# online submissions for Palindrome Partitioning II.
            //Memory Usage: 28.5 MB, less than 9.38% of C# online submissions for Palindrome Partitioning II.
            // QAQ
            // target : 1500
            public int Solution(string str)
            {
                // 如何利用 str in a-z?
                int len = str.Length;
                int[][] dp = new int[len][];
                for (int i = 0; i < len; i++)
                {
                    // 缩减空间。 提升不大。
                    dp[i] = new int[len - i];
                    dp[i][0] = 1;
                }

                for (int k = 1; k < len; k++)
                {
                    for (int i = 0; i + k < len; i++)
                    {
                        dp[i][k] = GetLen(i, k, dp, str);
                    }
                }

                //ShowTools.ShowMatrix(dp);

                var res = dp[0][len - 1] - 1;
                //Console.WriteLine($"real:{res}");
                return res;

            }

            private int GetLen(int start, int k, int[][] dp, string str)
            {
                if (str[start] == str[start + k])
                {
                    if (k < 3 || dp[start + 1][k - 2] == 1) return 1;
                }

                // key*** how fast?
                int min = k + 1;
                int copyEnd = k;
                while (copyEnd-- > 0)
                {
                    min = Math.Min(dp[start][copyEnd] + dp[copyEnd + start + 1][k - copyEnd - 1], min);
                }

                return min;
            }


        }

        [Obsolete("time limit")]
        public class Try2
        {
            public int Solution(string str)
            {

                int len = str.Length;
                int[][] dp = new int[len][];
                for (int i = 0; i < len; i++)
                {
                    dp[i] = new int[len];
                    dp[i][i] = 1;
                }

                for (int k = 1; k < len; k++)
                {
                    for (int i = 0; i + k < len; i++)
                    {
                        dp[i][i + k] = GetLen(i, i + k, dp, str);
                    }
                }

                //ShowTools.ShowMatrix(dp);

                return dp[0][len - 1] - 1;

            }

            // 感觉到dp极限了,应该是我算法有问题。。。
            private int GetLen(int start, int end, int[][] dp, string str)
            {
                if (str[start] == str[end])
                {
                    if (end - start < 3 || dp[start + 1][end - 1] == 1) return 1;
                }

                // key*** how fast?
                int min = end - start + 1;
                int copyEnd = end;
                while (copyEnd-- > start)
                {
                    min = Math.Min(dp[start][copyEnd] + dp[copyEnd + 1][end], min);
                    if (min == 2) break;
                }
                dp[start][end] = min;

                return min;
            }
        }

        [Obsolete("time limit")]
        public class Try1
        {
            public int Solution(string str)
            {

                int len = str.Length;
                int[][] dp = new int[len][];
                for (int i = 0; i < len; i++)
                {
                    dp[i] = new int[len];
                    dp[i][i] = 1;
                }

                for (int k = 1; k < len; k++)
                {
                    for (int i = 0; i + k < len; i++)
                    {
                        dp[i][i + k] = GetLen(i, i + k, dp, str);
                    }
                }

                return dp[0][len - 1] - 1;

            }

            // time limit
            private int GetLen(int start, int end, int[][] dp, string str)
            {
                if (str[start] == str[end])
                {
                    if (end - start < 3 || dp[start + 1][end - 1] == 1) return 1;
                }

                int min = end - start + 1;
                int copyEnd = end;
                while (copyEnd-- > start)
                {
                    min = Math.Min(dp[start][copyEnd] + dp[copyEnd + 1][end], min);
                }
                int copyStart = start;
                while (end > copyStart++)
                {
                    min = Math.Min(dp[copyStart][end] + dp[start][copyStart - 1], min);
                }

                dp[start][end] = min;

                return min;
            }
        }

        public int Think(string str)
        {

            int len = str.Length;
            bool[][] isPalindrome = new bool[len][];
            int[][] dp = new int[len][];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                isPalindrome[i] = new bool[len];
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    isPalindrome[i][j] = true;

                    for (int start = i, end = j; start < end; start++, end--)
                    {
                        if (str[start] != str[end])
                        {
                            isPalindrome[i][j] = false;
                            break;
                        }
                    }
                }
            }

            var res = GetLen(isPalindrome, 0, len - 1, dp);

            //ShowTools.ShowMatrix(dp);

            return res - 1;

        }

        // time limit
        private int GetLen(bool[][] isPalindrome, int start, int end, int[][] dp)
        {
            if (start == end || isPalindrome[start][end]) return 1;
            if (start == end - 1) return dp[start][end] = 2;
            if (dp[start][end] > 0) return dp[start][end];

            int min = int.MaxValue;
            int copyEnd = end;
            while (copyEnd-- > start)
            {
                min = Math.Min(GetLen(isPalindrome, start, copyEnd, dp) + GetLen(isPalindrome, copyEnd + 1, end, dp), min);
            }
            int copyStart = start;
            while (end > copyStart++)
            {
                min = Math.Min(GetLen(isPalindrome, copyStart, end, dp) + GetLen(isPalindrome, start, copyStart - 1, dp), min);
            }

            dp[start][end] = min;

            return min;

        }

    }
}