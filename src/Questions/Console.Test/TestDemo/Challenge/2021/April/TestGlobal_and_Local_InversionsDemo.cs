using Command.Helper;
using Questions.DailyChallenge._2021.April.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 4:07:23 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestGlobal_and_Local_InversionsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Global_and_Local_Inversions instance = new Global_and_Local_Inversions();
            BaseLibrary.CommonTest(new[] {
                    new []{ 0,2,1 },// t
                    new []{ 1,0,2,3 },// t
                    new []{ 2,0,1 },// f
                    new []{ 1, 2, 0 },// f
                    new [] { 1, 0, 2 },// t
                }
            , instance.Solution2
            , () =>
            {
                List<int> list = Enumerable.Range(0, 5000).ToList();

                return CollectionHelper.GetEnumerable(list.Count, () =>
                {
                    var i = random.Next(list.Count);
                    var v = list[i];
                    list.RemoveAt(i);
                    return v;
                }).ToArray();
            }
            );
        }
    }
}
