using Command.Tools;
using Questions.DailyChallenge._2020.November.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/25/2020 12:18:04 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBasic_Calculator_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Basic_Calculator_II instance = new Basic_Calculator_II();
            if (runSimple)
            { // simple
                var argArr = new[] {
                        "3 + 2 * 2", // 7
                        "3/2", // 1
                        "3+5 / 2",// 5
                        $"0{int.MinValue}", // -int.min
                        "14/3*2"//8
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Calculate(item));
                    ShowTools.Show(instance.Optimize(item));
                }

            }
            else
            { // speed&real
            }
        }

    }
}
