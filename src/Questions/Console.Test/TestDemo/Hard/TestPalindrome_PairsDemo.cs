using Command.Tools;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/17/2020 6:57:38 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPalindrome_PairsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Palindrome_Pairs instance = new Palindrome_Pairs();
            if (runSimple)
            {
                var argArr = new[]
                {
                        new []{ "abcd", "dcba", "lls", "s", "sssll" },
                        new []{ "bat", "tab", "cat" }
                };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Simple(item));
                    ShowTools.Show(instance.Try2(item));
                }

            }
            //else 
            for (int k = 0; k < 10; k++)
            {

                int len = 5000, wordLen = 300;

                var arr = new string[len];
                for (int i = 0; i < len; i++)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < wordLen; j++)
                    {
                        builder.Append((char)(random.Next(26) + 'a'));
                    }
                    arr[i] = builder.ToString();
                }

                IList<IList<int>> real = null, res = null;

                //CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                //{
                //    real = instance.Simple(arr);
                //});

                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () =>
                {
                    res = instance.Try3(arr);
                });

                ShowTools.ShowMulti(new (string, object)[]
                {
                        (nameof(real),real),
                        (nameof(res),res),
                        //(nameof(codeTimerResult),codeTimerResult),
                        (nameof(codeTimerResult2),codeTimerResult2),
                });

            }
        }

    }
}
