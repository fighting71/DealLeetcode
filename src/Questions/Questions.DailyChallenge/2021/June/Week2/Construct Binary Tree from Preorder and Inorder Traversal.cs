using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/8/2021 3:25:00 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3772/
    /// @des : 通过 preorder+inorder 构建树
    /// 
    ///     示例：
    ///     
    ///     	  3
    ///     9	 		20
    ///     		15		7
    ///     <==>
    ///     preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
    /// 
    /// 
    /// </summary>
    [Serie(FlagConst.Tree)]
    [Optimize(FlagConst.Slow)]
    public class Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
    {

        // Constraints:

        //1 <= preorder.length <= 3000
        //inorder.length == preorder.length
        //-3000 <= preorder[i], inorder[i] <= 3000
        //preorder and inorder consist of unique values.
        //Each value of inorder also appears in preorder.
        //preorder is guaranteed to be the preorder traversal of the tree.
        //inorder is guaranteed to be the inorder traversal of the tree.

        // Your runtime beats 12.35 %
        public TreeNode Try(int[] preorder, int[] inorder)
        {
            /**
             * 
             * preorder = [root,root.left,root.left.left....,root.left....right,]   递归=> 先left 再right
             * 
             * inorder = [最左边的节点,....最右边的节点]
             * 
             * 按此定义，需要根据位置来锁定 left和right
             * 
             * 于是提供一个 帮助方法：
             *  function(当前节点，当前位置, 允许访问的最小位置-1,允许访问的最大位置+1) 
             *  {
             *      // base check
             *      
             *      从preorder按序拉取一个未访问的项 match
             *      通过inorder锁定match的位置 => matchIndex
             *      
             *      if(位置匹配)
             *      {
             *          标记已访问
             *          
             *          if(符合左节点)
             *          {
             *              当前节点.left = 新节点
             *              递归
             *              
             *              if(还有未访问的节点) 
             *              {
             *                  ...同上继续拉取作为right节点
             *                  递归
             *              }
             *              
             *          }
             *          else
             *          {
             *              当前节点.right = 新节点
             *              递归
             *          }
             *          
             *      }
             *  }
             * 
             */
            var first = preorder[0];
            TreeNode root = new TreeNode(first);

            int i = 1, len = preorder.Length;

            Dictionary<int, int> indexDic = new Dictionary<int, int>();

            for (int j = 0; j < len; j++)
            {
                indexDic[inorder[j]] = j;
            }

            Help(root, indexDic[first], -1, len);

            return root;

            void Help(TreeNode node, int currIndex, int minIndex, int maxIndex)
            {

                if (node == null || i == len) return;

                var match = preorder[i];

                var matchIndex = indexDic[match];

                if (matchIndex < minIndex || matchIndex > maxIndex) return;

                i++;
                if (matchIndex < currIndex)
                {
                    node.left = new TreeNode(match);
                    Help(node.left, matchIndex, minIndex, currIndex);
                    if (i == len) return;
                    var rightMatch = preorder[i];
                    var rightMatchIndex = indexDic[rightMatch];

                    if (rightMatchIndex < maxIndex && rightMatchIndex > currIndex)
                    {
                        i++;
                        node.right = new TreeNode(rightMatch);
                        Help(node.right, rightMatchIndex, currIndex, maxIndex);
                    }

                }
                else
                {
                    node.right = new TreeNode(match);
                    Help(node.right, matchIndex, currIndex, maxIndex);
                }

            }

        }

        // bug
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {

            var first = preorder[0];
            TreeNode root = new TreeNode(first);

            int i = 1, len = preorder.Length;

            Dictionary<int, int> indexDic = new Dictionary<int, int>();

            for (int j = 0; j < len; j++)
            {
                indexDic[inorder[j]] = j;
            }

            Help(root, indexDic[first], -1, len);

            return root;

            void Help(TreeNode node, int currIndex, int minIndex, int maxIndex)
            {
                if (node == null || i == len) return;

                var match = preorder[i];

                var matchIndex = indexDic[match];

                if (matchIndex < minIndex || matchIndex > maxIndex) return;

                i++;
                if (matchIndex < currIndex)
                {
                    node.left = new TreeNode(match);
                    if (i == len) return;
                    var rightMatch = preorder[i];
                    var rightMatchIndex = indexDic[rightMatch];

                    if (rightMatchIndex < maxIndex && rightMatchIndex > currIndex)
                    {
                        i++;
                        node.right = new TreeNode(rightMatch);
                        Help(node.left, matchIndex, minIndex, currIndex);
                        Help(node.right, rightMatchIndex, currIndex, maxIndex);
                    }
                    else
                    {
                        Help(node.left, matchIndex, minIndex, currIndex);
                    }

                }
                else
                {
                    node.right = new TreeNode(match);
                    Help(node.right, matchIndex, currIndex, maxIndex);
                }

            }

        }

    }
}
