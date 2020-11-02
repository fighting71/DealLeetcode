using Command.Attr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Questions.DailyChallenge._2020.October.Week5
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/30/2020 4:27:08 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3513/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Number_of_Longest_Increasing_Subsequence
    {

        public int Optimize(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            // i -> 最大递增长度，可行的路径数
            // 只需要记录最大递增长度->可行的路径数
            Dictionary<int, (int Count, int Way)> dic = new Dictionary<int, (int, int)>() { { 0, (0, 1) } };

            // 最大递增序列长度
            int maxCount = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                int count = 0, way = 1;
                foreach (var item in dic)
                {
                    if (nums[i] > nums[item.Key])
                    {
                        if (item.Value.Count + 1 > count)
                        {
                            count = item.Value.Count + 1;
                            way = item.Value.Way;
                        }
                        else if (item.Value.Count + 1 == count)
                        {
                            way += item.Value.Way;
                        }
                    }
                }
                if (count > maxCount)
                {
                    foreach (var key in dic.Keys)
                    {
                        if (dic[key].Count == maxCount - 2) dic.Remove(key);
                    }
                    dic.Add(i, (count, way));
                    maxCount = count;
                }
                else if (count >= maxCount - 2)
                {
                    dic.Add(i, (count, way));
                }
            }

            Console.WriteLine(JsonConvert.SerializeObject(dic));

            return dic.Where(u => u.Value.Count == maxCount).Sum(u => u.Value.Way);
        }

        //0 <= nums.length <= 2000
        //-106 <= nums[i] <= 106

        // Runtime: 120 ms
        // Memory Usage: 26.4 MB
        // Your runtime beats 43.75 % of csharp submissions.
        // 看起来没问题，又感觉有问题，都上dp了就这？
        public int Simple(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int len = nums.Length, max = 0, res = 1;
            int[] count = new int[len];
            int[] ways = new int[len];
            ways[0] = 1;
            for (int i = 1; i < len; i++)
            {
                ways[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (count[i] < count[j] + 1)
                        {
                            count[i] = count[j] + 1;
                            ways[i] = ways[j];
                        }
                        else if (count[i] == count[j] + 1)
                        {
                            ways[i] += ways[j];
                        }
                    }
                }
                if (count[i] > max)
                {
                    max = count[i];
                    res = ways[i];
                }
                else if (count[i] == max) res += ways[i];
            }

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine($"i:{i},count:{count[i]},way:{ways[i]}        ,num:{nums[i]}");
            }

            return res;
        }

    }
}
