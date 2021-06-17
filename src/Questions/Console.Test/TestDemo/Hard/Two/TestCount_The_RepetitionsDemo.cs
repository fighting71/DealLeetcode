using Command.Helper;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/17/2021 3:08:49 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_The_RepetitionsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Count_The_Repetitions instance = new Count_The_Repetitions();
            BaseLibrary.CommonTest(new[] {
                    ("aaa",3,"aa",1), // 4
                    ("bacaba",3,"abacab",1), // 2
                    ("acb",4,"ab",2),// 2
                }
            //, arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            //, arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , arg => instance.Try4(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , () =>
            {

                var s2 = CollectionHelper.GetString(10, 'a');

                var s1 = CollectionHelper.GetString(random.Next(100) + s2.Length, () => s2[random.Next(s2.Length)]);

                var n2 = (random.Next(5) + 1) * 3;

                var n1 = (random.Next(10) + n2) * 2;

                return (s1, n1, s2, n2);

                //return (
                //    string.Concat(CollectionHelper.GetEnumerable(10, () => (char)(random.Next(10) + 'a'))),
                //    (random.Next(10) + 1) * 3,

                //    string.Concat(CollectionHelper.GetEnumerable(5, () => (char)(random.Next(10) + 'a'))),
                //    (random.Next(5) + 1) * 2
                //);
            }
            , checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , skipFunc: res => res == 0
            );

        }
    }
}
