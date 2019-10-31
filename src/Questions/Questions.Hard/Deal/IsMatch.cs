using System;
using System.Collections.Generic;
using System.Text;
using Command.Attr;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/28 15:21:19
    /// @source : https://leetcode.com/problems/regular-expression-matching/
    /// @des : 实现正则中的.和*的匹配
    /// </summary>
    [Favorite("正则&dp 相关")]
    public class IsMatch
    {

        #region other solution
        // Runtime: 96 ms, faster than 51.23% of C# online submissions for Regular Expression Matching.
        // Memory Usage: 23.9 MB, less than 25.00% of C# online submissions for Regular Expression Matching. 
        // 差不多...
        // source : https://leetcode.com/problems/regular-expression-matching/discuss/5651/Easy-DP-Java-Solution-with-detailed-Explanation
        public bool OtherSolution(String s, String p)
        {

            if (s == null || p == null)
            {
                return false;
            }
            bool[][] dp = new bool[s.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[p.Length + 1];
            }

            dp[0][0] = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '*' && dp[0][i - 1])
                {
                    dp[0][i + 1] = true;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '.')
                    {
                        dp[i + 1][j + 1] = dp[i][j];
                    }
                    if (p[j] == s[i])
                    {
                        dp[i + 1][j + 1] = dp[i][j];
                    }
                    if (p[j] == '*')
                    {
                        if (p[j - 1] != s[i] && p[j - 1] != '.')
                        {
                            dp[i + 1][j + 1] = dp[i + 1][j - 1];
                        }
                        else
                        {
                            dp[i + 1][j + 1] = (dp[i + 1][j] || dp[i][j + 1] || dp[i + 1][j - 1]);
                        }
                    }
                }
            }
            return dp[s.Length][p.Length];
        }

        // 评论中的解决方案.
        public bool OtherSolution2(String s, String p)
        {
            // corner case
            if (s == null || p == null) return false;

            int m = s.Length;
            int n = p.Length;

            // M[i][j] represents if the 1st i characters in s can match the 1st j characters in p
            bool[][] M = new bool[m + 1][];
            for (int i = 0; i < M.Length; i++)
            {
                M[i] = new bool[n + 1];
            }

            // initialization: 
            // 1. M[0][0] = true, since empty string matches empty pattern
            M[0][0] = true;

            // 2. M[i][0] = false(which is default value of the boolean array) since empty pattern cannot match non-empty string
            // 3. M[0][j]: what pattern matches empty string ""? It should be #*#*#*#*..., or (#*)* if allow me to represent regex using regex :P, 
            // and for this case we need to check manually: 
            // as we can see, the length of pattern should be even && the character at the even position should be *, 
            // thus for odd length, M[0][j] = false which is default. So we can just skip the odd position, i.e. j starts from 2, the interval of j is also 2. 
            // and notice that the length of repeat sub-pattern #* is only 2, we can just make use of M[0][j - 2] rather than scanning j length each time 
            // for checking if it matches #*#*#*#*.
            for (int j = 2; j < n + 1; j += 2)
            {
                if (p[j - 1] == '*' && M[0][j - 2])
                {
                    M[0][j] = true;
                }
            }

            // Induction rule is very similar to edit distance, where we also consider from the end. And it is based on what character in the pattern we meet.
            // 1. if p.charAt(j) == s.charAt(i), M[i][j] = M[i - 1][j - 1]
            //    ######a(i)
            //    ####a(j)
            // 2. if p.charAt(j) == '.', M[i][j] = M[i - 1][j - 1]
            // 	  #######a(i)
            //    ####.(j)
            // 3. if p.charAt(j) == '*':
            //    1. if p.charAt(j - 1) != '.' && p.charAt(j - 1) != s.charAt(i), then b* is counted as empty. M[i][j] = M[i][j - 2]
            //       #####a(i)
            //       ####b*(j)
            //    2.if p.charAt(j - 1) == '.' || p.charAt(j - 1) == s.charAt(i):
            //       ######a(i)
            //       ####.*(j)
            //
            // 	  	 #####a(i)
            //    	 ###a*(j)
            //      2.1 if p.charAt(j - 1) is counted as empty, then M[i][j] = M[i][j - 2]
            //      2.2 if counted as one, then M[i][j] = M[i - 1][j - 2]
            //      2.3 if counted as multiple, then M[i][j] = M[i - 1][j]

            // recap:
            // M[i][j] = M[i - 1][j - 1]
            // M[i][j] = M[i - 1][j - 1]
            // M[i][j] = M[i][j - 2]
            // M[i][j] = M[i][j - 2]
            // M[i][j] = M[i - 1][j - 2]
            // M[i][j] = M[i - 1][j]
            // Observation: from above, we can see to get M[i][j], we need to know previous elements in M, i.e. we need to compute them first. 
            // which determines i goes from 1 to m - 1, j goes from 1 to n + 1

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    char curS = s[i - 1];
                    char curP = p[j - 1];
                    if (curS == curP || curP == '.')
                    {
                        M[i][j] = M[i - 1][j - 1];
                    }
                    else if (curP == '*')
                    {
                        char preCurP = p[j - 2];
                        if (preCurP != '.' && preCurP != curS)
                        {
                            M[i][j] = M[i][j - 2];
                        }
                        else
                        {
                            M[i][j] = (M[i][j - 2] || M[i - 1][j - 2] || M[i - 1][j]);
                        }
                    }
                }
            }

            return M[m][n];
        }

        #endregion

        /**
         * Runtime: 1528 ms, faster than 5.10% of C# online submissions for Regular Expression Matching.
         * Memory Usage: 23.8 MB, less than 25.00% of C# online submissions for Regular Expression Matching.
         * 
         * emmm..... 虽然看起来简单但还不如用try2... over.
         * 
         */
        public bool Solution(string s, string p)
        {
            return Helper(s, p, 0, 0);
        }

        private bool Helper(string str, string match, int i, int j)
        {
            bool overStr = str.Length == i, overMatch = match.Length == j;

            if (overStr && overMatch) return true;

            if (overStr)
            {
                while (j < match.Length)
                {
                    if (j + 1 == match.Length || match[j + 1] != '*') return false;
                    j += 2;
                }

                return true;
            }

            if (overMatch) return false;

            bool anyNum = j + 1 < match.Length && match[j + 1] == '*';

            if(match[j] == str[i] || match[j] == '.')
            {
                if (anyNum)
                {
                    return Helper(str, match, i, j + 2) || Helper(str, match, i + 1, j) ||
                           Helper(str, match, i + 1, j + 2);
                }

                return Helper(str, match, i + 1, j + 1);
            }

            if (anyNum)
            {
                return Helper(str, match, i, j + 2);
            }

            return false;
        }

        /**
         * Runtime: 92 ms, faster than 54.08% of C# online submissions for Regular Expression Matching.
         * Memory Usage: 23.9 MB, less than 25.00% of C# online submissions for Regular Expression Matching.
         *
         * 虽然完成但不算快...
         * 
         */
        public bool Try2(string s, string p)
        {
            /**
             * thinking:
             *
             * 对s、p 进行简单的整理 -> 方便研究、方便处理
             *
             * 利用递归处理各种各样的情况...
             * 
             */

            if (p.Equals(".*")) return true;

            // 先对s和p进行解析
            List<char> chars = new List<char>();
            List<int> needNum = new List<int>();

            foreach (var c in s)
            {
                if (chars.Count > 0 && chars[chars.Count - 1] == c) needNum[needNum.Count - 1]++;
                else
                {
                    chars.Add(c);
                    needNum.Add(1);
                }
            }

            List<MatchModel> list = new List<MatchModel>();

            foreach (var c in p)
            {
                if (c == '.')
                {
                    list.Add(new MatchModel() {AnyChar = true, MinNum = 1});
                }
                else if (c == '*')
                {
                    list[list.Count - 1].AnyNum = true;
                    list[list.Count - 1].MinNum--;
                }
                else
                {
                    if (list.Count > 0 && list[list.Count - 1].Char == c)
                    {
                        list[list.Count - 1].MinNum++;
                    }
                    else
                    {
                        list.Add(new MatchModel() {MinNum = 1, Char = c});
                    }
                }
            }

            return Helper(chars, needNum, list, 0, 0);
        }

        private bool Helper(List<char> chars, List<int> nums, List<MatchModel> list, int i, int j)
        {
            bool overStr = chars.Count == i, overMatch = list.Count == j;
            // 都到终点->匹配完成
            if (overStr && overMatch) return true;
            // 一个到终点
            if (overStr)
            {
                for (; j < list.Count; j++)
                {
                    // 若存在match中有未匹配的 返回false
                    if (list[j].MinNum > 0) return false;
                }

                return true;
            }

            // 存在多余str -> 失败
            if (overMatch) return false;

            // 同一字符
            if (list[j].Char == chars[i])
            {
                // 任意长度
                if (list[j].AnyNum)
                {
                    // 是否满足所需要的最小长度
                    if (nums[i] >= list[j].MinNum)
                    {
                        var old = nums[i]; // 便于num恢复

                        // 全匹配
                        if (Helper(chars, nums, list, i + 1, j + 1)) return true;

                        // 匹配 maxNum->minNum 不匹配  匹配1个 匹配2个 .... 
                        for (int k = nums[i]; k >= list[j].MinNum; k--)
                        {
                            nums[i] = k;
                            if (Helper(chars, nums, list, i, j + 1))
                            {
                                return true;
                            }
                        }

                        // num恢复 避免递归造成nums错误
                        nums[i] = old;
                    }

                    return false;
                }

                // 不满足最小长度 -> 失败
                if (nums[i] < list[j].MinNum) return false;

                // 相同 全匹配
                if (nums[i] == list[j].MinNum)
                    return Helper(chars, nums, list, i + 1, j + 1);

                // 小于 减去匹配部分 继续匹配  解决后续有.的情况 例如 : aa a.
                nums[i] -= list[j].MinNum;

                if (Helper(chars, nums, list, i, j + 1)) return true;

                nums[i] += list[j].MinNum; // 恢复num
                return false;
            }

            // 任意字符
            if (list[j].AnyChar)
            {
                // 任意长度
                if (list[j].AnyNum)
                {
                    // 全部匹配
                    if (Helper(chars, nums, list, nums.Count, j + 1)) return true;

                    // 不匹配 匹配一个 匹配2个 ... 等
                    for (int k = nums.Count - 1; k >= i; k--)
                    {
                        var old = nums[k];
                        for (int l = 1; l <= old; l++)
                        {
                            nums[k] = l;
                            if (Helper(chars, nums, list, k, j + 1)) return true;
                        }

                        nums[k] = old;
                    }
                }

                var num = list[j].MinNum;

                // 减去需要匹配的数量
                while (true)
                {
                    if (i == nums.Count) return num == 0 && Helper(chars, nums, list, i, j + 1);
                    if (num >= nums[i])
                    {
                        num -= nums[i++];
                    }
                    else
                    {
                        nums[i] -= num;
                        if (Helper(chars, nums, list, i, j + 1)) return true;
                        nums[i] += num; // nums恢复
                        return false;
                    }
                }
            }

            if (list[j].MinNum == 0) // 字符不匹配 但可以跳过
                return Helper(chars, nums, list, i, j + 1);

            return false;
        }

        #region try

        class MatchModel
        {
            public bool AnyNum { get; set; }
            public bool AnyChar { get; set; }
            public int MinNum { get; set; }
            public char Char { get; set; }
        }

        // bug 
        public bool Try(string s, string p)
        {
            List<char> chars = new List<char>();
            List<int> needNum = new List<int>();

            foreach (var c in s)
            {
                if (chars.Count > 0 && chars[chars.Count - 1] == c) needNum[needNum.Count - 1]++;
                else
                {
                    chars.Add(c);
                    needNum.Add(1);
                }
            }

            List<MatchModel> list = new List<MatchModel>();

            foreach (var c in p)
            {
                if (c == '.')
                {
                    list.Add(new MatchModel() {AnyChar = true, MinNum = 1});
                }
                else if (c == '*')
                {
                    list[list.Count - 1].AnyNum = true;
                    list[list.Count - 1].MinNum--;
                }
                else
                {
                    if (list.Count > 0 && list[list.Count - 1].Char == c)
                    {
                        list[list.Count - 1].MinNum++;
                    }
                    else
                    {
                        list.Add(new MatchModel() {MinNum = 1, Char = c});
                    }
                }
            }

            // a*b*a*c
            // aabbaac
            var j = 0;
            for (int i = 0; i < chars.Count; i++)
            {
                while (j < list.Count && list[j].MinNum == 0)
                {
                    j++;
                }

                if (list[j].AnyChar || list[j].Char == chars[i])
                {
                }
            }

            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MinNum == 0)
                {
                    if (list[i].AnyChar || list[i].Char == chars[j]) flag = true;
                    continue;
                }

                if (j == s.Length)
                {
                    if (i < list.Count - 1) return false;
                    return true;
                }

                if (list[i].Char == chars[j] || list[i].AnyChar)
                {
                    if (list[i].AnyNum)
                    {
                        if (list[i].MinNum <= needNum[j])
                        {
                            j++;
                        }
                        else
                            return false;
                    }
                    else if (list[i].MinNum == needNum[j])
                    {
                        j++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (flag)
                {
                    j++;
                }
                else
                {
                    return false;
                }

                flag = false;
            }

            return j == s.Length || (flag && j == s.Length - 1);
        }

        #endregion
    }
}