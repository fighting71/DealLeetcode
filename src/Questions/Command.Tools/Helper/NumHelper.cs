using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Helper
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/10/2021 6:37:58 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class NumHelper
    {

        // overflow
        public bool CheckReduceOverFlow(int num, int num2)
        {
            long diffL = num - (long)num2;

            if (diffL < int.MinValue || diffL > int.MaxValue) return false;

            return true;
        }

    }
}
