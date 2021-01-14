using Command.Tools;
using Questions.DailyChallenge._2021.January.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 4:57:18 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMerge_Sorted_ArrayDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Merge_Sorted_Array instance = new Merge_Sorted_Array();

            var arr1 = new[] { 1, 2, 3, 0, 0, 0 };
            var arr2 = new[] { 2, 5, 6 };
            instance.Simple(arr1, 3, arr2, 3);

            ShowTools.Show(arr1);

        }
    }
}
