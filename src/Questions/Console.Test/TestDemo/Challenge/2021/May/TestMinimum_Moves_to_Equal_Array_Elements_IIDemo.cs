using Command.Helper;
using Questions.DailyChallenge._2021.May.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/19/2021 4:56:05 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinimum_Moves_to_Equal_Array_Elements_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Minimum_Moves_to_Equal_Array_Elements_II instance = new Minimum_Moves_to_Equal_Array_Elements_II();
            BaseLibrary.CommonTest(new[] {
                    new []{ 1, 2, 3 },// 2
                    new []{ 1,10,2,9 },// 16
                    new []{ 1,0,0,8,6 },// 14
                }
            , instance.Try2
            //, instance.MinMoves2
            , () => CollectionHelper.GetEnumerable(random.Next(100_000) + 1, () => random.Next(-1000_000_000, 1000_000_000)).ToArray()
            , checkFunc: instance.Try
            , showArg: false
            );
        }
    }
}
