using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/20/2021 4:17:33 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3749/
    /// @des : 
    /// </summary>
    public class Binary_Tree_Level_Order_Traversal
    {

        // Constraints:

        // The number of nodes in the tree is in the range[0, 2000].
        // -1000 <= Node.val <= 1000

        // Your runtime beats 50.42 %
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Help(root, 0);
            return res;

            void Help(TreeNode node, int depth)
            {
                if (node == null) return;

                if (res.Count == depth)
                {
                    res.Add(new List<int>() { node.val });
                }
                else
                {
                    res[depth].Add(node.val);
                }

                Help(node.left, depth + 1);
                Help(node.right, depth + 1);

            }

        }

    }
}
