using Command.Helper;
using Newtonsoft.Json;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Command.Extension;

namespace ConsoleTest.TestDemo.Todo
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 3:43:23 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSmallest_Range_Covering_Elements_from_K_ListsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Smallest_Range_Covering_Elements_from_K_Lists instance = new Smallest_Range_Covering_Elements_from_K_Lists();

            int[] arr = new int[0];

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]"),// [20,24]
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[-15,-13,19,40,84],[-87,-74,15,16,77],[-100,-59,-19,2,36],[-84,12,22,29,73],[-62,-53,-17,17,80],[-52,-50,-49,47,81],[-87,-61,18,39,96],[-83,-53,3,20,50],[-94,-28,-21,45,63],[-94,-80,-22,17,23]]"),// [16,47]
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[1,2,3],[1,2,3],[1,2,3]]"),//[1,1]
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[10,10],[11,11]]"),//[10,11]
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[10],[11]]"),//[[10],[11]]
                    JsonConvert.DeserializeObject<IList<IList<int>>>("[[1],[2],[3],[4],[5],[6],[7]]"),//[1,7]
                }, arg => instance.Try3(arg).MapTo(u => (u[0], u[1]))
            , () => CollectionHelper.GetEnumerable(3500, () => (IList<int>)CollectionHelper.GetEnumerable(50, () => random.Next(-100, 100)).ToList()).ToList()
            //, () => CollectionHelper.GetEnumerable(10, () => (IList<int>)CollectionHelper.GetEnumerable(5, () => random.Next(-100, 100)).OrderBy(u => u).ToList()).ToList()
            , checkFunc: arg => instance.Try(arg).MapTo(u => (u[0], u[1]))
            );

        }
    }
}
