using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week2
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 9:59:03 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3524/
    /// @des : 
    /// </summary>
    public class Binary_Tree_Tilt
    {

        // The number of nodes in the tree is in the range [0, 104].
        // -1000 <= Node.val <= 1000


        // Runtime: 96 ms
        // Memory Usage: 28.7 MB
        // Your runtime beats 93.81 % of csharp submissions.
        // easy.
        public int FindTilt(TreeNode root)
        {
            _res = 0;
            int sum = Help(root);

            //Console.WriteLine(sum);

            return _res;
        }

        int _res;

        private int Help(TreeNode node)
        {
            if (node == null) return 0;

            var left = Help(node.left);
            var right = Help(node.right);

            _res += Math.Abs(left - right);

            return node.val + left + right;

        }

    }
}
