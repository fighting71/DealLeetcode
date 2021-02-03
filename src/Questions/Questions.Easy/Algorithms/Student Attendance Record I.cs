using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 2:07:37 PM
    /// @source : https://leetcode.com/problems/student-attendance-record-i/
    /// @des : 
    /// </summary>
    public class Student_Attendance_Record_I
    {
        // Runtime: 104 ms, faster than 15.79% of C# online submissions for Student Attendance Record I.
        // Memory Usage: 22.8 MB, less than 36.84% of C# online submissions for Student Attendance Record I.
        public bool CheckRecord(string s)
        {

            int aCount = 0, lCount = 0;
            foreach (var c in s)
            {
                if(c == 'A')
                {
                    if (aCount++ == 1) return false;
                    lCount = 0;
                } 
                else if(c == 'L') if (lCount++ == 2) return false;
                else lCount = 0;
            }

            return true;
        }
    }
}
