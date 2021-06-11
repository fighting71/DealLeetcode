using Command.Helper;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.June.Week2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/10/2021 2:11:06 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestJump_Game_VIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Jump_Game_VI instance = new Jump_Game_VI();

            BaseLibrary.CommonTest(new[] {
                    (new []{ -2537, -11827, 2384, -5232, -844, 7744, 8353, 3153, 1324, -1520 } , 10), // -1520
                    (new []{ 1,-1,-2,4,-7,3 } , 2), // 7
                    (new []{ 10, -5, -2, 4, 0, 3 } , 3), // 17
                    (new []{ 1, -5, -20, 4, -1, 3, -6, -3 } , 2), // 0
                }
            , arg => instance.OtherSolution(arg.Item1, arg.Item2)
            , () =>
            {
                int len = 400_000;
                    //int len = 10;
                    return (
                    CollectionHelper.GetEnumerable(len, () => random.Next(-10_000, 10_000)).ToArray(),
                    len
                );
            }
            //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2)
            , checkFunc: arg => instance.Try(arg.Item1, arg.Item2)
            , showArg: false
            , formatArg: arg => $"{JsonConvert.SerializeObject(arg.Item1)}\n{arg.Item2}"
            //, codeTimeCount: 50
            );

        }

    }
}
