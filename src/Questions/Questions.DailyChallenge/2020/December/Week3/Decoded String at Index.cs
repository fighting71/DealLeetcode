using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/21/2020 3:24:38 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3572/
    /// @des : 
    ///     给定一个转义后的字符串，求反转义后的字符串第i个字符
    ///     转义规则:
    ///      若当前字符为字母，则将字符输出到字符串中 
    ///      若当前字符为数字，则将字符串复制(当前数字-1)遍  ha2 -> haha
    /// </summary>
    public class Decoded_String_at_Index
    {

        // 2 <= S.length <= 100
        // S will only contain lowercase letters and digits 2 through 9.
        //S starts with a letter.
        //1 <= K <= 10^9
        //It's guaranteed that K is less than or equal to the length of the decoded string.
        //The decoded string is guaranteed to have less than 2^63 letters.
        public string Simple(string code, int index)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var c in code)
            {
                if (c >= '0' && c <= '9')
                {
                    for (int i = 0; i < c - '1'; i++)
                    {
                        builder.Append(builder);
                    }
                }
                else
                {
                    builder.Append(c);
                }
                if (builder.Length >= index) return builder[index - 1].ToString();
            }

            return builder[index - 1].ToString();
        }

        // Your runtime beats 83.33 %
        public string Try2(string code, int index)
        {
            Dictionary<int, char> dic = new Dictionary<int, char>();

            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            int len = 0;
            bool prevIsNum = false;
            foreach (var c in code)
            {
                if (c >= '0' && c <= '9')
                {
                    if (!prevIsNum)
                        stack.Push(len);
                    len *= c - '0';
                    prevIsNum = true;
                }
                else
                {
                    prevIsNum = false;
                    dic[++len] = c;
                }
                if (len >= index) break;
            }

            if (dic.ContainsKey(index)) return dic[index].ToString();

            while (stack.Count > 0)
            {
                int num = stack.Pop();
                index %= num;
                if (index == 0) return dic[num].ToString();
                if (dic.ContainsKey(index)) return dic[index].ToString();
            }

            return dic[index].ToString();
        }

    }
}
