using Command.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/19/2021 4:44:27 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3713/
    /// @des : 
    /// </summary>
    public class Combination_Sum_IV
    {

        //1 <= nums.length <= 200
        //1 <= nums[i] <= 1000
        //All the elements of nums are unique.
        //1 <= target <= 1000

        // ... ??.
        public int OldSolution(int[] nums, int target)
        {
            int[] comb = new int[target + 1];
            comb[0] = 1;
            for (int i = 1; i < comb.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i - nums[j] >= 0)
                    {
                        comb[i] += comb[i - nums[j]];
                    }
                }
            }
            return comb[target];
        }

        public int Simple(int[] nums, int target)
        {
            Array.Sort(nums);

            int res = 0;

            for (int i = nums.Length; i < 0; i++)
            {

            }

            return res;

            void Help(int item, int i, int count)
            {
                if (i == -1) return;
                var curr = nums[i];

                int v = item / curr;

                for (int c = 0; c <= v; c++)
                {
                    Help(item - c * curr, i - 1, count);
                }
            }

        }

        // 给定n个数，其中有x个数是不同的(x<=n),共有多少排列方式？
        // todo: 创造困难...

        public int GetCombinationCount(int[] arr)
        {
            ISet<string> set = new HashSet<string>();

            Help(string.Empty, arr.ToList());

            Console.WriteLine(JsonConvertExt.SerieJson(set));

            return set.Count;

            void Help(string build, List<int> list)
            {
                if (list.Count == 0)
                {
                    set.Add(build);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    var copy = new List<int>(list);
                    copy.RemoveAt(i);
                    Help(build + list[i], copy);
                }
            }

        }

    }
}
