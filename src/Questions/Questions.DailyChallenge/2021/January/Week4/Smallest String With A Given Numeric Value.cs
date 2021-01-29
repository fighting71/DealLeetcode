using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 11:04:30 AM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3619/
    /// @des : 
    /// </summary>
    public class Smallest_String_With_A_Given_Numeric_Value
    {

        /*
         * summary:
         *  new string(char[]) > string.Concat(char[]) > list.Reverse > builder.Insert(0,char)
         */

        // 1 <= n <= 10^5
        // n <= k <= 26 * n

        // Your runtime beats 68.75 % 
        public string Try4(int n, int k)
        {
            char[] arr = new char[n];
            for (int i = n - 1; i > 0; i--)
            {
                var empty = k - i;

                if (empty > 26)
                {
                    k -= 26;
                    arr[i] = 'z';
                }
                else
                {
                    arr[i] = (char)('a' + empty - 1);
                    for (int j = 0; j < i; j++)
                    {
                        arr[j] = 'a';
                    }
                    return new string(arr);
                }
            }
            arr[0] = (char)('a' + k - 1);
            return new string(arr);
        }

        // Your runtime beats 34.38 %
        public string Try3(int n, int k)
        {
            char[] arr = new char[n];
            for (int i = n - 1; i > 0; i--)
            {
                var empty = k - i;

                if (empty > 26)
                {
                    k -= 26;
                    arr[i] = 'z';
                }
                else
                {
                    arr[i] = (char)('a' + empty - 1);
                    for (int j = 0; j < i; j++)
                    {
                        arr[j] = 'a';
                    }
                    return string.Concat(arr);
                }
            }
            arr[0] = (char)('a' + k - 1);
            return string.Concat(arr);
        }

        // beats 9.38 %
        public string Try2(int n, int k)
        {
            List<char> list = new List<char>(n);
            for (int i = n - 1; i > 0; i--)
            {
                var empty = k - i;

                if (empty > 26)
                {
                    k -= 26;
                    list.Add('z');
                }
                else
                {
                    list.Add((char)('a' + empty - 1));
                    for (int j = 0; j < i; j++)
                    {
                        list.Add('a');
                    }
                    list.Reverse();
                    return string.Concat(list);
                }
            }
            list.Add((char)('a' + k - 1));
            list.Reverse();
            return string.Concat(list);
        }

        // bug:结果未翻转
        public string Try(int n, int k)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = n - 1; i > 0; i--)
            {
                var empty = k - i;

                if (empty > 26)
                {
                    k -= 26;
                    builder.Append('z');
                }
                else
                {
                    builder.Insert(0, (char)('a' + empty - 1));
                    for (int j = 0; j < i; j++)
                    {
                        builder.Append('a');
                    }
                    return builder.ToString();
                }
            }
            builder.Append((char)('a' + k - 1));

            return builder.ToString();
        }

        // time limit => Insert(0 比较耗时
        public string Simple(int n, int k)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = n - 1; i > 0; i--)
            {
                var empty = k - i;

                if(empty > 26)
                {
                    k -= 26;
                    builder.Insert(0, 'z');
                }
                else
                {
                    builder.Insert(0, (char)('a' + empty - 1));
                    k -= empty;
                }
            }

            builder.Insert(0, (char)('a' + k - 1));

            return builder.ToString();
        }

    }
}
