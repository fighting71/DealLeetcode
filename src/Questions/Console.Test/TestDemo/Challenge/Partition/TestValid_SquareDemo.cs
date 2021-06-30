using Questions.DailyChallenge._2020.November.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/12/2020 9:39:47 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestValid_SquareDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Valid_Square instance = new Valid_Square();
            { // simple
                Console.WriteLine(instance.OtherSolution(new[] { 0, 0 }, new[] { 5, 0 }, new[] { 5, 4 }, new[] { 0, 4 }));
                //Console.WriteLine(instance.OtherSolution(new[] { 0, 0 },new[] { 1, 1 },new[] { 1, 0 },new[] { 0, 1 }));
            }
            { // speed&real
            }
        }
    }
}
