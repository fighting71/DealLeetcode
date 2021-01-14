using Command.Tools;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 3:30:30 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestAdd_Two_NumbersDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Add_Two_Numbers instance = new Add_Two_Numbers();

            ShowTools.Show(instance.Simple(new[] { 0, 8, 6, 5, 6, 8, 3, 5, 7 }, new[] { 6, 7, 8, 0, 8, 5, 8, 9, 7 }));
            ShowTools.Show(instance.Simple(new[] { 2, 4, 9 }, new[] { 5, 6, 4, 9 }));
        }
    }
}
