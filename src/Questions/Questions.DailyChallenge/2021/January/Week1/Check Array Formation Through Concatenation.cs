using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/5/2021 5:28:17 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3589/
    /// @des : 
    /// </summary>
    public class Check_Array_Formation_Through_Concatenation
    {
        // 1 <= pieces.length <= arr.length <= 100
        // sum(pieces[i].length) == arr.length
        //1 <= pieces[i].length <= arr.length
        //1 <= arr[i], pieces[i][j] <= 100
        //The integers in arr are distinct.
        //The integers in pieces are distinct(i.e., If we flatten pieces in a 1D array, all the integers in this array are distinct).

        //  54.89 % 
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            bool[] used = new bool[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bool skip = true;
                for (int j = 0; j < pieces.Length; j++)
                {
                    if(!used[j] && pieces[j][0] == arr[i])
                    {
                        for (int k = 1; k < pieces[j].Length; k++)
                        {
                            if (pieces[j][k] != arr[++i]) return false;
                        }
                        used[j] = true;
                        skip = false;
                        break;
                    }
                }
                if (skip) return false;
            }

            return true;

        }

    }
}
