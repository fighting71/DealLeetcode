using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 8/11/2020 3:44:27 PM
    /// @source : https://leetcode.com/problems/permutation-sequence/
    /// @des : 
    /// </summary>
    public class Permutation_Sequence
    {

        /**
         * 
"123"
"132"
"213"
"231"
"312"
"321"
         * 
         */

        /**
         * Runtime: 76 ms, faster than 94.49% of C# online submissions for Permutation Sequence.
         * Memory Usage: 23.1 MB, less than 12.13% of C# online submissions for Permutation Sequence.
         */
        public string Clear(int n, int k)
        {

            int mult = 1, flag = 0;

            for (int i = 2; i < n; i++)
            {
                mult *= i;
            }

            StringBuilder builder = new StringBuilder(n);
            List<int> list = new List<int>(Enumerable.Range(1, n));

            for (int i = n; i > 1; i--)
            {
                if (k == 1)
                {
                    builder.Append(list[flag++]);
                    continue;
                }
                else if (k == 0)
                {
                    builder.Append(list[flag--]);
                    continue;
                }
                int index = k / mult + ((k %= mult) == 0 ? 0 : 1) - 1;

                builder.Append(list[index]);
                list.RemoveAt(index);
                mult /= i - 1;

                if (k == 0) flag = list.Count - 1;
            }

            builder.Append(list[flag]);

            return builder.ToString();
        }

        /**
         * Runtime: 84 ms, faster than 58.09% of C# online submissions for Permutation Sequence.
         * Memory Usage: 22.9 MB, less than 28.86% of C# online submissions for Permutation Sequence.
         * 
         * 可
         * 
         */
        public string Simple(int n, int k)
        {

            int mult = GetMultiply(n - 1);

            StringBuilder builder = new StringBuilder(n);

            List<int> list = new List<int>(Enumerable.Range(1, n));

            for (int i = n; i > 1; i--)
            {

                if (k == 1)
                {
                    builder.Append(list[0]);
                    list.RemoveAt(0);
                    continue;
                }
                else if (k == 0)
                {
                    /**
                     * Runtime: 80 ms, faster than 84.38% of C# online submissions for Permutation Sequence.
                     * Memory Usage: 22.8 MB, less than 82.72% of C# online submissions for Permutation Sequence
                     */
                    builder.Append(list[list.Count - 1]);
                    list.RemoveAt(list.Count - 1);
                    continue;
                }
                int index = k / mult + ((k %= mult) == 0 ? 0 : 1) - 1;
                builder.Append(list[index]);
                list.RemoveAt(index);
                mult /= i - 1;
            }

            builder.Append(list[0]);

            return builder.ToString();
        }

        public string Explain(int n, int k)
        {

            // 获取n-1的乘阶
            int mult = 1,
                // 减少移除操作
                flag = 0;

            for (int i = 2; i < n; i++)
            {
                mult *= i;
            }

            StringBuilder builder = new StringBuilder(n);

            // 将 {1,2,...n} 放置到集合中
            List<int> list = new List<int>(Enumerable.Range(1, n));

            for (int i = n; i > 1; i--) // 遍历获取位置
            {
                if (k == 1) // x%1 = 1 (x>1) ,即永远为第一位
                {
                    builder.Append(list[flag++]);
                    continue;
                }
                else if (k == 0)// 能整除 取最后一位
                {
                    builder.Append(list[flag--]);
                    continue;
                }

                // 以n=3为例，1/2/3排列在第一位都有2种可能
                // 当k = 1/2 时1为第一位
                // 当k = 3/4 时2为第一位
                // ...

                // 当k = 1-(n-1)! 时 1为第一位
                // 当k = ((n-1)!+1) -2*((n-1)!) 时 2为第一位
                int index = k / mult + ((k %= mult) == 0 ? 0 : 1) - 1;

                // 将目标元素进行添加
                builder.Append(list[index]);
                // 移除已添加元素
                list.RemoveAt(index);
                // 简化计算(i-1)!
                mult /= i - 1;

                // 以n=3为例
                // 2时整除 则res = 132
                // 4时整除 则res = 231
                // 即能整除时，(i-1...1)取值往往是最后一个元素
                if (k == 0) flag = list.Count - 1;
            }

            builder.Append(list[0]);

            return builder.ToString();
        }

        public int GetMultiply(int num)
        {
            if (num < 3) return num;
            return num * GetMultiply(num - 1);
        }

    }
}
