using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/19/2020 2:22:00 PM
    /// @source : https://leetcode.com/problems/candy/
    /// @des : 
    /// </summary>
    public class Candy
    {

        /// <summary>
        /// source:https://leetcode.com/problems/candy/discuss/42769/A-simple-solution
        /// 
        /// Runtime: 104 ms, faster than 93.26% of C# online submissions for Candy.
        /// Memory Usage: 29.9 MB, less than 100.00% of C# online submissions for Candy.
        /// 
        /// wc... 差不多的思路 
        /// 
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int OtherSolution(int[] ratings)
        {
            int n = ratings.Length;
            int[] res = new int[n];
            Array.Fill(res, 1);
            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    res[i] = res[i - 1] + 1;
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                if (ratings[i - 1] > ratings[i])
                {
                    res[i - 1] = Math.Max(res[i] + 1, res[i - 1]);
                }
            }

            int sum = 0;
            foreach (int r in res) sum += r;

            return sum;
        }

        // bug
        public int Fast(int[] ratings)
        {

            if (ratings.Length < 2) return ratings.Length;

            int n = ratings.Length,num = ratings[0] > ratings[1] ? 2 : 1,res = num,bigger = 0;

            for (int i = 1; i < n - 1;i++)
            {

                if (ratings[i] > ratings[i - 1])
                {
                    num++;
                    bigger = 0;
                }
                else if (ratings[i] > ratings[i + 1])
                {
                    if(ratings[i] == ratings[i - 1])
                    {
                        bigger = 0;
                    }
                    else
                    {
                        bigger++;
                    }
                    Console.WriteLine($"i:{i},num:{num},bigger:{bigger}");
                    if (num == 2) { res += bigger; }
                    num = 2;
                }
                else
                {
                    bigger = 0;
                    num = 1;
                }

                res += num;
            }

            res += ratings[n - 1] > ratings[n - 2] ? num + 1 : 1;

            //ShowTools.ShowLine(ratings);

            return res;
        }

        /// <summary>
        /// Runtime: 1120 ms, faster than 5.62% of C# online submissions for Candy.
        /// Memory Usage: 29.9 MB, less than 100.00% of C# online submissions for Candy.
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int Solution(int[] ratings)
        {

            if (ratings.Length < 2) return ratings.Length;

            int n = ratings.Length;

            int[] record = new int[n];

            int res = record[0] = ratings[0] > ratings[1] ? 2 : 1;

            for (int i = 1; i < n - 1;)
            {

                if (ratings[i] > ratings[i - 1])
                    record[i] = record[i - 1] + 1;
                else if (ratings[i] > ratings[i + 1])
                {
                    Console.Write($"i:{i}");
                    record[i] = 2;
                    for (int j = i; j > 0 && record[j] >= record[j - 1] && ratings[j] < ratings[j - 1]; res++)
                    {
                        record[--j]++;
                        Console.Write("\tup");
                    }
                    Console.WriteLine();
                }
                else
                    record[i] = 1;

                res += record[i++];
            }

            res += ratings[n - 1] > ratings[n - 2] ? record[n - 2] + 1 : 1;

            ShowTools.ShowLine(Enumerable.Range(0,n));
            ShowTools.ShowLine(ratings);
            ShowTools.ShowLine(record);

            return res;
        }

        /// <summary>
        /// Runtime: 1548 ms, faster than 5.62% of C# online submissions for Candy.
        /// Memory Usage: 29.9 MB, less than 100.00% of C# online submissions for Candy.
        /// 
        /// 仁慈的测试案例~
        /// 
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int Simple(int[] ratings)
        {

            if (ratings.Length < 2) return ratings.Length;

            int res = 0, n = ratings.Length;

            int[] record = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    if (ratings[i] > ratings[i + 1])
                    {
                        record[i] = 2;
                    }
                    else
                    {
                        record[i] = 1;
                    }
                }
                else if (i == n - 1)
                {
                    if (ratings[i] > ratings[i - 1])
                    {
                        record[i] = record[i - 1] + 1;
                    }
                    else
                    {
                        record[i] = 1;
                    }
                }
                else
                {
                    if (ratings[i] > ratings[i - 1])
                        record[i] = record[i - 1] + 1;
                    else if (ratings[i] > ratings[i + 1])
                    {
                        record[i] = 2;
                        for (int j = i; j > 0 && ratings[j] < ratings[j - 1] && record[j] >= record[j - 1]; j--)
                        {
                            res -= record[j - 1];
                            record[j - 1] = record[j] + 1;
                            res += record[j - 1];
                        }
                    }
                    else
                        record[i] = 1;
                }
                res += record[i];
            }

            //ShowTools.ShowLine(ratings);
            //ShowTools.ShowLine(record);

            return res;
        }

        public int Try(int[] ratings)
        {

            if (ratings.Length < 2) return ratings.Length;

            int res = 0,n = ratings.Length;

            int[] record = new int[n];

            for (int i = 0; i < n; i++)
            {
                if(i == 0)
                {
                    if(ratings[i] > ratings[i + 1])
                    {
                        record[i] = 2;
                    }
                    else
                    {
                        record[i] = 1;
                    }
                }
                else if(i == n - 1)
                {
                    if(ratings[i] > ratings[i - 1])
                    {
                        record[i] = 2;
                    }
                    else
                    {
                        record[i] = 1;
                    }
                }
                else
                {
                    if (ratings[i] > ratings[i - 1])
                        record[i] = record[i - 1] + 1;
                    else if (ratings[i] > ratings[i - 1])
                        record[i] = 2;
                    else
                        record[i] = 1;
                }
                res += record[i];
            }

            ShowTools.ShowLine(record);

            return res;
        }

    }
}
