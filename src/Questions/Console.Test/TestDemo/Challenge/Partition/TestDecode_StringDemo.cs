using Command.Tools;
using Questions.DailyChallenge._2020.November.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 6:52:33 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestDecode_StringDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Decode_String instance = new Decode_String();
            if (runSimple)
            { // simple
                var argArr = new[]
                {
                        "3[a]2[bc]",
                        "3[a2[c]]",
                        "2[abc]3[cd]ef",
                        "abc3[cd]xyz"
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.DecodeString(item));
                    ShowTools.Show(instance.Solution2(item));
                }

            }
            else
            { // speed&real
            }
        }

    }
}
