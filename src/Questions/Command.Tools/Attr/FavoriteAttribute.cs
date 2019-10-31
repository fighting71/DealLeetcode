using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Attr
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/28 15:17:18
    /// @source : 
    /// @des : 
    /// </summary>
    public class FavoriteAttribute : Attribute
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        public FavoriteAttribute(string desc)
        {
            Desc = desc;
        }
    }
}