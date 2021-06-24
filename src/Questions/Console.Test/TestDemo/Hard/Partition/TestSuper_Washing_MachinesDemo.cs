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
    /// @since : 2/2/2021 3:49:42 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSuper_Washing_MachinesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Super_Washing_Machines instance = new Super_Washing_Machines();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[]>("[6,5,0,3,7,5,8,8,6,2]"), // 6
                    JsonConvert.DeserializeObject<int[]>("[5,9,6,6,5,0,8,7,6,8]"), // 5
                    JsonConvert.DeserializeObject<int[]>("[7,0,9,1,7,1,9,8,4,4]"), // 5
                    new []{ 1, 0, 4, 3 }, // 3
                    new []{ 1, 0, 5 }, // 3
                    new []{ 0,3,0 }, // 2
                    new []{ 0,2,0 }, // -1

                }, instance.Try2
            , () => CollectionHelper.GetEnumerable(10, () => random.Next(10)).ToArray()
            , skipFunc: res => res == -1
            );

        }

    }
}
