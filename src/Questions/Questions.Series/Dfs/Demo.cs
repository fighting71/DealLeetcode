using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dfs
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/25/2021 2:32:38 PM
    /// @source : https://www.cnblogs.com/DWVictor/p/10048554.html
    /// @des : 
    /// </summary>
    public abstract class Demo
    {

// 2.2深度与广度的比较
//（你可以跳过这一节先看第三节，重点在第三节）

//从上一篇《【算法入门】广度/宽度优先搜索(BFS) 》中知道，我们搜索一个图是按照树的层次来搜索的。

//我们假设一个节点衍生出来的相邻节点平均的个数是N个，那么当起点开始搜索的时候，队列有一个节点，当起点拿出来后，把它相邻的节点放进去，那么队列就有N个节点，当下一层的搜索中再加入元素到队列的时候，节点数达到了N2，你可以想想，一旦N是一个比较大的数的时候，这个树的层次又比较深，那这个队列就得需要很大的内存空间了。

//于是广度优先搜索的缺点出来了：在树的层次较深&子节点数较多的情况下，消耗内存十分严重。广度优先搜索适用于节点的子节点数量不多，并且树的层次不会太深的情况。

//那么深度优先就可以克服这个缺点，因为每次搜的过程，每一层只需维护一个节点。但回过头想想，广度优先能够找到最短路径，那深度优先能否找到呢？深度优先的方法是一条路走到黑，那显然无法知道这条路是不是最短的，所以你还得继续走别的路去判断是否是最短路？

//于是深度优先搜索的缺点也出来了：难以寻找最优解，仅仅只能寻找有解。其优点就是内存消耗小，克服了刚刚说的广度优先搜索的缺点。

        //bool DFS(TreeNode n, int d)
        //{
        //    if (isEnd(n, d))
        //    {//一旦搜索深度到达一个结束状态，就返回true
        //        return true;
        //    }

        //    for (TreeNode nextNode in n)
        //    {//遍历n相邻的节点nextNode
        //        if (!visit[nextNode])
        //        {//
        //            visit[nextNode] = true;//在下一步搜索中，nextNode不能再次出现
        //            if (DFS(nextNode, d + 1))
        //            {//如果搜索出有解
        //             //做些其他事情，例如记录结果深度等
        //                return true;
        //            }

        //            //重新设置成false，因为它有可能出现在下一次搜索的别的路径中
        //            visit[nextNode] = false;
        //        }
        //    }
        //    return false;//本次搜索无解
        //}

    }
}
