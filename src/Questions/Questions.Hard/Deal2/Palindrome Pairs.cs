using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/17/2020 5:51:37 PM
    /// @source : https://leetcode.com/problems/palindrome-pairs/
    /// @des : 
    ///     获取所有 {i,j} (i != j) 令 words[i] + words[j] 是回文数
    /// </summary>
    [Obsolete]
    [Favorite("结构设计相关")]
    public class Palindrome_Pairs
    {

        //1 <= words.length <= 5000
        //0 <= words[i].length <= 300
        //words[i] consists of lower-case English letters.

        // 因为words中的每个元素与其他元素都要进行比较一遍(穷举所有可能)，该如何缩短这个比较的过程?

        public IList<IList<int>> Try3(string[] words)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int len = words.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    
                }
            }
            return res;
        }

        // 貌似耗时更久
        public IList<IList<int>> Try2(string[] words)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int len = words.Length;

            bool[][] cache = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                cache[i] = new bool[26];
                for (int j = 0; j < words[i].Length; j++)
                {
                    cache[i][words[i][j] - 'a'] = !cache[i][words[i][j] - 'a'];
                }
            }

            bool ExistsPalindrome(int i, int j)
            {
                bool isEvenLen = (words[i].Length + words[j].Length) % 2 == 0;

                bool hasDiff = false;

                for (int k = 0; k < 26; k++)
                {
                    if (cache[i][k] != cache[j][k])
                    {
                        if (isEvenLen || hasDiff) return false;
                        hasDiff = true;
                    }
                }

                return true;
            }
            ISet<(int, int)> skip = new HashSet<(int, int)>();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j || skip.Contains((j, i))) continue;
                    if (!ExistsPalindrome(i, j))
                    {
                        skip.Add((j, i));
                    }
                    else if (IsPalindrome(words[i], words[j])) res.Add(new[] { i, j });
                }
            }

            return res;

        }


        // Runtime: 1096 ms, faster than 6.82% of C# online submissions for Palindrome Pairs.
        // Memory Usage: 39 MB, less than 100.00% of C# online submissions for Palindrome Pairs.
        // 意料之中，n^2 * (x)
        public IList<IList<int>> Simple(string[] words)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int len = words.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j) continue;
                    if (IsPalindrome(words[i], words[j])) res.Add(new[] { i, j });
                }
            }

            return res;

        }

        private bool IsPalindrome(string v1, string v2)
        {
            int len = v1.Length + v2.Length;

            for (int i = 0; i < len/2; i++)
            {
                if (
                    (i >= v1.Length ? v2[i - v1.Length] : v1[i]) !=
                    (i >= v2.Length ? v1[v1.Length - 1 - i + v2.Length] : v2[v2.Length - 1 - i])
                    )
                {
                    return false;
                }
            }
            return true;
        }

    }
}
