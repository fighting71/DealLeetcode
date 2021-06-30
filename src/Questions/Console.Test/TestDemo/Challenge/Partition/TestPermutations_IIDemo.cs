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
    /// @since : 11/13/2020 3:01:51 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPermutations_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Permutations_II instance = new Permutations_II();
            { // simple
                var argArr = new[]
                {
                    "[2,2,2,3]",
                    //"[1,2,3]",
                    //"[1,1,2]",
                };

                foreach (var arg in argArr)
                {
                    ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<int[]>(arg)));
                }

            }
            { // speed&real
            }
        }

    }
}
