using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/30/2021 7:01:19 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSplit_Array_With_Same_AverageDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Split_Array_With_Same_Average instance = new Split_Array_With_Same_Average();

            BaseLibrary.CommonTest(new[] {
                    new []{ 72,56,81,54,15,96,80,90,8 },//true
                    new []{ 10,29,13,53,33,48,76,70,5,5 },//true
                    new []{ 0 },//false
                    new []{ 6,8,18,3,1 },//false
                    new []{ 1, 2, 3, 4, 5, 6, 7, 8 },//true
                    new []{ 3,1 },//false
                }
            , instance.Try3
            //, instance.Simple
            , generateArg: () => CollectionHelper.GetEnumerable(30, () => random.Next(1000_0)).ToArray()
            , codeTimeCount: 20
            );

        }

    }
}
