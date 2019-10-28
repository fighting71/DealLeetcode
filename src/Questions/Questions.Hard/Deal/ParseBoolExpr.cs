using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/16 星期五 下午 5:31:37
    /// @source : https://leetcode.com/problems/parsing-a-boolean-expression/
    /// @des : 
    /// </summary>
    public class ParseBoolExpr
    {
        #region Solution

        /*
         * 
         * basic test :
         * 
         * Runtime: 80 ms, faster than 84.95% of C# online submissions for Parsing A Boolean Expression.
         * Memory Usage: 21.3 MB, less than 100.00% of C# online submissions for Parsing A Boolean Expression.
         * 
         * optmize : 
         * 
         * Runtime: 72 ms, faster than 100.00% of C# online submissions for Parsing A Boolean Expression.
         * Memory Usage: 21.1 MB, less than 100.00% of C# online submissions for Parsing A Boolean Expression.
         * 
         * Runtime: 68 ms, faster than 100.00% of C# online submissions for Parsing A Boolean Expression.
         * Memory Usage: 21.2 MB, less than 100.00% of C# online submissions for Parsing A Boolean Expression.
         * 
         */

        public bool Solution(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '!')
                    return HelperNot(ref i, expression);

                if (expression[i] == '&')
                    return HelperAnd(ref i, expression);

                if (expression[i] == '|')
                    return HelperOr(ref i, expression);

                if (expression[i] == 't')
                    return true;
                if (expression[i] == 'f')
                    return false;
            }

            return true;
        }

        public bool HelperNot(ref int start, string expression)
        {
            var left = 0;
            var res = true;
            for (start++; start < expression.Length; start++)
            {

                if (expression[start] == '(') left++;
                else if (expression[start] == ')')
                {
                    left--;
                    if (left == 0) return res;
                }
                else if (expression[start] == '!')
                    res =!HelperNot(ref start, expression);

                else if (expression[start] == '&')
                    res = !HelperAnd(ref start, expression);

                else if (expression[start] == '|')
                    res = !HelperOr(ref start, expression);

                else if (expression[start] == 't')
                    res = false;

                else if (expression[start] == 'f')
                    res = true;
            }      

            return true;
        }

        private bool HelperAnd(ref int start, string expression)
        {
            var res = true;
            var left = 0;
            for (start++; start < expression.Length; start++)
            {

                if (expression[start] == '(')
                    left++;
                else if (expression[start] == ')')
                {
                    left--;
                    if (left == 0) return res;
                }
                else if (!res) continue;// optimize 已确定结果时 无需验证其他情况
                else if (expression[start] == '!')
                    res &= HelperNot(ref start, expression);

                else if (expression[start] == '&')
                    res &= HelperAnd(ref start, expression);

                else if (expression[start] == '|')
                    res &= HelperOr(ref start, expression);

                else if (expression[start] == 'f')
                    res = false;
            }

            return res;
        }

        public bool HelperOr(ref int start, string expression)
        {
            var res = false;
            var left = 0;
            for (start++; start < expression.Length; start++)
            {
                if (expression[start] == '(')
                    left++;
                else if (expression[start] == ')')
                {
                    left--;
                    if (left == 0) return res;
                }
                else if (res) continue;// optimize 已确定结果时 无需验证其他情况
                else if (expression[start] == '!')
                    res |= HelperNot(ref start, expression);

                else if (expression[start] == '&')
                    res |= HelperAnd(ref start, expression);

                else if (expression[start] == '|')
                    res |= HelperOr(ref start, expression);

                else if (expression[start] == 't')
                    res = true;
            }

            return res;
        }

        #endregion

        #region test

        public void Test(Func<string, bool> func)
        {
            Console.WriteLine(func("!(f)") == true);
            Console.WriteLine(func("|(f,t)") == true);
            Console.WriteLine(func("&(t,f)") == false);
            Console.WriteLine(func("|(&(t,f,t),!(t))") == false);
        }

        #endregion
    }
}