using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 6:04:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3629/
    /// @des : 
    /// </summary>
    public class Simplify_Path
    {

        // 1 <= path.length <= 3000
        // path consists of English letters, digits, period '.', slash '/' or '_'.
        // path is a valid absolute Unix path.

        // Your runtime beats 69.36 %
        // tul tul
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new Stack<string>();
            int count = 0;

            StringBuilder builder = new StringBuilder();

            foreach (var c in path)
            {
                if (c == '/')
                {
                    if (count > 2) /// ... 视为目录/文件名
                    {
                        AppendPoint();
                        stack.Push(builder.ToString());
                    }
                    else if (count == 2)
                    {
                        if (stack.Count > 0)
                            stack.Pop();
                    }
                    else if (builder.Length > 0)
                    {
                        stack.Push(builder.ToString());
                    }
                    count = 0;
                    builder.Clear();
                }
                else if (c == '.')
                {
                    if (builder.Length > 0)  builder.Append('.'); // [!\.]*\.*[!\.]* .xxx or xx. or xx.xx 视为目录/文件名
                    else count++;
                }
                else
                {
                    AppendPoint();
                    count = 0;
                    builder.Append(c);
                }
            }

            string res = string.Empty;

            if (count > 2)
            {
                AppendPoint();
                res = builder.ToString();
            }
            else if (count == 2)
            {
                if (stack.Count > 0)
                    stack.Pop();
            }
            else if (builder.Length > 0)
            {
                res = builder.ToString();
            }

            while (stack.Count > 0)
            {
                if (res.Length == 0) res = stack.Pop();
                else
                    res = stack.Pop() + "/" + res;
            }
            return "/" + res;

            void AppendPoint()
            {
                for (int i = 0; i < count; i++)
                    builder.Append('.');
                count = 0;
            }

        }

    }
}
