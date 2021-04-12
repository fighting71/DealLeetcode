using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Attr
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 10:41:15 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class SerieAttribute : Attribute
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string[] Desc { get; set; }

        public SerieAttribute(params string[] desc)
        {
            Desc = desc;
        }
    }
}
