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
    /// @since : 2/4/2021 4:23:47 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCourse_Schedule_IIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Course_Schedule_III instance = new Course_Schedule_III();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>("[[18,32],[7,13],[9,25],[19,20],[4,7],[2,18],[1,9],[14,26],[1,11],[15,32],[6,20],[12,14],[13,28],[3,17],[10,13],[6,11],[14,30],[8,18],[15,19],[20,23]]"),//7
                    JsonConvert.DeserializeObject<int[][]>(" [[100, 200], [200, 1300], [1000, 1250], [2000, 3200]]"),//3
                }
            , instance.Optimize
            , () => CollectionHelper.GetEnumerable(1000_00, () => {

                var t = random.Next(1000) + 1;
                var d = random.Next(1000 - t + 1) + t;

                return new[] { t, d };

            }).ToArray()
            , checkFunc: instance.Simple
            , codeTimeCount: 30
            , showArg: false
            , throwDiff: false
            );

        }
    }
}
