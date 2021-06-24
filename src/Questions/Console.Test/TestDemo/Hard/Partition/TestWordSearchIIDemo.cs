using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 9:41:51 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestWordSearchIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            WordSearchII instance = new WordSearchII();

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['a','b'],['a','a']]")
                , new[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" }));

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['b','b','a','a','b','a'],['b','b','a','b','a','a'],['b','b','b','b','b','b'],['a','a','a','b','a','a'],['a','b','a','a','b','b']]")
                , new[] { "abbbababaa" }));

            Console.WriteLine("success");
        }
    }
}
