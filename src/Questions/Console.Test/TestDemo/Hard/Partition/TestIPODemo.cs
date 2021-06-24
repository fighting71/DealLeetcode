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
    /// @since : 1/29/2021 4:51:01 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestIPODemo : BaseDemo, IWork
    {
        public void Run()
        {
            IPO instance = new IPO();

            BaseLibrary.CommonTest(new[] {
                    (2,0,new []{1,2,3},new []{ 0,1,1 }), // 4
                }
            , arg => instance.Optimize(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , () => {

                var k = random.Next(5000_0);
                var n = random.Next(5000_0);
                var pro = CollectionHelper.GetEnumerable(5000_0, () => random.Next(40) + 1).ToArray();
                var cap = CollectionHelper.GetEnumerable(5000_0, () => random.Next(40) + 1).ToArray();
                return (k, n, pro, cap);
            }
            , showArg: false
            , checkFunc: arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3, arg.Item4)
            , formatArg: arg => $@"{arg.Item1}
{arg.Item2}
{JsonConvert.SerializeObject(arg.Item3)}
{JsonConvert.SerializeObject(arg.Item4)}"
            , throwDiff: false
            );
        }
    }
}
