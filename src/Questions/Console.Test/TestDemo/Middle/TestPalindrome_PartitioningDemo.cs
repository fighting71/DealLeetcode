using Command.Tools;
using Questions.Middle.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Middle
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 2:56:05 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPalindrome_PartitioningDemo : BaseDemo
    {

        public void Test()
        {
            IList<IList<string>> res = new Palindrome_Partitioning().Optimize("aab");

            ShowTools.Show(res);

            {
                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = new Palindrome_Partitioning().Optimize("qrxnfdznayannbotfypzvwvyuxybxfdthmmmeirqwgjnhpbmtlhhmhttwzthfxquuhgaocpwgzdonhqewmhmyvgastqepjkypptz");
                });
                Console.WriteLine($@"
------------
res:{res.Count}
------------
{codeTimerResult}");

            }

            for (int j = 0; j < 10; j++)
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < 50; i++)
                {
                    builder.Append((char)('a' + random.Next(26)));
                }
                Console.WriteLine($@"
str:  len - {builder.Length}
{builder}");

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = new Palindrome_Partitioning().Optimize(builder.ToString());
                });
                Console.WriteLine($@"
------------
res:{res.Count}
------------
{codeTimerResult}");

                var real = new Palindrome_Partitioning().Partition(builder.ToString());

                if (res.Count != real.Count)
                {
                    throw new Exception("bug");
                }

            }

        }


    }
}
