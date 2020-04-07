using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/3/2020 10:49:33 AM
    /// @source : https://leetcode.com/problems/shortest-palindrome/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Efficient)]
    public class ShortestPalindrome
    {

        public bool IsDebug { get; set; }

        private string Explain(string s)
        {

            // 简单查询思路:
            // s = {c1,c2.ck..cn}
            // 步骤1：k = n 查看 c1~ck是否回文
            //  true => 追加多余部分 c(k+1)~cn 返回
            //  false => 追加 ck 令k = k - 1  继续步骤1

            // 注：题目要求只能在前面添加
            // 初始化 l,r 找出最长回文数
            int l = 0, r = s.Length - 1;
            StringBuilder builder = new StringBuilder();

            while (l < r)
            {
                if (s[l] == s[r])// 符合回文，继续
                {
                    l++;
                    r--;
                }
                else
                {// 不相等

                    // 则最后一个必定不匹配 直接追加  
                    //  说明示例: 
                    //      abc  a!=c 则必定追加c
                    //      abca (1):a==a (2):c!=b 则必定追加a 

                    // 追加ck
                    builder.Append(s[s.Length - builder.Length - 1]);

                    /**
                     * 示例 aabbaaa
                     * 
                     * 1: a(0) = a(6) 继续
                     * 2. a(1) = a(5) 继续
                     * 3. b(2) != a(4) 追加a(6) 即ck 最后一个.
                     * 
                     * 开始遍历，
                     *  i = a(4),j = a(1) 匹配 
                     *  i = a(5) j = a(0) 匹配 结束循环
                     * 最终 r-- l = 2 r = 3
                     * 
                     * 示例 aabbcaa
                     * 
                     * 1: a(0) = a(6) 继续
                     * 2. a(1) = a(5) 继续
                     * 3. b(2) != c(4) 追加a(6) 即ck 最后一个.
                     * 
                     * 开始遍历， 
                     *   i = c(4),j = a(1) 不匹配 追加 a(5) 即ck 重置 r = 4,l = 1
                     *   i = c(4),j = a(0) 不匹配 追加 c(4) 即ck 重置 r = 4,l = 0
                     * 最终 r-- l = 0 r = 3
                     * 
                     * 
                     * 示例 cabdaac
                     * 
                     * 1: c(0) = c(6) 继续
                     * 2. a(1) = a(5) 继续
                     * 3. b(2) != a(4) 追加a(6) 即ck 最后一个.
                     * 
                     * 开始遍历， 
                     *   i = a(4),j = a(1) 匹配 
                     *   i = a(5),j = c(0) 不匹配 追加 a(5) 即ck 重置 r = 5,l = 0
                     * 最终 r-- l = 0 r = 4
                     * 
                     */
                    for (int i = r, j = l - 1; j >= 0; j--)
                    {
                        // 若ck != c(l-1)
                        if (s[i] != s[j])
                        {
                            // 追加ck
                            builder.Append(s[s.Length - builder.Length - 1]);
                            // 重置 l,r
                            l = j;
                            r = i;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    r--;
                }

            }

            builder.Append(s);

            return builder.ToString();
        }

        /// <summary>
        /// Runtime: 72 ms, faster than 100.00% of C# online submissions for Shortest Palindrome.
        /// Memory Usage: 23.6 MB, less than 100.00% of C# online submissions for Shortest Palindrome.
        /// 
        /// I'm genuis hahaha
        /// 
        /// 舒服了~
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Solution(string s)
        {

            int l = 0, r = s.Length - 1;
            StringBuilder builder = new StringBuilder();

            while (l < r)
            {
                if(s[l] == s[r])
                {
                    l++;
                    r--;
                }
                else
                {
                    builder.Append(s[s.Length - builder.Length - 1]);
                    for (int i = r, j = l - 1; j >= 0; j--)
                    {
                        if (s[i] != s[j])
                        {
                            builder.Append(s[s.Length - builder.Length - 1]);
                            l = j;
                            r = i;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    r--;
                }

            }

            builder.Append(s);

            return builder.ToString();
        }

        public string Clear(string s)
        {

            int l = 0, r = s.Length - 1, i, j, k = s.Length - 1;
            StringBuilder builder = new StringBuilder();

            while (l < r)
            {
                if (s[l] == s[r]) l++;
                else
                {
                    builder.Append(s[k--]);
                    for (i = r, j = l - 1; j >= 0; j--)
                    {
                        if (s[i] != s[j])
                        {
                            builder.Append(s[k--]);
                            l = j;
                            r = i;
                        }
                        else i++;
                    }
                }

                r--;

            }

            builder.Append(s);

            return builder.ToString();
        }

        // bug
        public string Simple(string s)
        {

            if (IsDebug)
            {
                ShowTools.ShowIndex(s);
            }

            if (Help(s)) return s;

            StringBuilder prev = new StringBuilder();

            for (int i = 1, len = s.Length; i < len; i++)
            {
                if (Help(s.AsSpan(0, len - i)))
                {
                    if (IsDebug)
                    { Console.WriteLine($"maxLen:{len - i}"); }

                    for (int j = s.Length - 1; j >= len - i; j--)
                        prev.Append(s[j]);

                    prev.Append(s);
                    return prev.ToString();
                }
            }

            for (int j = s.Length - 1; j > 0; j--)
                prev.Append(s[j]);

            prev.Append(s);

            return prev.ToString();

        }

        private bool Help(ReadOnlySpan<char> span)
        {

            int len = span.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (span[i] != span[len - 1 - i]) return false;
            }
            return true;

        }

    }
}
