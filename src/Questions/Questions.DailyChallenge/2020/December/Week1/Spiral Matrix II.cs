using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/8/2020 10:24:49 AM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3557/
    /// @des : 
    /// </summary>
    public class Spiral_Matrix_II
    {
        // 288ms
        // 1 <= n <= 20
        public int[][] GenerateMatrix(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }
            num = 1;
            start = 0;
            end = n;
            start2 = 0;
            end2 = n - 2;
            HelpLeft(res, 0);
            return res;
        }

        int start, end, num, start2, end2;

        private void HelpLeft(int[][] arr, int i)
        {
            if (start >= end) return;
            for (int j = start; j < end; j++)
            {
                arr[i][j] = num++;
            }
            start++;
            HelpDown(arr, end - 1);
        }

        private void HelpDown(int[][] arr, int j)
        {
            for (int i = start; i < end; i++)
            {
                arr[i][j] = num++;
            }
            end--;
            HelpRight(arr, end);
        }
        private void HelpRight(int[][] arr, int i)
        {
            for (int j = end2; j >= start2; j--)
            {
                arr[i][j] = num++;
            }
            start2++;
            HelpTop(arr, start2 - 1);
        }

        private void HelpTop(int[][] arr, int j)
        {
            for (int i = end2; i >= start2; i--)
            {
                arr[i][j] = num++;
            }
            end2--;
            HelpLeft(arr, start2);
        }
    }
}
