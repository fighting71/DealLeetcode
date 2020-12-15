using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/13/2020 6:28:12 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3563/
    /// @des : 
    /// </summary>
    public class Smallest_Subtree_with_all_the_Deepest_Nodes
    {

        // The number of nodes in the tree will be in the range [1, 500].
        //0 <= Node.val <= 500
        //The values of the nodes in the tree are unique.
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            _res = root;
            _maxDeep = 0;
            GetDeep(root, 0);
            return _res;
        }

        int _maxDeep = 0;
        TreeNode _res;

        // Your runtime beats 60.87 %
        private int GetDeep(TreeNode node, int deep)
        {
            if (node == null) return deep;
            int left = GetDeep(node.right, deep + 1), right = GetDeep(node.left, deep + 1);

            if (left == right)
            {
                if (left >= _maxDeep)
                {
                    _res = node;
                    _maxDeep = left;
                }
            }
            return Math.Max(left, right);

        }

    }
}
