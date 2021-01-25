using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/25/2021 5:26:46 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCheck_If_All_1_s_Are_at_Least_Length_K_Places_AwayDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Check_If_All_1_s_Are_at_Least_Length_K_Places_Away instance = new Check_If_All_1_s_Are_at_Least_Length_K_Places_Away();

            BaseLibrary.CommonTest(new[] {
                    (new[]{1,0,0,0,1,0,0,1},2),
                    (new[]{1,0,0,1,0,1},2),
                    (new[]{1,1,1,1,1},0),
                    (new[]{0,1,0,1},1),
                }, arg => instance.KLengthApart(arg.Item1, arg.Item2), () => {

                    var arr = CollectionHelper.GetArr(10000, () => random.Next(3) / 2).ToArray();

                    var k = random.Next(arr.Length + 1);

                    return (arr, k);

                });

        }
    }
}
