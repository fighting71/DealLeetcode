using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/27/2021 2:18:16 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3756/
    /// @des : 
    /// 
    ///     如果一个十进制数的每一个数字都是0或1，前导没有任何零，则称为十进位十进制数。例如，101和1100是十二进制，而112和3001不是。
    ///     
    ///     给定一个表示正十进制整数的字符串n，返回使其和为n所需的正十进制数的最小数目。
    ///     
    ///     示例1:
    ///     输入:n = "32"
    ///     输出:3
    ///     说明:10 + 11 + 11 = 32
    ///     示例2:
    /// 
    /// </summary>
    public class Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers
    {

        // Your runtime beats 58.71 %
        // xlxl 就这？cbddl
        public int MinPartitions(string n)
        {
            int res = 0;

            foreach (var c in n)
            {
                res = Math.Max(res, c - '0');
            }
            return res;
        }

    }
}
