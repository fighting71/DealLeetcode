using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/15/2021 4:33:21 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3673/
    /// @des : 
    /// </summary>
    public class Encode_and_Decode_TinyURL
    {

        private Dictionary<int, string> dic = new Dictionary<int, string>();

        private Random rand = new Random();

        // from : https://www.jianshu.com/p/6ae954ac4c44
        // Your runtime beats 68.64 % of csharp submissions

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            int key;
            do
            {
                key = rand.Next(int.MaxValue);
            } while (dic.ContainsKey(key));
            dic[key] = longUrl;
            return "http://tinyurl.com/" + key;
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return dic[int.Parse(shortUrl.Replace("http://tinyurl.com/", ""))];
        }

    }
}
