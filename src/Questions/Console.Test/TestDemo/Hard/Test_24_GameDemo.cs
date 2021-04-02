using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/26/2021 2:57:42 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Test_24_GameDemo : BaseDemo, IWork
    {
        public void Run()
        {
            _24_Game instance = new _24_Game();

            BaseLibrary.CommonTest(
                new[]
                {
                        new[] { 1, 9, 1, 2 },// t
                        new[] { 1, 5, 9, 1 },// f
                        new[] { 9, 8, 6, 8 },// t
                        new[] { 4, 1, 8, 7 },// true
                        new[] { 1, 2, 1, 2 },// f
                        new[] { 1, 3, 4, 6 },// t
                }
                , instance.Try2
                , generateArg: () => CollectionHelper.GetEnumerable(4, () => random.Next(9) + 1).ToArray()
            );

        }

    }
}
