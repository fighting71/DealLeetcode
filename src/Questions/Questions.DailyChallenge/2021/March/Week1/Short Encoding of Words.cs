using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/9/2021 12:02:42 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3662/
    /// @des : 
    /// </summary>
    public class Short_Encoding_of_Words
    {

        // 1 <= words.length <= 2000
        //1 <= words[i].length <= 7
        //words[i] consists of only lowercase letters.

        // Runtime: 116 ms
        public int MinimumLengthEncoding(string[] words)
        {
            int res = 0;

            Dictionary<char, List<string>> dic = new Dictionary<char, List<string>>();

            foreach (var word in words)
            {
                int len = word.Length;
                var key = word[^1];
                if (dic.ContainsKey(key))
                {
                    bool skip = false;
                    List<string> list = dic[key];
                    for (int index = 0; index < list.Count; index++)
                    {
                        var match = list[index];
                        if(match.Length >= len)
                        {
                            bool flag = true;
                            for (int i = len - 2,j = match.Length - 2; i >= 0; i--,j--)
                            {
                                if(match[j] != word[i])
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                skip = true;
                                break;
                            }
                        }
                        else
                        {
                            bool flag = true;
                            for (int i = len - 2, j = match.Length - 2; j >= 0; i--, j--)
                            {
                                if (match[j] != word[i])
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                res += len - match.Length;
                                list[index] = word;
                                skip = true;
                                break;
                            }
                        }
                    }
                    if (skip) continue;
                    dic[key].Add(word);
                    res += len + 1;
                }
                else
                {
                    dic[key] = new List<string>() { word };
                    res += len + 1;
                }
            }

            return res;
        }

    }
}
