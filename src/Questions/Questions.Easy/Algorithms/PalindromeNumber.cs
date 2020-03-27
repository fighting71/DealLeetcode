using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/27/2020 5:10:09 PM
    /// @source : https://leetcode.com/problems/palindrome-number/
    /// @des : 
    /// </summary>
    public class PalindromeNumber
    {

        /// <summary>
        /// Runtime: 48 ms, faster than 98.98% of C# online submissions for Palindrome Number.
        /// Memory Usage: 16.4 MB, less than 15.00% of C# online submissions for Palindrome Number.
        /// 
        /// ... 告辞
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool Solution2(int x)
        {

            if (x < 0) return false;

            var str = x.ToString();

            for (int i = 0; i < str.Length / 2; i++)
                if (str[i] != str[str.Length - 1 - i]) return false;

            return true;

        }

        /// <summary>
        /// Runtime: 76 ms, faster than 29.36% of C# online submissions for Palindrome Number.
        /// Memory Usage: 18.6 MB, less than 5.00% of C# online submissions for Palindrome Number.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool Solution(int x)
        {

            if (x < 0) return false;

            List<int> list = new List<int>();

            while (x > 0)
            {
                list.Add(x % 10);
                x /= 10;
            }

            for (int i = 0; i < list.Count/2; i++)
            {
                if (list[i] != list[list.Count - 1 - i]) return false;
            }

            return true;

        }

    }
}
