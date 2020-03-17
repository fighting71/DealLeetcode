using Command.Const;
using System;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/11/2020 10:34:38 AM
    /// @source : https://leetcode.com/problems/recover-binary-search-tree/
    /// @des : 一个二叉搜索树(BST)的两个元素被错误地交换了。恢复树而不改变它的结构。
    /// </summary>
    public class RecoverBinarySearchTree
    {

        bool flag;

        /// <summary>
        /// Runtime: 108 ms, faster than 90.06% of C# online submissions for Recover Binary Search Tree.
        /// Memory Usage: 27.7 MB, less than 50.00% of C# online submissions for Recover Binary Search Tree.
        /// </summary>
        /// <param name="root"></param>
        public void Solution(TreeNode root)
        {
            flag = false;
            Helper(root, int.MinValue, int.MaxValue);
        }

        private TreeNode Helper(TreeNode node, int left, int right)
        {
            if (node == null || flag) return null;

            if (left > right)
            {
                var old = left;
                left = right;
                right = old;
            }

            var rightSub = Helper(node.right, Math.Max(left, node.val), right);

            var leftSub = Helper(node.left, left, Math.Min(right, node.val));

            if (leftSub != null && rightSub != null)
            {
                if (node.val < left || node.val > right)
                {
                    if (leftSub.val > node.val) return leftSub;
                    if (rightSub.val < node.val) return rightSub;
                    return node;
                }
                var old = leftSub.val;
                leftSub.val = rightSub.val;
                rightSub.val = old;
                flag = true;
                return null;
            }

            if (leftSub != null)
            {
                if (leftSub.val < left) return leftSub;
                if (leftSub.val > right) return leftSub;
                if (node.val < left || node.val > right)
                    return node;
                var old = node.val;
                node.val = leftSub.val;
                leftSub.val = old;
                flag = true;
                return null;
            }

            if (rightSub != null)
            {
                if (rightSub.val < left) return rightSub;
                if (rightSub.val > right) return rightSub;
                if (node.val < left || node.val > right)
                    return node;
                var old = node.val;
                node.val = rightSub.val;
                rightSub.val = old;
                flag = true;
                return null;
            }

            if (node.val < left || node.val > right)
                return node;

            return null;
        }

        private TreeNode ExplainHelper(TreeNode node, int left, int right)
        {
            if (node == null) return null;

            if (left > right)// 避免错误的因素导致left>right
            {
                var old = left;
                left = right;
                right = old;
            }

            // why : 先递归获取最底下的元素
            // because : 若由于上层元素错误导致了下层和下下层元素错误，直接将下层元素返回是不合理的. 应返回下下层 故需要先找到最下层的错误元素

            // 递归获取错误的right
            var rightSub = Helper(node.right, Math.Max(left, node.val), right);

            // 递归获取错误的left
            var leftSub = Helper(node.left, left, Math.Min(right, node.val));

            if (leftSub != null && rightSub != null)// 当左子节点和右子节点都存在异常
            {
                // 查看当前节点是否正常
                if (node.val < left || node.val > right) // 否：交换左右节点不能改变当前节点异常
                {
                    // 验证左子节点仅对于当前节点是否正常 否：左子节点应该被交换
                    if (leftSub.val > node.val) return leftSub;
                    // 同上
                    if (rightSub.val < node.val) return rightSub;
                    // 都正常时返回当前节点
                    return node;
                }

                // 交换左右节点
                var old = leftSub.val;
                leftSub.val = rightSub.val;
                rightSub.val = old;
                flag = true;
                return null;
            }

            if (leftSub != null)// 左子节点异常
            {
                // 验证左子节点与当前节点的区间是否匹配
                if (leftSub.val < left || leftSub.val > right) return leftSub; // 否：返回左子节点
                if (node.val < left || node.val > right)// 当前节点是否正常 -》 否：返回当前节点
                    return node;

                // 节点交换
                var old = node.val;
                node.val = leftSub.val;
                leftSub.val = old;
                flag = true;
                return null;
            }

            // 同上
            if (rightSub != null)
            {
                if (rightSub.val < left) return rightSub;
                if (rightSub.val > right) return rightSub;
                if (node.val < left || node.val > right)
                    return node;
                var old = node.val;
                node.val = rightSub.val;
                rightSub.val = old;
                flag = true;
                return null;
            }

            if (node.val < left || node.val > right)
                return node;

            return null;
        }

    }
}
