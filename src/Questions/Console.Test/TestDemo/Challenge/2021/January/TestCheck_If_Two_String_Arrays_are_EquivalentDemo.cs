using Command.Helper;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/15/2021 4:30:25 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCheck_If_Two_String_Arrays_are_EquivalentDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Check_If_Two_String_Arrays_are_Equivalent instance = new Check_If_Two_String_Arrays_are_Equivalent();

            BaseLibrary.CommonTest(new[] {
                   (new []{ "ab", "c"},new []{ "a","bcd" }),
                   (new []{ "ab", "c"},new []{ "a", "bc"}),
                   (new []{ "a", "cb"},new []{ "ab", "c"}),
                   (new []{ "abc", "d", "defg"},new []{ "abcddefg" }),
                }, arg => instance.ArrayStringsAreEqual(arg.Item1, arg.Item2), () =>
                {

                    Func<string> getEle = () =>
                    {
                        var len = random.Next(1000) + 1;
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < len; i++)
                        {
                            builder.Append((char)(random.Next(5) + 'a'));
                        }
                        return builder.ToString();
                    };

                    return (CollectionHelper.GetArr(1000, getEle).ToArray(),
                     CollectionHelper.GetArr(1000, getEle).ToArray());
                }, showArg: false);

        }
    }
}
