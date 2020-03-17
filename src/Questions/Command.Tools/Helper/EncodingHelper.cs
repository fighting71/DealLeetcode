using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Command.Helper
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/17/2020 2:23:42 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class EncodingHelper
    {

        static Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);

        /// <summary>
        /// \\u转换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Decode(string s)
        {
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }

    }
}
