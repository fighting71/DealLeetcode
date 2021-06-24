using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/28/2021 11:28:53 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestZuma_GameDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Zuma_Game instance = new Zuma_Game();

            var choice = "RYBGW";

            string GetStr(int len)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < len; i++)
                {
                    var item = choice[random.Next(choice.Length)];

                    if (i > 1 && builder[i - 1] == item && builder[i - 2] == item) i--;
                    else
                    {
                        builder.Append(item);
                    }
                }
                return builder.ToString();
            }

            BaseLibrary.CommonTest(new[] {
                    ("RRWWRRBBRR", "WB"), // 2 ??? 
                    ("WRRBBW", "RB"), // -1
                    ( "WWRRBBWW", "WRBRW"), // 2
                    (  "G", "GGGGG"), // 2
                    (  "RBYYBBRRB", "YRBGB"), // 3
                }, arg => instance.Try2(arg.Item1, arg.Item2), () => (GetStr(15), GetStr(5)), codeTimeCount: 100000, isShowInfo: res => res > 0);

        }
    }
}
