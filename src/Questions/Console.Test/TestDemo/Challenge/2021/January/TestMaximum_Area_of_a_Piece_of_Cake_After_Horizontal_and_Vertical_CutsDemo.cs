using Questions.DailyChallenge._2021.June.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/3/2021 6:27:57 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMaximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_CutsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts instance = new Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts();

            Console.WriteLine(instance.Simple(5, 4, new[] { 1, 2, 4 }, new[] { 1, 3 })); // 4
            Console.WriteLine(instance.Simple(5, 4, new[] { 3, 1 }, new[] { 1 })); // 6
            Console.WriteLine(instance.Simple(5, 4, new[] { 3 }, new[] { 3 })); // 9

        }

    }
}
