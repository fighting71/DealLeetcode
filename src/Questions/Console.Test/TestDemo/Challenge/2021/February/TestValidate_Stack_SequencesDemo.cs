using Questions.DailyChallenge._2021.February.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2021 5:57:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestValidate_Stack_SequencesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Validate_Stack_Sequences instance = new Validate_Stack_Sequences();

            {
                Console.WriteLine(instance.Simple(new[] { 1, 2, 3, 4, 5 }, new[] { 4, 5, 3, 2, 1 })); // t
                Console.WriteLine(instance.Simple(new[] { 1, 2, 3, 4, 5 }, new[] { 4, 3, 5, 1, 2 })); // f
            }
        }
    }
}
