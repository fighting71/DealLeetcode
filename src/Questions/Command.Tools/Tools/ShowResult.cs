using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Command.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 16:53:25
    /// @source : 
    /// @des : 
    /// </summary>
    public class ShowResult
    {

        public static void ShowMulti(Dictionary<string, object> dictionary)
        {
            Console.WriteLine("\n-------------ShowMulti S---------------------");

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} : ");
                Console.WriteLine(GetStr(item.Value));
            }

            Console.WriteLine("-------------ShowMulti E---------------------\n");
        }

        public static void ShowMulti<T>(Dictionary<string, T> dictionary)
        {
            Console.WriteLine("-------------ShowMulti S---------------------");

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} : {GetStr(item.Value)}");
            }

            Console.WriteLine("-------------ShowMulti E---------------------");
        }

        public static void Show<T>(Func<T> func)
        {
            Show(func());
        }

        public static void Show<T>(T data)
        {
            System.Console.WriteLine("----------------S------------------");
            Console.WriteLine(GetStr(data));
            System.Console.WriteLine("----------------E------------------");
        }

        public static string GetStr<T>(T data)
        {
            if (typeof(T).IsValueType)
                return data.ToString();
            return JsonConvert.SerializeObject(data);
        }

        public static string GetStr(object data)
        {
            if (data is string)
                return (string)data;
            if (data.GetType().IsValueType )
                return data.ToString();
            return JsonConvert.SerializeObject(data);
        }
        
    }
}