using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/23 17:17:38
    /// @source : https://leetcode.com/problems/ugly-number-iii/
    /// @des : 
    /// </summary>
    [Obsolete("crash...")]
    public class NthUglyNumber
    {
        private class NumItem
        {
            public NumItem(int num, int add)
            {
                Num = num;
                Add = add;
            }

            public int Num { get; set; }
            public int Add { get; }
        }

        private int Helper(NumItem minItem, NumItem num2, NumItem num3, int n)
        {
            var multiple = (Math.Min(num2.Num - minItem.Num, num3.Num - minItem.Num) / minItem.Add) + 1;

            if (multiple >= n)
            {
                minItem.Num += n * minItem.Add;
                return 0;
            }

            minItem.Num += multiple * minItem.Add;
            if (num2.Num == minItem.Num) num2.Num += num2.Add;
            if (num3.Num == minItem.Num) num3.Num += num3.Add;

            return n - multiple;
        }

        public int SimpleSolution(int n, int a, int b, int c)
        {

            return 0;

            #region bug

            // time limit
            //NumItem num = new NumItem(a, a), num2 = new NumItem(b, b), num3 = new NumItem(c, c);

            //int res;

            //while (true)
            //{
            //    if (num.Num <= num2.Num && num.Num <= num3.Num)
            //    {
            //        n = Helper(num, num2, num3, n);
            //        res = num.Num - num.Add;
            //    }
            //    else if (num2.Num <= num.Num && num2.Num <= num3.Num)
            //    {
            //        n = Helper(num2, num, num3, n);
            //        res = num2.Num - num2.Add;
            //    }
            //    else
            //    {
            //        n = Helper(num3, num2, num, n);
            //        res = num3.Num - num3.Add;
            //    }

            //    if (n == 0)
            //    {
            //        return res;
            //    }
            //}

            // time limit
            // 将abc放入一个列表中
//            var list = new[]
//            {
//                new[] {1, a},
//                new[] {1, b},
//                new[] {1, c},
//            };
//
//            while (true)
//            {
//                // 利用列表的排序功能获取最小的数
//
//                Console.WriteLine(JsonConvert.SerializeObject(list));
//
//                var min = GetMin(list);
//
//                if (--n == 0) return list[min][0] * list[min][1];
//
//                // 获取后让最小的数*基数
//                list[min][0]++;
//
//                // 为避免重复 例如 2*3 3*2 在出现重复时让重复数*基数
//                for (int i = 0; i < 3; i++)
//                {
//                    if (min != i && list[min][0] * list[min][1] == list[i][0] * list[i][1])
//                        list[i][0]++;
//                }
//            }

            // 定义一个一直自增的num
            // var num = 0;
            // while (n > 0)
            // {
            //     // 当num可以被a/b/c整除时 表示为一个合适的数字 出现次数减一
            //     if (++num % a == 0 || num % b == 0 || num % c == 0) n--;
            // }

            // 最终返回num,不用测肯定超时...
            // return num;

            #endregion

        }

        private int GetMin(int[][] arr)
        {
            var min = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i][0] * arr[i][1] < arr[min][0] * arr[min][1]) min = i;
            }

            return min;
        }
    }
}