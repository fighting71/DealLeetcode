using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/17/2021 4:04:48 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3746/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Longest_String_Chain
    {

        // 1 <= words.length <= 1000
        //1 <= words[i].length <= 16
        //words[i] only consists of English lowercase letters.


        // Your runtime beats 40.30 %
        public int Simple(string[] words)
        {

            Dictionary<string, int> cache = new Dictionary<string, int>();
            int res = 0;
            foreach (var word in words.OrderBy(u => u.Length))
            {
                if (word.Length == 1)
                {
                    cache[word] = 1;
                    continue;
                }
                int count = 1;
                for (int i = 0; i < word.Length; i++)
                {
                    var key = word.AsSpan(0, i).ToString() + word.AsSpan(i + 1, word.Length - i - 1).ToString();

                    if (cache.TryGetValue(key, out int v))
                    {
                        count = Math.Max(count, 1 + v);
                        if (count == word.Length) break;
                    }
                }
                cache[word] = count;
                res = Math.Max(res, count);
            }

            return res;
        }

    }
}
