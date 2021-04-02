using Command.Helper;
using Questions.DailyChallenge._2021.March.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/2/2021 4:53:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStamping_The_SequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Stamping_The_Sequence instance = new Stamping_The_Sequence();

            BaseLibrary.CommonTest(new[] {
                    ("cab","cabbb"), // 210
                    ("oz","ooozz"), // 3 0,1,2
                    ("abc","ababc"), // 0 2
                    ("abca","aabcaca"), // 3 0 1
                    ("h","hhhhh"), // 3 0 1
                }
            , arg => instance.Try2(arg.Item1, arg.Item2)
            , generateArg: () =>
            {
                    //string target = CollectionHelper.GetString(random.Next(1000) + 1, () => (char)(random.Next(26) + 'a'));
                    //string stamp = CollectionHelper.GetString(random.Next(target.Length) + 1, () => (char)(random.Next(26) + 'a'));
                    string target = CollectionHelper.GetString(random.Next(1000) + 20, () => (char)(random.Next(4) + 'a'));
                string stamp = CollectionHelper.GetString(random.Next(target.Length) + 1, () => (char)(random.Next(4) + 'a'));

                return (stamp, target);
            }
            , skipFunc: res => res.Length == 0
            );

        }
    }
}
