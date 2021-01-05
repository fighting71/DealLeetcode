using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/30/2020 3:51:28 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3578/
    /// @des : 
    /// </summary>
    public class Next_Greater_Element_III
    {

        // 1 <= n <= 231 - 1
        public int NextGreaterElement(int n)
        {
            List<int> list = new List<int>();
            while (n > 0)
            {
                int curr = n % 10;
                list.Add(curr);
                n /= 10;
                if(list.Count > 0)
                {
                    var prev = list[list.Count - 1];

                    if(curr < prev)
                    {
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            var item = list[i];
                            if(item > curr)
                            {
                                n = n * 10 + item;
                            }
                        }
                    }

                }
            }
            return default;

        }
    }
}
