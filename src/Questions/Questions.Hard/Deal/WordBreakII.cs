using Command.Const;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/19/2020 5:36:49 PM
    /// @source : https://leetcode.com/problems/word-break-ii/
    /// @des : 
    /// </summary>
    [Obsolete("time limit,no thinking")]
    [Description(nameof(FlagConst.DFS))]
    public class WordBreakII
    {

        #region Other Solution

        public List<String> OtherSolution(String s, IList<string> wordDict)
        {
            return DFS(s, wordDict, new Dictionary<String, List<String>>());
        }

        // DFS function returns an array including all substrings derived from s.
        List<String> DFS(String s, IList<string> wordDict, Dictionary<String, List<String>> map)
        {
            if (map.ContainsKey(s))
                return map[s];

            List<String> res = new List<String>();
            if (s.Length == 0)
            {
                res.Add("");
                return res;
            }
            foreach (String word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    List<String> sublist = DFS(s.Substring(word.Length), wordDict, map);
                    foreach (String sub in sublist)
                        res.Add(word + (sub == "" ? "" : " ") + sub);
                }
            }
            map.Add(s, res);
            return res;
        }

        #endregion

        IList<string> res;

        //"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        //["aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa","ba"]

        // Time Limit Exceeded
        public IList<string> Simple(string s, IList<string> wordDict)
        {

            ISet<char> set = new HashSet<char>();

            foreach (var item in wordDict)
            {
                foreach (var c in item)
                {
                    set.Add(c);
                }
            }

            foreach (var c in s)
            {
                if (!set.Contains(c)) return res;
            }

            res = new List<string>();
            Help(s, 0, wordDict, new List<string>());
            return res;
        }

        private void Help(string s, int i, IList<string> wordDict, IList<string> builder)
        {

            if (i == s.Length)
            {
                res.Add(string.Join(' ', builder));
                return;
            }

            for (int j = 0; j < wordDict.Count; j++)
            {
                if (IsMatch(s, wordDict[j], i))
                {
                    builder.Add(wordDict[j]);
                    Help(s, i + wordDict[j].Length, wordDict, builder);
                    builder.RemoveAt(builder.Count - 1);
                }
            }

        }

        private bool IsMatch(string s, string t, int i)
        {

            if (s.Length - i < t.Length) return false;

            for (int j = 0; j < t.Length; j++)
            {
                if (s[i + j] != t[j]) return false;
            }

            return true;
        }

    }
}
