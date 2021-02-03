using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/1/2021 5:25:10 PM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3625/
    /// @des : 
    ///     给定一个数字n
    ///     target: 转为2进制后有多少位1?
    /// </summary>
    public class Number_of_1_Bits
    {

        // slow
        public int Simple(uint n)
        {
            int res = 0;

            while (n > 0)
            {
                res += n % 2 == 0 ? 0 : 1;
                n /= 2;
            }

            return res;
        }

        int OtherSolution(uint n)
        {
            int count = 0;

            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }

            return count;
        }

    }
}
