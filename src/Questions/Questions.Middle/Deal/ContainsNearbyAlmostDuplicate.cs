using System;
using System.Linq;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/23 15:28:34
    /// @source : 
    /// @des : https://leetcode.com/problems/contains-duplicate-iii/
    /// </summary>
    public class ContainsNearbyAlmostDuplicate
    {

        #region try

        // 由于随着nums的数量增加 需要循环的次数会变得非常巨大...故不适合
        [Obsolete("time limit")]
        public bool SimpleSolution(int[] nums, int k, int t)
        {
            // bug : abs 越界
            // fix : 使用long避免

            // bug : time limit
            // 设置visited 避免验证ij后验证ji

            bool[][] visited = new bool[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                visited[i] = new bool[nums.Length];
            }

            // 遍历数组
            for (int i = 0; i < nums.Length; i++)
            {
                // 由于i和j之间的绝对差值最多为k。 则 j 的范围为 i - k 到 i +  k
                // 再考虑下标的边界
                for (int j = Math.Max(i - k, 0); j < Math.Min(i + k + 1, nums.Length); j++)
                {
                    if (j == i || visited[i][j]) continue; // i != j

                    // nums[i]和nums[j]之间的绝对差值最多为t 满足则成功返回.

                    // time limit
                    //if (ReducesValid(nums[i], nums[j], t)) return true;

                    // time limit
                    bool isNegative = nums[i] < 0, isNegative2 = nums[j] < 0;

                    if (isNegative == isNegative2)
                    {
                        if (Math.Abs(nums[i] - nums[j]) <= t) return true;
                    }

                    if (isNegative)
                    {
                        if (nums[j] - nums[i] > 0 && nums[j] - nums[i] <= t) return true;
                    }
                    else
                    {
                        if (nums[i] - nums[j] > 0 && nums[i] - nums[j] <= t) return true;
                    }

                    visited[j][i] = true;
                }
            }

            return false;
        }

        /// <summary>
        /// 验证 num - num2 &gt;= maxNum
        /// 避免abs int越界
        /// </summary>
        /// <param name="num"></param>
        /// <param name="num2"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        private bool ReducesValid(int num, int num2, int maxNum)
        {
            var res = num - (long) num2;

            if (res > int.MaxValue) return false;
            if (res < int.MinValue) return false;

            if (Math.Abs(res) <= maxNum) return true;

            return false;
        }

        // time limit...
        private bool ReducesValid2(int num, int num2, int maxNum)
        {
            if (num == maxNum) return num2 == 0;
            if (num2 == maxNum) return num == 0;

            if ((num > 0 && num2 > 0) || (num < 0 && num2 < 0)) return Math.Abs(num - num2) <= maxNum;

            if (num > 0)
            {
                if (num > maxNum) return num2 >= num - maxNum;
                return num2 <= maxNum - num;
            }

            if (num2 > maxNum) return num >= num2 - maxNum;
            return num <= maxNum - num2;
        }

        #endregion
        
        /**
         * Runtime: 100 ms, faster than 90.35% of C# online submissions for Contains Duplicate III.
         * Memory Usage: 25.4 MB, less than 100.00% of C# online submissions for Contains Duplicate III.
         *
         * 可优化排序列表的获取
         * 可优化避免越界的处理,可能有比转long型更优的解答... maybe~
         *
         * try vs Solution
         *
         * try thinking:
         *     遍历列表
         *     根据k的范围进行遍历，查找是否有符合差值t的情况
         *
         * solution thinking:
         *     先获取差值t，再查找是否满足在k范围内
         *     由于排序的特点，能够快速的找到符合差值t的元素，故更容易求解（减少多余的处理和避免往前求差）
         * 
         */
        public bool Solution(int[] nums, int k, int t)
        {
            
            var len = nums.Length;
            
            // 将nums进行排序 获取一个num + index的列表
            var arr = nums.Select(((num, index) => new {num, index})).OrderBy(u => u.num).ToArray();

            // 从最小的值开始
            for (int i = 0; i < len; i++)
            {
                // 往后遍历
                // 且 num2 - num <= t 循环继续 
                //    举例：列表元素={a,b,c} 若 b-a > t 因为列表是升序的 所以 c>b 那么 c-a >t 
                
                // 尝试避免越界 no test.
                // for (int j = i + 1; j < len && int.MaxValue - arr[j].num <= arr[i].num && arr[j].num - arr[i].num <= t; j++)
                // 由于越界的特殊性 此处使用最方便的转long型进行比较
                for (int j = i + 1; j < len && arr[j].num - (long)arr[i].num <= t; j++)
                {
                    // 若i与j的下标最大为k则符合返回true
                    if (Math.Abs(arr[i].index - arr[j].index) <= k) return true;
                }
            }
            
            return false;
        }

        
    }
}