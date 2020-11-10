using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week2
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 4:41:36 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3525/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DFS)]
    public class Maximum_Difference_Between_Node_and_Ancestor
    {
        // The number of nodes in the tree is in the range [2, 5000].
        // 0 <= Node.val <= 105
        public int Simple(TreeNode root)
        {
            res = 0;
            Help(root, new HashSet<int>());
            return res;
        }

        private int res;

        // Runtime: 256 ms
        // Memory Usage: 26.3 MB
        private void Help(TreeNode node, ISet<int> either)
        {
            if (node == null) return;

            foreach (var item in either)
            {
                res = Math.Max(res, Math.Abs(node.val - item));
            }

            either.Add(node.val);
            Help(node.left, either);
            Help(node.right, either);
            either.Remove(node.val);

        }

        #region dfs solution

        public int MaxAncestorDiff(TreeNode root)
        {
            return dfs(root, root.val, root.val);
        }

        public int dfs(TreeNode root, int mn, int mx)
        {
            if (root == null) return mx - mn;
            mx = Math.Max(mx, root.val);
            mn = Math.Min(mn, root.val);
            return Math.Max(dfs(root.left, mn, mx), dfs(root.right, mn, mx));
        }

        #endregion

    }
}
