using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/17/2021 9:41:46 AM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3745/
    /// @des : hard
    /// </summary>
    [Obsolete(FlagConst.Tree + FlagConst.Hard)]
    public class Binary_Tree_Cameras
    {

        #region other solution

        int res = 0;
        public int minCameraCover(TreeNode root)
        {
            return (dfs(root) < 1 ? 1 : 0) + res;
        }

        public int dfs(TreeNode root)
        {
            if (root == null) return 2;
            int left = dfs(root.left), right = dfs(root.right);
            if (left == 0 || right == 0)
            {
                res++;
                return 1;
            }
            return left == 1 || right == 1 ? 2 : 0;
        }

        #endregion

        public int Try2(TreeNode root)
        {
            int res = 0;

            return res;

            int Help(TreeNode node)
            {
                if (node == null) return 0;
                int l = Help(node.left);
                int r = Help(node.right);

                res++;
                if (l + r == 0) return 1;

                if (l + r == 1)
                {
                    res--;
                    return 0;
                }

                return l + r;
            }

        }

        // bug
        public int Try(TreeNode root)
        {
            if (root == null) return 0;

            Dictionary<(TreeNode, bool), int> cache = new Dictionary<(TreeNode, bool), int>();

            return Math.Max(Help(root, true), 1);

            int Help(TreeNode node, bool parentFlag)
            {
                if (node == null) return 0;

                var key = (node, parentFlag);

                if (cache.TryGetValue(key, out int v))
                {
                    return v;
                }

                int res;
                if (parentFlag)
                {
                    res = Math.Min(
                            1 + Help(node.left, true) + Help(node.right, true),
                            Help(node.left, false) + Help(node.right, false)
                        );
                }
                else
                {
                    res = 1 + Help(node.left, true) + Help(node.right, true);
                }
                return cache[key] = res;
            }

        }

        public int MinCameraCover(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(Help(root, true), 1);

            int Help(TreeNode node, bool parentFlag)
            {
                if (node == null) return parentFlag ? 0 : 1;

                bool nonL = node.left == null, nonR = node.right == null;

                if (nonL && nonR)
                {
                    return parentFlag ? 0 : 1;
                }

                if (nonL)
                {
                    if (parentFlag)
                    {
                        return Math.Min(
                            Help(node.right, false),
                            1 + Help(node.right, true)
                        );
                    }
                    else
                    {
                        return 1 + Help(node.right, true);
                    }
                }
                else if (nonR)
                {
                    if (parentFlag)
                    {
                        return Math.Min(
                            Help(node.left, false),
                            1 + Help(node.left, true)
                        );
                    }
                    else
                    {
                        return 1 + Help(node.left, true);
                    }
                }
                else
                {
                    if (parentFlag)
                    {
                        return Math.Min(
                                1 + Help(node.left, true) + Help(node.right, true),
                                Help(node.left, false) + Help(node.right, false)
                            );
                    }
                    else
                    {
                        return 1 + Help(node.left, true) + Help(node.right, true);
                    }
                }

            }

        }

    }
}
