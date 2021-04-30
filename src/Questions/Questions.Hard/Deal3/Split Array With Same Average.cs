using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/30/2021 5:24:27 PM
    /// @source : https://leetcode.com/problems/split-array-with-same-average/
    /// @des : 
    /// </summary>
    [Optimize("待速度优化,slow")]
    public class Split_Array_With_Same_Average
    {

        //1 <= nums.length <= 30
        //0 <= nums[i] <= 10^4


        /*
         * simple think :
         *  len = nums.Length
         *  a = A.length
         *  b = B.length
         *      for a = 1,b = len - a
         *          body:
         *              列出所有可能，查看A,B平均值是否相同
         *          iteration:
         *              a++,b--
         *          break:
         *              a>b
         *              
         *  O(n/2 * (C(a/len) + C(b/len)))
         *           
         */

        /*
         * think 2 :
         *      avg(A) = avg(B) ==> ?
         *          avg(A) = avg(B) = avg(nums) ==>
         *              存在 avg(C) = avg(nums)
         * 
         */
        // Runtime: 1232 ms, faster than 25.00% of C# online submissions for Split Array With Same Average.
        // Memory Usage: 163.2 MB, less than 25.00% of C# online submissions for Split Array With Same Average.
        // ~~~ 勉强过关
        public bool Try3(int[] nums)
        {
            if (nums.Length == 1) return false;
            int sum = nums.Sum(), len = nums.Length;

            double avg = sum / (double)len;

            if (sum % len == 0 && nums.Contains((int)avg)) return true;

            HashSet<(int sum, double avg)>[][] set = new HashSet<(int sum, double avg)>[len][];

            Array.Sort(nums);

            for (int i = 0; i < len; i++)
            {
                set[i] = new HashSet<(int sum, double avg)>[len + 1];
                var curr = nums[i];
                set[i][1] = new HashSet<(int sum, double avg)>() { (curr, curr) };
                for (int count = 2; count <= i + 1 && count < len; count++)
                {
                    HashSet<(int sum, double avg)> currSet = new HashSet<(int sum, double avg)>();
                    for (int j = count - 2; j < i; j++)
                    {
                        foreach (var item in set[j][count - 1])
                        {
                            if (item.avg > avg && curr > avg) continue;
                            int currSum = item.sum + curr;
                            var currAvg = currSum / (double)count;
                            if (currAvg == avg) return true;
                            if (currSet.Add((currSum, currAvg)))
                            {
                                if (currSum / (double)count == avg) return true;
                            }
                        }
                    }
                    set[i][count] = currSet;
                }
            }

            return false;

        }

        // 单次耗时最长 :
        // 756
        // slow
        public bool Try2(int[] nums)
        {

            int sum = nums.Sum(), len = nums.Length;

            double avg = sum / (double)len;

            if (sum % len == 0 && nums.Contains((int)avg)) return true;

            HashSet<int>[][] set = new HashSet<int>[len][];

            set[0] = new HashSet<int>[1] { new HashSet<int>() { nums[0] } };

            for (int i = 0; i < len; i++)
            {
                set[i] = new HashSet<int>[len + 1];
                var curr = nums[i];
                set[i][1] = new HashSet<int>() { curr };
                for (int count = 2; count <= i + 1 && count < len; count++)
                {
                    HashSet<int> currSet = new HashSet<int>();
                    for (int j = count - 2; j < i; j++)
                    {
                        foreach (var item in set[j][count - 1])
                        {
                            int currSum = item + curr;
                            if (currSet.Add(currSum))
                            {
                                if (currSum / (double)count == avg) return true;
                            }
                        }
                    }
                    set[i][count] = currSet;
                }
            }

            return false;

        }
        // slow
        public bool Simple(int[] nums)
        {

            int sum = nums.Sum(), len = nums.Length;

            double avg = sum / (double)len;

            if (sum % len == 0 && nums.Contains((int)avg)) return true;

            Array.Sort(nums);

            bool[] visited = new bool[len];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int num = nums[i];
                visited[i] = true;
                if (Help(num, num, 1, visited)) return true;
                visited[i] = false;
            }

            return false;
            bool Help(double currAvg, int sum, int count, bool[] visited)
            {
                if (currAvg == avg)
                {
                    return true;
                }

                if (count == len - 1) return false;

                if (currAvg > avg)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (visited[i]) continue;
                        var curr = nums[i];
                        if (curr > currAvg) break;
                        visited[i] = true;
                        if (Help((sum + curr) / (double)(count + 1), sum + curr, count + 1, visited)) return true;
                        visited[i] = false;
                    }
                }
                else
                {
                    for (int i = len - 1; i >= 0; i--)
                    {
                        if (visited[i]) continue;
                        var curr = nums[i];
                        if (curr < currAvg) break;
                        visited[i] = true;
                        if (Help((sum + curr) / (double)(count + 1), sum + curr, count + 1, visited)) return true;
                        visited[i] = false;
                    }
                }
                return false;
            }

        }

        // bug: 错意
        public bool Try(int[] nums)
        {
            int sum = nums.Sum();

            if (sum % 2 != 0) return false;

            int avg = sum / 2;

            if (nums.Contains(avg)) return true;

            Array.Sort(nums);

            ISet<int> cache = new HashSet<int>();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int num = nums[i];
                if (Help(i - 1, num)) return true;
            }
            return false;
            bool Help(int i, int num)
            {
                if (cache.Contains(num)) return false;
                if (i == -1) return false;

                var curr = nums[i];

                if (num + curr == avg) return true;

                if (num + curr > avg) return Help(i - 1, num);

                var res = Help(i - 1, num) || Help(i - 1, num + curr);
                if (!res) cache.Add(num);
                return res;
            }

        }

    }
}
