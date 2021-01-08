using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 3:49:05 PM
    /// @source : https://leetcode.com/problems/k-th-smallest-in-lexicographical-order/
    /// @des : 
    ///     给定整数n和k，在1到n的范围内找出字典上第k小的整数。
    ///     （字典查找顺序）例:13:  [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9]
    /// </summary>
    [Obsolete]
    public class K_th_Smallest_in_Lexicographical_Order
    {

        // 1 ≤ k ≤ n ≤ 10^9


        public int Try2(int n, int k)
        {
            int clone = n, len = 0;

            while (clone > 0)
            {
                len++;
                clone /= 10;
            }

            /*
             * 210
             */

            while (k > 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    int curr = 0;
                    for (int j = 0; j < len; j++)
                    {

                    }

                }

            }

            return default;

        }

        public int Try(int n, int k)
        {


            int clone = n;

            List<int> list = new List<int>();

            while (clone> 0)
            {
                list.Add(clone % 10);
                clone /= 10;
            }

            int res = 0;

            /*
             * 200
             */

            while (k > 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    int curr = 0;
                    foreach (var item in list)
                    {
                        curr = curr * 10 + item;

                    }

                }

            }

            return default;

        }
    }
}
