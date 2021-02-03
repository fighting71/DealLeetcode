using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 12:28:57 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStudent_Attendance_Record_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Student_Attendance_Record_II instance = new Student_Attendance_Record_II();

            BaseLibrary.CommonTest(new[] {
                    1,// 3
                    2,// 8
                    3,// 19
                    4,// 43
                    5,// 94
                    20,// 2947811
                    100,// 985598218
                    980000,// 726847434
                }
            , instance.Try2
            //, instance.Simple
            );
        }

    }
}
