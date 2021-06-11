using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 5:10:58 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3773/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.Hard, FlagConst.LinkedList, FlagConst.DP)]
    public class Jump_Game_VI
    {

        // Constraints:

        // 1 <= nums.length, k <= 10^5
        //-10^4 <= nums[i] <= 10^4

        // source: https://leetcode.com/problems/jump-game-vi/discuss/978462/C%2B%2B-DP-%2B-Monoqueue-O(n)
        // evaluate: ... 将list替换成了linkedList ... 
        public int OtherSolution(int[] nums, int k)
        {
            int len = nums.Length ;
            int[] dp = new int[len];   // dp[i] : max sum from 0-th index to i-th index, following the given conditions
            var deque = new LinkedList<int>();    // for each index i, front of the deque will be storing max{dp[i-k], dp[i-k-1], dp[i-k-2], .... , dp[i-2], dp[i-1]} 
            for (int i = 0; i < len; i++)
            {
                int prev_max = deque.Count == 0 ? 0 : dp[deque.First.Value];
                dp[i] = nums[i] + prev_max;
                while (deque.Count > 0 && dp[deque.Last.Value] < dp[i])
                    deque.RemoveLast();
                deque.AddLast(i);
                while (deque.Count > 0 && i - deque.First.Value >= k)
                    deque.RemoveFirst();
            }
            return dp[len - 1];
        }

        //public int maxResult(int[] nums, int k)
        //{
        //    int len = nums.length;
        //    int[] dp = new int[len];   // dp[i] : max sum from 0-th index to i-th index, following the given conditions
        //    Deque<Integer> deque = new LinkedList<Integer>();    // for each index i, front of the deque will be storing max{dp[i-k], dp[i-k-1], dp[i-k-2], .... , dp[i-2], dp[i-1]} 
        //    for (int i = 0; i < len; i++)
        //    {
        //        int prev_max = deque.isEmpty() ? 0 : dp[deque.peekFirst()];
        //        dp[i] = nums[i] + prev_max;
        //        while (!deque.isEmpty() && dp[deque.peekLast()] < dp[i])
        //            deque.pollLast();
        //        deque.add(i);
        //        while (!deque.isEmpty() && i - deque.peekFirst() >= k)
        //            deque.pollFirst();
        //    }
        //    return dp[len - 1];
        //}

        public int Try2(int[] nums, int k)
        {
            int len = nums.Length;
            int max = nums[0],maxIndex = 0,curr;

            for (int i = 1; i < len; i++)
            {
                curr = nums[i] + max;

                if(curr >= max)
                {
                    max = curr;
                    maxIndex = i;
                }
                else if (i >= k && i - k == maxIndex)
                {
                    max = curr;
                    maxIndex = i;
                    for (int j = i - k + 1; j < i; j++)
                    {
                        if (nums[j] >= max)
                        {
                            max = nums[j];
                            maxIndex = j;
                        }
                    }
                }
            }
            return max;
        }

        // Runtime: 2088 ms
        // Memory Usage: 44.1 MB
        // Time Limit ??? 
        // O(n * lgN + lgN)
        public int Try(int[] nums, int k)
        {
            nums = (int[])nums.Clone();
            int len = nums.Length;

            int curr = nums[0];
            List<int> list = new List<int>(len) { curr };

            for (int i = 1; i < len; i++)
            {

                curr = nums[i] + list[list.Count - 1];

                if (i >= k)
                {
                    // optimize?
                    list.Remove(nums[i - k]);
                }

                int index = BinarySearch(curr);

                list.Insert(index, curr);
                nums[i] = curr;

            }

            return curr;

            int BinarySearch(int target)
            {
                int len = list.Count, left = 0, right = len - 1;

                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    var num = list[mid];
                    if (num == target) return mid;
                    if (num > target) right = mid - 1;
                    else left = mid + 1;
                }

                return left;
            }

        }

        // slow
        public int Simple(int[] nums, int k)
        {
            nums = (int[])nums.Clone();
            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i], max = num + nums[i - 1];
                for (int j = Math.Max(0, i - k); j < i - 1; j++)
                {
                    max = Math.Max(num + nums[j], max);
                }
                nums[i] = max;
            }
            return nums[nums.Length - 1];
        }
    }
}
