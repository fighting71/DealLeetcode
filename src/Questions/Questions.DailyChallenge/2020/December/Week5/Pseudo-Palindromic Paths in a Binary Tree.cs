using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/30/2020 2:55:29 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/573/week-5-december-29th-december-31st/3585/
    /// @des : 
    ///     给定一个tree,从根节点到叶子节点构成一条线，若使用这条线上的值可以组成回文数 则称为伪回文路径
    ///     target: 总共有多少条伪回文路径
    ///     analysis: 因为可以任意组合，故只需要这些数能否构成回文数即可=>所有数出现次数为偶数或仅有一个数出现次数为奇数
    /// </summary>
    public class Pseudo_Palindromic_Paths_in_a_Binary_Tree
    {

        // The given binary tree will have between 1 and 10^5 nodes.
        // Node values are digits from 1 to 9.

        // Your runtime beats 79.49 % 
        public int PseudoPalindromicPaths(TreeNode root)
        {
            res = 0;
            Helper(root, new int[10]);
            return res;
        }

        int res;

        private void Helper(TreeNode node, int[] count)
        {
            if (node == null) return;
            if(node.left == null && node.right == null)// 到达叶子节点
            {
                bool hasOdd = false;
                for (int i = 1; i <= 9; i++)// 检测此条线是否满足回文数
                {
                    int item = count[i];
                    if (i == node.val) item++;
                    if(item %2 == 1)
                    {
                        if (hasOdd) return;
                        hasOdd = true;
                    }
                }
                res++;
            }
            else
            {
                count[node.val]++;
                Helper(node.left, count);
                Helper(node.right, count);
                count[node.val]--;
            }
        }

    }
}
