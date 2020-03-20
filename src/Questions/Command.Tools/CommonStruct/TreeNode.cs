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


            for (int i = 1; i < arr.Length; i+=2)
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

        //public override string ToString()
        //{
        //    if (left == null && right == null) return val.ToString();
        //    return $"[{val},left:{(left == null ? "null" : left.ToString())},right:{(right == null ? "null" : right.ToString())}]";
        //}
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");

            Queue<TreeNode> queue = new Queue<TreeNode>();

            bool first = true;
            queue.Enqueue(this);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (first)
                {
                    first = false;
                    builder.Append(node.val);
                }

                if (queue.Count == 0 && node.right == null && node.left == null)
                {

                }
                else
                {
                    builder.Append($",{(node.left == null ? "null" : node.left.val.ToString())},{(node.right == null ? "null" : node.right.val.ToString())}");
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            builder.Append("]");

            return builder.ToString();
        }

    }
}
