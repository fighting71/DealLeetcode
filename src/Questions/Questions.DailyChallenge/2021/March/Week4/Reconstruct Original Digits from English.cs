using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/29/2021 10:30:26 AM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3687/
    /// @des : 
    ///     给定一个非空字符串，其中包含无序的数字0-9的英文表示形式(顺序不固定)，按升序输出这些数字。
    ///     【技巧性】
    /// </summary>
    public class Reconstruct_Original_Digits_from_English
    {

        public string[] Map = new[] {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "even",
            "eight",
            "nine",
        };

        private static MatchItem[] _MatchRules;

        private class MatchItem
        {
            public char Key { get; set; }
            public int[] Counter { get; set; }
            public int Num { get; set; }
            public string Str { get; set; }
        }

        static Reconstruct_Original_Digits_from_English()
        {
            // 构建匹配规则

            // index -> 表示匹配优先级，例如：必须先匹配0再匹配1
            // 根据字母重复数进行构建
            _MatchRules = new MatchItem[]
            {
                new MatchItem(){ Key = 'z', Num = 0, Str = "zero" },
                new MatchItem(){ Key = 'x', Num = 6, Str = "six" },
                new MatchItem(){ Key = 'w', Num = 2, Str = "two" },
                new MatchItem(){ Key = 'u', Num = 4, Str = "four" },
                new MatchItem(){ Key = 'g', Num = 8, Str = "eight" },
                                                     
                new MatchItem(){ Key = 'f', Num = 5, Str = "five" },
                new MatchItem(){ Key = 'v', Num = 7, Str = "even" },
                new MatchItem(){ Key = 't', Num = 3, Str = "three" },
                new MatchItem(){ Key = 'o', Num = 1, Str = "one" },
                new MatchItem(){ Key = 'n', Num = 9, Str = "nine" },
            };

            foreach (var item in _MatchRules)
            {
                item.Counter = GetCounter(item.Str);
            }

        }

        // Runtime: 96 ms
        // Memory Usage: 31.5 MB
        public string OriginalDigits(string s)
        {
            int[] counter = GetCounter(s);

            int[] numCounter = new int[10];

            foreach (var rule in _MatchRules)
            {
                var key = rule.Key - 'a';
                if (counter[key] > 0)
                {
                    int count = numCounter[rule.Num] = counter[key] / rule.Counter[key];
                    for (int i = 0; i < 26; i++)
                    {
                        if (rule.Counter[i] > 0)
                        {
                            counter[i] -= rule.Counter[i] * count;
                        }
                    }
                }
            }

            StringBuilder res = new StringBuilder();

            for (int i = 0; i < numCounter.Length; i++)
            {
                int count = numCounter[i];
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        res.Append(i);
                    }
                }
            }

            return res.ToString();
        }

        private static int[] GetCounter(string s)
        {
            int[] counter = new int[26];

            foreach (var c in s)
            {
                counter[c - 'a']++;
            }

            return counter;
        }

    }
}
