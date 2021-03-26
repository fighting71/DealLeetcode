using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/22/2021 4:37:35 PM
    /// @source : 
    /// @des : 
    ///     给定一个字典列表wordlist+一个查询列表queries，返回查询结果
    ///     查询步骤:
    ///         将查询元素query放入wordlist中
    ///         其中有两种错误是可忽略的：
    ///             1.大小写不匹配
    ///             2.虽然不同但同属于元音  例如  a = e/i/o/u
    ///     返回优先级:
    ///         若完全相同 直接返回 >
    ///             存在大小写不匹配 返回wordlist中第一个不匹配的单词 >
    ///                 存在元音不匹配 同上返回第一个 >
    ///                     都不匹配 返回空
    /// </summary>
    [Optimize("Slow")]
    public class Vowel_Spellchecker
    {

        // 1 <= wordlist.length <= 5000
        //1 <= queries.length <= 5000
        //1 <= wordlist[i].length <= 7
        //1 <= queries[i].length <= 7

        HashSet<char> _vowels = new HashSet<char>()
        {
            'a','e','i','o','u'
        };

        // 匹配优先级： 完全相同 > 大小写问题 > 元音问题

        public string[] Try2(string[] wordlist, string[] queries)
        {
            int len = queries.Length;
            string[] answer = new string[len];

            Dictionary<string, string> dic = new Dictionary<string, string>();
            ISet<string> set = new HashSet<string>();
            StringBuilder builder = new StringBuilder();
            foreach (var str in wordlist)
            {
                set.Add(str);
                string lower = str.ToLower();
                if (dic.ContainsKey(lower)) continue;
                
                dic[lower] = str;
                string key = GetKey(lower);
                if (!dic.ContainsKey(key))
                    dic[key] = str;
            }

            for (int i = 0; i < len; i++)
            {
                string query = queries[i];
                if (set.Contains(query))
                {
                    answer[i] = query;
                    continue;
                }
                string lower = query.ToLower();
                if(dic.TryGetValue(lower,out var a))
                {
                    answer[i] = a;
                    continue;
                }

                string key = GetKey(lower);
                if(dic.TryGetValue(key,out a))
                {
                    answer[i] = a;
                }
                else
                {
                    answer[i] = string.Empty;
                }
            }

            return answer;

            string GetKey(string str)
            {
                builder.Clear();
                foreach (var c in str)
                    if (_vowels.Contains(c))
                        builder.Append('*');
                    else
                        builder.Append(c);
                return builder.ToString();
            }

        }
        // Runtime: 312 ms
        // Memory Usage: 45.8 MB
        public string[] Try(string[] wordlist, string[] queries)
        {
            int len = queries.Length;
            string[] answer = new string[len];

            Dictionary<string, string> dic = new Dictionary<string, string>();
            ISet<string> set = new HashSet<string>();
            StringBuilder builder = new StringBuilder();
            foreach (var str in wordlist)
            {
                set.Add(str);
                string lower = str.ToLower();
                if (!dic.ContainsKey(lower))
                    dic[lower] = str;

                string key = GetKey(lower);
                if (!dic.ContainsKey(key))
                    dic[key] = str;
            }

            for (int i = 0; i < len; i++)
            {
                string query = queries[i];
                if(set.Contains(query))
                {
                    answer[i] = query;
                    continue;
                }
                string lower = query.ToLower();
                if (dic.ContainsKey(lower))
                {
                    answer[i] = dic[lower];
                    continue;
                }
                string key = GetKey(lower);
                if (dic.ContainsKey(key)) answer[i] = dic[key];
                else answer[i] = string.Empty;
            }

            return answer;

            string GetKey(string str)
            {
                builder.Clear();
                foreach (var c in str)
                {
                    if (_vowels.Contains(c))
                        builder.Append('*');
                    else
                        builder.Append(c);
                }
                return builder.ToString();
            }

        }

        // test : 1466ms +
        public string[] Simple(string[] wordlist, string[] queries)
        {
            int len = queries.Length;
            string[] answer = new string[len];

            HashSet<string> set = wordlist.ToHashSet();

            HashSet<char> vowels = new HashSet<char>()
            {
                'a','e','i','o','u'
            };

            for (int i = 0; i < len; i++)
            {
                var query = queries[i];
                if (set.Contains(query))
                {
                    answer[i] = query;
                    continue;
                }

                answer[i] = string.Empty;

                foreach (var word in wordlist)
                {
                    if (word.Length != query.Length) continue;
                    bool flag = true;
                    for (int j = 0; j < word.Length; j++)
                    {
                        char q = char.ToLower(query[j]), w = char.ToLower(word[j]);
                        if (q != w && !(vowels.Contains(q) && vowels.Contains(w)))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        answer[i] = word;
                        break;
                    }

                }
            }
            return answer;
        }

    }
}
