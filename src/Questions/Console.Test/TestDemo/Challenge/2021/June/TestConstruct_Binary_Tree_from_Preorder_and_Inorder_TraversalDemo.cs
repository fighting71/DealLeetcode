using Command.CommonStruct;
using Questions.DailyChallenge._2021.June.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/8/2021 7:01:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestConstruct_Binary_Tree_from_Preorder_and_Inorder_TraversalDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal instance = new Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal();

            Console.WriteLine(instance.BuildTree(new[] { 3, 1, 2, 4 }, new[] { 1, 2, 3, 4 }));
            Console.WriteLine(instance.BuildTree(new[] { 1, 2 }, new[] { 1, 2 }));
            Console.WriteLine(instance.BuildTree(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 }));

            BaseLibrary.CommonTest(new[] {
                    (new[] { 3, 1, 2, 4 }, new[] { 1, 2, 3, 4 }),
                    (new[] { 1,2 }, new[] { 1,2 }),
                    (new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 })
                },
            arg =>
            {
                TreeNode treeNode = instance.Try(arg.Item1, arg.Item2);
                Console.WriteLine(treeNode);
                return true;
            }
            );

        }

    }
}
