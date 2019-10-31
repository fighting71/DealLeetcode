using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/31 16:23:56
    /// @source : https://leetcode.com/problems/longest-valid-parentheses/
    /// @des : 看描述就是跟dp相关... 
    /// </summary>
    public class LongestValidParentheses
    {

        /**
         * 
         * Runtime: 76 ms, faster than 84.95% of C# online submissions for Longest Valid Parentheses.
         * Memory Usage: 23 MB, less than 25.00% of C# online submissions for Longest Valid Parentheses.
         * 
         * Runtime: 72 ms, faster than 95.39% of C# online submissions for Longest Valid Parentheses.
         * Memory Usage: 23.1 MB, less than 25.00% of C# online submissions for Longest Valid Parentheses.
         * 
         * whl<.
         * 
         */
        public int Solution2(string s)
        {
            int num = 0, max = 0;
            // 使用Stack替代List 毕竟不需要下标功能...
            Stack<int> queue = new Stack<int>();
            int[] dp = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    queue.Push(i);
                else if (queue.Count > 0)
                {
                    // 移除并获取最后一位
                    var lastIndex = queue.Pop();
                    if (lastIndex == i - num - 1)
                        num += 2;
                    else
                        num = 2;

                    if (i - num >= 0)
                        num += dp[i - num];

                    dp[i] = num;
                    // 只有此处需要验证 more efficient.
                    max = Math.Max(max, num);
                }
                else
                    num = 0;
            }

            return max;
        }

        /**
         * Runtime: 76 ms, faster than 84.95% of C# online submissions for Longest Valid Parentheses.
         * Memory Usage: 22.9 MB, less than 25.00% of C# online submissions for Longest Valid Parentheses.
         */
        public int Solution(string s)
        {
            int num = 0, max = 0;
            // 方便追踪下标...
            List<int> leftIndex = new List<int>();
            // 果不其然...
            int[] dp = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    // 记录下标 方便验证.
                    leftIndex.Add(i);
                }
                else if (leftIndex.Count > 0)
                {
                    //举例: (()()) num 为4 当到最后一个)时 由于 lastIndex = 0 right = 5 so num+=2 not num = 2
                    if (leftIndex[leftIndex.Count - 1] == i - num - 1)
                    {
                        num += 2;
                    }
                    else
                    {
                        num = 2;
                    }

                    // 当 ()(() -> ()(()) 时  (())需要加上前面的()
                    if (i - num >= 0)
                        num += dp[i - num];

                    dp[i] = num;

                    // 移除已匹配的(下标
                    leftIndex.RemoveAt(leftIndex.Count - 1);
                }
                // 有 ) 无 ( 直接跳过
                else
                {
                    num = 0;
                }

                max = Math.Max(max, num);
            }

            return max;
        }

        public int Error(string s)
        {
            // 如果不考虑必须连续 ...

            int res = 0, left = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else if (left > 0)
                {
                    left--;
                    res += 2;
                }
            }

            return res;
        }
    }
}