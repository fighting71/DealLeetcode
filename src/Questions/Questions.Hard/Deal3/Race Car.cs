using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/25/2021 6:11:59 PM
    /// @source : https://leetcode.com/problems/race-car/
    /// @des : 
    /// 
    ///     你的车在一个无限数轴上的位置0和速度+1启动。你的车可以进入负值。你的车根据一系列指令“a”(加速)和“R”(倒车)自动驾驶:
    ///     当你得到指令“A”时，你的车会执行以下操作:
    ///     位置+ =速度
    ///     速度* = 2
    ///     当你得到一个指令'R'时，你的车会做以下事情:
    ///     如果速度是正的，那么速度= -1
    ///     否则speed = 1
    ///     你的位置保持不变。
    ///     
    /// 给定一个目标位置的目标，返回到达那里的最短指令序列的长度。
    /// 
    /// </summary>
    [Serie(FlagConst.BFS, "dfs试了个遍...")]
    [Favorite]
    public class Race_Car
    {

        // Constraints:
        // 1 <= target <= 10^4


        /*
         * init : speed location
         * change:
         *      Up:
         *          location += speed
         *          speed*=2
         *      
         *      Back:
         *          speed = speed > 0 ? -1 : 1
         *          
         *          
         * try:
         *      dp[location][speed]
         *      
         *          case 1: speed == 1
         *              dp[location][speed] = dp[location][speed < 0]
         *      
         *          case 2: speed == -1
         *              dp[location][speed] = dp[location][speed > 0]
         *              
         *          case 3: speed % 2 == 0
         *              dp[location][speed] = dp[location - speed/2][speed/2]
         *          
         *          case ....
         *          
         *    error: 场景太多，计算复杂
         *    
         * try2:
         * 
         *      递归，每次选择 Up 或 Back  
         *          0 -> Back(0) + Up(0) -> Up(Up(0)) + Back(Up(0)) + Up(Back(0)) + Back(Back(0)) -> ....
         *          
         *      退出条件：？？?
         *          a. 连续 Back 3次 ， 1 -> -1 -> 1 显然无意义
         * 
         */

        public int Clear(int target)
        {

            /**
             * 最终的最终，我抛弃了dfs 而改用 bfs
             *      原因：
             *          使用dfs难以判断当前节点是否已访问
             *          当target较大时，dfs递归层数增加，取得最优解便会存在大量的重复递归
             *          根据题意，当前节点的值即取决于父节点+子节点，难以处理先后问题
             *          
             *      bfs优势：
             *          从初始节点出发，每次count + 1
             *          发布判断是否跳过节点：
             *              a.差值过大（可优化）
             *              b.节点已访问（每一层都是最优解，故后面重复必定不会是最优解） 最优解=>最短路径
             * 
             */

            ISet<(int position, int speed)> visited = new HashSet<(int position, int speed)>();
            Queue<(int position, int speed)> curr = new Queue<(int position, int speed)>();
            Queue<(int position, int speed)> next = new Queue<(int position, int speed)>();
            int count = 0;
            curr.Enqueue((0, 1));
            while (true) // bfs
            {
                while (curr.Count > 0)
                {
                    (int position, int speed) = curr.Dequeue();

                    if (position == target) return count;

                    if (Math.Abs(position - target) > target) continue;
                    if (!visited.Add((position, speed))) continue;

                    next.Enqueue((position + speed, speed * 2));
                    next.Enqueue((position, speed > 0 ? -1 : 1));

                }
                count++;
                var t = curr;
                curr = next;
                next = t;
            }


        }

        private int Bfs(int target)
        {
            ISet<(int position, int speed)> visited = new HashSet<(int position, int speed)>();
            Queue<(int position, int speed)> curr = new Queue<(int position, int speed)>();
            Queue<(int position, int speed)> next = new Queue<(int position, int speed)>();
            int count = 0;
            // init
            curr.Enqueue((0, 1));
            while (true)
            {
                while (curr.Count > 0)
                {
                    (int position, int speed) = curr.Dequeue();

                    if (position == target) return count;

                    // skip large diff
                    // todo: optimize
                    if (Math.Abs(position - target) > target) continue;

                    // skip Visited node
                    if (!visited.Add((position, speed))) continue;

                    // push up
                    next.Enqueue((position + speed, speed * 2));
                    // push back
                    next.Enqueue((position, speed > 0 ? -1 : 1));

                }
                // min count ++ 
                count++;
                var t = curr;
                curr = next;
                next = t;
            }


        }

        // Runtime: 968 ms, faster than 28.57% of C# online submissions for Race Car.
        // Memory Usage: 107.4 MB, less than 14.29% of C# online submissions for Race Car.
        // ...果然还得看bfs
        public int Try5(int target)
        {

            Queue<(int position, int speed, int count)> stack = new Queue<(int position, int speed, int count)>();

            ISet<(int, int)> visited = new HashSet<(int, int)>();

            stack.Enqueue((0, 1, 0));

            while (stack.Count > 0)
            {
                (int position, int speed, int count) = stack.Dequeue();

                if (position == target) return count;

                /**
                 * Runtime: 168 ms, faster than 57.14% of C# online submissions for Race Car.
                 * Memory Usage: 35.4 MB, less than 64.29% of C# online submissions for Race Car.
                 */
                if (Math.Abs(position - target) > target) continue;

                //if (!visited.Add((position, speed))) continue;

                {// up
                    int upPosition = position + speed, upSpeed = speed * 2;
                    //stack.Enqueue((upPosition, upSpeed, count + 1));
                    if (visited.Add((upPosition, upSpeed)))
                    {
                        stack.Enqueue((upPosition, upSpeed, count + 1));
                    }
                }

                {// back
                    int backSpeed = speed > 0 ? -1 : 1;
                    //stack.Enqueue((position, backSpeed, count + 1));

                    // Runtime: 164 ms, faster than 57.14% of C# online submissions for Race Car.
                    // Memory Usage: 36.2 MB, less than 64.29 % of C# online submissions for Race Car.
                    // 影响不大
                    if (visited.Add((position, backSpeed)))
                    {
                        stack.Enqueue((position, backSpeed, count + 1));
                    }
                }

            }

            return 0;

        }

        // todo: fix bug 
        public int Try4(int target)
        {
            Dictionary<(int, int), int> dic = new Dictionary<(int, int), int>();
            ISet<(int, int)> visited = new HashSet<(int, int)>();
            return Dfs(0, 1, 0);

            int Dfs(int position, int speed, int count)
            {
                if (position == 3 && speed == -1 && count == 3)
                {

                }
                var key = (position, speed);
                if (dic.TryGetValue(key, out var cache)) return cache;

                if (position == target)
                {
                    return 0;
                }

                Console.WriteLine($"{position}, {speed}, {count}");
                if (Math.Abs(position - target) > target) return int.MaxValue;

                // this code has bug ...~~~

                /**
                 * 
                 * a -> up - 0
                 *   -> back ->     b -> up -> xxx
                 *                    -> back 
                 * 
                 * dfs 难以判断  3,1 -> 3,-1 -> 3,1 这种重复访问
                 *      若允许：将大幅度提高递归次数
                 *      若不允许：若在 3,1 取得最小值，那么在 3,-1 处就无法取得正确的最小值，若无法取得最小值则难以规避重复计算
                 * 
                 */

                if (!visited.Add(key)) return int.MaxValue;

                int up = Dfs(position + speed, speed * 2, count + 1);
                if (position == 3 && speed == -1)
                {

                }
                int back = Dfs(position, speed > 0 ? -1 : 1, count + 1);

                visited.Remove(key);

                if (position == 3 && speed == 1)
                {

                }
                if (position == 3 && speed == -1)
                {

                }
                if (up == int.MaxValue && back == int.MaxValue)
                {
                    return int.MaxValue;
                }

                int res = dic[key] = 1 + Math.Min(up, back);

                if (speed == 1)
                {
                    var nearKey = (position, -1);
                    if (dic.TryGetValue(nearKey, out var t) && t > res + 1)
                    {
                        dic[nearKey] = res + 1;
                    }
                }
                else if (speed == -1)
                {
                    var nearKey = (position, 1);
                    if (dic.TryGetValue(nearKey, out var t) && t > res + 1)
                    {
                        dic[nearKey] = res + 1;
                    }
                }

                return res;


            }
        }

        public int Try3(int target)
        {
            int res = int.MaxValue;
            Dictionary<(int, int), int> dic = new Dictionary<(int, int), int>();
            Dfs(0, 1, 0);

            return res;

            void Dfs(int position, int speed, int count)
            {
                //Console.WriteLine($"{position}, {speed}, {count}");
                var cache = (position, speed);
                if (dic.TryGetValue(cache, out var cacheCount) && count >= cacheCount) return;
                dic[cache] = count;
                if (count >= res) return;
                if (position == target)
                {
                    if (count == 17)
                    {

                    }
                    res = count;
                    return;
                }

                /**
                 * 其他退出条件？？？
                 * 
                */

                if (Math.Abs(position - target) > target) return;

                Dfs(position + speed, speed * 2, count + 1);
                Dfs(position, speed > 0 ? -1 : 1, count + 1);
                //if (speed > 0 == position > target)
                //{
                //    Dfs(position + speed, speed * 2, count + 1, backCount);
                //    Dfs(position, speed > 0 ? -1 : 1, count + 1, backCount + 1);
                //}
                //else
                //{
                //    Dfs(position, speed > 0 ? -1 : 1, count + 1, backCount + 1);
                //    Dfs(position + speed, speed * 2, count + 1, backCount);
                //}

            }
        }
        public int Try2(int target)
        {
            Dictionary<(int, int), int> dic = new Dictionary<(int, int), int>();
            Dictionary<int, int> minDic = new Dictionary<int, int>();
            int res = int.MaxValue;

            Help(0, 1, 0);

            return res;

            // bug : 5 -> 8
            void Help(int position, int speed, int count)
            {
                //Console.WriteLine($"{position}, {speed}, {count}");
                var cache = (position, speed);
                if (count > res) return;
                if (dic.TryGetValue(cache, out var cacheCount) && count >= cacheCount) return;
                dic[cache] = count;
                if (minDic.TryGetValue(position, out var t))
                {
                    minDic[position] = Math.Min(t, count);
                }
                else
                {
                    minDic[position] = count;
                }
                if (position == target)
                {
                    res = count;
                    return;
                }

                if (Math.Abs(position - target) > target) return;

                var need = target - position;

                if (minDic.TryGetValue(need, out var minNeed) && minNeed + count >= res) return;

                Help(position + speed, speed * 2, count + 1);

                Help(position, speed > 0 ? -1 : 1, count + 1);
            }

            // slow
            //void Help(int position, int speed, int count)
            //{
            //    Console.WriteLine($"{position}, {speed}, {count}");
            //    var cache = (position, speed);
            //    if (count > res) return;
            //    if (dic.TryGetValue(cache, out var cacheCount) && count >= cacheCount) return;
            //    if (position == target)
            //    {
            //        res = count;
            //    }

            //    if (Math.Abs(position - target) > target) return;

            //    dic[cache] = count;

            //    Help(position + speed, speed * 2, count + 1);
            //    Help(position, speed > 0 ? -1 : 1, count + 1);

            //}

        }

        /*
         * 可能到达的speed: 1 2 4 ... 2^n
         * 
         * init : location = 0, speed = 1
         * 
         * case: 
         *      1   Up  1
         *      2   Up Up Back Up   10
         *      3   Up Up   11
         *      4   Up Up Back Back Up  100
         *      5   Up Up Back Up Back Up Up    101      7
         *      6   Up  Up  Up  Back    Up  110 
         *      7   Up  Up  Up
         *      8   Up  Up  Up  Back    Back    Up        1000
         *      9   Up  Up  Up  Back    Up    Back    Up    Up  
         *      10  Up  Up  Up  Back    Back    Up  Up   1010
         *      11  
         *     
         *      -x = x+1
         *      
         *      x = low + 2 + low   / 
         */

        public int Try(int target)
        {
            /*
             * dp[l][s] 
             * 
             *      dp[l][s] = dp[l-s/2][s/2] + 1
             *           s == 1     dp[l][s>1] + 2
             *           s == -1    dp[l][s>0] + 1
             *      
             * 
             */
            return 0;

        }
        public int Racecar(int target)
        {

            /*
             * position-speed target
             */

            // question: 如何处理可以进入负值
            int location = 0, speed = 1;

            return 0;

            void Up(int location = 0, int speed = 1)
            {
                location += speed;
                speed *= 2;
            }

            void BackOff(int location = 0, int speed = 1)
            {
                if (speed > 0)
                {
                    speed = -1;
                }
                else
                {
                    speed = 1;
                }
            }

        }

    }
}
