using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.AlgorithmThinking
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/25/2021 11:36:58 AM
    /// @source : 
    ///     https://www.cnblogs.com/yanyiming10243247/p/9294160.html
    ///     https://blog.csdn.net/qq_34374664/article/details/77488976
    /// @des : 
    /// </summary>
    public class Tarjan_s
    {


        int cnt = 0, t;
        int[] dfn, low, stack, f;
        Item[] e;
        bool[] v;
        class Item
        {
            public int u;
            public int v;
            public int w;
            public int next;
        }

        void tarjan(int now)
        {
            dfn[now] = low[now] = ++cnt;  //初始化
            stack[++t] = now;       //入栈操作
            v[now] = true;            //v[]代表该点是否已入栈
            for (int i = f[now]; i != -1; i = e[i].next)  //邻接表存图
                if (dfn[e[i].v] != 0)           //判断该点是否被搜索过
                {
                    tarjan(e[i].v);
                    low[now] = Math.Min(low[now], low[e[i].v]); //回溯时更新low[ ]，取最小值
                }
                else if (v[e[i].v])
                    low[now] = Math.Min(low[now], dfn[e[i].v]); //一旦遇到已入栈的点，就将该点作为连通量的根
                                                                //这里用dfn[e[i].v]更新的原因是：这个点可能
                                                                //已经在另一个强连通分量中了但暂时尚未出栈，所
                                                                //以now不一定能到达low[e[i].v]但一定能到达
                                                                //dfn[e[i].v].
            if (dfn[now] == low[now])
            {
                int cur;
                do
                {
                    cur = stack[t--];
                    v[cur] = false;                       //不要忘记出栈
                } while (now != cur);
            }
        }

    }
}
