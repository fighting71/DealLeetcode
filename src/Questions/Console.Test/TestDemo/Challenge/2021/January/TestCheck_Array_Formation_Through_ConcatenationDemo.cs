using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.January;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/5/2021 5:47:41 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCheck_Array_Formation_Through_ConcatenationDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Check_Array_Formation_Through_Concatenation instance = new Check_Array_Formation_Through_Concatenation();
            if (runSimple)
            {

                var argArr = new[]
                {
                        ("[85]"," [[85]]"),
                        ("[15,88]","[[88],[15]]"),
                        ("[49,18,16]","[[16,18,49]]"),// false
                        ("[91,4,64,78]","[[78],[4,64],[91]]"),
                        ("[1,3,5,7]","[[2,4,6,8]]"),// false
                    };

                foreach (var arg in argArr)
                {
                    ShowTools.Show(instance.CanFormArray(JsonConvert.DeserializeObject<int[]>(arg.Item1), JsonConvert.DeserializeObject<int[][]>(arg.Item2)));
                }

            }
            else { }
        }
    }
}
