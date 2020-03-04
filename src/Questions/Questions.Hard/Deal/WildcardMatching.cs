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
    /// @since : 3/2/2020 5:22:34 PM
    /// @source : https://leetcode.com/problems/wildcard-matching/
    /// @des : 实现正则中的.和?的匹配
    /// </summary>
    [Favorite(FlagConst.DP, FlagConst.RegexMatch)]
    public class WildcardMatching
    {

        /**
         * Runtime: 92 ms, faster than 86.12% of C# online submissions for Wildcard Matching.
         * Memory Usage: 25.6 MB, less than 100.00% of C# online submissions for Wildcard Matching.
         * 
         * dp大法好...
         * 
         */
        public bool Solution(string s, string p)
        {

            int m = s.Length, n = p.Length;

            bool[][] flag = new bool[m + 1][];
            for (int i = 0; i < flag.Length; i++)
                flag[i] = new bool[n+1];

            flag[0][0] = true;

            for (int i = 0; i < n; i++)
                if(p[i] == '*' && (i == 0 || flag[0][i]))
                    flag[0][i + 1] = true;

            for (int i = 1; i < m + 1; i++)
            {
                char curS = s[i - 1];
                for (int j = 1; j < n + 1; j++)
                {
                    char curP = p[j - 1];
                    if (curS == curP || curP == '?')
                        flag[i][j] = flag[i - 1][j - 1];
                    else if (curP == '*')
                        flag[i][j] = (flag[i][j - 1] || flag[i - 1][j - 1] || flag[i - 1][j]);
                }
            }

            return flag[m][n];

        }

        // 解决方案说明
        private bool Explain(string s, string p)
        {

            // Simple -> dp
            // 递归的方式简单明了 只是当s/p 长度过大时  容易出现over stack 
            // 参考递归中的处理 常规下 会造成 大量重复处理的(i,j)
            // 故使用dp 存储每次处理结果 减少重复验证

            int m = s.Length, n = p.Length;

            // 创建table存储处理结果
            bool[][] flag = new bool[m + 1][];
            for (int i = 0; i < flag.Length; i++)
                flag[i] = new bool[n + 1];

            // 给定初始值
            flag[0][0] = true;

            // 遍历p
            for (int i = 0; i < n; i++)
                // 若为* -> （*表示空则符合）
                //      i为0 -> 通过
                //      上一个能通过 -> 通过
                if (p[i] == '*' && (i == 0 || flag[0][i]))
                    flag[0][i + 1] = true;

            // 遍历 s
            for (int i = 1; i < m + 1; i++)
            {
                char curS = s[i - 1];
                // 遍历 p
                for (int j = 1; j < n + 1; j++)
                {
                    char curP = p[j - 1];
                    // 字符匹配 flag(i,j) = 上一个结果 flag(i-1,j-1)
                    if (curS == curP || curP == '?')
                        flag[i][j] = flag[i - 1][j - 1];
                    // 不匹配 但为* 则 flag(i,j) =
                    //      flag[i][j - 1] || (*包括curP但不结束 例:*={*,*,curS,*}) 
                    //      flag[i - 1][j - 1] || (*包含至curP 例:*={*,*,curS})
                    //      flag[i - 1][j] (*表示为空)
                    else if (curP == '*')   
                        flag[i][j] = (flag[i][j - 1] || flag[i - 1][j - 1] || flag[i - 1][j]);
                }
            }

            return flag[m][n];

        }

        // over stack
        public bool Simple(string s, string p)
        {
            return Helper(s, p, 0, 0);
        }

        public bool Helper(string s,string p,int i,int j)
        {
            if (i == s.Length && j == p.Length) return true;

            if(i == s.Length)
            {
                for (; j < p.Length; j++)
                {
                    if (p[j] == '?' || p[j] == '*') continue;
                    return false;
                }
                return true;
            }

            if (j == p.Length) return false;

            if (s[i] == p[j] || p[j] == '?') return Helper(s, p, i + 1, j + 1);
            if (p[j] == '*') return Helper(s, p, i + 1, j + 1) || Helper(s, p, i + 1, j) || Helper(s, p, i, j + 1);

            return false;

        }

    }
}
