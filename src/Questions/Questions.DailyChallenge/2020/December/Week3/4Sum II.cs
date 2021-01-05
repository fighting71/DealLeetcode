using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/17/2020 4:06:20 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3569/
    /// @des : 存在多少个{i,j,k,l} 令 A[i] + B[j] + C[k] + D[l] = 0
    /// 
    /// ~哈希表的使用~
    /// 
    /// </summary>
    public class _4Sum_II
    {

        /*
         * 最简单的方法即为遍历a,b,c,d 的所有 {i,j,k,l} 令 A[i] + B[j] + C[k] + D[l] = 0 
         * 
         * 复杂度 = n^4
         * 
         * 为减少循环次数，simple采用分割进行计算：
         * 遍历a,b {i,j} 保留所有可能和
         * 
         * 再遍历 c,d {i,j} 查看之前的可能和是否满足
         * 
         * 复杂度 = 2 * n^2 * (可能和的查找)
         * 
         * main: ***使用哈希表实现可能和的查找***
         * 
         */

        // Your runtime beats 55.93 %
        // 出人意料，竟然速度还行
        public int Simple(int[] A, int[] B, int[] C, int[] D)
        {
            // max循环: 500 * 500 * 2 = 500000
            // 空间: 500 * 500 = 250000
            // solution==>穷举所有可能
            int len = A.Length;

            Dictionary<long, int> dic = new Dictionary<long, int>();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    long num = (long)A[i] + B[j];

                    if (dic.ContainsKey(num)) dic[num]++;
                    else dic[num] = 1;
                }
            }
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    long num = (long)C[i] + D[j];

                    if (dic.ContainsKey(-num)) res += dic[-num];
                }
            }
            return res;

        }
    }
}
