using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/9/12 10:26:44
    /// @source : https://leetcode.com/problems/delete-columns-to-make-sorted-iii/
    /// @des : error
    /// </summary>
    public class MinDeletionSize
    {
        // bug
        [Obsolete]
        public int Try(string[] A)
        {
            int len = A[0].Length, res = 0;
            int[] flag = new int[len];
            Array.Fill(flag, 1);

            for (int i = 0; i < A.Length; i++)
            {
//                var helper = Helper(A[i], flag);
//
//                for (int j = 0; j < len; j++)
//                {
//                    if (flag[j] == 1 && helper[j] == 0)
//                    {
//                        res++;
//                        flag[j] = 0;
//                    }
//                }
            }

            return res;
        }

        public int Try2(string[] A)
        {
            return -1;
            //int len = A[0].Length, res = len - 1, prev, itemRes;

//            bool[] flag = new bool[len];
//            var arr = new int[len];
//
//            for (int i = 0; i < len; i++)
//            {
//                if (flag[i]) continue;
//
//                arr = Helper(A[0]);
//
//                for (int j = 0; j < arr.Length; j++)
//                {
//                    if (arr[j] == 1) flag[j] = true;
//                }
//
//                for (int j = 1; j < A.Length; j++)
//                {
//                    var helper = Helper(A[j], arr);
//
//                    for (int k = 0; k < len; k++)
//                    {
//                        if (arr[k] == 1 && helper[k] == 0)
//                        {
//                            arr[k] = 0;
//                        }
//                    }
//                }
//
//                itemRes = 0;
//                for (int j = 0; j < arr.Length; j++)
//                {
//                    if (arr[j] == 0) itemRes++;
//                }
//
//                if (itemRes < res) res = itemRes;
//            }

            //return res;
        }

        public int Solution(string[] A)
        {
            int len = A[0].Length, res = len - 1, itemRes;

            bool[] flag = new bool[len];
            IList<int[]> firstList = new List<int[]>();
            var first = new int[len];
            Array.Fill(first, 1);

            for (int i = 0; i < len; i++)
            {
                if (flag[i]) continue;

                var maxLen = 2;
//                firstList = Helper2(A[0]);

                foreach (var arr in firstList)
                {
                    itemRes = len - maxLen;

                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == 1) flag[j] = true;
                    }

                    for (int j = 1; j < A.Length; j++)
                    {
//                        var helper = Helper(A[j], arr);

//                        for (int k = 0; k < len; k++)
//                        {
//                            if (arr[k] == 1 && helper[k] == 0)
//                            {
//                                arr[k] = 0;
//                                itemRes++;
//                            }
//                        }
                    }

                    if (itemRes < res) res = itemRes;
                }
            }

            return res;
        }

        public int[] Helper(string str)
        {
            int max = 0, len = str.Length, resIndex = 0;
            int[] dp = new int[len];
            int[][] res = new int[len][];

            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
            }

            res[0][0] = 1;
            Array.Fill(dp, 1);

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] + 1 > dp[i] && str[i] > str[j])
                    {
                        dp[i] = dp[j] + 1;
                        res[i] = res[j];
                    }
                }

                if (dp[i] > 1) res[i] = (int[]) res[i].Clone();
                res[i][i] = 1;

                if (dp[i] > max)
                {
                    max = dp[i];
                    resIndex = i;
                }
            }

            return res[resIndex];
        }

        public int[] Helper(string str, int[] flag,out int maxLen)
        {
            int max = 0, len = str.Length, resIndex = 0;
            int[] dp = new int[len];
            int[][] res = new int[len][];

            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
            }

            res[0][0] = 1;
            Array.Fill(dp, 1);

            for (int i = 1; i < len; i++)
            {
                if (flag[i] == 0) continue;

                for (int j = 0; j < i; j++)
                {
                    if (flag[j] == 0) continue;

                    if (dp[j] + 1 > dp[i] && str[i] >= str[j])
                    {
                        dp[i] = dp[j] + 1;
                        res[i] = res[j];
                    }
                }

                if (dp[i] > 1) res[i] = (int[]) res[i].Clone();
                res[i][i] = 1;

                if (dp[i] > max)
                {
                    max = dp[i];
                    resIndex = i;
                }
            }

            maxLen = max;
            return res[resIndex];
        }


        public void Helper2(string str)
        {
            int max = 0, len = str.Length;
            int[] dp = new int[len];
            List<bool[]>[] arr = new List<bool[]>[len];

            Array.Fill(dp, 1);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (str[i] >= str[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            arr[i].Clear();
                            arr[i].AddRange(arr[j]);
                        }
                        else if (dp[j] + 1 == dp[i])
                        {
                            arr[i].AddRange(arr[j]);
                        }
                    }
                }

                if (arr[i].Count > 0)
                {
                    var list = new List<bool[]>();

                    for (int j = 0; j < arr[i].Count; j++)
                    {
                        var copy = new bool[len];
                        Array.Copy(arr[i][j], copy, len);
                        copy[i] = true;
                        list.Add(copy);
                    }

                    arr[i] = list;
                }
                else
                {
                    var newArr = new bool[len];
                    newArr[i] = true;
                    arr[i] = new List<bool[]>() {newArr};
                }

                if (dp[i] > max) max = dp[i];
            }
            
        }
    }
}