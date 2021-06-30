using Command.Tools;
using Questions.DailyChallenge._2020.November.Week5;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 2:46:20 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestJump_Game_IIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Jump_Game_III instance = new Jump_Game_III();
            if (runSimple)
            { // simple
                var argArr = new[] {
                        (new[] { 4,2,3,0,3,1,2},5),// true
                        (new []{ 4,2,3,0,3,1,2},2),// true
                        (new []{ 3,0,2,1,2},2),// false
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Simple(item.Item1, item.Item2));
                }

            }
            else
            { // speed&real
            }
        }
    }
}
