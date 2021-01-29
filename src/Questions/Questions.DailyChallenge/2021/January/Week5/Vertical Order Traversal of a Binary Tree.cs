using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 4:52:20 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3621/
    /// @des : 
    ///     给定一个二叉树,获取垂直顺序遍历
    ///     rule: 根节点位置为(0,0)  左子节点位置为(x-1,y-1) 右子节点位置为(x+1,y-1)
    ///         x相同的在同一行，若x和y都相同，则val较小的排在前面
    ///         按照x从小到大，y从大到小排序，返回集合.
    /// </summary>
    [Optimize("实现更加快速的排序...")]
    public class Vertical_Order_Traversal_of_a_Binary_Tree
    {

        public IList<IList<int>> Try(TreeNode root)
        {

            IList<IList<int[]>> res = new List<IList<int[]>>();

            Dictionary<int, Dictionary<int, List<int>>> dic = new Dictionary<int, Dictionary<int, List<int>>>();

            Helper(root, 0, 0);

            // 直接交给linq 拼接，排序了。
            return dic.OrderBy(u => u.Key).Select(u => u.Value.OrderByDescending(x => x.Key).SelectMany(x => x.Value).ToList()).ToArray();

            void Helper(TreeNode node, int x, int y)
            {
                if (node == null) return;

                if (dic.ContainsKey(x))
                {
                    var itemDic = dic[x];
                    if (itemDic.ContainsKey(y))
                    {
                        var list = itemDic[y];
                        if (list[0] > node.val) // bug  list（x,y) .Count 可能大于2
                            list.Insert(0, node.val);
                        else
                            list.Add(node.val);
                    }
                    else
                        itemDic[y] = new List<int>() { node.val };
                }
                else dic[x] = new Dictionary<int, List<int>> { { y, new List<int>() { node.val } } };

                Helper(node.left, x - 1, y - 1);
                Helper(node.right, x + 1, y - 1);

            }
        }

        // Your runtime beats 12.69 %
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {

            IList<IList<int[]>> res = new List<IList<int[]>>();

            Dictionary<int, Dictionary<int, List<int>>> dic = new Dictionary<int, Dictionary<int, List<int>>>();

            Helper(root, 0, 0);

            // 直接交给linq 拼接，排序了。
            return dic.OrderBy(u => u.Key).Select(u => u.Value.OrderByDescending(x => x.Key).SelectMany(x => x.Value.OrderBy(u => u)).ToList()).ToArray();

            void Helper(TreeNode node, int x, int y)
            {
                if (node == null) return;

                if (dic.ContainsKey(x))
                {
                    var itemDic = dic[x];
                    if (itemDic.ContainsKey(y))
                        itemDic[y].Add(node.val);
                    else
                        itemDic[y] = new List<int>() { node.val };
                }
                else dic[x] = new Dictionary<int, List<int>> { { y, new List<int>() { node.val } } };

                Helper(node.left, x - 1, y - 1);
                Helper(node.right, x + 1, y - 1);

            }
        }


    }
}
