using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/26/2021 6:11:58 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3685/
    /// @des : 
    /// </summary>
    public class Word_Subsets
    {
        // Your runtime beats 70.00 % o
        // old solution
        public IList<string> WordSubsets(string[] A, string[] B)
        {
            int[] compare = new int[26], temp;

            foreach (var item in B)
            {
                temp = Counter(item);
                for (int j = 0; j < compare.Length; j++)
                    if (temp[j] > compare[j])
                        compare[j] = temp[j];
            }

            List<string> res = new List<string>();

            foreach (var str in A)
            {
                temp = Counter(str);
                int j = 0;
                for (; j < compare.Length; j++)
                    if (temp[j] < compare[j])
                        break;
                if (j == compare.Length) res.Add(str);
            }

            return res;
        }

        protected int[] Counter(string word)
        {
            int[] count = new int[26];

            foreach (var c in word)
                count[c - 'a']++;

            return count;
        }
    }
}
