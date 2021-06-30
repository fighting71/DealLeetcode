using Command.Tools;
using Questions.DailyChallenge._2020.November.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 9:45:44 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinimum_Height_TreesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Minimum_Height_Trees instance = new Minimum_Height_Trees();
            { // simple

                ShowTools.Show(instance.OtherSolution(4, new[] {
                        new []{1, 0},
                        new []{1, 2},
                        new []{1, 3}
                    }));// [1]

                ShowTools.Show(instance.OtherSolution(6, new[] {
                        new []{3, 0},
                        new []{3,1},
                        new []{3,2},
                        new []{3,4},
                        new []{5,4}
                    }));// [3,4]


                ShowTools.Show(instance.OtherSolution(1, new int[0][]));// [0]

                ShowTools.Show(instance.OtherSolution(2, new[] {
                        new []{1, 0},
                    }));// [0,1]

            }
            { // speed&real
            }
        }
    }
}
