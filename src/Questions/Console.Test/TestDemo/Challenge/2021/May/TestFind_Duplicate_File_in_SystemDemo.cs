using Questions.DailyChallenge._2021.May.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/18/2021 5:12:48 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFind_Duplicate_File_in_SystemDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Find_Duplicate_File_in_System instance = new Find_Duplicate_File_in_System();

            instance.FindDuplicate(new[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" });

        }
    }
}
