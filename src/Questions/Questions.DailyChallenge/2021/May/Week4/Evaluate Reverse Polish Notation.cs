using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/25/2021 4:03:02 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3755/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.AnalysisExpression)]
    public class Evaluate_Reverse_Polish_Notation
    {

        // Your runtime beats 94.51 % of csharp submissions.
        public int EvalRPN(string[] tokens)
        {

            Stack<int> stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (token == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (token == "-")
                {
                    stack.Push(-stack.Pop() + stack.Pop());
                }
                else if (token == "*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (token == "/")
                {
                    int num = stack.Pop(), num2 = stack.Pop();
                    stack.Push(num2 / num);
                }
                else
                {
                    stack.Push(int.Parse(token));
                }
            }

            return stack.Pop();
        }

    }
}
