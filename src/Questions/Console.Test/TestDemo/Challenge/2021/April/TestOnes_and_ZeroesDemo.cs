using Command.Helper;
using Command.Tools;
using Questions.DailyChallenge._2021.April.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 2:20:53 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestOnes_and_ZeroesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Ones_and_Zeroes instance = new Ones_and_Zeroes();

            BaseLibrary.CommonTest(new[] {
                    (new []{"10","0001","111001","1","0"},5,3),// 4
                    (new []{"10","0","1"},1,1),// 2

                }
            , arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3)
            //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
            , generateArg: () =>
            {
                return (
                        CollectionHelper.GetEnumerable(600, () => CollectionHelper.GetString(() => random.Next(100) + 1, () => (char)(random.Next(2) + '0'))).ToArray(),
                        //CollectionHelper.GetEnumerable(30, () => CollectionHelper.GetString(() => random.Next(100) + 1, () => (char)(random.Next(2) + '0'))).ToArray(),
                        random.Next(100) + 1,
                        random.Next(100) + 1
                    );
            }
            , formatArg: arg => $"{ShowTools.GetStr(arg.Item1)}\n{arg.Item2}\n{arg.Item3}"
            );

        }
    }
}
