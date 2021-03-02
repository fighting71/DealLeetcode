using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/1/2021 10:04:03 AM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3655/
    /// @des : 
    ///     push(int x)，将整数x压入堆栈。
    ///     pop()，它删除并返回栈中最常见的元素。
    ///         如果最频繁的元素存在多个，则移除最接近堆栈顶部的元素并返回。
    /// </summary>
    public class Maximum_Frequency_Stack
    {

        //Calls to FreqStack.push(int x) will be such that 0 <= x <= 10^9.
        //It is guaranteed that FreqStack.pop() won't be called if the stack has zero elements.
        //The total number of FreqStack.push calls will not exceed 10000 in a single test case.
        //The total number of FreqStack.pop calls will not exceed 10000 in a single test case.
        //The total number of FreqStack.push and FreqStack.pop calls will not exceed 150000 across all test cases.

        Dictionary<int, int> _numMapMaxLen = new Dictionary<int, int>();
        int _maxLen;
        Dictionary<int, Stack<int>> _lenMapStack = new Dictionary<int, Stack<int>>();

        public Maximum_Frequency_Stack()
        {

        }

        //  756 ms 勉强通过.
        public void Push(int x)
        {
            int len;
            if (_numMapMaxLen.ContainsKey(x))
            {
                len = ++_numMapMaxLen[x];
            }
            else
            {
                len = _numMapMaxLen[x] = 1;
            }

            if (_lenMapStack.ContainsKey(len))
            {
                _lenMapStack[len].Push(x);
            }
            else
            {
                var stack = new Stack<int>();
                stack.Push(x);
                _lenMapStack[len] = stack;
            }
            _maxLen = Math.Max(_maxLen, len);
        }

        public int Pop()
        {
            var stack = _lenMapStack[_maxLen];
            if (stack.Count == 1) _maxLen--;
            int res = stack.Pop();
            _numMapMaxLen[res]--;
            return res;
        }

        class Try
        {

            Dictionary<int, List<int>> _dic = new Dictionary<int, List<int>>();

            int _count, _maxCount;

            // time limit
            public void Push1(int x)
            {
                if (_dic.ContainsKey(x)) _dic[x].Add(_count);
                else _dic[x] = new List<int>() { _count };
                _maxCount = Math.Max(_maxCount, _dic[x].Count);
                _count++;
            }

            // time limit
            public int Pop1()
            {
                KeyValuePair<int, List<int>>[] keyValuePairs = _dic.Where(u => u.Value.Count == _maxCount).ToArray();

                if (keyValuePairs.Length == 1)
                {
                    _maxCount--;
                }

                int res = keyValuePairs[0].Key, lastIndex = keyValuePairs[0].Value[^1];

                for (int i = 1; i < keyValuePairs.Length; i++)
                {
                    if (keyValuePairs[i].Value[^1] > lastIndex)
                    {
                        lastIndex = keyValuePairs[i].Value[^1];
                        res = keyValuePairs[i].Key;
                    }
                }

                _dic[res].RemoveAt(_dic[res].Count - 1);
                return res;
            }
        }

    }
}
