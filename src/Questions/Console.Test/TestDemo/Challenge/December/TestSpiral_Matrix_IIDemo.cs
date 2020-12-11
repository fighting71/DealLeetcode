using Command.Tools;
using Questions.DailyChallenge._2020.December.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/10/2020 10:45:05 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSpiral_Matrix_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Spiral_Matrix_II instance = new Spiral_Matrix_II();
            if (runSimple)
            { // simple
                for (int i = 2; i < 21; i++)
                {
                    ShowTools.Show(instance.GenerateMatrix(i));
                }
            }
            else
            { // speed&real
            }
        }
    }
}
