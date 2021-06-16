using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/16/2021 4:52:18 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3781/
    /// @des : 给定n对括号，编写一个函数来生成所有形式良好的括号组合。
    /// </summary>
    [Serie(FlagConst.Complex)]
    public class Generate_Parentheses
    {

        // Constraints:

        // 1 <= n <= 8

        // Your runtime beats 43.16 %
        // 告辞 
        // optimize -> 减少字符串构造，使用循环+stack/queue 代替递归.
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = new List<string>();
            Help(n, n, string.Empty);
            return res;
            void Help(int left, int right, string curr)
            {
                if (right == 0) res.Add(curr);
                else if(left == 0)
                {
                    StringBuilder builder = new StringBuilder(curr);
                    for (int i = 0; i < right; i++)
                    {
                        builder.Append(')');
                    }
                    res.Add(builder.ToString());
                }
                else if (left == right)
                {
                    Help(left - 1, right, curr + '(');
                }
                else
                {
                    Help(left - 1, right, curr + '(');
                    Help(left, right - 1, curr + ')');
                }
            }
        }

    }
}
