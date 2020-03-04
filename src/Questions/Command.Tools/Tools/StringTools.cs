using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Command.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/4/2020 11:01:06 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class StringTools
    {

        public static int GetLen(string value)
        {
            int valueLength = 0;
            /* 获取字段值的长度，如果含中文字符，则每个中文字符长度为3，否则为1 */
            for (int i = 0; i < value.Length; i++)
            {
                /* 获取一个字符 */
                char c = value[i];
                /* 判断是否为中文字符 */
                if (Regex.IsMatch(c.ToString(), "[\u4e00-\u9fa5]"))
                {
                    /* 中文字符长度为3 */
                    valueLength += 3;
                }
                else
                {
                    /* 其他字符长度为1 */
                    valueLength += 1;
                }
            }
            return valueLength;
        }

    }
}
