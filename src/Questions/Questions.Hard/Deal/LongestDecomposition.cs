using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/16 星期五 下午 3:58:26
    /// @source : https://leetcode.com/problems/longest-chunked-palindrome-decomposition/
    /// @des : 
    /// </summary>
    public class LongestDecomposition
    {
        public void Test()
        {
            Console.WriteLine(Solution("ghiabcdefhelloadamhelloabcdefghi") == 7);

            Console.WriteLine(Solution("merchant") == 1);

            Console.WriteLine(Solution("aaa") == 3);

            Console.WriteLine(Solution("antaprezatepzapreanta") == 11);
        }

        public void Test(Func<string, int> solutionFunc)
        {
            Console.WriteLine(solutionFunc("ghiabcdefhelloadamhelloabcdefghi") == 7);

            Console.WriteLine(solutionFunc("merchant") == 1);

            Console.WriteLine(solutionFunc("aaa") == 3);

            Console.WriteLine(solutionFunc("antaprezatepzapreanta") == 11);
        }

        /**
         * Runtime: 72 ms, faster than 98.55% of C# online submissions for Longest Chunked Palindrome Decomposition.
         * Memory Usage: 20 MB, less than 100.00% of C# online submissions for Longest Chunked Palindrome Decomposition.
         */
        public int Solution(string text)
        {
            //if (text.Length <= 1) return 1;

            int res = 0, start = 0, end = text.Length - 1, len = 1, txtLen = text.Length;

            while (end > start)
            {
                bool flag = true;
                for (var i = 0; i < len; i++)
                {
                    //Console.WriteLine($"len : {len}, start : {start},i : {i},{start - i} vs {txtLen - 1 - start + len - 1 - i}");
                    // txtLen - 1 : last index
                    // start : left : 0 - start   right : len 
                    if (text[start - i] != text[txtLen - 1 - start + len - 1 - i])
                    {
                        flag = false;
                        break;
                    }
                }

                end--;
                start++;

                if (flag)
                {
                    res += 2;
                    len = 1;
                }
                else
                {
                    len++;
                }
            }

            if (start == end || len > 1) res++;

            return res;
        }

        public void TestCase(int testCount, int textLen, Func<string, int> func, Func<string, int> compareFunc = null)
        {
            var rand = new Random();

            for (int i = 0; i < testCount; i++)
            {
                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < rand.Next(textLen); j++)
                {
                    builder.Append((char) (rand.Next(26) + 'a'));
                }

                var txt = builder.ToString();

                var res = func(txt);


                Console.WriteLine($"txt:{txt}");

                if (compareFunc == null)
                    Console.WriteLine($"res:{res}");
                else
                {
                    var compare = compareFunc(txt);
                    if (res != compare)
                        throw new Exception($"test failure : res-{res},compare-{compare}");
                }
            }
        }
    }
}