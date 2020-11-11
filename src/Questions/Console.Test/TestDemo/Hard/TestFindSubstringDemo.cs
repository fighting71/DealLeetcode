using Command.Tools;
using ConsoleTest.LargeData;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    public class TestFindSubstringDemo : BaseDemo, IWork
    {
        public void Run()
        {
            FindSubstring instance = new FindSubstring();
            { // simple

                var argArr = new[]
                {
                        (LargeString.Data, new []{ "ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba","ab","ba"}),
                        ("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "good" }), // 8
                        ("barfoothefoobarman", new[] { "foo", "bar" }), //  [0,9]
                        ("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "word" }),// []
                        ("barfoofoobarthefoobarman", new[] { "bar", "foo", "the" }),// [6,9,12]
                    };

                foreach (var arg in argArr)
                {
                    ShowTools.Show(instance.Optimize2(arg.Item1, arg.Item2));
                }
            }
            for (int j = 0; j < 1000; j++)
            { // speed&real


                //var arg1 = GetRandStr(random.Next(1000_0) + 1);
                var arg1 = GetRandStr(1000_0);

                //var arg2 = new string[random.Next(5000) + 1];
                var arg2 = new string[10];

                for (int i = 0; i < arg2.Length; i++)
                {
                    //arg2[i] = GetRandStr(random.Next(30) + 1);
                    arg2[i] = GetRandStr(random.Next(10) + 3);
                }

                IList<int> res = null;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Optimize2(arg1, arg2);
                });

                if (res.Count > 0)
                {
                    ShowTools.ShowMulti(new Dictionary<string, object>()
                        {
                            {"arg",$"\"{arg1}\"\n{ShowTools.GetStr(arg2)}" },
                            { nameof(res),res},
                            { nameof(codeTimerResult),codeTimerResult},

                        });
                }

                string GetRandStr(int len)
                {
                    StringBuilder builder = new StringBuilder(len);

                    for (int i = 0; i < len; i++)
                    {
                        builder.Append((char)('a' + random.Next(26)));
                    }
                    return builder.ToString();
                }

            }
        }

    }
}
