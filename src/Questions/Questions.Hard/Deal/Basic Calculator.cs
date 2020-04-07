using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/7/2020 4:20:36 PM
    /// @source : https://leetcode.com/problems/basic-calculator/
    /// @des : 
    /// </summary>
    public class Basic_Calculator
    {

        /// <summary>
        /// Runtime: 112 ms, faster than 31.82% of C# online submissions for Basic Calculator.
        /// Memory Usage: 23.9 MB, less than 100.00% of C# online submissions for Basic Calculator.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RecursionSolution(string s)
        {
            int i = 0;
            return Help(s, ref i);
        }

        private int Help(string s, ref int index)
        {
            int res = 0, num = 0;
            bool isAdd = true;

            for (; index < s.Length; index++)
            {

                if (s[index] == ' ') continue;
                if (s[index] == '(')
                {
                    index++;
                    if (isAdd) res += Help(s, ref index);
                    else res -= Help(s, ref index);
                    isAdd = true;
                }
                else if (s[index] == ')') break;
                else if (s[index] == '+')
                {
                    if (isAdd) res += num;
                    else res -= num;
                    num = 0;
                    isAdd = true;
                }
                else if (s[index] == '-')
                {
                    if (isAdd) res += num;
                    else res -= num;
                    num = 0;
                    isAdd = false;
                }
                else num = num * 10 + s[index] - '0';

            }

            return isAdd ? res + num : res - num;
        }

        /// <summary>
        /// Runtime: 80 ms, faster than 70.13% of C# online submissions for Basic Calculator.
        /// Memory Usage: 24 MB, less than 100.00% of C# online submissions for Basic Calculator.
        /// 
        /// Runtime: 72 ms, faster than 98.05% of C# online submissions for Basic Calculator.
        /// Memory Usage: 24.4 MB, less than 100.00% of C# online submissions for Basic Calculator.
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int StackSolution(string s)
        {

            int num = 0;
            bool isAdd = true;

            Stack<bool> flagStack = new Stack<bool>();
            Stack<int> numStack = new Stack<int>();

            numStack.Push(0);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                if (s[i] == '(')
                {
                    flagStack.Push(isAdd);
                    numStack.Push(num);
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == ')')
                {
                    num = numStack.Pop() + (isAdd ? num : -num);
                    numStack.Push(numStack.Pop() + (flagStack.Pop() ? num : -num));
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == '+')
                {
                    numStack.Push(numStack.Pop() + (isAdd ? num : -num));
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == '-')
                {
                    numStack.Push(numStack.Pop() + (isAdd ? num : -num));
                    num = 0;
                    isAdd = false;
                }
                else
                    num = num * 10 + s[i] - '0';
            }

            return numStack.Pop() + (isAdd ? num : -num);
        }

        /// <summary>
        /// Runtime: 80 ms, faster than 70.13% of C# online submissions for Basic Calculator.
        /// Memory Usage: 23.9 MB, less than 100.00% of C# online submissions for Basic Calculator.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int ListSolution(string s)
        {

            int num = 0;
            bool isAdd = true;

            Stack<bool> flagStack = new Stack<bool>();
            List<int> list = new List<int>();

            list.Add(0);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                if (s[i] == '(')
                {
                    flagStack.Push(isAdd);
                    list.Insert(0,num);
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == ')')
                {
                    num = list[0] + (isAdd ? num : -num);
                    list.RemoveAt(0);
                    list[0] +=(flagStack.Pop() ? num : -num);
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == '+')
                {
                    list[0] += isAdd ? num : -num;
                    num = 0;
                    isAdd = true;
                }
                else if (s[i] == '-')
                {
                    list[0] += isAdd ? num : -num;
                    num = 0;
                    isAdd = false;
                }
                else
                    num = num * 10 + s[i] - '0';
            }

            return list[0] + (isAdd ? num : -num);
        }

    }
}
