using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 5:56:12 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestConcatenation_of_Consecutive_Binary_NumbersDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Concatenation_of_Consecutive_Binary_Numbers instance = new Concatenation_of_Consecutive_Binary_Numbers();

            BaseLibrary.CommonWithCheckTest(new[] {
                    1,
                    3,
                    12
                }, instance.Solution, instance.Try, () => 1000_00);
        }
    }
}
