using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/28/2020 4:31:50 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3510/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Summary_Ranges
    {

        // 利用： nums[end] - nums[start] == end - start
        // 优化不明显...
        public IList<string> Optmize(int[] nums)
        {
            if (nums.Length == 0) return new List<string>();
            if (nums.Length == 1) return new List<string>() { nums[0].ToString() };

            IList<string> res = new List<string>();

            int start = 0, end = nums.Length - 1;

            while (start < nums.Length)
            {
                if (start == end)
                {
                    res.Add(nums[start].ToString());
                    break;
                }

                if(nums[end] - nums[start] == end - start)
                {
                    res.Add($"{nums[start]}->{nums[end]}");
                }
                else
                {
                    int left = start;
                    while (end > left)
                    {
                        int mid = (left + end) / 2;
                        if (mid - start != nums[mid] - nums[start])
                        {
                            end = mid;
                        }
                        else if(mid + 1 < nums.Length && nums[mid +1] - nums[mid] == 1)
                        {
                            left = mid;
                        }
                        else
                        {
                            end = mid;
                            break;
                        }
                    }
                    if(start == end)
                    {
                        res.Add(nums[start].ToString());
                    }
                    else
                    {
                        res.Add($"{nums[start]}->{nums[end]}");
                    }
                }
                start = end + 1;
                end = nums.Length - 1;

            }

            return res;

        }

        /*
         0 <= nums.length <= 20
-231 <= nums[i] <= 231 - 1
All the values of nums are unique.
         */
        // slow => more than 30%+
        public IList<string> Simple(int[] nums)
        {

            if (nums.Length == 0) return new List<string>();
            if (nums.Length == 1) return new List<string>() { nums[0].ToString() };

            IList<string> res = new List<string>();
            int i = 1, start = 0;
            for (; i < nums.Length; i++)
            {

                if (nums[i] - nums[i - 1] == 1) continue;
                else
                {
                    if (start == i - 1)
                    {
                        res.Add(nums[start].ToString());
                    }
                    else
                    {
                        res.Add($"{nums[start]}->{nums[i - 1]}");
                    }
                    start = i;
                }

            }

            if (start == i - 1)
            {
                res.Add(nums[start].ToString());
            }
            else
            {
                res.Add($"{nums[start]}->{nums[i - 1]}");
            }

            return res;

        }
    }
}
