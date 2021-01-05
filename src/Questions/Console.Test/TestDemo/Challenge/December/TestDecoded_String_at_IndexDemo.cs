using Questions.DailyChallenge._2020.December.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/29/2020 2:33:48 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestDecoded_String_at_IndexDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Decoded_String_at_Index instance = new Decoded_String_at_Index();
            if (runSimple)
            {

                for (int i = 1; i < 37; i++)
                {
                    Console.WriteLine(i + ":" + instance.Try2("leet2code3", i));
                }

            }
            else { }
        }
    }
}
