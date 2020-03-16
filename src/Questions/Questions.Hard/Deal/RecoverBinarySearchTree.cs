using Command.Const;
using System;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/11/2020 10:34:38 AM
    /// @source : https://leetcode.com/problems/recover-binary-search-tree/
    /// @des : 
    /// </summary>
    public class RecoverBinarySearchTree
    {

        // TODO:
        public void Solution(TreeNode root)
        {
            Helper(root, int.MinValue, int.MaxValue);
        }


        private TreeNode Helper(TreeNode node, int left, int right, TreeNode prev)
        {
            if (node == null) return null;

            if (left > right)
            {
                var old = left;
                left = right;
                right = old;
            }

            if (node.val < left)
            {
                return node;
            }
            if (node.val > right)
            {
                return node;
            }

            var rightSub = Helper(node.right, Math.Max(left, node.val), right);

            var leftSub = Helper(node.left, left, Math.Min(right, node.val));

            if (leftSub != null && rightSub != null)
            {
                var old = leftSub.val;
                leftSub.val = rightSub.val;
                rightSub.val = old;
                return null;
            }

            if (leftSub != null)
            {
                if (leftSub.val < left) return leftSub;
                if (leftSub.val > right) return leftSub;
                var old = node.val;
                node.val = leftSub.val;
                leftSub.val = old;
                return null;
            }

            if (rightSub != null)
            {
                if (rightSub.val < left) return rightSub;
                if (rightSub.val > right) return rightSub;
                var old = node.val;
                node.val = leftSub.val;
                leftSub.val = old;
                return null;
            }

            return null;
        }

        private TreeNode Helper(TreeNode node,int left,int right)
        {
            if (node == null) return null;

            if(left > right)
            {
                var old = left;
                left = right;
                right = old;
            }

            if (node.val < left)
            {
                return node;
            }
            if (node.val > right)
            {
                return node;
            }

            var rightSub = Helper(node.right, Math.Max(left, node.val), right);

            var leftSub = Helper(node.left, left, Math.Min(right, node.val));

            if(leftSub != null && rightSub != null)
            {
                var old = leftSub.val;
                leftSub.val = rightSub.val;
                rightSub.val = old;
                return null;
            }

            if (leftSub != null)
            {
                if (leftSub.val < left) return leftSub;
                if (leftSub.val > right) return leftSub;
                var old = node.val;
                node.val = leftSub.val;
                leftSub.val = old;
                return null;
            }

            if (rightSub != null)
            {
                if (rightSub.val < left) return rightSub;
                if (rightSub.val > right) return rightSub;
                var old = node.val;
                node.val = rightSub.val;
                rightSub.val = old;
                return null;
            }

            return null;
        }

    }
}
