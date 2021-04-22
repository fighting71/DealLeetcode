using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/20/2021 6:24:03 PM
    /// @source : https://leetcode.com/problems/preimage-size-of-factorial-zeroes-function/
    /// @des : 
    ///     给定一个K，问有K个后置0的乘阶有多少个
    ///     例如: 
    ///         1! = 1  后置0 = 0
    ///         5! = 5*4*3*2*1 = 120  后置0 = 1
    ///         后置0 => 最后有几个0
    /// </summary>
    [Favorite(FlagConst.Special)]
    public class Preimage_Size_of_Factorial_Zeroes_Function
    {

        // K will be an integer in the range [0, 10^9].

        // Runtime: 32 ms, faster than 100.00% of C# online submissions for Preimage Size of Factorial Zeroes Function.
        // Memory Usage: 15.2 MB, less than 66.67% of C# online submissions for Preimage Size of Factorial Zeroes Function.

        // 芜湖起飞

        /*
         * analysis:
         * 
         *  仅考虑会出现后置0的情况
         *  
         *  case 1 : K = 0
         *      res = 5, 对应 0!,1!,2!,3!,4!
         *  case 2 : K = 1
         *      res = 5, 对应 5!,6!,7!,8!,9!
         *      
         *  考虑 后置0的出现条件：
         *      10 = 10 * 1 | 2 * 5
         *  然后
         *      n! = (n-1)!*n
         *      若(n-1)!有x个后置0，则n的后置0数量必定>=x
         *      
         *  根据乘积计算,令f(n) = x ,表示为n!的后置0有x位
         *      f(1)=f(2)=f(3)=f(4)=f(0) 2,3,4,0 中不存在乘积=10的倍数
         *      f(5)=f(6)=f(7)=f(8)=f(9) 6,7,8,9 中除了(5!中产生的后置0) 剩下的数字同样不会产生后置0
         *   
         *      然后 f(0) != f(5) => f(5) != f(10) ... => f(n) != f(n + 5) [只要+5就必定会出现一对 2 * 5 或者是 10的倍数]
         *      故结果 必定是 0 或 5
         *      
         *  然后再看后置0的出现规则：
         *  
         *      f(n) = num => {  由于f(1...4)  = f(0)  f(6...9) = f(5), 故直接考虑 n%5 == 0 的值即可.
         *          num == 0 => 0
         *          int res = 0;
         *          while(num % 5 = 0) { // 每出现一次5 后置零必+1 ，有5必有2  2 * 5 = 10
         *              res++;
         *              num/=5;
         *          }
         *      }
         *   
         * 根据后置0规则来看(5*n)测试结果
         * 
         *  5=>1
         *  10=>1
         *  15=>1
         *  20=>1
         *  25=>2
         *  
         *  => { { 1[4]2 }[4] 1[4] 2 }[4] ....
         *  4个1后出现一个2
         *  4个2后出现一个3
         *  
         *  根据此规则映射到K上去=>
         *  
         *  4*1 + 2 = 6 = 5 * 1 + 1 缺失部位: (4,6)
         *  { 4*1 + 2 } * 4 + 4* 1 + 3 =  5 * 6 + 1 缺失部位: (29,31)
         *  sum = 5 * prev + 1 缺失部位: (sum - last, sum)
         *  ....
         *  
         */

        public int Solution(int K)
        {
            int prev = 1, sum = 1, last = 1;
            while (K > sum)
            {
                last++;
                prev = sum;
                sum = 5 * sum + 1;
            }

            // 刚好相等，即K为最后一个，则肯定存在
            if (K == sum) return 5;

            while (K > 0)
            {
                // 最后一个不存在，因为最后一个会+1,
                if (K / 5 == prev) return 0;
                K %= prev;
                last--;
                // k 不存在于此范围
                if (K > prev - last && K < prev) return 0;

                // 检索下一个范围
                prev = (prev - 1) / 5;
            }

            return 5;

        }

        public int Try5(int K)
        {
            int i = 1;
            int?[] cache = new int?[(K / 4) + 1];
            cache[0] = 0;
            while (K > 4)
            {
                K -= 4 + 2 + GetNum(i);
                i++;
            }

            return K < 0 ? 0 : 5;

            int GetNum(int num)
            {
                var count = cache[num];
                if (count.HasValue) return count.Value;
                if (num % 5 != 0) return 0;
                var res = 1 + GetNum(num / 5);
                cache[num] = res;
                return res;
            }

        }

        public int Try4(int K)
        {
            int i = 0;

            while (K > 4)
            {
                K -= 4 + GetNum(i);
                i++;
            }
            return K < 0 ? 0 : 5;


            int GetNum(int num)
            {
                int res = 2;
                if (num == 0) return res;
                while (num % 5 == 0)
                {
                    res++;
                    num /= 5;
                }
                return res;
            }

        }

        // slow
        public int Try3(int K)
        {
            int special = 25;

            while (K > 4)
            {
                K -= 4 + GetNum(special);
                special += 25;
            }
            return K < 0 ? 0 : 5;

            int GetNum(int num)
            {
                int res = 0;
                while (num % 10 == 0)
                {
                    res++;
                    num /= 10;
                }

                while (num % 5 == 0)
                {
                    res++;
                    num /= 5;
                }
                return res;
            }

        }

        // todo: bug - 24 = true => 5
        public int Try2(int K)
        {
            int special = 25, special2 = 100, start = 0, count = 1;

            while (K > 0)
            {
                if (special > special2)
                {

                    int single = (special2 - start) / 5;

                    if (K < single) return 5;
                    K -= single;
                    var copy = special2;
                    while (copy > 100 && copy % 10 == 0)
                    {
                        K--;
                        copy /= 10;
                    }
                    start = special2 + 5;
                    special2 += 100;
                }
                else
                {
                    int single = (special - start) / 5;
                    if (K < single) return 5;
                    K -= single;
                    K -= count;
                    count++;
                    start = special + 5;
                    special *= 5;
                }

            }

            return K < 0 ? 0 : 5;
        }
        public int PreimageSizeFZF(int K)
        {

            int num = 0;

            int target = 25, sum = 1;

            while (K > 0)
            {
                num += 5;
                K--;
                if (num % 10 == 0)
                {
                    var copy = num;
                    while (copy > 100 && copy % 10 == 0)
                    {
                        K--;
                        copy /= 10;
                    }
                }
                else if (num == target)
                {
                    K -= sum;
                    target *= 5;
                }
            }

            return K < 0 ? -1 : 5;
        }

    }
}
