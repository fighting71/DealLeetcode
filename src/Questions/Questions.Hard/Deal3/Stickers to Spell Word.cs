using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/26/2021 3:04:42 PM
    /// @source : https://leetcode.com/problems/stickers-to-spell-word/
    /// @des : 
    /// We are given N different types of stickers.
    ///     我们收到N种不同的贴纸。
    ///     Each sticker has a lowercase English word on it.
    ///     每个贴纸上都有一个小写的英文单词。
    ///     You would like to spell out the given target string by cutting individual letters from your collection of stickers and rearranging them.
    ///     您想要拼出给定的目标字符串，通过从您的贴纸集合中剪下单独的字母并重新排列它们。
    /// </summary>
    [Obsolete("time limit")]
    public class Stickers_to_Spell_Word
    {

        // stickers has length in the range [1, 50].
        // stickers consists of lowercase English words(without apostrophes).
        //target has length in the range[1, 15], and consists of lowercase English letters.
        //In all test cases, all words were chosen randomly from the 1000 most common US English words, and the target was chosen as a concatenation of two random words.
        //The time limit may be more challenging than usual. It is expected that a 50 sticker test case can be solved within 35ms on average.

        #region other solution
        public int OtherSolution(String[] stickers, String target)
        {
            int m = stickers.Length;
            int[][] mp = new int[m][];
            Dictionary<string, int> dp = new Dictionary<string, int>();
            for (int i = 0; i < m; i++)
            {
                mp[i] = new int[26];
                foreach (char c in stickers[i]) mp[i][c - 'a']++;
            }
            dp.Add("", 0);
            return helper(dp, mp, target);
        }

        private int helper(Dictionary<string, int> dp, int[][] mp, String target)
        {
            // ... 就差这步跳过重复执行 淦！
            if (dp.TryGetValue(target, out var v)) return v;
            int ans = int.MaxValue, n = mp.Length;
            int[] tar = new int[26];
            foreach (char c in target) tar[c - 'a']++;
            // try every sticker
            for (int i = 0; i < n; i++)
            {
                // optimization
                if (mp[i][target[0] - 'a'] == 0) continue;
                StringBuilder sb = new StringBuilder();
                // apply a sticker on every character a-z
                for (int j = 0; j < 26; j++)
                {
                    if (tar[j] > 0)
                        for (int k = 0; k < Math.Max(0, tar[j] - mp[i][j]); k++)
                            sb.Append((char)('a' + j));
                }
                String s = sb.ToString();
                int tmp = helper(dp, mp, s);
                if (tmp != -1) ans = Math.Min(ans, 1 + tmp);
            }
            dp.Add(target, ans == int.MaxValue ? -1 : ans);
            return dp[target];
        }
        #endregion


        class Item
        {
            public int[] Build { get; set; }
            public int Count { get; set; }
        }


        public int Try5(string[] stickers, string target)
        {
            int[] targetCount = GetCount(target);

            int[][] stickersCount = new int[stickers.Length][];

            HashSet<int>[] set = new HashSet<int>[26];

            for (int i = 0; i < 26; i++)
            {
                set[i] = new HashSet<int>();
            }

            for (int i = 0; i < stickers.Length; i++)
            {
                int[] count = new int[26];
                var item = stickers[i];
                foreach (var c in item)
                {
                    var key = c - 'a';

                    if (targetCount[key] > 0)
                    {
                        count[key]++;
                        set[key].Add(i);
                    }
                }
                stickersCount[i] = count;
            }

            for (int i = 0; i < 26; i++)
            {
                if (targetCount[i] > 0 && set[i].Count == 0) return -1;
            }

            int res = int.MaxValue;

            int[] keys = targetCount.Select((item, index) => new { item, index }).Where(u => u.item > 0).OrderBy(u => u.item).Select(u => u.index).ToArray();

            Help(new int[26], 0, 0, 0);

            return res;

            void Help(int[] build,int count,int keyIndex, int minIndex)
            {
                if(keyIndex == keys.Length)
                {
                    res = count;
                    return;
                }
                var key = keys[keyIndex];

                Console.WriteLine("H");
                if (count > res) return;
                int curr = targetCount[key];
                int need = curr - build[key];
                if (need < 1)
                {
                    Help(build, count, keyIndex + 1, 0);
                    return;
                }

                foreach (var index in set[key])
                {
                    Console.WriteLine("set");
                    if (index < minIndex) continue;

                    var counter = stickersCount[index];

                    var st = counter[key];
                    for (int i = need / st + (need % st == 0 ? 0 : 1); i > 0 ; i--)
                    {
                        Console.WriteLine("i");
                        int[] clone = new int[26];
                        Array.Copy(build, clone, 26);
                        for (int j = 0; j < 26; j++)
                        {
                            clone[j] += counter[j] * i;
                        }
                        Help(clone, count + i, keyIndex, index + 1);
                    }

                }

            }

        }

        public int Try4(string[] stickers, string target)
        {
            int[] targetCount = GetCount(target);

            int[][] stickersCount = new int[stickers.Length][];

            HashSet<int>[] set = new HashSet<int>[26];

            for (int i = 0; i < 26; i++)
            {
                set[i] = new HashSet<int>();
            }

            for (int i = 0; i < stickers.Length; i++)
            {
                int[] count = new int[26];
                var item = stickers[i];
                foreach (var c in item)
                {
                    var key = c - 'a';

                    if (targetCount[key] > 0)
                    {
                        count[key]++;
                        set[key].Add(i);
                    }
                }
                stickersCount[i] = count;
            }

            for (int i = 0; i < 26; i++)
            {
                if (targetCount[i] > 0 && set[i].Count == 0) return -1;
            }

            Queue<Item> next = new Queue<Item>();
            Queue<Item> curr = new Queue<Item>();

            curr.Enqueue(new Stickers_to_Spell_Word.Item()
            {
                Build = new int[26],
                Count = 0
            });

            for (int i = 0; i < 26; i++)
            {
                if (targetCount[i] == 0) continue;

                while (curr.Count > 0)
                {
                    Help(curr.Dequeue(), i, 0, next);
                }

                var empty = next;
                next = curr;
                curr = empty;

            }

            return curr.Min(u => u.Count);

            void Help(Item item, int key, int minIndex,Queue<Item> queue)
            {
                int curr = targetCount[key];
                int need = curr - item.Build[key];
                if (need < 1)
                {
                    queue.Enqueue(item);
                    return;
                }

                foreach (var index in set[key])
                {
                    if (index < minIndex) continue;

                    var st = stickersCount[index][key];
                    for (int i = 1; i <= need / st + (need % st == 0 ? 0 : 1); i++)
                    {
                        var clone = new Item
                        {
                            Build = new int[26],
                            Count = item.Count + i
                        };

                        Array.Copy(item.Build, clone.Build, 26);
                        for (int j = 0; j < 26; j++)
                        {
                            clone.Build[j] += stickersCount[index][j] * i;
                        }
                        Help(clone, key, index + 1, queue);
                    }

                }

            }

        }

        // more slow
        public int Try3(string[] stickers, string target)
        {

            Dictionary<char, int> targetDic = GetCharCountDic(target);

            HashSet<int>[] list = new HashSet<int>[26];

            for (int i = 0; i < 26; i++)
            {
                list[i] = new HashSet<int>();
            }

            for (int i = 0; i < stickers.Length; i++)
            {
                foreach (var item in stickers[i])
                {
                    list[item - 'a'].Add(i);
                }
            }

            int res = Help(targetDic, 0);

            return res == int.MaxValue ? -1 : res;

            int Help(Dictionary<char, int> counter, int count)
            {
                if (counter.Count == 0) return count;

                bool[] visited = new bool[stickers.Length];

                int res = int.MaxValue;

                foreach (var pair in counter)
                {
                    foreach (var item in list[pair.Key - 'a'])
                    {
                        if (visited[item]) continue;
                        visited[item] = true;
                        var match = stickers[item];
                        var clone = new Dictionary<char, int>(counter);
                        foreach (var c in match)
                        {
                            if (clone.ContainsKey(c) && --clone[c] == 0)
                            {
                                clone.Remove(c);
                            }
                        }
                        res = Math.Min(res, Help(clone, count + 1));
                    }
                }

                return res;
            }

        }

        // more slow
        public int Try2(string[] stickers, string target)
        {

            int[] counter = GetCount(target);

            HashSet<int>[] list = new HashSet<int>[26];

            for (int i = 0; i < 26; i++)
            {
                list[i] = new HashSet<int>();
            }

            for (int i = 0; i < stickers.Length; i++)
            {
                foreach (var item in stickers[i])
                {
                    list[item - 'a'].Add(i);
                }
            }

            int res = Help(counter, 0, target.Length);

            return res == int.MaxValue ? -1 : res;

            int Help(int[] counter, int count,int need)
            {
                if (need == 0) return count;

                bool[] visited = new bool[stickers.Length];

                int res = int.MaxValue;

                int oldNeed = need;

                for (int i = 0; i < 26; i++)
                {
                    if(counter[i] > 0)
                    {
                        foreach (var item in list[i])
                        {
                            if (visited[item]) continue;

                            need = oldNeed;
                            visited[item] = true;

                            var match = stickers[item];

                            foreach (var c in match)
                            {
                                if(--counter[c-'a'] >= 0)
                                {
                                    need--;
                                }
                            }
                            res = Math.Min(res, Help(counter, count + 1, need));

                            // recover
                            foreach (var c in match)
                            {
                                counter[c - 'a']++;
                            }

                        }
                    }
                }
                return res;
            }

        }

        // time limit
        public int Simple(string[] stickers, string target)
        {
            Console.WriteLine("Simple");
            Dictionary<int, int> targetDic = GetCountDic(target);

            Dictionary<int, int>[] cardDic = stickers.Select(u => GetCountDic(u)).ToArray();

            int res = Help(targetDic, 0);

            return res == int.MaxValue ? -1 : res;

            int Help(Dictionary<int, int> counter, int count)
            {
                if (counter.Count == 0) return count;

                int res = int.MaxValue;

                Dictionary<int, int> clone = null;
                foreach (var item in cardDic)
                {
                    bool match = false;
                    foreach (var sub in item)
                    {
                        if (counter.ContainsKey(sub.Key))
                        {
                            if (!match)
                            {
                                clone = new Dictionary<int, int>(counter);
                            }
                            match = true;
                            if (counter[sub.Key] > sub.Value)
                            {
                                counter[sub.Key] -= sub.Value;
                            }
                            else
                            {
                                counter.Remove(sub.Key);
                            }
                        }
                    }
                    if (match)
                    {
                        res = Math.Min(res, Help(counter, count + 1));
                        counter = clone;
                    }
                }

                return res;

            }
        }

        private Dictionary<char, int> GetCharCountDic(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>(26);

            foreach (var c in str)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }
            return dic;

        }

        private Dictionary<int,int> GetCountDic(string str)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>(26);

            foreach (var c in str)
            {
                var key = c - 'a';
                if (dic.ContainsKey(key)) dic[key]++;
                else dic[key] = 1;
            }
            return dic;

        }

        private int[] GetCount(string str)
        {
            int[] count = new int[26];

            foreach (var c in str)
            {
                count[c - 'a']++;
            }
            return count;
        }

    }
}
