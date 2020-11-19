using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 5:43:25 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3536/
    /// @des : 
    /// </summary>
    public class Decode_String
    {

        //1 <= s.length <= 30
        // s consists of lowercase English letters, digits, and square brackets '[]'.
        // s is guaranteed to be a valid input.
        // All the integers in s are in the range [1, 300].

        // Runtime: 88 ms
        // Memory Usage: 23.2 MB
        // 使用Stack替代recursion，但效率更慢...
        public string Solution2(string s)
        {
            Stack<(StringBuilder, int)> stack = new Stack<(StringBuilder, int)>();
            StringBuilder curr = new StringBuilder(),prev;
            int count = 0,prevCount;
            for (var index = 0; index < s.Length; index++)
            {
                var c = s[index];
                if (c >= '0' && c <= '9')
                {
                    count = count * 10 + (c - '0');
                }
                else if (c == '[')
                {
                    stack.Push((curr, count));
                    curr = new StringBuilder();
                    count = 0;
                }
                else if (c == ']')
                {
                    (prev, prevCount) = stack.Pop();
                    if(prevCount == 0)
                    {
                        prev.Append(curr);
                    }
                    else
                    {
                        for (int i = 0; i < prevCount; i++)
                        {
                            prev.Append(curr);
                        }
                    }
                    curr = prev;
                    count = 0;
                }
                else
                {
                    curr.Append(c);
                }

            }

            return curr.ToString();
        }

        // Runtime: 80 ms
        // Memory Usage: 23.5 MB
        // Your runtime beats 90.83 % of csharp submissions
        // 以前弄过类似的~~
        public string DecodeString(string s)
        {
            int i = 0;
            return Help(s, ref i);
        }

        private string Help(string s, ref int index)
        {
            StringBuilder builder = new StringBuilder();
            int count = 0;
            for (; index < s.Length; index++)
            {
                var c = s[index];
                if(c >= '0' && c <= '9')
                {
                    count = count * 10 + (c - '0');
                }
                else if(c == '[')
                {
                    index++;
                    var inner = Help(s, ref index);
                    if(count == 0)
                    {
                        builder.Append(inner);
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            builder.Append(inner);
                        }
                    }
                    count = 0;
                }
                else if(c == ']')
                {
                    break;
                }
                else
                {
                    builder.Append(c);
                }

            }

            return builder.ToString();

        }

    }
}
