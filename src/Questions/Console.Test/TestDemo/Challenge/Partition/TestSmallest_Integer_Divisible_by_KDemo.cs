using Command.Tools;
using Questions.DailyChallenge._2020.November.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 10:14:15 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSmallest_Integer_Divisible_by_KDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Smallest_Integer_Divisible_by_K instance = new Smallest_Integer_Divisible_by_K();

            if (runSimple)
            { // simple

                //ShowTools.Show(instance.Try2(43));//21
                for (int i = 1; i < 106; i++)
                {
                    var res = instance.OldSolution(i);
                    if (res != -1)
                        ShowTools.Show($"{i}:{res}");
                }

            }
            else
            { // speed&real
            }
        }
    }
}
