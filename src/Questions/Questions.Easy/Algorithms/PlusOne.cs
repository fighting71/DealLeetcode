using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2020 2:30:09 PM
    /// @source : https://leetcode.com/problems/plus-one/
    /// @des : 
    /// </summary>
    public class PlusOne
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] Solution(int[] digits)
        {
            for (int n = digits.Length, i = n - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                    if (i == 0)
                    {
                        /**
                         * Runtime: 236 ms, faster than 72.04% of C# online submissions for Plus One.
                         * Memory Usage: 29.9 MB, less than 11.54% of C# online submissions for Plus One.
                         */
                        var list = new List<int>(digits);
                        list.Insert(0, 1);
                        return list.ToArray();

                        /**
                         * Runtime: 240 ms, faster than 49.19% of C# online submissions for Plus One.
                         * Memory Usage: 29.9 MB, less than 11.54% of C# online submissions for Plus One.
                         */
                        var arr = new int[n + 1];
                        Array.Copy(digits, 0, arr, 1, n);
                        arr[0] = 1;
                        return arr;
                    }
                }
                else
                {
                    digits[i]++;
                    break;
                }
            }

            return digits;

        }

        /// <summary>
        /// Runtime: 228 ms, faster than 93.97% of C# online submissions for Plus One.
        /// Memory Usage: 29.9 MB, less than 11.54% of C# online submissions for Plus One.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] Solution2(int[] digits)
        {
            int n = digits.Length;
            int[] prepareArr = new int[n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                    if (i == 0)
                    {
                        prepareArr[i + 1] = digits[i];
                        prepareArr[0] = 1;
                        return prepareArr;
                    }
                }
                else
                {
                    digits[i]++;
                    break;
                }
                prepareArr[i + 1] = digits[i];
            }

            return digits;

        }

        public int[] OtherSolution(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
            }

            var arr = new int[digits.Length + 1];
            arr[0] = 1;// 后面都是0还copy啥 傻了...

            return arr;

        }

    }
}
