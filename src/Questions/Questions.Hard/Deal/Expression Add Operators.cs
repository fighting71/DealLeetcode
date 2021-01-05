using Command.Attr;
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
    public class Expression_Add_Operators
    {

        #region combination
        public IList<string> Try3(string num, int target)
        {
            _res = new List<string>();
            _target = target;
            int len = num.Length;
            if (len == 0) return _res;
            Help(num, 1, new Stack<(long, Opt)>(), num[0] - '0', new Opt[len - 1]);
            Console.WriteLine("_maxStackCount:"+ _maxStackCount);
            return _res;
        }

        int _maxStackCount = 0;
        // Runtime: 416 ms, faster than 61.98%
        // optimize direction : 避免stack复制. 将递归进行替换~
        private void Help(string str, int index, Stack<(long, Opt)> stack, long num, Opt[] opts)
        {

            if (index == str.Length)
            {
                if (GetNum(stack, num) == _target)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(str[0]);
                    for (int i = 0; i < opts.Length; i++)
                    {
                        if (opts[i] == Opt.Add) builder.Append('+');
                        else if (opts[i] == Opt.Reduce) builder.Append('-');
                        else if (opts[i] == Opt.Mul) builder.Append('*');
                        builder.Append(str[i + 1]);
                    }
                    _res.Add(builder.ToString());
                }
                return;
            }
            _maxStackCount = Math.Max(_maxStackCount, stack.Count);
            var number = str[index] - '0';
            #region +
            opts[index - 1] = Opt.Add;
            Stack<(long, Opt)> clone = Clone(stack);
            clone.Push((GetNum(clone, num), Opt.Add));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region -
            opts[index - 1] = Opt.Reduce;
            clone = Clone(stack);
            clone.Push((GetNum(clone, num), Opt.Reduce));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region *
            opts[index - 1] = Opt.Mul;
            clone = Clone(stack);
            clone.Push((num, Opt.Mul));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region nothing
            if (num != 0)
            {
                opts[index - 1] = Opt.Default;
                Help(str, index + 1, stack, num * 10 + number, opts);
            }
            #endregion

        }

        private Stack<(long, Opt)> Clone(Stack<(long, Opt)> stack)
        {
            if (stack.Count == 0) return new Stack<(long, Opt)>();

            (long, Opt)[] arr = stack.ToArray();
            Stack<(long, Opt)> clone = new Stack<(long, Opt)>();
            for (int i = 0; i < arr.Length; i++)
            {
                clone.Push(arr[arr.Length - 1 - i]);
            }
            return clone;

        }

        // bug... new Stack<(long, Opt)>(stack)会将stack倒序
        private void BugHelp(string str, int index, Stack<(long, Opt)> stack, long num, Opt[] opts)
        {

            if (index == str.Length)
            {
                if (GetNum(stack, num) == _target)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(str[0]);
                    for (int i = 0; i < opts.Length; i++)
                    {
                        if (opts[i] == Opt.Add) builder.Append('+');
                        else if (opts[i] == Opt.Reduce) builder.Append('-');
                        else if (opts[i] == Opt.Mul) builder.Append('*');
                        builder.Append(str[i+1]);
                    }
                    _res.Add(builder.ToString());
                }
                return;
            }
            var number = str[index] - '0';
            long cache;
            #region +
            opts[index - 1] = Opt.Add;
            Stack<(long, Opt)> clone = new Stack<(long, Opt)>(stack);
            clone.Push(((cache = GetNum(clone, num)), Opt.Add));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region -
            opts[index - 1] = Opt.Reduce;
            clone = new Stack<(long, Opt)>(stack);
            clone.Push(((cache = GetNum(clone, num)), Opt.Reduce));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region *
            opts[index - 1] = Opt.Mul;
            clone = new Stack<(long, Opt)>(stack);
            clone.Push((num, Opt.Mul));
            Help(str, index + 1, clone, number, opts);
            #endregion

            #region nothing
            if(num != 0)
            {
                opts[index - 1] = Opt.Default;
                Help(str, index + 1, stack, num * 10 + number, opts);
            }
            #endregion

        }

        #endregion

        /// <summary>
        /// 操作
        /// </summary>
        private enum Operation
        {
            /// <summary>
            /// 无操作
            /// </summary>
            None = 0,
            /// <summary>
            /// 相加
            /// </summary>
            Add = 1,
            /// <summary>
            /// 相减
            /// </summary>
            Reduce = 2,
            /// <summary>
            /// 乘以
            /// </summary>
            Mult = 3
        }

        // 0 <= num.length <= 10
        // num only contain digits.

        // Runtime: 736 ms, faster than 5.79% of C# online submissions for Expression Add Operators.
        // Memory Usage: 33.9 MB, less than 98.35% of C# online submissions for Expression Add Operators.
        // 过了过了！！！ 只能说 Basic_Calculator 做得还行...
        // 先计算所有可能，然后解析所有可能...
        public IList<string> Try2(string num, int target)
        {
            _res = new List<string>();

            if (num.Length == 0) return _res;

            _target = target;

            Help(num, 1, num[0] + "",num[0]-'0');

            return _res;

        }

        #region 

        private void Help(string str, int index, string builder, int num)
        {
            if (index == str.Length)
            {
                if (Calculate(builder) == _target)
                {
                    _res.Add(builder);
                }
                return;
            }
            var number = str[index] - '0';

            Help(str, index + 1, builder + "+" + number, number);
            Help(str, index + 1, builder + "-" + number, number);
            Help(str, index + 1, builder + "*" + number, number);
            if (num != 0)// 不允许前导0  例如 : 05 ...
                Help(str, index + 1, builder + number, num * 10 + number);

        }
        #endregion

        private int _target;
        private IList<string> _res;

        #region 来自其他题的解决方案...

        public long Calculate(string s)
        {
            long num = 0;
            Stack<(long, Opt)> stack = new Stack<(long, Opt)>();
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
            }
            return GetNum(stack, num);
        }

        public enum Opt
        {
            Default,
            Add,
            Reduce,
            Mul,
        }

        private long GetNum(Stack<(long, Opt)> stack, long num)
        {
            while (stack.Count > 0)
            {
                (long, Opt) item = stack.Pop();

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
            }
            return num;
        }
        private long GetNum2(Stack<(long, Opt)> stack, long num)
        {
            while (stack.Count > 0 && stack.Peek().Item2 == Opt.Mul)
                num *= stack.Pop().Item1;
            return num;
        }
        #endregion

       

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
