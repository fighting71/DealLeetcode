using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/24/2020 4:37:27 PM
    /// @source : https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3471/
    /// @des : 
    /// </summary>
    public class Find_the_Difference
    {
        //Runtime: 120 ms
        //Memory Usage: 24.8 MB
        public char Simple(string s, string t)
        {

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }

            foreach (var c in t)
            {
                if (dic.ContainsKey(c))
                {
                    if (dic[c] == 0) return c;
                    dic[c]--;
                }
                else return c;
            }

            return t[0];
        }

        //Runtime: 92 ms
        //Memory Usage: 24.3 MB
        public char Optimize(string s, string t)
        {

            int[] arr = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }
            arr[t[t.Length - 1] - 'a']--;
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] == -1) return (char)(i + 'a');
            }

            return default;
        }

    }
}
