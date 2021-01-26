using Command.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 5:41:59 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSliding_Window_MedianDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Sliding_Window_Median instance = new Sliding_Window_Median();

            // [1,-1,-1,3,5,6]
            BaseLibrary.CommonTest(new[] {
                    (new []{1,1,1,1},2),
                    //(new []{1,2},1),
                    //(new []{1,3,-1,-3,5,3,6,7},3),
                    //(new []{int.MaxValue,int.MaxValue},2),
                }, arg => instance.Try(arg.Item1, arg.Item2), arg => instance.Simple(arg.Item1, arg.Item2), () =>
                {
                    var arr = CollectionHelper.GetArr(10000, () => random.Next(int.MaxValue)).ToArray();
                    return (arr, random.Next(arr.Length) + 1);
                }, showArg: false, showRes: false);
        }
    }
}
