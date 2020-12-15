using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Union_Find
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/14/2020 6:19:22 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Sample
    {

        private interface IUF
        {
            /* 将 p 和 q 连接 */
            void Union(int p, int q);
            /* 判断 p 和 q 是否连通 */
            bool Connected(int p, int q);
            /* 返回图中有多少个连通分量 */
            int count();
        }

        #region Version3

        public class Version3 : IUF
        {

            private int _count;
            private int[] _parent;
            private int[] _size; // 用于记录树的高度

            public Version3(int n)
            {
                _count = n;
                _parent = new int[n];
                _size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    _parent[i] = i;
                }
            }

            public bool Connected(int p, int q)
            {
                return GetRoot(p) == GetRoot(q);
            }

            public int count()
            {
                return _count;
            }

            public void Union(int p, int q)
            {
                int pRoot = GetRoot(p);
                int qRoot = GetRoot(q);

                if (pRoot == qRoot) return;
                _count--;
                // 将高度较小的树连接到高度较大的树上
                // 从而减少树的高度-》尽量减少出现节点偏差产生类似与链表
                if (_size[pRoot] > _size[qRoot])
                {
                    _parent[qRoot] = pRoot;
                    _size[pRoot]++;
                }
                else
                {
                    _parent[pRoot] = qRoot;
                    _size[qRoot]++;
                }

            }

            /// <summary>
            /// 查找节点的根节点
            ///    当树高度越高，查找次数越多，耗时越长
            ///    故应尽量减少树的高度->减少查找次数->减少耗时
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            private int GetRoot(int x)
            {
                while (_parent[x] != x)
                {
                    // 节点压缩~,二次减少树的高度
                    _parent[x] = _parent[_parent[x]];
                    x = _parent[x];
                }
                return x;
            }

        }

        #endregion Version2

        #region Version2

        public class Version2 : IUF
        {

            private int _count;
            private int[] _parent;
            private int[] _size; // 用于记录树的高度

            public Version2(int n)
            {
                _count = n;
                _parent = new int[n];
                _size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    _parent[i] = i;
                }
            }

            public bool Connected(int p, int q)
            {
                return GetRoot(p) == GetRoot(q);
            }

            public int count()
            {
                return _count;
            }

            public void Union(int p, int q)
            {
                int pRoot = GetRoot(p);
                int qRoot = GetRoot(q);

                if (pRoot == qRoot) return;
                _count--;
                // 将高度较小的树连接到高度较大的树上
                // 从而减少树的高度-》尽量减少出现节点偏差产生类似与链表
                if (_size[pRoot] > _size[qRoot])
                {
                    _parent[qRoot] = pRoot;
                    _size[pRoot]++;
                }
                else
                {
                    _parent[pRoot] = qRoot;
                    _size[qRoot]++;
                }

            }

            private int GetRoot(int x)
            {
                while (_parent[x] != x)
                {
                    x = _parent[x];
                }
                return x;
            }

        }

        #endregion Version2

        #region Version1

        private class Version : IUF
        {

            /// <summary>
            /// 连通分量
            /// </summary>
            private int _count;

            // 节点 x 的节点是 parent[x]
            // 使用数组来替代树结构
            private int[] _parent;

            public Version(int n)
            {
                _count = n;
                _parent = new int[n];
                for (int i = 0; i < n; i++)
                {
                    _parent[i] = i;// 初始父节点为自己  1->1
                }
            }

            public bool Connected(int p, int q)
            {
                // 获取两者的根节点
                int pRoot = FindRoot(p);
                int qRoot = FindRoot(q);

                // 根节点相同即连通
                return pRoot == qRoot;

            }

            public int count()
            {
                return _count;
            }

            public void Union(int p, int q)
            {
                // 获取两者的根节点
                int pRoot = FindRoot(p);
                int qRoot = FindRoot(q);

                if (pRoot == qRoot) return;
                _count--;
                _parent[pRoot] = qRoot;
                //_parent[qRoot] = pRoot;

            }

            /* 返回某个节点 x 的根节点 */
            private int FindRoot(int x)
            {
                // 根节点的 parent[x] == x
                while (_parent[x] != x)
                    x = _parent[x];
                return x;
            }
        }

        #endregion

    }
}
