using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 10:17:37 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3540/
    /// @des : 
    /// </summary>
    public class Unique_Morse_Code_Words
    {
        // The length of words will be at most 100.
        // Each words[i] will have length in range[1, 12].
        // words[i] will only consist of lowercase letters.

        // Your runtime beats 51.02 % of csharp submission
        public int Simple(string[] words)
        {

            ISet<string> set = new HashSet<string>();

            StringBuilder builder = new StringBuilder();

            foreach (var word in words)
            {
                builder.Clear();
                foreach (var c in word)
                {
                    builder.Append(_converts[c - 'a']);
                }
                Console.WriteLine(builder);
                set.Add(builder.ToString());
            }

            return set.Count;

        }

        // optmize direction -> analysis <_converts> ?
        private static readonly string[] _converts = new[] {
        ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };

    }
}
