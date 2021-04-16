using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/16/2021 11:06:11 AM
    /// @source : 
    /// @des : 
    /// </summary>
    [Obsolete("later 3000 years....")]
    public class Reaching_Points
    {

        // sx, sy, tx, ty will all be integers in the range [1, 10^9].


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
