using Newtonsoft.Json;
using Questions.DailyChallenge._2021.June.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/11/2021 3:10:02 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMy_Calendar_IDemo : BaseDemo, IWork
    {
        public void Run()
        {
            {

                My_Calendar_I.IMyCalendar myCalendar = new My_Calendar_I.MyCalendar();

                Console.WriteLine(myCalendar.Book(10, 20)); // t
                Console.WriteLine(myCalendar.Book(15, 25)); // f
                Console.WriteLine(myCalendar.Book(20, 30)); // t
            }

            {

                My_Calendar_I.IMyCalendar myCalendar = new My_Calendar_I.MyCalendar();

                var arg = JsonConvert.DeserializeObject<int[][]>("[[47,50],[33,41],[39,45],[33,42],[25,32],[26,35],[19,25],[3,8],[8,13],[18,27]]");

                var real = JsonConvert.DeserializeObject<bool[]>("[true,true,false,false,true,false,true,true,true,false]");

                for (int i = 0; i < arg.Length; i++)
                {
                    bool res = myCalendar.Book(arg[i][0], arg[i][1]);

                    if (res != real[i])
                    {
                        Console.WriteLine("bug");
                    }

                }

            }

            BaseLibrary.CommonTest(new[] { 1 }, arg =>
            {
                My_Calendar_I.IMyCalendar myCalendar = new My_Calendar_I.MyCalendar();

                for (int i = 0; i < 1000; i++)
                {
                    var start = random.Next(0, 1000_000_000 - 1);
                    var end = random.Next(start + 1, 1000_000_000);
                    bool res = myCalendar.Book(start, end);

                    Console.WriteLine($"book({start}, {end}) = {res}");
                }
                return "end";

            }, () => 1);

        }
    }
}
