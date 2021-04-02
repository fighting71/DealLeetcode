using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/29/2021 4:50:31 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3689/
    /// @des : 
    /// </summary>
    public class Flip_Binary_Tree_To_Match_Preorder_Traversal
    {

        // The number of nodes in the tree is n.
        //n == voyage.length
        //1 <= n <= 100
        //1 <= Node.val, voyage[i] <= n
        //All the values in the tree are unique.
        //All the values in voyage are unique.

        // Runtime: 232 ms
        // Memory Usage: 31.5 MB
        // Your runtime beats 100.00 % of csharp submissions
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {

            IList<int> res = new List<int>();

            int index = 0;

            if(Help(root))
            {
                return res;
            }
            else
            {
                return new[] { -1 };
            }

            bool Help(TreeNode node)
            {
                if (node == null) return true;

                if (node.val != voyage[index]) return false;

                index++;

                if(!Help(node.left))
                {
                    if (!Help(node.right)) return false;

                    res.Add(node.val);

                    return Help(node.left);
                }
                return Help(node.right);
            }

        }

    }
}
