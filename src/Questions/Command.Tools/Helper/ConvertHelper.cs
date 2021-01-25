using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Helper
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/24/2021 6:14:58 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class ConvertHelper
    {

        public static ListNode[] ConvertToListNode(int[][] arr)
        {
            ListNode[] list = new ListNode[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                list[i] = arr[i];
            }
            return list;
        }

    }
}
