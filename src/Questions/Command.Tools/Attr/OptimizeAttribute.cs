using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Attr
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/10/2020 5:12:15 PM
    /// @source : 
    /// @des : 待优化
    /// </summary>
    public class OptimizeAttribute : Attribute
    {

        public string[] Desc { get; }

        public OptimizeAttribute(params string[] desc)
        {
            Desc = desc;
        }
        public OptimizeAttribute() { }

    }
}
