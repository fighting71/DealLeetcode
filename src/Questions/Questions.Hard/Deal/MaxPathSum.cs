using Command.CommonStruct;
using System;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/1 17:18:58
    /// @source : https://leetcode.com/problems/binary-tree-maximum-path-sum/
    /// @des : 求二叉树的最大路径值
    /// </summary>
    public class MaxPathSum
    {
        
        // 定义一个全局的max字段 方便比较
        private int max = int.MinValue;

        /**
         * Runtime: 108 ms, faster than 84.03% of C# online submissions for Binary Tree Maximum Path Sum.
         * Memory Usage: 29.9 MB, less than 14.29% of C# online submissions for Binary Tree Maximum Path Sum.
         */
        public int Solution(TreeNode root)
        {
            Helper2(root);

            return max;
        }

        /**
         * Runtime: 96 ms, faster than 98.99% of C# online submissions for Binary Tree Maximum Path Sum.
         * Memory Usage: 30 MB, less than 14.29% of C# online submissions for Binary Tree Maximum Path Sum.
         *
         * perfect~
         * 
         */
        private int Helper2(TreeNode node)
        {
            if (node == null) return 0;
            
            var val = node.val;
            var left = Helper2(node.left);
            var right = Helper2(node.right);

            if (left > right)
            {
                if (left > 0) val += left;
            }
            else if (right > 0)
                val += right;
            
            max = Math.Max(max, node.val + left + right);
            max = Math.Max(val, max);
            
            return val;
        }

        
        /// <summary>
        /// 辅助方法 获取路径的最大值
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Helper(TreeNode node)
        {
            if (node == null) return 0;
            
            var val = node.val;
            // 获取left路径的最大值
            var left = Helper(node.left);
            // 获取right路径的最大值
            var right = Helper(node.right);
            
            // 比较返回一个最大值 
            //    ps：此处只能仅加一边的原因 若是两边都加 那么返回的val 上节点就不能加
            //    示例:    a
            //            / \
            //           b   c
            //          /\ 
            //         d  e        
            //        如果a的left    返回的是 b+d+e    那么a+b+d+e就是不合法的 因为有分叉的不能算是一个合法路径
            val = Math.Max(val, node.val + left);
            val = Math.Max(val, node.val + right);
            
            // 此处仍然需要进行比较 因为要计算 b+d+e 和 a+left节点+right节点这种 
            max = Math.Max(max, node.val + left + right);
            max = Math.Max(val, max);
            
            return val;
        }
    }
}