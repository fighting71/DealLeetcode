using System.Collections.Generic;
using System.Text;

namespace Command.CommonStruct
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/11/2020 11:38:28 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode(int x)
        {
            val = x;
        }

        public static implicit operator TreeNode(int num)
        {
            return new TreeNode(num);
        }


        public static implicit operator TreeNode(int?[] arr)
        {
            if (arr.Length == 0) return null;

            TreeNode root = arr[0];

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            for (int i = 1; i < arr.Length; i += 2)
            {
                var node = queue.Dequeue();
                node.left = arr[i];
                if (i + 1 != arr.Length)
                    node.right = arr[i + 1];

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

            }
            return root;
        }

        /// <summary>
        /// Runtime: 104 ms, faster than 99.38% of C# online submissions for Serialize and Deserialize Binary Tree.
        /// Memory Usage: 31.9 MB, less than 40.00% of C# online submissions for Serialize and Deserialize Binary Tree.
        /// 
        /// 曾经只是因为测试格式化比较麻烦，竟然还有hard题目...
        /// 
        /// source:https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static implicit operator TreeNode(string str)
        {

            if (str.Length < 3) return null;

            int i = 1;

            TreeNode root = GetNum(str, ref i);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            for (i++; i < str.Length - 1; i++)
            {
                var node = queue.Dequeue();
                node.left = GetNum(str, ref i);
                i++;
                node.right = GetNum(str, ref i);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return root;
        }

        private static int? GetNum(string str, ref int index)
        {
            if (index >= str.Length - 1) return null;
            if (str[index] == 'n')
            {
                index += 4;
                return null;
            }
            bool isNegative = true;
            if (str[index] == '-')
            {
                isNegative = false;
                index++;
            }
            var num = str[index] - '0';
            while (str[++index] != ',' && index < str.Length - 1)
                num = num * 10 + str[index] - '0';
            return isNegative ? num : -num;
        }

        //public override string ToString()
        //{
        //    if (left == null && right == null) return val.ToString();
        //    return $"[{val},left:{(left == null ? "null" : left.ToString())},right:{(right == null ? "null" : right.ToString())}]";
        //}

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("["), cache = new StringBuilder();

            Queue<TreeNode> queue = new Queue<TreeNode>();

            bool first = true;
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (first)
                {
                    first = false;
                    builder.Append(node.val);
                }

                if (node.right == null && node.left == null) cache.Append(",null,null");
                else
                {
                    builder.Append($"{cache},{(node.left == null ? "null" : node.left.val.ToString())},{(node.right == null ? "null" : node.right.val.ToString())}");
                    cache.Clear();
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            builder.Append("]");

            return builder.ToString();
        }

    }
}
