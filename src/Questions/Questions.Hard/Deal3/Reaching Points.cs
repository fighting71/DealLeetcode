using Command.Const;
using Command.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/16/2021 11:06:11 AM
    /// @source : https://leetcode.com/problems/reaching-points/
    /// @des : 
    ///     给定四个整数sx、sy、tx和ty，如果可以通过一些操作将点(sx, sy)转换为点(tx, ty)，则返回true，否则返回false。
    ///     对某点(x, y)允许的操作是将其转换为(x, x + y)或(x + y, y)。
    /// 
    /// </summary>
    //[Obsolete("later 3000 years....")]
    [Obsolete(FlagConst.Slow)]
    public class Reaching_Points
    {

        // sx, sy, tx, ty will all be integers in the range [1, 10^9].

        #region other solution
        // https://leetcode.com/problems/reaching-points/discuss/114856/JavaC%2B%2BPython-Modulo-from-the-End
        // 6..
        public bool reachingPoints(int sx, int sy, int tx, int ty)
        {
            while (sx < tx && sy < ty)
                if (tx < ty) ty %= tx;
                else tx %= ty;
            return sx == tx && sy <= ty && (ty - sy) % sx == 0 ||
                   sy == ty && sx <= tx && (tx - sx) % sy == 0;
        }
        #endregion

        // time limit
        public bool Try2(int sx, int sy, int tx, int ty)
        {
            if (sx == tx && sy == ty) return true;

            Stack<(int x, int y)> curr = new Stack<(int x, int y)>(), next = new Stack<(int x, int y)>();

            ISet<(int x, int y)> visited = new HashSet<(int x, int y)>() { (sx, sy) };
            curr.Push((sx, sy));
            return BfsHelper.Bfs(curr, next, () => { }, (next, currV) =>
            {
                (int x, int y) = currV;

                if (x > tx || y > ty) return false;

                if (Help(next, x + y, y)) return true;
                if (Help(next, x, y + x)) return true;

                return false;

            });

            bool Help(Stack<(int x, int y)> next, int x, int y)
            {
                if (x > tx || y > ty) return false;

                if (x == tx && ty - y % x == 0) return true;
                if (y == ty && tx - x % y == 0) return true;

                if (visited.Add((x, y)))
                {
                    next.Push((x, y));
                }
                return false;
            }

        }


        // 9
        //5
        //5465456
        //87897041
        public bool Try(int sx, int sy, int tx, int ty)
        {


            //if (tx % (sx + sy) % sx == 0 && ty % (sx + sy) % sy == 0)
            //{
            //    return true;
            //}

            //if (ty % (sx + sy) % sy == 0 && ty % sx % sy == 0)
            //{
            //    return true;
            //}

            return false;
        }

        // stack overflow
        // cache 难以命中.
        public bool CacheSimple(int sx, int sy, int tx, int ty)
        {

            Dictionary<(int x, int y), bool> cache = new Dictionary<(int x, int y), bool>();

            return Help(sx, sy);

            bool Help(int x, int y)
            {
                var key = (x, y);
                if (cache.TryGetValue(key, out bool res)) return res;
                if (x == tx && y == ty) return cache[key] = true;
                if (x > tx || y > ty) return cache[key] = false;

                int sum = x + y;

                return cache[key] = Help(x + y, y) || Help(x, x + y);
            }

        }

        public bool Simple(int sx, int sy, int tx, int ty)
        {

            return Help(sx, sy);

            bool Help(int x, int y)
            {
                if (x == tx && y == ty) return true;

                if (x > tx || y > ty) return false;

                return Help(x + y, y) || Help(x, x + y);

            }

        }

    }
}
