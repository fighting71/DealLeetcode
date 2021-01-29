using Command.Helper;
using ConsoleTest.LargeData;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 10:13:16 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestReverse_PairsDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Reverse_Pairs instance = new Reverse_Pairs();

            BaseLibrary.CommonTest(new[] {
                    LargeArray.Arr4.Skip(250).Take(10).ToArray(),
                    LargeArray.Arr4,
                    LargeArray.Get<int[]>("large_data/int/arr5.txt").Skip(0).Take(13).ToArray(),
                    LargeArray.Get<int[]>("large_data/int/arr5.txt").Skip(0).Take(14).ToArray(),
                    new []{ 2147483647,2147483647,-2147483647,-2147483647,-2147483647,2147483647 }, // 9
                    new []{ -5,-5 }, // 1
                    new []{ 2566, 5469, 1898, 127, 2441, 4612, 2554, 5269, 2785, 5093, 3931, 2532 },
                    new []{ 1, 3, 2, 3, 1 }, // 2
                    new []{ 2, 4, 3, 5, 1 }, // 3
                }, instance.Optimize2,
            instance.Optimize,
            () => CollectionHelper.GetEnumerable(5000_0, () => random.Next(int.MinValue, int.MaxValue)).ToArray()
            //() => CollectionHelper.GetEnumerable(5000_0, () => random.Next(-10,10)).ToArray()
            , showArg: false
            , codeTimeCount: 1000);

        }
    }
}
