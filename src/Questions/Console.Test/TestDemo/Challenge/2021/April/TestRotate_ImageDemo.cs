using Newtonsoft.Json;
using Questions.DailyChallenge._2021.April.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/26/2021 3:02:08 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRotate_ImageDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Rotate_Image instance = new Rotate_Image();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>(" [[1,2,3],[4,5,6],[7,8,9]]"), //  [[7,4,1],[8,5,2],[9,6,3]]
                    JsonConvert.DeserializeObject<int[][]>(" [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]"), // [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
                }
            , arg =>
            {
                instance.Solution3(arg);
                //instance.Solution2(arg);
                return arg;
            }
            );

        }
    }
}
