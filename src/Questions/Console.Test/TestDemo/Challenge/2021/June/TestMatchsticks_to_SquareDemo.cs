using Command.Helper;
using Questions.DailyChallenge._2021.June.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/16/2021 2:35:24 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMatchsticks_to_SquareDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Matchsticks_to_Square instance = new Matchsticks_to_Square();

            BaseLibrary.CommonTest(new[] {
                    new []{ 4,3,3,3,2,2,2,1}, // true
                    new []{ 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15}, // true
                    new []{ 1, 1, 2, 2, 2 }, // true
                    new []{ 3,3,3,3,4 }, // false
                }
            , instance.Makesquare
            , () => CollectionHelper.GetEnumerable(15, () => random.Next(10)).ToArray()
            //, () => CollectionHelper.GetEnumerable(15, () => random.Next((int)Math.Pow(10, 9))).ToArray()
            , skipFunc: res => !res
            );

        }

    }
}
