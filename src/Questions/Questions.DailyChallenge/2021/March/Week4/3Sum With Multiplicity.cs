using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/24/2021 12:17:51 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3682/
    /// @des : 
    ///     Given an integer array arr, and an integer target, return the number of tuples i, j, k such that i < j < k and arr[i] + arr[j] + arr[k] == target.
    /// </summary>
    [Optimize("速度提升")]
    public class _3Sum_With_Multiplicity
    {

        // 3 <= arr.length <= 3000
        // 0 <= arr[i] <= 100
        // 0 <= target <= 300
        // As the answer can be very large, return it modulo 109 + 7.

        const int max = 100;
        const int mod = 1000_000_007;

        public int Try4(int[] arr, int target)
        {
            int res = 0, len = arr.Length, first, last, find;

            int[] countDic = new int[101];
            for (int i = 0; i < len - 2; i++)
            {
                first = arr[i];
                Array.Fill(countDic, 0);
                countDic[arr[i + 1]] = 1;
                for (int k = i + 2; k < len; k++)
                {
                    last = arr[k];
                    find = target - first - last;
                    if (find >= 0 && find < countDic.Length)
                        res = (res + countDic[find]) % mod;
                    countDic[last]++;
                }
            }

            return res;
        }

        // Runtime: 2660 ms
        // Memory Usage: 25.9 MB
        // ?
        public int Try3(int[] arr, int target)
        {
            int res = 0, len = arr.Length, first, last, find, count;

            Dictionary<int, int> countDic = new Dictionary<int, int>();
            for (int i = 0; i < len - 2; i++)
            {
                first = arr[i];
                countDic.Clear();
                countDic.Add(arr[i + 1], 1);
                for (int k = i + 2; k < len; k++)
                {
                    last = arr[k];
                    find = target - first - last;
                    if (countDic.TryGetValue(find, out count))
                        res = (res + count) % mod;
                    if (countDic.ContainsKey(last)) countDic[last]++;
                    else countDic[last] = 1;
                }
            }

            return res;
        }


        public int Try2(int[] arr, int target)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();

            int len = arr.Length;

            foreach (var item in arr)
            {
                if (dic.ContainsKey(item)) dic[item]++;
                else dic[item]--;
            }

            int res = 0, startNum, endNum, find;

            for (int start = 0; start < len - 2; start++)
            {
                startNum = arr[start];
                dic[startNum]--;
                Dictionary<int, int> clone = new Dictionary<int, int>(dic);

                for (int end = len - 1; end > start + 1; end--)
                {
                    endNum = arr[end];
                    clone[endNum]--;
                    find = target - startNum - endNum;
                    if (dic.TryGetValue(find, out var num))
                    {
                        res = (res + num) % mod;
                    }
                }
            }

            return res;
        }

        // Runtime: 388 ms
        // Memory Usage: 28.7 MB
        public int Try(int[] arr, int target)
        {

            int[] count = new int[max + 1];

            int len = arr.Length;

            foreach (var item in arr)
            {
                count[item]++;
            }

            int res = 0;

            for (int start = 0; start < len - 2; start++)
            {
                var startNum = arr[start];
                count[startNum]--;

                int[] clone = new int[max + 1];
                Array.Copy(count, clone, max + 1);

                for (int end = len - 1; end > start + 1; end--)
                {
                    var endNum = arr[end];
                    clone[endNum]--;
                    var find = target - startNum - endNum;
                    if (find >= 0 && find <= max) res = (res + clone[find]) % mod;
                }
            }

            return res;
        }
        public int Simple(int[] arr, int target)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            int len = arr.Length;

            for (int i = 1; i < len - 1; i++)
            {
                var num = target - arr[i];
                if (dic.TryGetValue(num, out var list))
                {
                    list.Add(i);
                }
                else
                {
                    dic[num] = new List<int>() { i };
                }
            }
            int res = 0;
            for (int first = 0; first < len - 1; first++)
            {
                for (int last = len - 1; last > first + 1; last--)
                {
                    var find = arr[first] + arr[last];

                    if (dic.TryGetValue(find, out var list))
                    {
                        res += list.Where(u => u > first && u < last).Count();
                    }

                }
            }
            return res;

        }

    }
}
