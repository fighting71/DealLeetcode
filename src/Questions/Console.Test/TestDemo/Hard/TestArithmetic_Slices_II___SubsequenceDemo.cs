using Command.Helper;
using Command.Tools;
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
    /// @since : 1/10/2021 7:03:57 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestArithmetic_Slices_II___SubsequenceDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Arithmetic_Slices_II___Subsequence instance = new Arithmetic_Slices_II___Subsequence();

            BaseLibrary.CommonTest(new[] {
                    new []{1,2,3},
                    new []{1,2,3,4},
                    new []{1,2,3,4,5},
                    new []{1,2,3,4,5,6},
                    new []{1,2,3,4,5,6,7},
                    new []{1,2,3,4,5,6,7,8},
                    new []{1,2,3,4,5,6,7,8,9},
                    new []{1,2,3,4,5,6,7,8,9,10},
                    new []{3,4,4,5}, // 2
                    new []{2,3,4,4,5}, // 6
                    new []{1,2,3,4,4,5}, // 12
                    new []{1,2,2,3,4,4,5}, // 21
                    //JsonConvert.DeserializeObject<int[]>("[18,2,0,0,12,8,17,15,4,14,1,18,18,12,5,10,15,13,1,6]"),// 24
                    JsonConvert.DeserializeObject<int[]>("[2147483638,2147483639,2147483640,2147483641,2147483642,2147483643,2147483644,2147483645,2147483646,2147483647,-2147483648,-2147483647,-2147483646,-2147483645,-2147483644,-2147483643,-2147483642,-2147483641,-2147483640,-2147483639]"),// 110
                }, instance.EfficientSolution, () => CollectionHelper.GetArr(1000, () => random.Next(100)).ToArray());

            ShowTools.ShowHr();

            //BaseLibrary.CommonTest(new[] {
            //        new []{1,2,3},
            //        new []{1,2,3,4},
            //        new []{1,2,3,4,5},
            //        new []{1,2,3,4,5,6},
            //        new []{1,2,3,4,5,6,7},
            //        new []{1,2,3,4,5,6,7,8},
            //        new []{1,2,3,4,5,6,7,8,9},
            //        new []{1,2,3,4,5,6,7,8,9,10},
            //        new []{3,4,4,5}, // 2
            //        new []{2,3,4,4,5}, // 6
            //        new []{1,2,3,4,4,5}, // 12
            //        new []{1,2,2,3,4,4,5}, // 21
            //        JsonConvert.DeserializeObject<int[]>("[18,2,0,0,12,8,17,15,4,14,1,18,18,12,5,10,15,13,1,6]"),// 24
            //    }, instance.Simple, () => CollectionHelper.GetArr(20, () => random.Next(20)).ToArray());
        }
    }
}
