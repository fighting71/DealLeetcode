using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/28 15:21:19
    /// @source : https://leetcode.com/problems/regular-expression-matching/
    /// @des : 实现正则中的.和*的匹配
    /// </summary>
    public class IsMatch
    {
        public bool Solution(string s, string p)
        {
            if (p.Equals(".*")) return true;
            List<char> chars = new List<char>();
            List<int> needNum = new List<int>();

            foreach (var c in s)
            {
                if (chars.Count > 0 && chars[chars.Count - 1] == c) needNum[needNum.Count - 1]++;
                else
                {
                    chars.Add(c);
                    needNum.Add(1);
                }
            }

            List<MatchModel> list = new List<MatchModel>();

            foreach (var c in p)
            {
                if (c == '.')
                {
                    list.Add(new MatchModel() {AnyChar = true, MinNum = 1});
                }
                else if (c == '*')
                {
                    list[list.Count - 1].AnyNum = true;
                    list[list.Count - 1].MinNum--;
                }
                else
                {
                    if (list.Count > 0 && list[list.Count - 1].Char == c)
                    {
                        list[list.Count - 1].MinNum++;
                    }
                    else
                    {
                        list.Add(new MatchModel() {MinNum = 1, Char = c});
                    }
                }
            }

            return Helper(chars, needNum, list, 0, 0);
        }

        private bool Helper(List<char> chars, List<int> nums, List<MatchModel> list, int i, int j)
        {
            bool overStr = chars.Count == i, overMatch = list.Count == j;
            if (overStr && overMatch) return true;
            if (overStr)
            {
                for (; j < list.Count; j++)
                {
                    if (list[j].MinNum > 0) return false;
                }

                return true;
            }

            if (overMatch) return false;

            if (list[j].Char == chars[i])
            {
                if (list[j].MinNum == 0)
                    return Helper(chars, nums, list, i, j + 1) || Helper(chars, nums, list, i + 1, j + 1);

                if (list[j].AnyNum)
                {
                    if (nums[i] >= list[j].MinNum)
                        return Helper(chars, nums, list, i + 1, j + 1);

                    return false;
                }

                if (nums[i] == list[j].MinNum)
                    return Helper(chars, nums, list, i + 1, j + 1);

                return false;
            }

            if (list[j].AnyChar)
            {
                
                // complex.... >>> next fix

                return false;
            }

            if (list[j].MinNum == 0)
                return Helper(chars, nums, list, i, j + 1);

            return false;
        }

        #region try

        class MatchModel
        {
            public bool AnyNum { get; set; }
            public bool AnyChar { get; set; }
            public int MinNum { get; set; }
            public char Char { get; set; }
        }

        // bug 
        public bool Try(string s, string p)
        {
            List<char> chars = new List<char>();
            List<int> needNum = new List<int>();

            foreach (var c in s)
            {
                if (chars.Count > 0 && chars[chars.Count - 1] == c) needNum[needNum.Count - 1]++;
                else
                {
                    chars.Add(c);
                    needNum.Add(1);
                }
            }

            List<MatchModel> list = new List<MatchModel>();

            foreach (var c in p)
            {
                if (c == '.')
                {
                    list.Add(new MatchModel() {AnyChar = true, MinNum = 1});
                }
                else if (c == '*')
                {
                    list[list.Count - 1].AnyNum = true;
                    list[list.Count - 1].MinNum--;
                }
                else
                {
                    if (list.Count > 0 && list[list.Count - 1].Char == c)
                    {
                        list[list.Count - 1].MinNum++;
                    }
                    else
                    {
                        list.Add(new MatchModel() {MinNum = 1, Char = c});
                    }
                }
            }

            // a*b*a*c
            // aabbaac
            var j = 0;
            for (int i = 0; i < chars.Count; i++)
            {
                while (j < list.Count && list[j].MinNum == 0)
                {
                    j++;
                }

                if (list[j].AnyChar || list[j].Char == chars[i])
                {
                }
            }

            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MinNum == 0)
                {
                    if (list[i].AnyChar || list[i].Char == chars[j]) flag = true;
                    continue;
                }

                if (j == s.Length)
                {
                    if (i < list.Count - 1) return false;
                    return true;
                }

                if (list[i].Char == chars[j] || list[i].AnyChar)
                {
                    if (list[i].AnyNum)
                    {
                        if (list[i].MinNum <= needNum[j])
                        {
                            j++;
                        }
                        else
                            return false;
                    }
                    else if (list[i].MinNum == needNum[j])
                    {
                        j++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (flag)
                {
                    j++;
                }
                else
                {
                    return false;
                }

                flag = false;
            }

            return j == s.Length || (flag && j == s.Length - 1);
        }

        #endregion
    }
}