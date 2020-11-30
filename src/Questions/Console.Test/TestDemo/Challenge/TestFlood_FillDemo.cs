using Command.Tools;
using Newtonsoft.Json;
using Questions.Series.AlgorithmThinking;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 5:16:18 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFlood_FillDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Flood_Fill instance = new Flood_Fill();
            if (runSimple)
            { // simple

                ShowTools.Show(instance.FloodFill(JsonConvert.DeserializeObject<int[][]>("[[0,0,0],[1,0,0]]"), 1, 0, 2));
                ShowTools.Show(instance.FloodFill(JsonConvert.DeserializeObject<int[][]>("[[0,0,0],[0,0,0]]"), 0, 0, 2));

            }
            else
            { // speed&real
            }
        }

    }
}
