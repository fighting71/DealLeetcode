using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/10/2021 4:28:24 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3667/
    /// @des : 
    /// </summary>
    public class Integer_to_Roman
    {

        private static (int num,string Roman)[] dataArr = new[] { 
            (1000,"M" ),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90,  "XC"),
            (50,  "L"),
            (40,  "XL"),
            (10,  "X"),
            (9,   "IX"),
            (5,   "V"),
            (4,   "IV"),
            (1,   "I"),
        };

        public string Try2(int num)
        {
            var builder = new StringBuilder();

            foreach (var item in dataArr)
            {
                if (num == 0) break;
                if (num >= item.num)
                {
                    var count = num / item.num;
                    for (var j = 0; j < count; j++) builder.Append(item.Roman);
                    num %= item.num;
                }
            }

            return builder.ToString();
        }
        private static int[] valueArr = new[]
    {
      1,
      4,
      5,
      9,
      10,
      40,
      50,
      90,
      100,
      400,
      500,
      900,
      1000
    };

        private static readonly string[] strArr = new[]
        {
      "I",
      "IV",
      "V",
      "IX",
      "X",
      "XL",
      "L",
      "XC",
      "C",
      "CD",
      "D",
      "CM",
      "M"
    };

        // 50% 之前做过.
        public string IntToRoman(int num)
        {
            var builder = new StringBuilder();

            for (var i = valueArr.Length - 1; i >= 0; i--)
            {
                if (num == 0)
                    break;
                if (num >= valueArr[i])
                    for (var j = 0; j < num / valueArr[i]; j++) builder.Append(strArr[i]);

                num %= valueArr[i];
            }

            return builder.ToString();
        }
    }
}
