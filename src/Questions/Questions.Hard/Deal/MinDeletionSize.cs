using Command.Attr;
using Command.Tools;
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
    /// @des : 
    /// </summary>
    [Optimize, Favorite]
    public class MinDeletionSize
    {

        // 1 <= A.length <= 100
        // 1 <= A[i].length <= 100
        // We are given an array A of N lowercase letter strings, all of the same length.


        // Runtime: 96 ms, faster than 50.00% of C# online submissions for Delete Columns to Make Sorted III.
        // Memory Usage: 26.9 MB, less than 100.00% of C# online submissions for Delete Columns to Make Sorted III.
        // ... 合并换来4ms,就这？ lowercase letter strings?
        public int Optimize(string[] A)
        {

            int wordLen = A[0].Length, maxLen = 1;
            int[] dp = new int[wordLen];
            dp[wordLen - 1] = 1;

            // 合并两处循环
            for (int i = wordLen - 2; i >= 0; i--)
            {
                dp[i] = 1;
                for (int j = i + 1; j < wordLen; j++)// 优化此处，
                {
                    if (1 + dp[j] <= dp[i]) continue;// *** optimize ==> 100ms 没啥用
                    bool flag = true;
                    foreach (var item in A)
                    {
                        if (item[j] < item[i])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        dp[i] = 1 + dp[j];
                }
                maxLen = Math.Max(dp[i], maxLen);
            }

            return wordLen - maxLen;
        }

        // Runtime: 100 ms, faster than 50.00% of C# online submissions for Delete Columns to Make Sorted III.
        // Memory Usage: 27.6 MB, less than 100.00% of C# online submissions for Delete Columns to Make Sorted III.
        // 这也太平均了...
        public int Solution(string[] A)
        {

            var wordLen = A[0].Length;

            List<int>[] map = new List<int>[wordLen - 1];

            // a.首先找出符合的路径(a->b) 
            // a 比较耗时
            for (int i = 0; i < wordLen - 1; i++)
            {
                map[i] = new List<int>();
                for (int j = i + 1; j < wordLen; j++) // 由于使用字符串保存来比较耗时+耗内存，便一开始就只保存符合的路径
                {
                    bool flag = true;
                    foreach (var item in A)
                    {
                        if(item[j] < item[i])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) map[i].Add(j);
                }
            }

            int maxLen = 1;

            // 找到所有符合的路径后，找到最长的路径
            // recursion->dp,dp并不怎么耗时.
            int[] dp = new int[wordLen];
            dp[wordLen - 1] = 1;

            for (int i = wordLen - 2; i >= 0; i--)
            {
                dp[i] = 1;
                foreach (var item in map[i])
                {
                    dp[i] = Math.Max(dp[i], 1 + dp[item]);
                }
                maxLen = Math.Max(dp[i], maxLen);
            }

            return wordLen - maxLen;
        }

        // timelimit , 存在重复递归，==> dp优化
        private int GetMaxLen(List<int>[] map,int index,int count)
        {
            if (index == map.Length) return count;

            var old = count + 1;
            foreach (var item in map[index])
            {
                count = Math.Max(count, GetMaxLen(map, item, old));
            }
            return count;
        }

        public int Try3(string[] A)
        {

            var wordLen = A[0].Length;
            
            IDictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in A)
            {
                // 获取字典排序的所有可能
                List<int>[] list = new List<int>[wordLen];
                for (int i = 0; i < wordLen - 1; i++)
                {
                    list[i] = new List<int>();
                    for (int j = i + 1; j < wordLen; j++)
                    {
                        if (item[j] >= item[i]) list[i].Add(j);
                    }
                }
                // 将所有可能生成字符串.

                // out of memory , 字符串太占空间...
                //for (int i = 0; i < wordLen-1; i++)
                //{
                //    Help(list, i, item, new StringBuilder(), dic);
                //}

            }

            int maxLen = 1;
            foreach (var item in dic)
            {
                //Console.WriteLine($"{item.Key},{item.Value}");
                if (item.Value == A.Length && item.Key.Length > maxLen)
                {
                    maxLen = item.Key.Length;
                }
            }

            return wordLen - maxLen;
        }

        private void Help(List<int>[] list,int index,string str,StringBuilder builder,IDictionary<string,int> dic)
        {
            builder.Append(index);
            if(builder.Length > 1)
            {
                string key = builder.ToString();
                if (dic.ContainsKey(key)) dic[key]++;
                else dic[key] = 1;
            }
            if(list[index] != null)
                foreach (var item in list[index])
                {
                    Help(list, item, str, builder,dic);
                }
            builder.Remove(builder.Length - 1, 1);
        }

        // bug
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

        public int Try0(string[] A)
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