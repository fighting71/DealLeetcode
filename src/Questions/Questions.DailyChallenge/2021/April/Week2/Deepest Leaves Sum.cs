using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 10:28:48 AM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3704/
    /// @des : 
    ///     获取深度最大的节点的和
    ///         深度最大可能存在多个节点，例如：
    ///             1
    ///            2 3 (2,3深度一样)  = 5
    /// </summary>
    [Serie(FlagConst.Tree, FlagConst.Recursion)]
    public class Deepest_Leaves_Sum
    {

        // The number of nodes in the tree is in the range [1, 104].
        // 1 <= Node.val <= 100


        // Your runtime beats 95.73 % of csharp submissions
        public int DeepestLeavesSum(TreeNode root)
        {

            int res = 0, maxDepth = 0;

            Help(root);

            return res;

            void Help(TreeNode node, int depth = 0)
            {
                bool leftIsNull = node.left == null, rightIsNull = node.right == null;
                if (leftIsNull && rightIsNull)
                {
                    if (depth > maxDepth)
                    {
                        res = node.val;
                        maxDepth = depth;
                    }
                    else if (depth == maxDepth)
                    {
                        res += node.val;
                    }
                    return;
                }

                if (!leftIsNull) Help(node.left, depth + 1);
                if (!rightIsNull) Help(node.right, depth + 1);
            }

        }

    }
}
