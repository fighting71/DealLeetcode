using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 11:00:31
    /// @source : https://leetcode.com/problems/triples-with-bitwise-and-equal-to-zero/
    /// @des : 
    /// </summary>
    [Obsolete("pass but not efficient")]
    public class CountTriplets
    {

        // 0 <= i < A.length
        //0 <= j<A.length
        //0 <= k<A.length
        //A[i] & A[j] & A[k] == 0, where & represents the bitwise-AND operator.

        public int Optimize3(int[] arr)
        {
            if (arr.Length < 3) return 0;

            int len = arr.Length, res = 0;

            List<int> list = new List<int>();

            foreach (var num in arr)
            {
                if(num == 0)res += 1 + ((len - 1) * 3) + ((len - 1) * (len - 1) * 3);
                else list.Add(num);
            }

            ISet<(int, int, int)> set = new HashSet<(int, int, int)>();
            len = list.Count;

            bool[][] flag = new bool[len][];
            IList<(int, int)> twoZero = new List<(int, int)>();
            for (int i = 0; i < len; i++)
            {
                flag[i] = new bool[len];
                for (int j = i + 1; j < len; j++)
                {
                    if((arr[i] & arr[j]) == 0)
                    {
                        // todo:如何加...
                        res += 6 * len;
                        // todo:如何减...

                        foreach (var item in twoZero)
                        {
                            if(item.Item1 == i || item.Item2 == j)
                            {
                                res -= 12;
                            }
                        }

                        twoZero.Add((i, j));
                        flag[i][j] = true;
                    }
                }
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (flag[i][j]) continue;
                    for (int k = j + 1; k < len; k++)
                    {
                        if (flag[j][k] == false && (arr[i] & arr[j] & arr[k]) == 0)
                        {
                            set.Add((i, j, k));
                        }
                    }
                }
            }

            return set.Count * 6 + res;

        }


        public int Optimize2(int[] arr)
        {
            if (arr.Length < 3) return 0;

            int len = arr.Length,res = 0;
            ISet<(int, int, int)> set = new HashSet<(int, int, int)>();

            for (int i = 0; i < len; i++)
            {
                //if (arr[i] == 0)
                //{
                //    res += 1 + ((len - 1) * 3) + ((len - 1) * (len - 1) * 3);
                //    set = set.Where(u => u.Item2 != i && u.Item3 != i).ToHashSet();
                //    continue;
                //}
                for (int j = i + 1; j < len; j++)
                {
                    var item = (arr[i] & arr[j]);
                    if (item == 0)
                    {
                        for (int k = j; k < len; k++) // 耗时.
                        {
                            set.Add((i, j, k));
                        }
                    }
                    else
                    {
                        for (int k = j + 1; k < len; k++)
                        {
                            if ((item & arr[k]) == 0)
                            {
                                set.Add((i, j, k));
                            }
                        }
                    }
                }
            }
            return set.Count * 6 + res;

        }

        public int Optimize(int[] arr)
        {

            var res = 0;

            if (arr.Length < 3) return res;

            int len = arr.Length,mulZero = 0;

            List<int> list = new List<int>();
            List<(int,int)> test = new List<(int, int)>();

            for (int i = 0; i < len - 1; i++)
            {
                if(arr[i] == 0)
                {
                    res += len * len;
                    continue;
                }
                for (int j = i + 1; j < len; j++)
                {
                    var item = (arr[i] & arr[j]);
                    if (item == 0)
                    {
                        mulZero += 6 * len;
                    }
                    else
                    {
                        test.Add((i, j));
                        list.Add(item);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                var num = list[i];
                //}
                //foreach (var num in list)
                //{
                var empty = test[i];
                for (int j = empty.Item2 + 1; j < arr.Length; j++)
                {
                    var item = arr[j];
                //}
                //foreach (var item in arr)
                //{
                    if ((num & item) == 0)
                    {
                        mulZero -= 6;
                        Console.WriteLine($"{test[i].Item1}-{test[i].Item2}-{j}");
                        res += 6;
                    }
                }
            }

            return res;

        }

        ISet<(int, int, int)> set = new HashSet<(int, int, int)>();

        public int Solution(int[] arr)
        {
            var res = 0;

            if (arr.Length < 3) return res;

            var len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if ((arr[i] & arr[j] & arr[k]) == 0)
                        {
                            set.Add((i, j, k));
                            res++;
                        }
                    }
                }
            }
            foreach (var item in set.Where(u => u.Item1 != u.Item2 && u.Item2 != u.Item3 && u.Item3 != u.Item1).OrderBy(u => u))
            {
                Console.WriteLine($"{arr[item.Item1]}-{arr[item.Item2]}-{arr[item.Item3]}");
            }
            foreach (var item in set.Where(u => u.Item1 == u.Item2 || u.Item2 == u.Item3 || u.Item3 == u.Item1).OrderBy(u => u))
            {
                Console.WriteLine($"{arr[item.Item1]}-{arr[item.Item2]}-{arr[item.Item3]}");
            }
            //Console.WriteLine(set.Where(u => u.Item1 == 10 || u.Item2 == 10 || u.Item3 == 10).Count());
            //Console.WriteLine(set.Where(u => u.Item1 != 10 && u.Item2 != 10 && u.Item3 != 10).Count());

            //foreach (var item in set.Where(u => u.Item1 == 10 || u.Item2 == 10 || u.Item3 == 10).OrderBy(u => u))
            //{
            //    Console.WriteLine($"{item.Item1}-{item.Item2}-{item.Item3}");
            //}
            //foreach (var item in set.Where(u => u.Item1 != 10 && u.Item2 != 10 && u.Item3 != 10).Where(u => u.Item1 < u.Item2 && u.Item2 < u.Item3).OrderBy(u => u))
            //{
            //    Console.WriteLine($"{item.Item1}-{item.Item2}-{item.Item3}");
            //}

            return res;
        }

        // time to long ....
        public int Simple(int[] A)
        {
            var count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0) count++;

                for (int j = i + 1; j < A.Length; j++)
                {
                    if ((A[i] & A[j]) == 0)
                    {
                        count += 6;
                    }

                    for (int k = j + 1; k < A.Length; k++)
                    {
                        if ((A[i] & A[j] & A[k]) == 0)
                        {
                            count += 6;
                        }
                    }
                }
            }

            return count;
        }

        public int OtherSolution(int[] A)
        {
            int N = 1 << 16, M = 3;
            int[][] dp = new int[M + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[N];
            }

            dp[0][N - 1] = 1;
            for (int i = 0; i < M; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    foreach (int a in A)
                    {
                        dp[i + 1][k & a] += dp[i][k];
                    }
                }
            }

            return dp[M][0];
        }
    }
}