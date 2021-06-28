using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/16/2021 5:37:02 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3710/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Zuma)]
    public class Remove_All_Adjacent_Duplicates_in_String_II
    {

        class Item
        {
            public char Char { get; set; }
            public int Count { get; set; }

            public override string ToString()
            {
                return $"{Char}-{Count}";
            }
        }

        // 1 <= s.length <= 10^5
        //2 <= k <= 10^4
        //s only contains lower case English letters.

        // Your runtime beats 96.17 % of csharp submissions
        // 祖玛压缩 haoye~
        public string RemoveDuplicates(string s, int k)
        {
            List<Item> list = new List<Item>();

            Item prev = default;

            foreach (var c in s)
            {
                if (prev != default && prev.Char == c)
                {
                    prev.Count++;
                }
                else
                {
                    list.Add(prev = new Item { Char = c, Count = 1 });
                }
            }

            for (int i = 0; i < list.Count;)
            {
                var curr = list[i];
                if (curr.Count % k == 0)
                {

                    list.RemoveAt(i);
                    if (i > 0 && i < list.Count)
                    {
                        Item next = list[i];
                        prev = list[i - 1];
                        if (next.Char == prev.Char)
                        {
                            list.RemoveAt(i);
                            prev.Count += next.Count;
                            i--;
                        }
                    }
                }
                else
                {
                    curr.Count %= k;
                    i++;
                }
            }

            StringBuilder builder = new StringBuilder();

            foreach (var item in list)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    builder.Append(item.Char);
                }
            }
            return builder.ToString();

        }

    }
}
