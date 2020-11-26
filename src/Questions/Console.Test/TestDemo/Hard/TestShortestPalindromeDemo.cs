using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 9:42:32 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestShortestPalindromeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            ShortestPalindrome instance = new ShortestPalindrome();

            //instance.IsDebug = true;

            ShowTools.ShowIndex("bbacabbacabbabbcacabcabcccccaaaabccba");

            Console.WriteLine(instance.Simple("bbacabbacabbabbcacabcabcccccaaaabccba"));
            Console.WriteLine(instance.Solution("bbacabbacabbabbcacabcabcccccaaaabccba"));

            Console.WriteLine(instance.Simple("cabcbacbacaccaaaacacaabcba"));
            Console.WriteLine(instance.Solution("cabcbacbacaccaaaacacaabcba"));

            Console.WriteLine(instance.Simple("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));
            Console.WriteLine(instance.Solution("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));

            Console.WriteLine(instance.Simple("bcbbbcccaabbbcaaaba"));
            Console.WriteLine(instance.Solution("bcbbbcccaabbbcaaaba"));

            Console.WriteLine(instance.Simple("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            Console.WriteLine(instance.Solution("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));

            Console.WriteLine(instance.Simple("aabba"));
            Console.WriteLine(instance.Solution("aabba"));

            Console.WriteLine(instance.Simple("aacecaaa"));
            Console.WriteLine(instance.Solution("aacecaaa"));

            Console.WriteLine(instance.Simple("abcd"));
            Console.WriteLine(instance.Solution("abcd"));
            Console.ReadKey(true);
            for (int i = 0; i < 100000; i++)
            {
                StringBuilder builder = new StringBuilder();

                var len = random.Next(40000);

                for (int j = 0; j < len; j++)
                {
                    builder.Append((char)('a' + random.Next(3)));
                }

                var real = instance.Simple(builder.ToString());
                var res = instance.Solution(builder.ToString());

                ShowTools.ShowMulti(new System.Collections.Generic.Dictionary<string, object>() {
                    {nameof(builder),builder },
                    {nameof(real),real },
                    {nameof(res),res },
                });

                if (real != res) throw new Exception();

            }
        }
    }
}
