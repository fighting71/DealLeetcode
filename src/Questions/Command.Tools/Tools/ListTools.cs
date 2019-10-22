using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/22 16:32:48
    /// @source : 
    /// @des : 
    /// </summary>
    public class ListTools
    {

        public static void ShowMartix<T>(T[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}\t");
                }
                Console.WriteLine();
            }
        }
        
    }
}
