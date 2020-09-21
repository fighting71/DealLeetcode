using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/21/2020 6:49:27 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPalindrome_Partitioning_IIDemo
    {

        public static void Test()
        {
            Palindrome_Partitioning_II instance = new Palindrome_Partitioning_II();

            CodeTimerResult codeTimerResult;

            {
                string[] arr = new[]
                {
                        "bb",
                        "aaabdba",
                        "ccbdbcca",
                        "ccbdbcca",
                        "abdbcc",
                        "ccbdcc",
                        "ccbccdcc",
                        "cbcbbc",
                        "ababbbabbaba",
                        //"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    };

                foreach (var item in arr)
                {
                    break;
                    Console.WriteLine(item);

                    int res = 0, real = 0;
                    codeTimerResult = BaseTools.codeTimer.Time(1, () => {
                        res = new Palindrome_Partitioning_II().Solution(item);
                    });

                    Console.WriteLine($"res:{res},\ntime:{codeTimerResult}");

                    real = new Palindrome_Partitioning_II().Clear(item);
                    if (real != res)
                    {
                        throw new Exception("bug");
                    }
                }

            }
            //return;
            for (int j = 0; j < 1000; j++)
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < 500; i++)
                {
                    builder.Append((char)('a' + BaseTools.random.Next(26)));
                }
                Console.WriteLine($@"
str:  len - {builder.Length}
{builder}");

                int res = 0, real = 0;
                codeTimerResult = BaseTools.codeTimer.Time(1, () => {
                    res = new Palindrome_Partitioning_II().Solution(builder.ToString());
                });
                Console.WriteLine($@"
------------
res:{res}
------------
{codeTimerResult}");

                //                    codeTimerResult = codeTimer.Time(1, () => {
                //                        res = new Palindrome_Partitioning_II.Try2().Solution(builder.ToString());
                //                    });
                //                    Console.WriteLine($@"
                //---------Try2---
                //res:{res}
                //------------
                //{codeTimerResult}");

                //real = new Palindrome_Partitioning_II.Check().Solution(builder.ToString());
                real = new Palindrome_Partitioning_II().Clear(builder.ToString());

                if (real != res)
                {
                    throw new Exception("bug");
                }

            }

        }

    }
}
