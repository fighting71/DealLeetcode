using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 9:29:30 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/568/week-5-november-29th-november-30th/3548/
    /// @des : 
    /// </summary>
    public class Jump_Game_III
    {

        // 1 <= arr.length <= 5 * 10^4
        // 0 <= arr[i] < arr.length
        // 0 <= start<arr.length

        // Your runtime beats 99.26 % of csharp submissions.
        // Runtime: 116 ms
        // Memory Usage: 35.4 MB
        // ??? 这就过了...
        public bool Simple(int[] arr, int start)
        {
            return Helper(arr, start, new bool[arr.Length], new bool?[arr.Length]);
        }

        private bool Helper(int[] arr, int index, bool[] visited, bool?[] dp)
        {
            if (index < 0 || index >= arr.Length || visited[index]) return false;
            if (dp[index].HasValue) return dp[index].Value;
            visited[index] = true;
            var num = arr[index];
            if (num == 0) return true;
            var res = Helper(arr, index + num, visited, dp) || Helper(arr, index - num, visited, dp);
            visited[index] = false;
            dp[index] = res;
            return res;
        }

    }
}
