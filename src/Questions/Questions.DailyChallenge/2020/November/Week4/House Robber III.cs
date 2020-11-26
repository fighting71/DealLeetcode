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
    public class House_Robber_III
    {

        #region other solution
        // 移除备忘录
        int rob(TreeNode root)
        {
            int[] res = dp(root);
            return Math.Max(res[0], res[1]);
        }

        /* 返回一个大小为 2 的数组 arr
        arr[0] 表示不抢 root 的话，得到的最大钱数
        arr[1] 表示抢 root 的话，得到的最大钱数 */
        // nb!
        int[] dp(TreeNode root)
        {
            if (root == null)
                return new int[] { 0, 0 };
            int[] left = dp(root.left);
            int[] right = dp(root.right);
            // 抢，下家就不能抢了
            int rob = root.val + left[0] + right[0];
            // 不抢，下家可抢可不抢，取决于收益大小
            int not_rob = Math.Max(left[0], left[1])
                        + Math.Max(right[0], right[1]);

            return new int[] { not_rob, rob };
        }
        #endregion

        public int Optimize3(TreeNode root)
        {

            Dictionary<TreeNode, int> checkDp = new Dictionary<TreeNode, int>();
            Dictionary<TreeNode, int> uncheckDp = new Dictionary<TreeNode, int>();

            int Helper(TreeNode node, bool prevIsCheck)
            {
                if (node == null) return 0;

                if (checkDp.ContainsKey(node)) return prevIsCheck ? checkDp[node] : uncheckDp[node];

                int res = Helper(node.left, false) + Helper(node.right, false);
                checkDp[node] = res;
                uncheckDp[node] = Math.Max(res, node.val + Helper(node.left, true) + Helper(node.right, true));

                return prevIsCheck ? checkDp[node] : uncheckDp[node];
            }
            return Helper(root, false);

        }

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
