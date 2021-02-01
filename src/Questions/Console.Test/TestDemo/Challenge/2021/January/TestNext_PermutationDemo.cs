using Command.Helper;
using Questions.DailyChallenge._2021.January.Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/1/2021 4:11:19 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNext_PermutationDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Next_Permutation instance = new Next_Permutation();

            BaseLibrary.CommonTest(new int[][] {
                    new []{ 9,4,4,2,1,10,1,3,10,1,5,8,7,4,9,6,7,1,5,5,3,9,10,10,5,1,5,6,10,5,8,8,10,9,3,4,8,1,10,8,9,10,5,7,1,10,1,10,1,2,4,4,7,1,6,10,4,4,7,10,5,5,3,5,4,7,8,8,1,5,9,7,2,8,7,4,4,4,10,5,1,6,5,9,1,4,2,10,4,3,1,4,4,10,3,4,7,10,5,3 },
                    new []{ 3,7,3,7,7,2,8 },
                    new []{ 92,20,96,66,19,83,12 },
                    new []{ 1, 2, 3 },
                    new []{ 3,2,1 },
                    new []{ 1,1,5 },
                    new []{ 1 },
                }, arg =>
                {
                    var clone = (int[])arg.Clone();
                    instance.Try(clone);
                    return clone;
                }
            //, () => CollectionHelper.GetEnumerable(100, () => random.Next(100) + 1).ToArray()
            , () => CollectionHelper.GetEnumerable(100, () => random.Next(10) + 1).ToArray()
            );

        }
    }
}
