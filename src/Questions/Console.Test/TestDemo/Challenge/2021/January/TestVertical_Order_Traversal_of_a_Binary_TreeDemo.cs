using Command.CommonStruct;
using Command.Helper;
using Questions.DailyChallenge._2021.January.Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 6:28:02 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestVertical_Order_Traversal_of_a_Binary_TreeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Vertical_Order_Traversal_of_a_Binary_Tree instance = new Vertical_Order_Traversal_of_a_Binary_Tree();

            TreeNode treeNode = "[3,9,20,null,null,15,7]";

            BaseLibrary.CommonTest(new TreeNode[] {
                    new int?[]{ 3, 9, 20, null, null, 15, 7 },
                    new []{ 1, 2, 3, 4, 5, 6, 7 }
                }
            , instance.VerticalTraversal
            , () => CollectionHelper.GetEnumerable(300, () => random.Next(30)).ToArray()
            //, checkFunc: instance.VerticalTraversal
            , formatArg: arg => arg.ToString()
            //, showArg: true
            //, showRes: true
            , throwDiff: false
            , codeTimeCount: 20
            );

        }

    }
}
