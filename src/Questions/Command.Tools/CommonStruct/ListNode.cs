using System;
using System.Collections.Generic;
using System.Text;

namespace Command.CommonStruct
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/25/2020 4:43:13 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ListNode
    {

        public int val;

        public ListNode next;

        public ListNode(int x) { val = x; }

        public ListNode(int val, ListNode next) : this(val)
        {
            this.next = next;
        }

        public static implicit operator ListNode(int num)
        {
            return new ListNode(num);
        }
        public static implicit operator ListNode(int[] arr)
        {

            if (arr.Length == 0) return null;

            ListNode root = new ListNode(arr[0]),node = root;

            for (int i = 1; i < arr.Length; i++)
            {
                node = (node.next = new ListNode(arr[i]));
            }

            return root;
        }

        public override string ToString()
        {

            var node = this;

            StringBuilder builder = new StringBuilder();
            builder.Append(val);

            while ((node = node.next) != null)
            {
                builder.Append(",");
                builder.Append(node.val);
            }

            return builder.ToString();
        }
    }
}
