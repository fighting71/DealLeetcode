using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 9:32:05 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSearch_in_Rotated_Sorted_Array_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Search_in_Rotated_Sorted_Array_II instance = new Search_in_Rotated_Sorted_Array_II();
            if (runSimple)
            { // simple
                Console.WriteLine(instance.Search(new[] { 2, 2, 2, 0, 2, 2 }, 0));// true
                Console.WriteLine(instance.Search(new[] { 1 }, 0));// false
                Console.WriteLine(instance.Search(new[] { 1, 1 }, 0));// false
                Console.WriteLine(instance.Search(new[] { 1, 1, 1, 3, 1 }, 3));// true
                Console.WriteLine(instance.Search(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0));// true
                Console.WriteLine(instance.Search(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3));// false
            }
            else
            { // speed&real
            }
        }

    }
}
