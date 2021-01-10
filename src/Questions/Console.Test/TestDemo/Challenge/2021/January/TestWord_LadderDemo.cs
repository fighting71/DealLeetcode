using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/10/2021 12:30:56 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestWord_LadderDemo : IWork
    {
        public void Run()
        {

            Word_Ladder instance = new Word_Ladder();

            BaseLibrary.CommonTest(new[] {
                    ("hit","cog",new []{  "hot","dot","dog","lot","log","cog"}),// 5
                    ("hit","cog",new []{  "hot","dot","dog","lot","log"}), // 0
                }, arg => instance.LadderLength(arg.Item1, arg.Item2, arg.Item3));

        }
    }
}
