using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/24/2020 6:37:31 PM
    /// @source : https://leetcode.com/explore/featured/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3542/
    /// @des : 
    /// </summary>
    public class Basic_Calculator_II
    {

        // 直接存变量没stack高效...
        public int Clear(string s)
        {
            int num = 0;
            int prev = 1, prev2 = 0;
            bool isMul = true, isAdd = true;

            int GetNumWithAllOpt(int num) => isAdd ? prev2 + GetNum(num) : prev2 - GetNum(num);
            int GetNum(int num) => isMul ? num * prev : prev / num;

            foreach (var c in s)
            {
                if (c == ' ') continue;
                if (c >= '0' && c <= '9') num = num * 10 + c - '0';
                else if (c == '+')
                {
                    prev2 = GetNumWithAllOpt(num);
                    isAdd = true;
                    isMul = true;
                    prev = 1;
                    num = 0;
                }
                else if (c == '-')
                {
                    prev2 = GetNumWithAllOpt(num);
                    isAdd = false;
                    isMul = true;
                    prev = 1;
                    num = 0;
                }
                else if (c == '*')
                {
                    prev = GetNum(num);
                    isMul = true;
                    num = 0;
                }
                else if (c == '/')
                {
                    prev = GetNum(num);
                    isMul = false;
                    num = 0;
                }
            }
            return GetNumWithAllOpt(num);
        }

        // Your runtime beats 76.74 % of
        public int Optimize(string s)
        {
            int num = 0;
            int prev = 1,addPrev = 0;
            bool isMul = true,isAdd = true;

            int GetNumWithAllOpt(int num)
            {
                if (isMul)
                    num *= prev;
                else
                    num = prev / num;
                if (isAdd)
                    num += addPrev;
                else num = addPrev - num;
                return num;
            }
            int GetNum(int num)
            {
                if (isMul)
                    num *= prev;
                else
                    num = prev / num;
                return num;
            }

            foreach (var c in s)
            {
                if (c == ' ') continue;
                if (c >= '0' && c <= '9')
                {
                    num = num * 10 + c - '0';
                }
                else if (c == '+')
                {
                    addPrev = GetNumWithAllOpt(num);
                    isAdd = true;
                    isMul = true;
                    prev = 1;
                    num = 0;
                }
                else if (c == '-')
                {
                    addPrev = GetNumWithAllOpt(num);
                    isAdd = false;
                    isMul = true;
                    prev = 1;
                    num = 0;
                }
                else if (c == '*')
                {
                    prev = GetNum(num);
                    isMul = true;
                    num = 0;
                }
                else if (c == '/')
                {
                    prev = GetNum(num);
                    isMul = false;
                    num = 0;
                }
            }
            return GetNumWithAllOpt(num);
        }

        // Your runtime beats 89.66 % of csharp submissions
        // ahaha 
        public int Calculate(string s)
        {
            int num = 0;
            Stack<(int, Opt)> stack = new Stack<(int, Opt)>();
            foreach (var c in s)
            {
                if (c == ' ') continue;
                if (c >= '0' && c <= '9')
                {
                    num = num * 10 + c - '0';
                }
                else if (c == '+')
                {
                    stack.Push((GetNum(stack, num), Opt.Add));
                    num = 0;
                }
                else if (c == '-')
                {
                    stack.Push((GetNum(stack, num), Opt.Reduce));
                    num = 0;
                }
                else if (c == '*')
                {
                    stack.Push((GetNum2(stack, num), Opt.Mul));
                    num = 0;
                }
                else if (c == '/')
                {
                    stack.Push((GetNum2(stack, num), Opt.Divide));
                    num = 0;
                }
            }
            return GetNum(stack, num);
        }

        public enum Opt
        {
            Add,
            Reduce,
            Mul,
            Divide
        }

        private int GetNum(Stack<(int, Opt)> stack, int num)
        {
            while (stack.Count > 0)
            {
                (int, Opt) item = stack.Pop();

                if (item.Item2 == Opt.Add)
                {
                    num += item.Item1;
                }
                else if (item.Item2 == Opt.Reduce)
                {
                    num = item.Item1 - num;
                }
                else if (item.Item2 == Opt.Mul)
                {
                    num *= item.Item1;
                }
                else if (item.Item2 == Opt.Divide)
                {
                    num = item.Item1 / num;
                }
            }
            return num;
        }

        private int GetNum2(Stack<(int, Opt)> stack, int num)
        {
            while (stack.Count > 0)
            {
                (int, Opt) item = stack.Pop();

                if (item.Item2 == Opt.Add)
                {
                    stack.Push(item);
                    break;
                }
                else if (item.Item2 == Opt.Reduce)
                {
                    stack.Push(item);
                    break;
                }
                else if (item.Item2 == Opt.Mul)
                {
                    num *= item.Item1;
                }
                else if (item.Item2 == Opt.Divide)
                {
                    num = item.Item1 / num;
                }
            }
            return num;
        }
    }
}
