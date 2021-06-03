using Questions.DailyChallenge._2021.June.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/3/2021 4:22:29 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestInterleaving_StringDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Interleaving_String instance = new Interleaving_String();

            Console.WriteLine(instance.Try2("", "b", "b"));
            Console.WriteLine(instance.Try2("aabcc", "dbbca", "aadbbcbcac"));
            Console.WriteLine(instance.Simple("aabcc", "dbbca", "aadbbcbcac"));

        }
    }
}
