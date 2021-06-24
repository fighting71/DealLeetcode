using Command.Helper;
using Newtonsoft.Json;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/2/2021 7:06:52 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRemove_BoxesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Remove_Boxes instance = new Remove_Boxes();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[]>("[10,1,1,9,10,1,2,8,3,2,3,1,4,7,6,10,6,10,7,6,7,4,6,2,2,10,6,8,6,10,6,9,5,3,3,1,10,2,7,10,3,10,3,5,6,1,7,5,1,3,5,8,10,10,6,7,5,10,7,1,6,4,3,3,7,5,7,1,5,6,1,5,4,7,4,7,1,2,7,2,3,1,8,3,6,8,9,5,8,6,6,10,5,6,5,9,8,10,9,1]").Skip(0).Take(30).ToArray(),
                    JsonConvert.DeserializeObject<int[]>("[10,1,1,9,10,1,2,8,3,2,3,1,4,7,6,10,6,10,7,6,7,4,6,2,2,10,6,8,6,10,6,9,5,3,3,1,10,2,7,10,3,10,3,5,6,1,7,5,1,3,5,8,10,10,6,7,5,10,7,1,6,4,3,3,7,5,7,1,5,6,1,5,4,7,4,7,1,2,7,2,3,1,8,3,6,8,9,5,8,6,6,10,5,6,5,9,8,10,9,1]"),
                    new []{ 1, 3, 2, 2, 2, 3, 4, 3, 1 }, // 23
                    new []{8,2,7,4,8,1,6,9,2,2}, // 16
                    new []{ 1, 1, 1 }, // 9
                    new []{ 1 }, // 1
                }
            , instance.Try3
            , () => CollectionHelper.GetEnumerable(100, () => random.Next(10) + 1).ToArray()
            //, checkFunc: instance.Try2
            );

        }
    }
}
