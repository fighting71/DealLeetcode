using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/4/2021 10:47:07 AM
    /// @source : https://leetcode.com/problems/consecutive-numbers-sum/
    /// @des : 
    ///     给定一个正整数n，有多少种方法可以把它写成连续正整数的和?
    ///     
    ///     示例：9 = 9 = 4 + 5 = 2 + 3 + 4
    /// </summary>
    [Serie(FlagConst.Easy, FlagConst.Special)]
    public class Consecutive_Numbers_Sum
    {

        // Note: 1 <= n <= 10 ^ 9.

        // Runtime: 40 ms, faster than 89.47% of C# online submissions for Consecutive Numbers Sum.
        // Memory Usage: 15.2 MB, less than 40.35% of C# online submissions for Consecutive Numbers Sum.
        // 嗯？？？ 啊这... 感觉像是搞错了 这种也算hard?
        // 找到规律后很简单，规律也比较明显。
        public int Try(int n)
        {
            /**
             * i 表示当前有多少个数字
             * 
             * sum 当有i个连续正整数时所需要的最小的和
             * 
             * 若i%2 == 0 有偶数个数字,示例：
             *      1,2  = 3 = 1*2 + 1
             *      1,2,3,4 = 2*4 + 2
             *      故 n要满足 n % i = i/2 且最小的数 > 0(满足正整数)
             *      
             * 若i%2 == 1 有奇数个数字,示例：
             *      1,2,3 = 6 = 2 * 3
             *      1,2,3,4,5 = 3 * 5
             *      故 n要满足 n%i == 0 且最小的数 > 0(满足正整数)
             * 
             * optimize => 拆分为两个循环，去除if判断
             * 
             */
            int res = 1, sum = 1, i = 2;

            while (n >= sum)
            {
                if (i % 2 == 0)
                {
                    var remind = n % i;
                    var half = i / 2;
                    if (remind == half && n / i - half + 1 > 0)
                    {
                        res++;
                    }
                }
                else if (n % i == 0)
                {
                    var mid = n / i;

                    if (mid - i / 2 > 0)
                    {
                        res++;
                    }
                }
                sum += i++;
            }

            return res;
        }

        // slow
        public int Simple(int n)
        {

            int res = 1;

            for (int i = 2; i < n; i++)
            {
                if (i % 2 == 0)
                {

                    var remind = n % i;
                    var half = i / 2;
                    if (remind == half && n / i - half + 1 > 0)
                    {
                        //Console.WriteLine($">>>>{i}");
                        res++;
                    }
                }
                else if (n % i == 0)
                {
                    var mid = n / i;

                    if (mid - i / 2 > 0)
                    {
                        //Console.WriteLine($">>>>{i}");
                        res++;
                    }
                }
            }
            return res;
        }

    }
}
