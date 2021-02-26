using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2021 3:54:41 PM
    /// @source : https://leetcode.com/problems/kth-smallest-number-in-multiplication-table/
    /// @des : 
    ///     给定一个m * n的乘法表,返回表中第k小的数
    ///     table[m][n] = [
    ///                     1,  2,  3...    n
    ///                     2   4
    ///                     3   6
    ///                     .  
    ///                     .
    ///                     .
    ///                     m              m*n
    ///                     ]
    /// </summary>
    [Obsolete("没想到")]
    [Favorite(FlagConst.BinarySearch)]
    public class Kth_Smallest_Number_in_Multiplication_Table
    {

        // The m and n will be in the range [1, 30000].
        // The k will be in the range[1, m * n]

        #region other solution 
        // https://leetcode.com/problems/kth-smallest-number-in-multiplication-table/discuss/106977/Java-solution-binary-search
        // 666
        public int findKthNumber(int m, int n, int k)
        {
            // 二分查找
            int low = 1, high = m * n + 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;// 获取一个中间值
                int c = count(mid, m, n);// 统计[1,mid] 共有多少数
                if (c >= k) high = mid;
                else low = mid + 1;
            }

            return high;
        }

        private int count(int v, int m, int n)
        {
            int count = 0;
            for (int i = 1; i <= m; i++) // 遍历每一行
            {
                int temp = Math.Min(v / i, n); // v/i 即在此行可能出现的最大数量（理论上）   n为此行的总长度
                count += temp;
            }
            return count;
        }

        public int findKthNumber2(int m, int n, int k)
        {
            int lo = 1, hi = m * n;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2, cnt = 0;
                for (int i = 1, j = n; i <= m; i++) // 将count方法放在了一起
                {
                    while (j >= 1 && i * j > mid) j--;// 此处使用while 替换掉Maht.Min 按普遍情况上来说  Math.Min 优于> while
                    cnt += j;
                }
                if (cnt >= k) hi = mid;
                else lo = mid + 1;
            }
            return lo;
        }

        #endregion

        public int Try2(int m, int n, int k)
        {
            int curr = 1;
            bool[] visited = new bool[m + 1];
            while (k > 0)
            {
                Array.Fill(visited, false);
                int times = 0;
                for (int i = 1; i <= m; i++)
                {
                    if (curr % i != 0 || visited[i]) continue;
                    int j = curr / i;
                    if (j <= n)
                    {
                        if (i != j && j <= m)
                        {
                            times += 2;
                            visited[i] = visited[j] = true;
                        }
                        else
                        {
                            times++;
                            visited[i] = true;
                        }
                    }
                }

                k -= times;
                curr++;
            }

            return curr - 1;
        }

        public int Try(int m, int n, int k)
        {

            int curr = 1;
            while (k > 0)
            {
                int times = 0;
                for (int i = 1; i <= m; i++)
                {
                    if (curr % i != 0) continue;
                    int j = curr / i;
                    if (j <= n)
                    {
                        times++;
                    }
                }

                k -= times;
                curr++;
            }

            return curr - 1;
        }

        /// <summary>
        /// 获取乘法表
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GetTable(int m,int n)
        {
            var table = new int[m][];
            for (int i = 0; i < m; i++)
            {
                table[i] = new int[n];
                table[i][0] = i + 1;
            }

            for (int i = 0; i < n; i++)
            {
                table[0][i] = i + 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    table[i][j] = (i + 1) * (j + 1);
                }
            }
            return table;
        }

        public int Simple(int m, int n, int k)
        {
            int[][] table = GetTable(m, n);
            return table.SelectMany(u => u).OrderBy(u => u).Skip(k - 1).Take(1).First();
            //var table = new int[m][];
            //for (int i = 0; i < m; i++)
            //{
            //    table[i] = new int[n];
            //    table[i][0] = i + 1;
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    table[0][i] = i + 1;
            //}

            //List<int> list = new List<int>();

            //for (int i = 1; i < m; i++)
            //{
            //    for (int j = 1; j < n; j++)
            //    {
            //        list.Add(table[i][j] = (i + 1) * (j + 1));
            //    }
            //}

            //for (int i = 0; i < m; i++)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(table[i]));
            //}

            //return list.OrderBy(u => u).Skip(k - 1).Take(1).First();

        }

    }
}
