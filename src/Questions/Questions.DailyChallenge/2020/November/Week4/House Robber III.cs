using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 5:44:38 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3541/
    /// @des :  对于Tree的DP
    /// </summary>
    [Optimize]
    public class House_Robber_III
    {
        // todo : how save dp?
        // 差不多.
        public int Optimize2(TreeNode root)
        {

            Dictionary<string, int> checkDp = new Dictionary<string, int>();
            Dictionary<string, int> uncheckDp = new Dictionary<string, int>();

            int Helper(TreeNode node, bool prevIsCheck, int deep, int index)
            {
                if (node == null) return 0;

                string key = $"{index}.{deep}";

                if (checkDp.ContainsKey(key)) return prevIsCheck ? checkDp[key] : uncheckDp[key];

                int res = Helper(node.left, false, deep + 1, index * 2) + Helper(node.right, false, deep + 1, index * 2 + 1);
                checkDp[key] = res;
                uncheckDp[key] = Math.Max(res,node.val + Helper(node.left, true, deep + 1, index * 2) + Helper(node.right, true, deep + 1, index * 2 + 1));

                return prevIsCheck ? checkDp[key] : uncheckDp[key];
            }
            return Helper(root, false, 0, 0);

        }

        // beats 32.00 %
        public int Optimize(TreeNode root)
        {

            Dictionary<string, int> dp = new Dictionary<string, int>();

            int Helper(TreeNode node,bool prevIsCheck,int deep,int index)
            {
                if (node == null) return 0;

                string key = $"{deep}.{index}.{prevIsCheck}";

                if (dp.ContainsKey(key)) return dp[key];

                if (prevIsCheck)
                {
                    return dp[key] = Helper(node.left, false, deep + 1, index * 2) + Helper(node.right, false, deep + 1, index * 2 + 1);
                }
                else
                {
                    return dp[key] = Math.Max(
                        node.val + Helper(node.left, true, deep + 1, index * 2) + Helper(node.right, true, deep + 1, index * 2 + 1),
                        Helper(node.left, false, deep + 1, index * 2) + Helper(node.right, false, deep + 1, index * 2 + 1));
                }

            }
            return Helper(root, false, 0, 0);

        }


        public int DpSolution(TreeNode root)
        {
            return Helper(root, false, new List<int[]>(), new List<int[]>(), 0, 0);
        }
        // 状态:
        //  a.上一个是否被选
        //  b.node的位置
        // bug : out of memory
        private int Helper(TreeNode node, bool prevIsCheck, List<int[]> checkDp, List<int[]> unCheckDp, int deep, int index)
        {
            // base case
            if (node == null) return 0;

            if(unCheckDp.Count == 0)
            {
                unCheckDp.Add(new int[1]);
                checkDp.Add(new int[1]);
            }
            else if(unCheckDp.Count == deep)
            {
                var size = unCheckDp[unCheckDp.Count - 1].Length * 2;
                unCheckDp.Add(new int[size]);
                checkDp.Add(new int[size]);
            }
            else if (prevIsCheck)
            {
                if (checkDp[deep][index] > 0) return checkDp[deep][index];
            }
            else if (unCheckDp[deep][index] > 0) return unCheckDp[deep][index];

            if (prevIsCheck)
            {
                return checkDp[deep][index] =
                    Helper(node.left, false, checkDp, unCheckDp, deep + 1, index * 2) + Helper(node.right, false, checkDp, unCheckDp, deep + 1, index * 2 + 1);
            }
            else
            {
                return unCheckDp[deep][index] = Math.Max(
                    node.val + Helper(node.left, true, checkDp, unCheckDp, deep + 1, index * 2) + Helper(node.right, true, checkDp, unCheckDp, deep + 1, index * 2 + 1),
                    Helper(node.left, false, checkDp, unCheckDp, deep + 1, index * 2) + Helper(node.right, false, checkDp, unCheckDp, deep + 1, index * 2 + 1));
            }

        }

        /// <summary>
        /// 初始-递归版
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Recursion(TreeNode root)
        {
            return Helper(root, false);
        }

        private int Helper(TreeNode node, bool prevIsCheck)
        {
            // base case
            if (node == null) return 0;

            if (prevIsCheck)
            {
                return Helper(node.left, false) + Helper(node.right, false);
            }
            else
            {
                return Math.Max(node.val + Helper(node.left, true) + Helper(node.right, true),
                    Helper(node.left, false) + Helper(node.right, false));
            }

        }

    }
}
