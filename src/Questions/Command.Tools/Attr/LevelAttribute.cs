using Command.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Attr
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/22 16:13:05
    /// @source : 
    /// @des : 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LevelAttribute : Attribute
    {

        public LevelTypes Level { get; set; }

        public LevelAttribute(LevelTypes level)
        {
            Level = level;
        }
    }
}
