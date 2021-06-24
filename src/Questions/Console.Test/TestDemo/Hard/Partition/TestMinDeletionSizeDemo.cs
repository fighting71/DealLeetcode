using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/10/2020 5:27:31 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinDeletionSizeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            MinDeletionSize instance = new MinDeletionSize();
            { // simple
                List<string[]> argArr = new List<string[]>
                    {
                        new []{"aaababaabaababaaabbaaaabbabbbababbaaabbabbbbbabaaaaabbabbbbbaaababaaaaabaaabbbbbaaabbabababaabbaabab","aaaaaaaaaaabbaaaabaaaaabaabaabbbaabaaaaaababbbbabaabababbaabababaaabbabaaaaaaaaabbbaabbabbaaaaaaaabb"},//57
                        //new []{"bbazb", "dabca"},//3
                        //new []{"dabca", "bbazb"},//3
                        //new []{"edcba"},//4
                        //new []{"ghi", "def", "abc"},//0
                        //new []{"aaaabaa"},//1
                        //new []{"abcacba", "cbbcacb", "acabcbb", "aabaabc"},//4
                    };

                foreach (var arg in argArr)
                {
                    Console.WriteLine(instance.Solution(arg));
                }

            }
            for (int i = 0; i < 1000; i++)
            { // speed&real
                var len = random.Next(100) + 1;

                var arr = new string[random.Next(100) + 1];
                //var len = 1000;

                //var arr = new string[1000];

                for (int j = 0; j < arr.Length; j++)
                {
                    StringBuilder builder = new StringBuilder();

                    for (int k = 0; k < len; k++)
                    {
                        builder.Append((char)(random.Next(26) + 'a'));
                    }

                    arr[j] = builder.ToString();
                }

                int res = default,real = default;

                var codeTimerResult = codeTimer.Time(1, (Action)(() => { real = instance.Solution((string[])arr); }));
                var codeTimerResult2 = codeTimer.Time(1, (() => { res = instance.Optimize(arr); }));
                ShowTools.ShowMulti(new Dictionary<string, object>()
                        {
                            {nameof(res), res},
                            {nameof(codeTimerResult), codeTimerResult},
                            {nameof(codeTimerResult2), codeTimerResult2},
                            //{nameof(arr), arr}
                        });

                if (real != res) throw bugEx;

            }
        }

    }
}
