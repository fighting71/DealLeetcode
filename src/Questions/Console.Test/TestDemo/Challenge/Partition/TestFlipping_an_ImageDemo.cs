using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.November.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/10/2020 5:40:47 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFlipping_an_ImageDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Flipping_an_Image instance = new Flipping_an_Image();
            { // simple

                ShowTools.ShowMatrix(instance.FlipAndInvertImage(JsonConvert.DeserializeObject<int[][]>("[[1,1,0],[1,0,1],[0,0,0]]")));
                ShowTools.ShowMatrix(instance.FlipAndInvertImage(JsonConvert.DeserializeObject<int[][]>(" [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]")));
            }
            { // speed&real
            }
        }

    }
}
