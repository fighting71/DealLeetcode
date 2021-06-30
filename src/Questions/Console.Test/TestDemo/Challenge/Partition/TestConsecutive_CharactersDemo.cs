using Command.Tools;
using Questions.DailyChallenge._2020.November.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/4/2020 5:26:05 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestConsecutive_CharactersDemo : BaseDemo
    {

        public void Run()
        {
            Consecutive_Characters instance = new Consecutive_Characters();
            { // simple
                Console.WriteLine(instance.Simple("leetcode"));
                Console.WriteLine(instance.Simple("abbcccddddeeeeedcba"));
                Console.WriteLine(instance.Simple("triplepillooooow"));
                Console.WriteLine(instance.Simple("hooraaaaaaaaaaay"));
                Console.WriteLine(instance.Simple("游客"));
            }
            { // speed&real
                CodeTimerResult codeTimerResult;
            }
        }

    }
}
