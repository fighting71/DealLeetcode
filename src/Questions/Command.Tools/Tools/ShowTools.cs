using System;
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
            Console.WriteLine();
            for (int i = 0; i < martix.Length; i++)
            {
                for (int j = 0; j < martix[i].Length; j++)
                {
                    Console.Write($"[ {martix[i][j]} ]");
                }

                Console.WriteLine();
            }
        }

    }
}
