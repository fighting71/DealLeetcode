using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 11:55:57 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class FormatExt
    {

        public static TRes MapTo<T, TRes>(this T t, Func<T, TRes> func) => func(t);

    }
}
