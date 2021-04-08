using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/8/2021 5:53:01 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3701/
    /// @des : 
    /// </summary>
    public class Letter_Combinations_of_a_Phone_Number
    {

        // 0 <= digits.length <= 4
        // digits[i] is a digit in the range['2', '9'].

        static Letter_Combinations_of_a_Phone_Number()
        {
            KeyMap = new char[10][];
            int index = 1;
            char[] chars = new char[3];
            int j = 0;
            for (int i = 0; i < 26; i++)
            {
                chars[j++] = (char)('a' + i);
                if(j == chars.Length)
                {
                    KeyMap[index++] = chars;
                    if (index == 6 || index == 8) chars = new char[4];
                    else chars = new char[3];
                    j = 0;
                }
            }
        }

        static char[][] KeyMap;

        // Your runtime beats 43.74 % 
        public IList<string> LetterCombinations(string digits)
        {
            var len = digits.Length;
            if (len == 0) return new List<string>();
            IList<string> res = new List<string>();

            Help(0, new StringBuilder());

            return res;

            void Help(int i, StringBuilder builder)
            {
                if (i == len)
                {
                    res.Add(builder.ToString());
                    return;
                }

                var curr = KeyMap[digits[i] - '1'];

                foreach (var item in curr)
                {
                    var newBuild = new StringBuilder();
                    newBuild.Append(builder);
                    newBuild.Append(item);
                    Help(i + 1, newBuild);
                }

            }

        }

    }
}
