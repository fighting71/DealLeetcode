using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2021 4:28:34 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class JsonConvertExt
    {

        /// <summary>
        /// Newtonsoft.Json解析json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ParseJson<T>(this string str)
        {
            if (string.IsNullOrEmpty(str)) return default(T);

            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        ///  Newtonsoft.Json序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerieJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}
