using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 4:36:04 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3618/
    /// @des : 
    ///     给定一个n,将1,2...n的所有二进制连接起来，获取十进制值(总和=总和%10^9+7)
    ///     例如:n=3  2进制：1 , 10 , 11 = 11011 = 27(10进制)
    /// </summary>
    public class Concatenation_of_Consecutive_Binary_Numbers
    {

        // 1 <= n <= 10^5

        // Your runtime beats 95.87 %
        // 可达鸭眉头一紧，发现事情其实很简单...
        public int Solution(int n)
        {
            long res = 0, mul = 2, mod = 1000_000_007;

            for (int i = 1; i <= n; i++)
            {
                if (i == mul) mul *= 2; 
                res = (res * mul + i) % mod;
            }
            return (int)res;
        }


        // Your runtime beats 20.66 %
        public int Try(int n)
        {
            List<int> list = new List<int>();

            List<int> item = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (item.Count == 0)
                {
                    item.Add(1);
                }
                else
                {
                    item[item.Count - 1]++;

                    for (int j = item.Count - 1; j >= 0; j--)
                    {
                        if (item[j] == 2)
                        {
                            item[j] = 0;
                            if (j == 0)
                            {
                                item.Insert(0, 1);
                                break;
                            }
                            else
                            {
                                item[j - 1]++;
                            }
                        }
                        else
                            break;
                    }

                }

                list.AddRange(item);

            }

            long res = 0;

            int mod = 1000_000_007;

            //Console.WriteLine(string.Concat(list));
            for (int i = 0; i < list.Count; i++)
            {
                res = (res * 2 + list[i]) % mod;
                //Console.WriteLine(res);
            }

            return (int)res;

        }
        // bug : 相连2进制非相加
        public int Think(int n)
        {

            int num = 0;
            int res = 0;
            int mod = 1000_000_007;
            for (int i = 1; i <= n; i++)
            {
                num++;
                int mul = 1;
                if (num / mul % 10 == 2)
                {
                    num -= mul * 2;
                    mul *= 10;
                    num += mul;
                }
                res += num % mod;
                res %= mod;
            }

            return res;
        }

        public int GetBinaryNum(int n)
        {
            if (n == 0) return 0;
            return GetBinaryNum(n / 2) * 10 + n % 2;
        }

    }
}
