using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleTest.LargeData
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 6:08:25 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class LargeArray
    {

        public static int[] Arr
        {
            get
            {
                string txt = File.ReadAllText("large_data/int/arr1.txt");
                return JsonConvert.DeserializeObject<int[]>(txt);
            }
        }
        public static int[] Arr2
        {
            get
            {
                string txt = File.ReadAllText("large_data/int/arr2.txt");
                return JsonConvert.DeserializeObject<int[]>(txt);
            }
        }
        public static string[] Arr3
        {
            get
            {
                string txt = File.ReadAllText("large_data/str/arr3.txt");
                return JsonConvert.DeserializeObject<string[]>(txt);
            }
        }
        public static int[] Arr4
        {
            get
            {
                string txt = File.ReadAllText("large_data/int/arr4.txt");
                return JsonConvert.DeserializeObject<int[]>(txt);
            }
        }

        public static T Get<T>(string path)
        {
            string txt = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(txt);
        }

    }
}