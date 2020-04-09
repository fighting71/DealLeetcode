using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/8/2020 4:40:11 PM
    /// @source : https://leetcode.com/problems/expression-add-operators/
    /// @des : 
    /// </summary>
    [Obsolete("来日再战...")]
    public class Expression_Add_Operators
    {

        public IList<string> Simple(string num, int target)
        {
            IList<string> res = new List<string>();

            Help(num, 1, target, num[0] + "", res);

            return res;
        }


        // bug : "232" , 8 [可达鸭眉头一紧，发现事情并不简单....]
        private void Help(string str,int index,int target,string builder,int num,IList<string> res)
        {
            if (index == str.Length)
            {
                if (num == target) res.Add(builder);
                return;
            }
            var number = str[index] - '0';

            Help(str, index + 1, target, builder + "+" + number, num + number, res);
            Help(str, index + 1, target, builder + "-" + number, num - number, res);
            Help(str, index + 1, target, builder + "*" + number, num * number, res);
            Help(str, index + 1, target, builder + "/" + number, num / number, res);

        }

        // bug : 105 , 5  expected - ["1*0+5","10-5"]
        private void Help(string str, int index, int target, string builder, IList<string> res)
        {
            if (index == str.Length)
            {
                if (ParseExpression(builder, 0) == target) res.Add(builder);
                return;
            }
            var number = str[index] - '0';

            Help(str, index + 1, target, builder + "+" + number, res);
            Help(str, index + 1, target, builder + "-" + number, res);
            Help(str, index + 1, target, builder + "*" + number, res);

        }

        // bug
        private int ParseExpression(string expression,int index)
        {
            // 1 + 2 + 3
            Stack<int> stack = new Stack<int>();
            Stack<bool> flagStack = new Stack<bool>();

            stack.Push(expression[0] - '0');

            for (int i = 2; i < expression.Length; i+= 2)
            {
                var number = expression[i] - '0';

                if (expression[i - 1] == '*')
                {
                    stack.Push(stack.Pop() * number);
                }
                else
                {
                    stack.Push(number);
                    flagStack.Push(expression[i - 1] == '+');
                }
            }

            while(flagStack.Count > 0)
            {
                stack.Push(stack.Pop() + (flagStack.Pop() ? stack.Pop(): -stack.Pop()));
            }

            return stack.Pop();
        }

    }
}
