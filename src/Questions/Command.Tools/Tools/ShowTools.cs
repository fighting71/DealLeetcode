using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Command.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/2/2020 6:03:41 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class ShowTools
    {

        public static void ShowMatrix<T>(T[][] martix)
        {
            Console.WriteLine("----------------------Matrix-------S----------------");
            for (int i = 0; i < martix.Length; i++)
            {
                ShowLine(martix[i]);
            }
            Console.WriteLine("----------------------Matrix-------E----------------");
        }

        public static void ShowIndex<T>(IEnumerable<T> line)
        {
            int i = 0;
            foreach (var item in line)
            {
                Console.WriteLine($"{i++} - {item}");
            }

            Console.WriteLine();
        }

        public static void ShowLine<T>(IEnumerable<T> line)
        {
            foreach (var item in line)
            {
                Console.WriteLine($"[ {GetStr(item)} ]");
            }

            Console.WriteLine();
        }

        public static string GetStr<T>(T[][] arr)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    builder.Append(arr[i][j]);
                    if (j < arr[i].Length - 1) builder.Append(',');
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

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
            if (data.GetType().IsValueType || data.GetType() == typeof(StringBuilder))
                return data.ToString();
            return JsonConvert.SerializeObject(data);
        }

    }
}
